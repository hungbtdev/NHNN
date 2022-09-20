using KTApps.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Core.App.Notifications.Models
{
    public class CoreSMSPendingModel : KTAppDomainModel
    {
        [MaxLength(1000)]
        [Required]
        public string Subject { set; get; }
        [MaxLength(1000)]
        [Required]
        public string Phone { set; get; }
        [Required]
        [MaxLength(1000)]
        public string Body { set; get; }

        [Required]
        public Guid StatusId { set; get; }
        public CoreNotificationStatusModel CoreNotificationStatus { set; get; }
    }
}
