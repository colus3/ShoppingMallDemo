using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Cart.Data;
using Services.Order.Data;
using Services.Product.Data;
using Services.Product.Models.Entity;
using System;
using System.Linq;

namespace ShoppingMallDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                IHostingEnvironment env = services.GetService<IHostingEnvironment>();
                IConfiguration config = services.GetService<IConfiguration>();

                if (bool.TryParse(config["MigrateDatabaseToLatestVersion"], out bool bMigration) && bMigration)
                {
                    var productDbContext = scope.ServiceProvider.GetRequiredService<ProductDbContext>();

                    productDbContext.Database.Migrate();
                    scope.ServiceProvider.GetRequiredService<CartDbContext>().Database.Migrate();
                    scope.ServiceProvider.GetRequiredService<OrderDbContext>().Database.Migrate();

                    if (!productDbContext.Products.Any())
                    {
                        productDbContext.Products.Add(new Product
                        {
                            Name = "Teddy bear",
                            Price = (decimal)45.29
                        });

                        productDbContext.Products.Add(new Product
                        {
                            Name = "Candle",
                            Price = (decimal)12.25
                        });

                        productDbContext.Products.Add(new Product
                        {
                            Name = "Wilson Volleyball",
                            Price = (decimal)15.99
                        });

                        productDbContext.SaveChanges();
                    }
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
