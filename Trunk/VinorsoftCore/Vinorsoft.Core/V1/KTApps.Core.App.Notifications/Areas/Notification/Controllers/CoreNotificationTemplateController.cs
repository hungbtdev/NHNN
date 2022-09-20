using System;
using System.Linq;
using System.Linq.Expressions;
using KTApps.Core.App.Attribute;
using KTApps.Core.App.Controllers;
using KTApps.Core.App.Notifications.Models;
using KTApps.Core.App.Notifications.Models.Search;
using KTApps.Core.NotificationService.Entities;
using KTApps.Core.NotificationService.Interface;
using KTApps.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Notifications.Areas.Notification.Controllers
{
    public abstract class CoreNotificationTemplateController : NotificationCoreController<CoreNotificationTemplates, CoreNotificationTemplateModel, SearchNotificationTemplateModel>
    {
        protected readonly ICoreNotificationTypeService coreNotificationTypeService;
        public CoreNotificationTemplateController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            domainService = serviceProvider.GetRequiredService<ICoreNotificationTemplateService>();
            coreNotificationTypeService = serviceProvider.GetRequiredService<ICoreNotificationTypeService>();
        }

        [HttpPost]
        [ActionName("Save")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit, CoreConstants.AddNew })]
        public override ActionResult<KTAppDomainResult> Save([FromBody]CoreNotificationTemplateModel coreNotificationTemplate)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {
                    var existCode = domainService.Get(e => e.Code == coreNotificationTemplate.Code && e.Id != coreNotificationTemplate.Id && !e.Deleted).Any();
                    if (existCode)
                    {
                        throw new Exception(string.Format("{0} already exist", coreNotificationTemplate.Code));
                    }
                    CoreNotificationTemplates itemToSave = mapper.Map<CoreNotificationTemplates>(coreNotificationTemplate);
                    bool success = domainService.Save(itemToSave);
                    appResult.Success = success;
                }
                else
                {
                    appResult.Messages = GetModelStateError();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, new string[] { });
                appResult.Messages.Add(ex.Message);
            }
            return appResult;
        }

        [HttpGet]
        [ActionName("InitDropdown")]
        public override ActionResult<KTAppDomainResult> InitDropdown()
        {
            return new KTAppDomainResult()
            {
                Success = true,
                Data = new
                {
                    NotificationTypes = coreNotificationTypeService.Get(e => !e.Deleted)
                }
            };
        }

        protected override Expression<Func<CoreNotificationTemplates, CoreNotificationTemplates>> BuildSelectQuery()
        {
            return e => new CoreNotificationTemplates()
            {
                CoreNotificationTypes = e.CoreNotificationTypes,
                Id = e.Id,
                Code = e.Code,
                Name = e.Name,
                Subject = e.Subject,
            };
        }
    }
}