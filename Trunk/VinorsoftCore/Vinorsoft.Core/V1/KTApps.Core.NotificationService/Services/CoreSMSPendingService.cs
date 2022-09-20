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
using System.Text.RegularExpressions;

namespace KTApps.Core.NotificationService
{
    public class CoreSMSPendingService : DomainService<CoreSMSPendings>, ICoreSMSPendingService
    {
        readonly IStringLocalizer<SharedResource> sharedLocalizer;
        public CoreSMSPendingService(
            ICoreNotificationUnitOfWork unitOfWork,
            IMapper mapper,
            IStringLocalizer<SharedResource> sharedLocalizer
            ) : base(unitOfWork, mapper)
        {
            this.sharedLocalizer = sharedLocalizer;
        }

        private string BindingBody(string body, object bindingObj)
        {
            var relaceChars = unitOfWork.Repository<CoreContentReplaces>().GetQueryable().ToList();
            foreach (var chars in relaceChars)
            {
                string pattern = $"\\b{chars.NewChars}\\b";
                body = Regex.Replace(body, pattern, chars.OldChars);
            }

            foreach (var chars in relaceChars)
            {
                var value = bindingObj.GetPropValue(chars.OldChars);
                string pattern = $"\\b{chars.OldChars}\\b";
                body = Regex.Replace(body, pattern, string.Format("{0}", value));
            }
            return body;
        }

        private readonly string[] VietNamChar = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };
        public string ConvertVNKhongDau(string body)
        {
            //Thay thế và lọc dấu từng char      
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    body = body.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            return body;
        }

        public bool SaveSMSPending(string phone, string notificationTemplateCode, object bindingObj)
        {
            var notificationType = unitOfWork.Repository<CoreNotificationTypes>().GetQueryable()
                 .FirstOrDefault(e => e.Code == CoreConstants.NotificationType.SMS.ToString());
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

            CoreSMSPendings coreSMSPending = new CoreSMSPendings()
            {
                Id = Guid.NewGuid(),
                Body = ConvertVNKhongDau(BindingBody(notificationTemplate.Body, bindingObj)),
                Created = DateTime.Now,
                CreatedBy = "System",
                Phone = phone,
                StatusId = status.Id,
                Subject = notificationTemplate.Subject,
                Active = true,
            };
            return Save(coreSMSPending);
        }

        public void UpdateStatus(Guid id, Guid statusId)
        {
            unitOfWork.Repository<CoreSMSPendings>().ExecuteNonQuery("update CoreSMSPendings set StatusId = @StatusId where Id = @Id", new Dictionary<string, object>(){
                                                { "@Id", id },
                                                { "@StatusId", statusId}
            });
        }
    }
}
