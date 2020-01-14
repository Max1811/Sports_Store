using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Store.DataInitializer;

namespace Store
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger("startup");

                try
                {
                    logger.LogInformation("Trying to initialize with seed data if it needs");
                    InitializePrimaryData.Initialize(services);
                    logger.LogInformation("Data initialized correctly");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Data initialized incorrectly");
                }
            }

            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureLogging((ctx, builder) =>
                     {
                         builder.AddConfiguration(ctx.Configuration.GetSection("Logging"));
                         builder.AddFile(o => o.RootPath = ctx.HostingEnvironment.ContentRootPath);
                     }).UseStartup<Startup>();
                });
    }
}
