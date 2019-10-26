using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using Northwind.Api.Helpers;

namespace Northwind.Api
{
    public class Program
    {
        /// <summary>
        /// Please note: Microsoft has not taken a clear standpoint where to apply the database ef core migrations.
        /// Within the docs, they recommend to "Database migration should be done as part of deployment"
        /// Which we should follow for the semseter portfolio project: migration scripts are written during build, then the scripts are executed on release
        /// https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/migrations?view=aspnetcore-2.2&tabs=visual-studio#applying-migrations-in-production-1
        /// However their employees has other recommendations, such as use migration on the method of <see cref="Main(string[])"/> 
        /// https://github.com/aspnet/EntityFrameworkCore/issues/9033#issuecomment-317063370
        /// </summary>
        public static void Main(string[] args)
        {
            BuildHost(args).Run();

        }

        /// <summary>
        /// It executes to setup the environment, EF core tooling uses it in design time too.
        /// For supporting EF Core Migrations and keeping the cleaner DbContext class (no hardcoded connectionstrings etc)
        /// Please see <see cref="NorthwindDbContextDesignTimeDbContextFactory"/> implementation 
        /// </summary>
        public static IWebHost BuildHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(ConfigConfiguration)
                .ConfigureLogging(ConfigureLogger)
                .UseStartup<Startup>()
                .Build();
        }

        private static void ConfigureLogger(WebHostBuilderContext ctx, ILoggingBuilder logging)
        {
            logging.AddConfiguration(ctx.Configuration.GetSection("Logging"));
            logging.AddConsole();
            logging.AddDebug();
        }

        private static void ConfigConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder config)
        {
            config.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();
        }
    }
}
