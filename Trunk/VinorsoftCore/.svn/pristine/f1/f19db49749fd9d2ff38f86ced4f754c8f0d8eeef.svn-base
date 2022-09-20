using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.Core.NotificationService.Entities
{
    public class CoreFCMPendings : KTAppDomain
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
        [ForeignKey("CoreNotificationStatus")]
        [Required]
        public Guid StatusId { set; get; }
        [MaxLength(1000)]
        public string Sound { set; get; }
        public string Data { set; get; }
        [MaxLength(1000)]
        public string Priority { set; get; }

        /// <summary>
        /// UseId
        /// </summary>
        public Guid? RefId { set; get; }

        public CoreNotificationStatus CoreNotificationStatus { set; get; }
    }
}
