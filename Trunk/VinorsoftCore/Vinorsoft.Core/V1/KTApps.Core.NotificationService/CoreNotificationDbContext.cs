using KTApps.Core.NotificationService.Entities;
using KTApps.Core.NotificationService.Interface;
using Microsoft.EntityFrameworkCore;

namespace KTApps.Core.NotificationService
{
    public class CoreNotificationDbContext : DbContext, ICoreNotificationDbContext
    {
        public CoreNotificationDbContext(DbContextOptions<CoreNotificationDbContext> options) : base(options)
        {
        }
        public DbSet<CoreContentReplaces> CoreContentReplaces { get; set; }
        public DbSet<CoreEmailPendings> CoreEmailPendings { get; set; }
        public DbSet<CoreEmailSendLogs> CoreEmailSendLogs { get; set; }
        public DbSet<CoreFCMConfigurations> CoreFCMConfigurations { get; set; }
        public DbSet<CoreFCMDeviceTokens> CoreFCMDeviceTokens { get; set; }
        public DbSet<CoreFCMPendings> CoreFCMPendings { get; set; }
        public DbSet<CoreNotificationStatus> CoreNotificationStatus { get; set; }
        public DbSet<CoreNotificationTemplates> CoreNotificationTemplates { get; set; }
        public DbSet<CoreNotificationTypes> CoreNotificationTypes { get; set; }
        public DbSet<CoreSMSConfigurations> CoreSMSConfigurations { get; set; }
        public DbSet<CoreSMSLogs> CoreSMSLogs { get; set; }
        public DbSet<CoreSMSPendings> CoreSMSPendings { get; set; }
        public DbSet<CoreSMTPConfigurations> CoreSMTPConfigurations { get; set; }
    }
}
