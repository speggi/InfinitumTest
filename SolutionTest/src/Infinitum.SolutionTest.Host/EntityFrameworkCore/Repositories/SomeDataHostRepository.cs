using Infinitum.SolutionTest.Host.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infinitum.SolutionTest.Host.EntityFrameworkCore.Repositories
{
    public class SomeDataHostRepository : ISomeDataHostRepository
    {
        private readonly TestHostDbContext _dbContext;

        public SomeDataHostRepository(TestHostDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<int[]> GetIdForProcessing(CancellationToken token = default)
        {
            return _dbContext.SomeDatas
                .Select(a => a.Id)
                .ToArrayAsync(token);
        }
    }
}
