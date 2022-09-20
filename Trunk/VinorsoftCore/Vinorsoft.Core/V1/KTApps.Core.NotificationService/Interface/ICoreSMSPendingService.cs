using KTApps.Core.NotificationService.Entities;
using System;

namespace KTApps.Core.NotificationService.Interface
{
    public interface ICoreSMSPendingService : IDomainService<CoreSMSPendings>
    {
        bool SaveSMSPending(string phone, string notificationTemplateCode, object bindingObj);

        void UpdateStatus(Guid id, Guid statusId);
    }
}
