using Microsoft.EntityFrameworkCore;

namespace Vinorsoft.Core.VDbContext.Migrations
{
    public class AuthDbContextFactory : DesignTimeDbContextFactory<AuthDbContext>
    {
        protected override AuthDbContext CreateNewInstance(DbContextOptions<AuthDbContext> options)
        {
            return new AuthDbContext(options, null, null);
        }
    }
}
