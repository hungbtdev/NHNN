using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.VDbContext
{
    public class CoreConfigDbContext : CoreDbContext, ICoreConfigDbContext
    {
        public CoreConfigDbContext(DbContextOptions<CoreConfigDbContext> options, IHttpContextAccessor httpContextAccessor, ITenantProvider tenantProvider) : base(options, httpContextAccessor, tenantProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoreSystemConfigs>(x => x.ToTable("Conf_CoreSystemConfigs"));
            modelBuilder.Entity<CoreModules>(x => x.ToTable("Conf_CoreModules"));
            modelBuilder.Entity<CoreSlidebarItems>(x => x.ToTable("Conf_CoreSlidebarItems"));
            modelBuilder.Entity<CorePageTitles>(x => x.ToTable("Conf_CorePageTitles"));
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CorePageTitles> CorePageTitles { set; get; }
        public DbSet<CoreSystemConfigs> CoreSystemConfigs { set; get; }
        public DbSet<CoreModules> CoreModules { set; get; }
        public DbSet<CoreSlidebarItems> CoreSlidebarItems { set; get; }
    }
}
