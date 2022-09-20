using KTApps.Core.NotificationService.Entities;
using System;

namespace KTApps.Core.NotificationService.Interface
{
    public interface ICoreFCMPendingService : IDomainService<CoreFCMPendings>
    {
        bool SaveFCMPending(object notification, string template, object bindingObj);
        void UpdateStatus(Guid id, Guid statusId);

    }
}
