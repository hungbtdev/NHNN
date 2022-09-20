using Microsoft.EntityFrameworkCore;

namespace Vinorsoft.Core.VDbContext.Migrations
{
    public class VEventDbContextFactory : DesignTimeDbContextFactory<VEventDbContext>
    {
        protected override VEventDbContext CreateNewInstance(DbContextOptions<VEventDbContext> options)
        {
            return new VEventDbContext(options, null, null);
        }
    }
}
