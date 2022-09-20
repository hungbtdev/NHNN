using System.Collections.Generic;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
    public class NotificationMessages: VinorsoftDomain
    {
        public NotificationMessages()
        {
            SendLogs = new HashSet<SendLogs>();
        }
        public string Subject { set; get; }
        public string Body { set; get; }
        public string AppName { set; get; }
        public int ReadStatus { set; get; }
        public int SendStatus { set; get; }
        public int NotificationType { set; get; }
        public string Recipient { set; get; }
        public string JsonData { set; get; }
        public ICollection<SendLogs> SendLogs { set; get; }
    }
}
