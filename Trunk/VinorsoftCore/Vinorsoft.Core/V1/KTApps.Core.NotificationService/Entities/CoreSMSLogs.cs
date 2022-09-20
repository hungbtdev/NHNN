using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.Core.NotificationService.Entities
{
    public class CoreSMSLogs : KTAppDomain
    {
        [ForeignKey("CoreSMSPendings")]
        [Required]
        public Guid PendingId { set; get; }
        [Required]
        [ForeignKey("CoreNotificationStatus")]
        public Guid StatusId { set; get; }
        [Required]
        public string Logs { set; get; }

        public CoreNotificationStatus CoreNotificationStatus { set; get; }
        public CoreSMSPendings CoreSMSPendings { set; get; }
    }
}
