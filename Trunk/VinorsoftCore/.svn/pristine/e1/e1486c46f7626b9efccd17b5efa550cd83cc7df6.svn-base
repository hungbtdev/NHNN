using KTApps.Core.NotificationService.Interface;
using KTApps.Core.NotificationService.Notify.Entities;
using System;
using System.Threading.Tasks;

namespace KTApps.Core.NotificationService.Notify.Jobs
{
    public class CoreSmsNotifiy : ICoreSmsNotifiy
    {
        protected readonly SMSConfiguration configuration;
        public CoreSmsNotifiy(SMSConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public virtual void Notify(SMSNotificationMessage message)
        {
            NotifyAsync(message).Wait();
        }

        public virtual Task NotifyAsync(SMSNotificationMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
