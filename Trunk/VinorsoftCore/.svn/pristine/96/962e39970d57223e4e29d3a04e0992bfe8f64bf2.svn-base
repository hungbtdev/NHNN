using System;
using System.ComponentModel;
using KTApps.Core.App.Attribute;
using KTApps.Core.App.Models;
using KTApps.Models;
using KTApps.ShareService.Entities;
using KTApps.ShareService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Controllers
{
    [Authorize]
    [KTAppAuthorize2(permission: new string[] { CoreConstants.View })]
    [Description("Cấu hình hệ thống")]
    public abstract class SystemConfigCoreController : CatalogueCoreController<CoreSystemConfigs, SystemConfigModel, SearchCatalogueModel>
    {
        public SystemConfigCoreController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            catalogueService = serviceProvider.GetRequiredService<ICoreSystemConfigService>();
            domainService = catalogueService;
        }

        [KTAppAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        [HttpGet]
        public override IActionResult NewItem()
        {
            return View();
        }


        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit })]
        [HttpGet]
        public override IActionResult UpdateItem(Guid id)
        {
            return View();
        }
    }
}