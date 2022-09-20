﻿using System.Collections.Generic;
using System.Net.Mail;

namespace KTApps.Core.Notification
{
    public class EmailSendConfigure
    {
        public string SmtpServer { set; get; }
        public IList<string> TOs { get; set; }
        public string EmailTo { get; set; }
        public IList<string> CCs { get; set; }
        public string From { get; set; }
        public bool EnableSsl { get; set; }
        public int Port { get; set; }
        public string FromDisplayName { get; set; }
        public string Subject { get; set; }
        public MailPriority Priority { get; set; }
        public string ClientCredentialUserName { get; set; }
        public string ClientCredentialPassword { get; set; }
        public IList<string> BCCs { get; internal set; }

        public EmailSendConfigure()
        {
            TOs = new List<string>();
            CCs = new List<string>();
            BCCs = new List<string>();
        }
    }
}
