using KTApps.Core.NotificationService.Interface;
using KTApps.Core.NotificationService.Notify.Entities;
using System;
using System.Net.Mail;

namespace KTApps.Core.NotificationService.Notify.Jobs
{
    public class CoreSmtpMailNotifiy : ICoreMailNotifiy
    {
        protected readonly SmtpClient smtpClient;
        public CoreSmtpMailNotifiy(SmtpClient smtpClient)
        {
            this.smtpClient = smtpClient;
        }

        public virtual void Notify(MailNotificationMessage notificationMessage)
        {
            if (smtpClient == null)
            {
                throw new Exception("SmtpClient in valid");
            }
            if (notificationMessage == null)
            {
                throw new Exception("Notification message in valid");
            }
            smtpClient.Send(notificationMessage);
        }
    }
}
