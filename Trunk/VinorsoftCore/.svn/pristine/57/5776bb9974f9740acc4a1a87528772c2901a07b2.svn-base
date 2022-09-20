using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vinorsoft.Notify.Entities
{
    public class EmailMessage
    {
        public EmailMessage()
        {
            ToAddresses = new List<EmailAddress>();
            FromAddresses = new List<EmailAddress>();
        }

        public List<EmailAddress> ToAddresses { get; set; }
        public List<EmailAddress> FromAddresses { get; set; }
        public IEnumerable<EmailAddress> CCAddresses { get; set; }
        public IEnumerable<EmailAddress> BCCAddresses { get; set; }

        public string Subject { get; set; }
        public MimeEntity Body { get; set; }
       
    }
}
