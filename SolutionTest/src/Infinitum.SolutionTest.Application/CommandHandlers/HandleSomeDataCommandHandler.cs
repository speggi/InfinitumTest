using Infinitum.SolutionTest.Application.Contracts;
using Infinitum.SolutionTest.DataConverter.Abstractions;
using Infinitum.SolutionTest.Domain.DataModel;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infinitum.SolutionTest.Application.CommandHandlers
{
    public class HandleSomeDataCommandHandler : AsyncRequestHandler<HandleSomeDataCommand>
    {
        private readonly ILogger _logger;
        private readonly ISomeDataRepository _someDataRepository;
        private readonly ISomeDataConverter _someDataConverter;

        public HandleSomeDataCommandHandler(
            ILogger<HandleSomeDataCommandHandler> logger,
            ISomeDataRepository someDataRepository,
            ISomeDataConverter someDataConverter)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _someDataRepository = someDataRepository ?? throw new ArgumentNullException(nameof(someDataRepository));
            _someDataConverter = someDataConverter ?? throw new ArgumentNullException(nameof(someDataConverter));
        }

        protected override async Task Handle(HandleSomeDataCommand request, CancellationToken cancellationToken)
        {
            var data = await _someDataRepository.GetDataByIdAsync(request.DataId, cancellationToken);

            var converted = await _someDataConverter.Convert(data.Data);

            data.SetData(converted.ConvertedData);

            await _someDataRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
