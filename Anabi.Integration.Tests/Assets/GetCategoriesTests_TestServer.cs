using Anabi.DataAccess.Ef;
using Anabi.Features.Assets.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Anabi.Integration.Tests.Assets
{
    public class GetCategoriesTests_TestServer
    {
        public AnabiContext Context { get; set; }

        [Fact]
        public async Task ParentCategories_ReturnsList()
        {
            //var projectRootPath = Path.GetFullPath(Path.Combine(
            //                         Directory.GetCurrentDirectory(),
            //                         @"..\..\..\..", "Anabi"));

            //var hostBuilder = new WebHostBuilder()
            //    .UseStartup<Startup>()
            //    .UseEnvironment("Test")
            //    .UseContentRoot(projectRootPath);

            //var contextBuilder = new AnabiDbContextBuilder();
            //Context = contextBuilder.CreateInMemoryDbContext()
            //    .WithAssetCategories()
            //    .Build();

            //hostBuilder.ConfigureServices(services =>
            //{
            //    services.AddSingleton(Context);
            //});

            

            //using (var server = new TestServer(hostBuilder))
            //{

            //    var scopedServices = server.Host.Services;

            //    var db = scopedServices.GetRequiredService<AnabiContext>();

            //    db.Database.EnsureCreated();
            //    DbInitializer.InitializeFullDb(db);

                

            //    var client = server.CreateClient();
            //    var response = await client.GetAsync("/api/assets/parentcategories");
            //    response.EnsureSuccessStatusCode();

            //    var input = await response.Content.ReadAsStringAsync();
            //    var content = JsonConvert.DeserializeObject<List<CategoryViewModel>>(input);

            //    Assert.True(content.Count > 0);

            //}
        }
    }
}
