using Microsoft.EntityFrameworkCore;

namespace Vinorsoft.Core.VDbContext.Migrations
{
    public class ProfileDbContextFactory : DesignTimeDbContextFactory<ProfileDbContext>
    {
        protected override ProfileDbContext CreateNewInstance(DbContextOptions<ProfileDbContext> options)
        {
            return new ProfileDbContext(options, null, null);
        }
    }
}
