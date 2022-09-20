using System;
using System.ComponentModel.DataAnnotations.Schema;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
    public class SendLogs : VinorsoftDomain
    {
        [ForeignKey("NotificationMessages")]
        public Guid NotificationMessageId { set; get; }
        public DateTime? StartDate { set; get; }
        public DateTime? EndDate { set; get; }
        public bool Success { set; get; }
        public string Error { set; get; }
        public string From { set; get; }
        public string To { set; get; }
    }
}
