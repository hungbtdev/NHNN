using System;
using System.Linq;
using KTApps.Core.App.Context;
using KTApps.Core.App.Controllers;
using KTApps.Core.App.Notifications.Models;
using KTApps.Core.NotificationService.Entities;
using KTApps.Core.NotificationService.Interface;
using KTApps.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Notifications.Controllers
{
    public class CoreDeviceTokenController : KTAppCoreController
    {
        readonly ICoreFCMDeviceTokenService coreFCMDeviceTokenService;
        public CoreDeviceTokenController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            coreFCMDeviceTokenService = serviceProvider.GetRequiredService<ICoreFCMDeviceTokenService>();
        }


        [HttpPost]
        [ActionName("RegisterDevice")]
        public virtual ActionResult<KTAppDomainResult> RegisterDevice([FromBody]RegisterDeviceModel item)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {
                    var existDevice = coreFCMDeviceTokenService.Get(e => !e.Deleted && e.FCMToken == item.Token)
                        .FirstOrDefault();
                    if (existDevice != null)
                    {
                        existDevice.RefId = LoginContext.Instance.CurrentUser.UserId.ToString();
                        bool success = coreFCMDeviceTokenService.Save(existDevice, nameof(existDevice.RefId));
                        appResult.Success = success;
                    }
                    else
                    {
                        CoreFCMDeviceTokens itemToSave = new CoreFCMDeviceTokens()
                        {
                            Id = Guid.NewGuid(),
                            Active = true,
                            Created = DateTime.Now,
                            CreatedBy = LoginContext.Instance.CurrentUser.UserName,
                            FCMToken = item.Token,
                            RefId = LoginContext.Instance.CurrentUser.UserId.ToString(),
                            Model = item.Model
                        };
                        bool success = coreFCMDeviceTokenService.Save(itemToSave);
                        appResult.Success = success;
                    }
                }
                else
                {
                    appResult.Messages = GetModelStateError();
                }
            }
            catch (KTAppException ex)
            {
                appResult.ResultCode = ex.ErrorCode;
                logger.LogError(ex, ex.Message, new string[] { });
                appResult.Messages.Add(ex.Message);
            }
            return appResult;
        }
    }
}