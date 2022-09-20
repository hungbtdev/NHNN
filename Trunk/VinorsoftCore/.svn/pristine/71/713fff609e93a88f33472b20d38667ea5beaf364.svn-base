using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.VDbContext
{
    public class MCoreConfigDbContext : CoreConfigDbContext
    {
        public MCoreConfigDbContext(DbContextOptions<CoreConfigDbContext> options, IHttpContextAccessor httpContextAccessor, ITenantProvider tenantProvider) : base(options, httpContextAccessor, tenantProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (tenantProvider.GetTenantId().HasValue)
            {
                modelBuilder.Entity<CoreSystemConfigs>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<CoreModules>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<CoreSlidebarItems>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<CorePageTitles>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
            }
        }
    }
}
