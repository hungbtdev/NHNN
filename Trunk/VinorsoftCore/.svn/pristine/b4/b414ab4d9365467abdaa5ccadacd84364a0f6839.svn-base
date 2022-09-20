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
    public class CoreEmailPendingController : NotificationCoreController<CoreEmailPendings,CoreEmailPendingModel, SearchEmailPendingModel>
    {
        protected readonly ICoreNotificationStatusService coreNotificationStatusService;
        public CoreEmailPendingController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            domainService = serviceProvider.GetRequiredService<ICoreEmailPendingService>();
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

        protected override Expression<Func<CoreEmailPendings, CoreEmailPendings>> BuildSelectQuery()
        {
            return e => new CoreEmailPendings()
            {
                Active = e.Active,
                EmailTo = e.EmailTo,
                CC = e.CC,
                BCC = e.BCC,
                Id = e.Id,
                Subject = e.Subject,
                CoreNotificationStatus = e.CoreNotificationStatus,
                StatusId = e.StatusId,
            };
        }
    }
}