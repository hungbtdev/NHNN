using System;
using System.Linq.Expressions;
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
    public abstract class CoreSMSPendingController : NotificationCoreController<CoreSMSPendings, CoreSMSPendingModel, SearchEmailPendingModel>
    {
        protected readonly ICoreNotificationStatusService coreNotificationStatusService;
        public CoreSMSPendingController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            domainService = serviceProvider.GetRequiredService<ICoreSMSPendingService>();
            coreNotificationStatusService = serviceProvider.GetRequiredService<ICoreNotificationStatusService>();
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
                    NotificationStatus = coreNotificationStatusService.Get(e => !e.Deleted)
                }
            };
        }

        protected override Expression<Func<CoreSMSPendings, CoreSMSPendings>> BuildSelectQuery()
        {
            return e => new CoreSMSPendings()
            {
                Active = e.Active,
                Id = e.Id,
                StatusId = e.StatusId,
                CoreNotificationStatus = e.CoreNotificationStatus,
                Body = e.Body,
                Phone = e.Phone,
                Subject = e.Subject
            };
        }
    }
}