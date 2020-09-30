using Infinitum.SolutionTest.Host.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infinitum.SolutionTest.Host.EntityFrameworkCore
{
    public class TestHostDbContext : DbContext
    {
        public DbSet<HostSomeData> SomeDatas { get; set; }

        public TestHostDbContext(DbContextOptions<TestHostDbContext> options)
            : base(options)
        {
        }
    }
}
