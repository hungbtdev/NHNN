using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.VDbContext
{
    public class MAuthDbContext : AuthDbContext
    {
        public MAuthDbContext(DbContextOptions<AuthDbContext> options, IHttpContextAccessor httpContextAccessor, ITenantProvider tenantProvider) : base(options, httpContextAccessor, tenantProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (tenantProvider.GetTenantId().HasValue)
            {
                modelBuilder.Entity<Permissions>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<Users>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<UserInGroups>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<UserGroups>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<PermitObjectPermissions>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<PermitObjects>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<PermitObjectSidebars>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
            }
        }
    }
}
