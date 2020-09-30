using Infinitum.SolutionTest.Domain.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infinitum.SolutionTest.EntityFrameworkCore.Repositories
{
    public class SomeDataRepository : ISomeDataRepository
    {
        private readonly TestDbContext _dbContext;

        public SomeDataRepository(TestDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<SomeData> GetDataByIdAsync(int dataId, CancellationToken token = default)
        {
            return _dbContext.SomeDatas
                .SingleAsync(token);
        }

        public Task SaveChangesAsync(CancellationToken token = default)
        {
            return _dbContext.SaveChangesAsync(token);
        }
    }
}
