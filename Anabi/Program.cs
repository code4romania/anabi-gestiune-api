using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using System.IO;

namespace Anabi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseUrls("http://*:3000")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .UseStartup<Startup>()             
                .UseApplicationInsights("68fec371-3f13-45b8-ae53-92d0b6a9e18d")
                .Build();
    }
}
