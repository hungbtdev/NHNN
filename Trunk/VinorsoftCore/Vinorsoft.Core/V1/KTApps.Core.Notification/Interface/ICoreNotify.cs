using System;
using System.Collections.Generic;
using System.Text;

namespace KTApps.Core.Notification.Interface
{
    public interface ICoreNotify<T> where T: INotificationMessage 
    {
        void Notify(T message);
    }
}
