using System;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Controllers
{
    public abstract class PermissionCoreController : CatalogueCoreController<Permissions, PermissionModel, SearchCatalogueModel>
    {
        public PermissionCoreController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            catalogueService = (IPermissionService)serviceProvider.GetRequiredService(typeof(IPermissionService));
            domainService = catalogueService;
        }
    }
}