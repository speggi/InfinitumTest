using Infinitum.SolutionTest.Application.CommandHandlers;
using Infinitum.SolutionTest.DataConverter;
using Infinitum.SolutionTest.DataConverter.Abstractions;
using Infinitum.SolutionTest.Domain.DataModel;
using Infinitum.SolutionTest.EntityFrameworkCore;
using Infinitum.SolutionTest.EntityFrameworkCore.Repositories;
using Infinitum.SolutionTest.Host.BackroundServices;
using Infinitum.SolutionTest.Host.EntityFrameworkCore;
using Infinitum.SolutionTest.Host.EntityFrameworkCore.Repositories;
using Infinitum.SolutionTest.Host.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infinitum.SolutionTest.Host
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(HandleSomeDataCommandHandler));

            services.AddDbContext<TestHostDbContext>(opt =>
                opt.UseSqlServer(_configuration.GetConnectionString("TestDb")));

            services.AddDbContext<TestDbContext>(opt =>
                opt.UseSqlServer(_configuration.GetConnectionString("TestDb")));

            services.AddTransient<ISomeDataRepository, SomeDataRepository>();
            services.AddTransient<ISomeDataHostRepository, SomeDataHostRepository>();

            services.AddHostedService<DataDbScheduler>();

            services.AddTransient<ISomeDataConverter, SomeDataConverterImplementation>();

        }

        public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime, ILogger<Startup> logger)
        {
            lifetime.ApplicationStarted.Register(() =>
            {
                logger.LogWarning("Service is started");
            });
        }
    }
}
