using AutoMapper;
using KTApp.Core.Resources;
using KTApps.Core.NotificationService.Entities;
using KTApps.Core.NotificationService.Interface;
using KTApps.Core.Services;
using KTApps.Core.Utils;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KTApps.Core.NotificationService
{
    public class CoreFCMPendingService : DomainService<CoreFCMPendings>, ICoreFCMPendingService
    {
        readonly IStringLocalizer<SharedResource> sharedLocalizer;
        public CoreFCMPendingService(
            ICoreNotificationUnitOfWork unitOfWork,
            IMapper mapper,
            IStringLocalizer<SharedResource> sharedLocalizer) : base(unitOfWork, mapper)
        {
            this.sharedLocalizer = sharedLocalizer;
        }

        private string BindingBody(string body, object bindingObj)
        {
            var relaceChars = unitOfWork.Repository<CoreContentReplaces>().GetQueryable().ToList();
            foreach (var chars in relaceChars)
            {
                body = body.Replace(chars.NewChars, chars.OldChars);
            }

            foreach (var chars in relaceChars)
            {
                var value = bindingObj.GetPropValue(chars.OldChars);
                body = body.Replace(chars.OldChars, string.Format("{0}", value));
            }
            return body;
        }

        public bool SaveFCMPending(object notification, string template, object bindingObj)
        {
            var notificationType = unitOfWork.Repository<CoreNotificationTypes>().GetQueryable()
                 .FirstOrDefault(e => e.Code == CoreConstants.NotificationType.Email.ToString());
            var notificationTemplate = unitOfWork.Repository<CoreNotificationTemplates>().GetQueryable()
                .FirstOrDefault(e => e.Code == template);
            var status = unitOfWork.Repository<CoreNotificationStatus>().GetQueryable()
                .FirstOrDefault(e => e.Code == CoreConstants.NotificationStatus.New.ToString());

            if (status == null)
            {
                throw new KTAppException(10012, sharedLocalizer["_10012"]);
            }

            if (notificationType == null)
            {
                throw new KTAppException(10013, sharedLocalizer["_10013"]);
            }

            if (notificationTemplate == null)
            {
                throw new KTAppException(10014, sharedLocalizer["_10014"]);
            }

            Guid.TryParse($"{notification.GetPropValue("RefId")}", out Guid refId);
            CoreFCMPendings coreFCMPending = new CoreFCMPendings()
            {
                Id = Guid.NewGuid(),
                Body = BindingBody(notificationTemplate.Body, bindingObj),
                Created = DateTime.Now,
                CreatedBy = "System",
                StatusId = status.Id,
                Subject = notificationTemplate.Subject,
                Active = true,
                RefId = refId,
                FCMTo = $"{notification.GetPropValue("To")}",
                Icon = $"{notification.GetPropValue("Icon")}",
                ClickAction = $"{notification.GetPropValue("ClickAction")}",
                Data = $"{notification.GetPropValue("Data")}",
                Sound = $"{notification.GetPropValue("Sound")}",
                Priority = $"{notification.GetPropValue("Priority")}",
            };
            return Save(coreFCMPending);
        }

        public void UpdateStatus(Guid id, Guid statusId)
        {
            unitOfWork.Repository<CoreFCMPendings>().ExecuteNonQuery("update CoreFCMPendings set StatusId = @StatusId where Id = @Id",
                   new Dictionary<string, object>(){
                                                {"@Id",id},
                                                {"@StatusId",statusId}
                        });
        }
    }
}
