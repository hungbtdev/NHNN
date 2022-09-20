using System;
using KTApps.Core.App.Attribute;
using KTApps.Core.App.Controllers;
using KTApps.Core.App.Notifications.Models;
using KTApps.Core.NotificationService.Entities;
using KTApps.Core.NotificationService.Interface;
using KTApps.Models;
using KTApps.Models.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Notifications.Areas.Notification.Controllers
{
    public abstract class CoreNotificationTypeController : CatalogueCoreController<CoreNotificationTypes, CoreNotificationTypeModel, SearchCatalogueModel>
    {
        public CoreNotificationTypeController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            catalogueService = serviceProvider.GetRequiredService<ICoreNotificationTypeService>();
            domainService = catalogueService;
        }
    }
}