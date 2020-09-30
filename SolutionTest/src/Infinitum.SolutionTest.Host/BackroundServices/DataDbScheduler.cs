using Infinitum.SolutionTest.Application.Contracts;
using Infinitum.SolutionTest.Host.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infinitum.SolutionTest.Host.BackroundServices
{
    public class DataDbScheduler : BackgroundService
    {
        private readonly ILogger _logger;

        private readonly IServiceProvider _serviceProvider;

        public DataDbScheduler(
            ILogger<DataDbScheduler> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.Register(() => _logger.LogWarning("Cancellationtoken has been requested")); 

            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();

                var someDataRepo = scope.ServiceProvider.GetRequiredService<ISomeDataHostRepository>();
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                var dataIdsForProcessing = await someDataRepo.GetIdForProcessing(stoppingToken);

                foreach (var item in dataIdsForProcessing)
                {
                    try
                    {
                        var command = new HandleSomeDataCommand(item);

                        await mediator.Send(command);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred while HandleSomeDataCommand");
                    }
                }
            }
        }
    }
}
