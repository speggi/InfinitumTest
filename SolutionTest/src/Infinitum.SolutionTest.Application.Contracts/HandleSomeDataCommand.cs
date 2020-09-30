using MediatR;

namespace Infinitum.SolutionTest.Application.Contracts
{
    public class HandleSomeDataCommand : IRequest
    {
        public HandleSomeDataCommand(int dataId)
        {
            DataId = dataId;
        }

        public int DataId { get; private set; }
    }
}
