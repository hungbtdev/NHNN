using KTApps.ShareService.Entities;
using KTApps.ShareService.Interface;
using Microsoft.EntityFrameworkCore;

namespace KTApps.ShareService
{
    public class CoreConfigDbContext : DbContext, ICoreConfigDbContext
    {
        public CoreConfigDbContext(DbContextOptions<CoreConfigDbContext> options) : base(options)
        {
        }

        public DbSet<CorePageTitles> CorePageTitles { set; get; }
        public DbSet<CoreSystemConfigs> CoreSystemConfigs { set; get; }
        public DbSet<CoreTenants> CoreTenants { set; get; }
        public DbSet<CoreModules> CoreModules { set; get; }
        public DbSet<CoreSlidebarItems> CoreSlidebarItems { set; get; }
        public DbSet<CoreTenantConnections> CoreTenantConnections { set; get; }
    }
}
