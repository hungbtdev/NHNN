using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.VDbContext
{
    public class MNotificationDbContext : NotificationDbContext
    {
        public MNotificationDbContext(DbContextOptions<NotificationDbContext> options, IHttpContextAccessor httpContextAccessor, ITenantProvider tenantProvider) : base(options, httpContextAccessor, tenantProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (tenantProvider.GetTenantId().HasValue)
            {
                modelBuilder.Entity<SendLogs>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<EmailTemplates>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<FCMTemplates>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<SMSTemplates>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<BaseTemplates>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<DeviceTokens>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
                modelBuilder.Entity<NotificationMessages>().HasQueryFilter(p => p.TenantId == tenantProvider.GetTenantId());
            }
        }
    }
}
