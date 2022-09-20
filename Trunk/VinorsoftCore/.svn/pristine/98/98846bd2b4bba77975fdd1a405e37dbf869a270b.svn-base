using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.VDbContext
{
    public class MProfileDbContext: ProfileDbContext
    {
        public MProfileDbContext(DbContextOptions<ProfileDbContext> options, IHttpContextAccessor httpContextAccessor, ITenantProvider tenantProvider) : base(options, httpContextAccessor, tenantProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (tenantProvider.GetTenantId().HasValue)
            {
                modelBuilder.Entity<Cities>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<Countries>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<Districts>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<GeoAreas>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<Profiles>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<Wards>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
            }
        }
    }
}
