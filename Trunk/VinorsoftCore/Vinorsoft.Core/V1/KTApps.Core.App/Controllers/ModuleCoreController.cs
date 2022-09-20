using System;
using System.Linq;
using KTApps.AuthService.Interface;
using KTApps.Core.App.Attribute;
using KTApps.Core.App.Models;
using KTApps.Domain;
using KTApps.Models;
using KTApps.ShareService.Entities;
using KTApps.ShareService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Controllers
{
    [KTAppAuthorize2(permission: new string[] { CoreConstants.View })]
    public abstract class ModuleCoreController : CatalogueCoreController<CoreModules, CoreModuleModel, SearchCatalogueModel>
    {
        readonly IDepartmentService departmentService;
        public ModuleCoreController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            catalogueService = serviceProvider.GetRequiredService<ICoreModuleService>();
            departmentService = serviceProvider.GetRequiredService<IDepartmentService>();
            domainService = catalogueService;
        }

        [KTAppAuthorize2(permission: new string[] { CoreConstants.Delete })]
        [HttpPost]
        public override ActionResult<KTAppDomainResult> Delete([FromBody] CoreModuleModel item)
        {
            return base.Delete(item);
        }
      
        [KTAppAuthorize2(permission:new string[] { CoreConstants.AddNew })]
        [HttpGet]
        public override IActionResult NewItem()
        {
            return View();
        }

        [KTAppAuthorize2(permission:new string[] { CoreConstants.Edit })]
        [HttpGet]
        public override IActionResult UpdateItem(Guid id)
        {
            return View();
        }

        [KTAppAuthorize2(permission:new string[] { CoreConstants.View })]
        [HttpGet]
        public override ActionResult<KTAppDomainResult> InitDropdown()
        {
            KTAppDomainResult appDomainResult = new KTAppDomainResult();
            try
            {
                appDomainResult.Data = new
                {
                    Departments = departmentService.Get(e => !e.Deleted).OrderBy(e => e.Name)
                };
                appDomainResult.Success = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
            }
            return appDomainResult;
        }
    }
}