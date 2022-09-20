using AutoMapper;
using KTApps.Core.Notification.Interface;
using System.Net.Mail;

namespace KTApps.Core.Notification.Services
{
    public abstract class CoreMailNotify<T> : ICoreNotify<T> where T : INotificationMessage
    {
        protected readonly SmtpClient smtpClient;
        protected readonly IMapper mapper;
        public CoreMailNotify(SmtpClient smtpClient, IMapper mapper)
        {
            this.smtpClient = smtpClient;
            this.mapper = mapper;
        }

        public void Notify(T message)
        {
            if (smtpClient == null)
            {
                throw new System.Exception("SmtpClient in valid");
            }
            MailMessage mailMessage = mapper.Map<MailMessage>(message);
            if (mailMessage == null)
            {
                throw new System.Exception("Notification message in valid");
            }
            smtpClient.Send(mailMessage);
        }

        public virtual void NotifyAsync(T notificationMessage)
        {
           
        }
    }
}
