using KTApps.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Core.App.Notifications.Models
{
    public class CoreSMSLogModel : KTAppDomainModel
    {
        [Required]
        public Guid PendingId { set; get; }
        [Required]
        public Guid StatusId { set; get; }
        [Required]
        public string Logs { set; get; }
        public CoreNotificationStatusModel CoreNotificationStatus { set; get; }
        public CoreSMSPendingModel CoreSMSPendings { set; get; }
    }
}
