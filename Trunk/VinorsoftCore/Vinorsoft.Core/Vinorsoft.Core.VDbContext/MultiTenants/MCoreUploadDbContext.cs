using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vinorsoft.Core.Entities.Media;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.VDbContext
{
    public class MCoreUploadDbContext : CoreUploadDbContext
    {
        public MCoreUploadDbContext(DbContextOptions<CoreUploadDbContext> options, IHttpContextAccessor httpContextAccessor, ITenantProvider tenantProvider) : base(options, httpContextAccessor, tenantProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (tenantProvider.GetTenantId().HasValue)
            {
                modelBuilder.Entity<CoreUploadFiles>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
            }
        }
    }
}
