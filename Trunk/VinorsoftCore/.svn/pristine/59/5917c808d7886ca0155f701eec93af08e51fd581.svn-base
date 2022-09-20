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
    public abstract class CoreSMSConfigurationController : NotificationCoreController<CoreSMSConfigurations,CoreSMSConfigurationModel, SearchSMSConfigModel>
    {
        public CoreSMSConfigurationController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            domainService = serviceProvider.GetRequiredService<ICoreSMSConfigurationService>();
        }

        [HttpPost]
        [ActionName("Save")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit, CoreConstants.AddNew })]
        public override ActionResult<KTAppDomainResult> Save([FromBody]CoreSMSConfigurationModel config)
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
                    CoreSMSConfigurations itemToSave = mapper.Map<CoreSMSConfigurations>(config);
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