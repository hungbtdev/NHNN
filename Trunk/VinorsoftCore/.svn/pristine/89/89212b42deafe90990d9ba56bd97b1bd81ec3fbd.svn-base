using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.VDbContext
{
    public class NotificationDbContext : CoreDbContext, INotificationDbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options, IHttpContextAccessor httpContextAccessor, ITenantProvider tenantProvider) : base(options, httpContextAccessor, tenantProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<SendLogs>(x => x.ToTable("Noti_SendLogs"));
                modelBuilder.Entity<BaseTemplates>(x => x.ToTable("Noti_BaseTemplates"));
                modelBuilder.Entity<DeviceTokens>(x => x.ToTable("Noti_DeviceTokens"));
                modelBuilder.Entity<NotificationMessages>(x => x.ToTable("Noti_NotificationMessages"));

                modelBuilder.Entity<BaseTemplates>(entity => entity.Property(e => e.Id).ValueGeneratedNever());
                modelBuilder.Entity<BaseTemplates>()
                        .HasDiscriminator(p => p.Discriminator)
                        .HasValue<EmailTemplates>(nameof(EmailTemplates))
                        .HasValue<FCMTemplates>(nameof(FCMTemplates))
                        .HasValue<SMSTemplates>(nameof(SMSTemplates));
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<SendLogs> SendLogs { get; set; }
        public DbSet<EmailTemplates> EmailTemplates { get; set; }
        public DbSet<FCMTemplates> FCMTemplates { get; set; }
        public DbSet<SMSTemplates> SMSTemplates { get; set; }
        public DbSet<BaseTemplates> BaseTemplates { get; set; }
        public DbSet<DeviceTokens> DeviceTokens { get; set; }
        public DbSet<NotificationMessages> NotificationMessages { get; set; }
    }
}
