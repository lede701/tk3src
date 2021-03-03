using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var context = service.GetRequiredService<DataContext>();
                var logFactory = service.GetRequiredService<ILoggerFactory>();
                try
                {
                    await context.Database.MigrateAsync();
                }
                catch (Exception ex)
                {
                    var logger = logFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occured during migration");
                }
                // Check if the database needs to be seeded
                await Seed.SeedData(context, logFactory);
            }
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
