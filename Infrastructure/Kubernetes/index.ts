import * as pulumi from "@pulumi/pulumi";
import * as azure from "@pulumi/azure";
import * as docker from "@pulumi/docker";
import * as azuread from "@pulumi/azuread";
import * as random from "@pulumi/random";
import * as tls from "@pulumi/tls";
import * as k8s from "@pulumi/kubernetes";


const prefix = "anb";
// Create an Azure Resource Group
const resourceGroup = new azure.core.ResourceGroup(`${prefix}-kub-rg`);



const username = "pulumi";
// Generate a strong password for the Service Principal.
const sqlpassword = new random.RandomPassword("sqlpassword", {
    length: 20,
    special: true,
}).result;

const sqlServer = new azure.sql.SqlServer(`${prefix}sqlsrv`, {
         administratorLogin: username,
         administratorLoginPassword: sqlpassword,
         location: resourceGroup.location,
         resourceGroupName: resourceGroup.name, 
         tags: {
             environment: "test",
         },
         version: "12.0",
     });

const localIpAccessRule = new azure.sql.FirewallRule("TradeSolutionIp", {
        endIpAddress: "176.111.206.66",
        resourceGroupName: resourceGroup.name,
        serverName: sqlServer.name,
        startIpAddress: "176.111.206.66",
    });

const database = new azure.sql.Database("anabidb-test", {
        location: resourceGroup.location,
        resourceGroupName: resourceGroup.name,
        serverName: sqlServer.name,
        tags: {
            environment: "test",
        },
        requestedServiceObjectiveName: "S0"
    });


const containerRegistry = new azure.containerservice.Registry(`${prefix}creg`, {
    location: resourceGroup.location,
    resourceGroupName: resourceGroup.name,
    sku: "Basic",
    adminEnabled: true
});

    
const anabiImageName = pulumi.interpolate`${containerRegistry.loginServer}/anabi-api:v1.0.0`;
const registryDetils = {
    server: containerRegistry.loginServer,
    username: containerRegistry.adminUsername,
    password: containerRegistry.adminPassword, 
};

const d = new docker.Image("anabiapi", {
    build: {
        context: '../../'
    },
    imageName: anabiImageName,
    registry: registryDetils
});



// Generate a strong password for the Service Principal.
const password = new random.RandomPassword("password", {
    length: 20,
    special: true,
}).result;

// Create an SSH public key that will be used by the Kubernetes cluster.
        // Note: We create one here to simplify the demo, but a production deployment would probably pass
        // an existing key in as a variable.
        const sshPublicKey = new tls.PrivateKey("sshKey", {
            algorithm: "RSA",
            rsaBits: 4096,
        }).publicKeyOpenssh;

// Create the AD service principal for the K8s cluster.
const adApp = new azuread.Application("aks", undefined);
const adSp = new azuread.ServicePrincipal("aksSp", {
    applicationId: adApp.applicationId
});
const adSpPassword = new azuread.ServicePrincipalPassword("aksSpPassword", {
    servicePrincipalId: adSp.id,
    value: password,
    endDate: "2099-01-01T00:00:00Z",
});


// Grant the resource group the "Network Contributor" role so that it can link the static IP to a
        // Service LoadBalancer.
const rgContributorRole = new azure.role.Assignment(`${prefix}spRgRole`, {
    principalId: adSp.id,
    scope: resourceGroup.id,
    roleDefinitionName: "Contributor",
});

//there is a little race condition here; it seems that the container registry was not ready
/* const rgAcrPullRole = new azure.role.Assignment(`${prefix}spAcrRole`, {
    principalId: adSp.id,
    scope: containerRegistry.id,
    roleDefinitionName: "acrpull",
}); */

        // Create a Virtual Network for the cluster
        const vnet = new azure.network.VirtualNetwork(`${prefix}kubevn`, {
            resourceGroupName: resourceGroup.name,
            addressSpaces: ["10.2.0.0/16"],
        });

        // Create a Subnet for the cluster
        const subnet = new azure.network.Subnet(`${prefix}kubesubnet`, {
            resourceGroupName: resourceGroup.name,
            virtualNetworkName: vnet.name,
            addressPrefix: "10.2.1.0/24",
        });


// Now allocate an AKS cluster.
const cluster = new azure.containerservice.KubernetesCluster(`${prefix}aksCluster`, {
    resourceGroupName: resourceGroup.name,
    defaultNodePool: {
        name: "aksagentpool",
        nodeCount: 2,
        vmSize: "Standard_B2s",
        osDiskSizeGb: 30,
        type: "AvailabilitySet",
        vnetSubnetId: subnet.id
    },
    dnsPrefix: "lbtut",
    linuxProfile: {
        adminUsername: "aksuser",
        sshKey: {
            keyData: sshPublicKey,
        },
    },
    servicePrincipal: {
        clientId: adApp.applicationId,
        clientSecret: adSpPassword.value,
    },
    kubernetesVersion: "1.15.5",
    roleBasedAccessControl: {enabled: true},
    networkProfile: {
        networkPlugin: "azure",
        dnsServiceIp: "10.2.2.254",
        serviceCidr: "10.2.2.0/24",
        dockerBridgeCidr: "172.17.0.1/16",
    },
});

// Expose a K8s provider instance using our custom cluster instance.
const aksprovider = new k8s.Provider(`${prefix}aksprovider`, {
    kubeconfig: cluster.kubeConfigRaw,
});

/* const registrySecret = new k8s.core.v1.Secret(`creg-secret`, {
    stringData: {
        "DOCKER_USER": registryDetils.username,
        "DOCKER_PASSWORD": registryDetils.password,
        "DOCKER_REGISTRY_SERVER": registryDetils.server 
    }
}, { provider: aksprovider }); */


const appLabels = { app: "anabi-api" };
const anabiapiDeployment = new k8s.apps.v1.Deployment("anabi-api-deployment", {
    spec: {
        selector: { matchLabels: appLabels },
        replicas: 1,
        template: {
            metadata: { labels: appLabels },
            spec: { containers: [{ 
                name: "api", 
                image: anabiImageName,
                
                ports: [{
                    containerPort: 3000
                }],
                env: [{
                        name: "ConnectionStrings__AnabiDatabase",
                        value: pulumi.all([sqlServer.name, database.name, sqlpassword]).apply(([server, db, sqlpwd]) =>
                        `Server=tcp:${server}.database.windows.net;initial catalog=${db};user ID=${username};password=${sqlpwd};Min Pool Size=0;Max Pool Size=30;Persist Security Info=true;`)
                }]

                /* readinessProbe: {
                    httpGet: {
                        path: "/ready",
                        port: 8080
                    },
                    initialDelaySeconds: 5,
                    periodSeconds: 5
                }  */
            }] 
            //,imagePullSecrets: [{name: registrySecret.metadata.name }]
        }
        }
    }
}, {provider: aksprovider});


//https://github.com/pulumi/pulumi-azure/blob/master/sdk/nodejs/network/publicIp.ts
/* const apiLoadBalancerIp = new azure.network.PublicIp("LBIp", {
         allocationMethod: "Static",
         resourceGroupName: resourceGroup.name,
         tags: {
             service: "kubernetes-api-loadbalancer",
         },
     }); 

const apiLoadBalancerFirewallRule = new azure.sql.FirewallRule("api-lb", {
        endIpAddress: apiLoadBalancerIp.ipAddress,
        resourceGroupName: resourceGroup.name,
        serverName: sqlServer.name,
        startIpAddress: apiLoadBalancerIp.ipAddress,
    });*/

const anabiapiService = new k8s.core.v1.Service("anabi-api-service", {
    metadata: {
        labels: anabiapiDeployment.spec.template.metadata.labels
    },
    spec: {
        type: "LoadBalancer",
        ports: [{
            port: 80,
            targetPort: 3000
        }],
        //loadBalancerIP: apiLoadBalancerIp.ipAddress,
        selector: anabiapiDeployment.spec.template.metadata.labels
    }
}, { provider: aksprovider});
//, dependsOn: [apiLoadBalancerFirewallRule]



const firewallRules = anabiapiService.status.loadBalancer.ingress[0].ip.apply(
    ip => {
        new azure.sql.FirewallRule(`FR${ip}`, {
            endIpAddress: ip,
            resourceGroupName: resourceGroup.name,
            serverName: sqlServer.name,
            startIpAddress: ip,
        })}
    );
 
 //https://github.com/pulumi/examples/blob/master/kubernetes-ts-exposed-deployment/index.ts
export let apiIp = anabiapiService.status.loadBalancer.ingress[0].ip;

/*
The API populates the database on startup and that happens before the firewall rule on the SQL Server takes effect.
Therefore we have to restart the api manually

#get resource group as variable


#get AKS name as variable

#connect kubectl to AKS
az aks get-credentials --resource-group RGCreatedHere --name NameOfAKS

#find out deployment name
kubectl get deployments

#stop the pod with the api
kubectl scale deployment NameFromAbove --replicas=0

restart the pod with the api
kubectl scale deployment NameFromAbove --replicas=1
*/