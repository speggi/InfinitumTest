using System.Threading;
using System.Threading.Tasks;

namespace Infinitum.SolutionTest.Host.Interfaces
{
    interface ISomeDataHostRepository
    {
        Task<int[]> GetIdForProcessing(CancellationToken token = default);
    }
}
