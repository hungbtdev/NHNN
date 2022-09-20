using System;
using KTApps.Core.App.Controllers;
using KTApps.Core.App.Notifications.Models;
using KTApps.Core.NotificationService.Entities;
using KTApps.Core.NotificationService.Interface;
using KTApps.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Notifications.Areas.Notification.Controllers
{
    public abstract class CoreNotificationStatusController : CatalogueCoreController<CoreNotificationStatus, CoreNotificationStatusModel, SearchCatalogueModel>
    {
        public CoreNotificationStatusController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            catalogueService = serviceProvider.GetRequiredService<ICoreNotificationStatusService>();
            domainService = catalogueService;
        }
    }
}