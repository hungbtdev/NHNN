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
    public class CoreEmailPendingService : DomainService<CoreEmailPendings>, ICoreEmailPendingService
    {
        readonly IStringLocalizer<SharedResource> sharedLocalizer;
        public CoreEmailPendingService(
            ICoreNotificationUnitOfWork unitOfWork,
            IMapper mapper,
            IStringLocalizer<SharedResource> sharedLocalizer
            ) : base(unitOfWork, mapper)
        {
            this.sharedLocalizer = sharedLocalizer;
        }


        public void UpdateStatus(Guid id, Guid statusId)
        {
            unitOfWork.Repository<CoreEmailSendLogs>().ExecuteNonQuery("Update CoreEmailPendings set StatusId = @StatusId where Id = @Id", new Dictionary<string, object>()
            {
                {"@Id", id },
                {"@StatusId", statusId }
            });
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

        public bool SaveEmailPending(string email, string cc, string bcc, string notificationTemplateCode, object bindingObj)
        {
            var notificationType = unitOfWork.Repository<CoreNotificationTypes>().GetQueryable()
                .FirstOrDefault(e => e.Code == CoreConstants.NotificationType.Email.ToString());
            var notificationTemplate = unitOfWork.Repository<CoreNotificationTemplates>().GetQueryable()
                .FirstOrDefault(e => e.Code == notificationTemplateCode);
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

            CoreEmailPendings coreEmailPending = new CoreEmailPendings()
            {
                Id = Guid.NewGuid(),
                Body = BindingBody(notificationTemplate.Body, bindingObj),
                Created = DateTime.Now,
                CreatedBy = "System",
                BCC = bcc,
                CC = cc,
                EmailTo = email,
                IsBodyHtml = true,
                StatusId = status.Id,
                Subject = notificationTemplate.Subject,
                Active = true,
            };
            return Save(coreEmailPending);
        }
    }
}
