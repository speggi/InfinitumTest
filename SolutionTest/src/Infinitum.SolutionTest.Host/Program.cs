using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace Infinitum.SolutionTest.Host
{
    public class Program
    {
        private static IConfiguration _configuration;

        public static void Main(string[] args)
        {
            _configuration = BuildConfiguration(args);

            var logger = CreateLogger(_configuration);

            try
            {
                logger.Warning("Service is starting");

                CreateHostBuilder(args)
                    .Build()
                    .Run();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Fatal unhandled exception has occurred");
            }
            finally
            {
                logger.Warning("Service is stopped");
                Log.CloseAndFlush();
            }
        }

        private static Serilog.ILogger CreateLogger(IConfiguration configuration)
        {
            var loggerConfig = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext();

            Log.Logger = loggerConfig.CreateLogger();

            return Log.Logger;
        }

        private static IConfiguration BuildConfiguration(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddCommandLine(args);

            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            configurationBuilder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);

            return configurationBuilder.Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host
                .CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHost(conf =>
                {
                    conf.UseStartup<Startup>();
                    conf.UseKestrel();
                });
    }
}
