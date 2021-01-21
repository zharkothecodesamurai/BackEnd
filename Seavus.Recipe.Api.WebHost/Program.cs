using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Seavus.Recipe.Api.DataAccess.Ef.DbContext;
using System.Diagnostics;
using System.IO;

namespace Seavus.Recipe.Api.WebHost
{
    public class Program
    {
        public static string BasePath
        {
            get
            {
                using var processModule = Process.GetCurrentProcess().MainModule;
                return Path.GetDirectoryName(processModule?.FileName);
            }
        }

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
       .SetBasePath(BasePath)
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
       .Build();

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var logger = host.Services.GetService<ILogger<Program>>();

            MigrateDatabase(host, logger);

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>

            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void MigrateDatabase(IHost host, ILogger logger)
        {
            logger.LogInformation("Migrating the database...");
            var serviceScopeFactory = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<RecipeDbContext>();

                dbContext.Database.Migrate();
            }
            logger.LogInformation("Migration of the database completed.");
        }
    }
}
