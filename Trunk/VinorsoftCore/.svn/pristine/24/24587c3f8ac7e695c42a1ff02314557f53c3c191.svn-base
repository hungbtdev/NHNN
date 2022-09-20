using System;
using System.Linq;
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
    public class CoreFCMDeviceTokenController : NotificationCoreController<CoreFCMDeviceTokens, CoreFCMDeviceTokenModel, SearchCoreFCMDeviceTokenModel>
    {
        public CoreFCMDeviceTokenController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            domainService = serviceProvider.GetRequiredService<ICoreFCMDeviceTokenService>();
        }

        [HttpPost]
        [ActionName("Save")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit, CoreConstants.AddNew })]
        public override ActionResult<KTAppDomainResult> Save([FromBody]CoreFCMDeviceTokenModel coreFCMDeviceToken)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {
                    var existCode = domainService.Get(e => e.FCMToken == coreFCMDeviceToken.FCMToken && e.Id != coreFCMDeviceToken.Id && !e.Deleted).Any();
                    if (existCode)
                    {
                        throw new Exception(string.Format("{0} already exist", coreFCMDeviceToken.FCMToken));
                    }
                    CoreFCMDeviceTokens itemToSave = mapper.Map<CoreFCMDeviceTokens>(coreFCMDeviceToken);
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
    }
}