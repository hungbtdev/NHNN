using System;
using KTApps.Core.App.Controllers;
using KTApps.Core.App.Notifications.Models;
using KTApps.Core.App.Notifications.Models.Search;
using KTApps.Core.NotificationService.Entities;
using KTApps.Core.NotificationService.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Notifications.Areas.Notification.Controllers
{
    public abstract class CoreContentReplaceController : NotificationCoreController<CoreContentReplaces, CoreContentReplaceModel, SearchContentReplaceModel>
    {
        public CoreContentReplaceController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            domainService = serviceProvider.GetRequiredService<ICoreContentReplaceService>();
        }
    }
}