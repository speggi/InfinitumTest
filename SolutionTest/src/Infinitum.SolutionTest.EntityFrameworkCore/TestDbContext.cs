using Infinitum.SolutionTest.Domain.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infinitum.SolutionTest.EntityFrameworkCore
{
    public class TestDbContext : DbContext
    {
        public DbSet<SomeData> SomeDatas { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }
    }
}
