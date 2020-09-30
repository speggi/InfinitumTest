using System.Threading;
using System.Threading.Tasks;

namespace Infinitum.SolutionTest.DataConverter.Abstractions
{
    public interface ISomeDataConverter
    {
        Task<SomeConvertedData> Convert(string data, CancellationToken token = default);
    }
}
