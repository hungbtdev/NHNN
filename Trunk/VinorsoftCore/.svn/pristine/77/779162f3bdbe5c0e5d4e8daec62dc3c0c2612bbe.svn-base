using System;
using System.Collections.Generic;
using System.Text;

namespace KTApps.Core.Notification
{
    public interface IEmailNotifyService
    {
        void Send(string subject, string body, string[] Tos);
        void Send(string subject, string body, string[] Tos, string[] CCs);
        void Send(string subject, string body, string[] Tos, string[] CCs, string[] BCCs);
        void Send(string subject, string[] Tos, string[] CCs, string[] BCCs, EmailContent emailContent);
        void SendMail(string subject, string Tos, string[] CCs, string[] BCCs, EmailContent emailContent);
    }
}
