using System;
using System.Collections.Generic;
using AutoMapper;
using KTApps.Core.NotificationService.Entities;
using KTApps.Core.NotificationService.Interface;
using KTApps.Core.Services;

namespace KTApps.Core.NotificationService
{
    public class CoreEmailSendLogService : DomainService<CoreEmailSendLogs>, ICoreEmailSendLogService
    {
        public CoreEmailSendLogService(ICoreNotificationUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void UpdateStatus(Guid id, Guid statusId)
        {
            unitOfWork.Repository<CoreEmailSendLogs>().ExecuteNonQuery("Update CoreEmailSendLogs set StatusId = @StatusId where Id = @Id", new Dictionary<string, object>()
            {
                {"@Id", id },
                {"@StatusId", statusId }
            });
        }
    }
}
