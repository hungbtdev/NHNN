using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KTApps.Core.NotificationService.Interface
{
    public interface INotificationJob
    {
        Task SendEmail(int limit);
        Task SendSMS(int limit);
        Task SendFCM(int limit);
    }
}
