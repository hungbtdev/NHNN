using System;
using KTApps.Core.App.Attribute;
using KTApps.Core.App.Controllers;
using KTApps.Core.App.Notifications.Models;
using KTApps.Core.App.Notifications.Models.Search;
using KTApps.Core.NotificationService.Entities;
using KTApps.Core.NotificationService.Interface;
using KTApps.Core.Utils;
using KTApps.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Notifications.Areas.Notification.Controllers
{
    public abstract class CoreSMTPConfigurationController : NotificationCoreController<CoreSMTPConfigurations, CoreSMTPConfigurationModel, SearchSMTPConfigModel>
    {
        public CoreSMTPConfigurationController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            domainService = serviceProvider.GetRequiredService<ICoreSMTPConfigurationService>();
        }

        [HttpPost]
        [ActionName("Save")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit, CoreConstants.AddNew })]
        public override ActionResult<KTAppDomainResult> Save([FromBody]CoreSMTPConfigurationModel config)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {
                    var exists = domainService.GetById(config.Id);
                    if (exists == null || exists.Password != config.Password)
                    {
                        config.Password = StringCipher.Encrypt(config.Password, StringCipher.PassPhrase);
                    }
                    CoreSMTPConfigurations itemToSave = mapper.Map<CoreSMTPConfigurations>(config);
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
                }
            };
        }

    }
}