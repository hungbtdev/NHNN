using System;
using KTApps.Core.App.Controllers;
using KTApps.Domain;
using KTApps.Models;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Notifications.Areas.Notification.Controllers
{
    public abstract class NotificationCoreController<T, M, S> : KTAppCore2Controller<T, M, S> where M : KTAppDomainModel where S : IDomainSearchModel where T : KTAppDomain
    {
        public NotificationCoreController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
        }
    }
}