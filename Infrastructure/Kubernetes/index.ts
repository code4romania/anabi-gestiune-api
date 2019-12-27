import * as pulumi from "@pulumi/pulumi";
import * as azure from "@pulumi/azure";
import * as docker from "@pulumi/docker";
import * as kx from "@pulumi/kubernetesx";

// Create an Azure Resource Group
const resourceGroup = new azure.core.ResourceGroup("anabi-support-infra-rg");

const containerRegistry = new azure.containerservice.Registry("anabicreg", {
    location: resourceGroup.location,
    resourceGroupName: resourceGroup.name,
    sku: "Basic",
    adminEnabled: true
});

const sqlServer = new azure.sql.SqlServer("anabisqlsrv", {
         administratorLogin: "alex",
         administratorLoginPassword: "thisIsDog11",
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
    });

//endre appsettings.json


    //const imageNm: Output<string> = pulumi.concat(containerRegistry.loginServer, "/", "anabi", ":V1.0.0");
//console.log("Docker file name is: " + imageNm);
const anabiImageName = pulumi.interpolate`${containerRegistry.loginServer}/anabi-api:v1.0.0`;

const d = new docker.Image("anabiapi", {
    build: {
        context: '../'
    },
    imageName: anabiImageName,
    registry: {
        server: containerRegistry.loginServer,
        username: containerRegistry.adminUsername,
        password: containerRegistry.adminPassword, 
    }
});


//// Kubernetes
const pb = new kx.PodBuilder({
    containers: [{
        // name is not required. If not provided, it is inferred from the image.
        image: "nginx",
        ports: {http: 80}, // Simplified ports syntax.
    },
    {
        image: anabiImageName,
        ports: {http: 5001}
    }]
});

const depl = new kx.Deployment




/* // Create an Azure resource (Storage Account)
const account = new azure.storage.Account("storage", {
    // The location for the storage account will be derived automatically from the resource group.
    resourceGroupName: resourceGroup.name,
    accountTier: "Standard",
    accountReplicationType: "LRS",
});

// Export the connection string for the storage account
export const connectionString = account.primaryConnectionString; */

