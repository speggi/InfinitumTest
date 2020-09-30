using System.Threading;
using System.Threading.Tasks;

namespace Infinitum.SolutionTest.Domain.DataModel
{
    public interface ISomeDataRepository
    {
        Task<SomeData> GetDataByIdAsync(int dataId, CancellationToken token = default);

        Task SaveChangesAsync(CancellationToken token = default);
    }
}
