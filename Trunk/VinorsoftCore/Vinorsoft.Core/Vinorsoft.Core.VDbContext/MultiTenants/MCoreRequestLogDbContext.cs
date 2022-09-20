using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.VDbContext
{
    public class MCoreRequestLogDbContext : CoreRequestLogDbContext
    {
        public MCoreRequestLogDbContext(DbContextOptions<CoreRequestLogDbContext> options, IHttpContextAccessor httpContextAccessor, ITenantProvider tenantProvider) : base(options, httpContextAccessor, tenantProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (tenantProvider.GetTenantId().HasValue)
            {
                modelBuilder.Entity<CoreRequestLogs>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
            }
        }
    }
}
