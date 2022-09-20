using KTApps.Core.NotificationService.Entities;
using System;

namespace KTApps.Core.NotificationService.Interface
{
    public interface ICoreEmailPendingService : IDomainService<CoreEmailPendings>
    {
        bool SaveEmailPending(string email, string cc, string bcc, string notificationTemplateCode, object bindingObj);
        void UpdateStatus(Guid id, Guid statusId);
    }
}
