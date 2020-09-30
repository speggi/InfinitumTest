using Infinitum.SolutionTest.DataConverter.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infinitum.SolutionTest.DataConverter
{
    public class SomeDataConverterImplementation : ISomeDataConverter
    {
        public Task<SomeConvertedData> Convert(string data, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
