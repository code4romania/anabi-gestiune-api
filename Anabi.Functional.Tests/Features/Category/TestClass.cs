using Anabi.DataAccess.Ef;
using Anabi.Domain;
using Anabi.Security;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Anabi.Functional.Tests.Features.Category
{
    public class TestClass : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public TestClass(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Fact]
        public async Task Get_Categories_ReturnsListWithCategories()
        {
            var client = _factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var serviceProvider = new ServiceCollection()
                                    .AddEntityFrameworkInMemoryDatabase()
                                    .BuildServiceProvider();

                        services.AddDbContext<AnabiContext>(options =>
                        {
                            options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                            options.UseInternalServiceProvider(serviceProvider);
                        });

                        services.AddMediatR(typeof(Startup), typeof(BaseHandler), typeof(PasswordHashHandler));
                        services.AddAutoMapper(typeof(Startup), typeof(BaseHandler));

                        using (var scope = serviceProvider.CreateScope())
                        {
                            var scopedServices = scope.ServiceProvider;
                            var db = scopedServices
                                .GetRequiredService<AnabiContext>();

                            try
                            {

                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    });
                })
                .CreateClient();


            var response = await client.GetAsync("api/categories");

            var content = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var model = JsonConvert.DeserializeObject<List<Anabi.Features.Category.Models.Category>>(content);

            Assert.True(model.Count > 0);
        }
    }
}
