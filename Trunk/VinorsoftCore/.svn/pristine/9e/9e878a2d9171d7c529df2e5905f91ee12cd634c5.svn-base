using KTApps.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Core.App.Notifications.Models
{
    public class CoreFCMPendingModel : KTAppDomainModel
    {
        [MaxLength(1000)]
        [Required]
        public string Subject { set; get; }
        [MaxLength(4000)]
        [Required]
        public string Body { set; get; }
        public string ClickAction { set; get; }
        [MaxLength(1000)]
        public string Icon { set; get; }
        [MaxLength(1000)]
        [Required]
        public string FCMTo { set; get; }
        [Required]
        public Guid StatusId { set; get; }
        public Guid? RefId { set; get; }
        public CoreNotificationStatusModel CoreNotificationStatus { set; get; }
    }
}
