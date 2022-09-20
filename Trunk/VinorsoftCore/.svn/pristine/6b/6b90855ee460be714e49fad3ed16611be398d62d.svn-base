using System;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Controllers
{
    public abstract class CoreUserConfirmTypeController : CatalogueCoreController<UserConfirmTypes, UserConfirmTypeModel, SearchCatalogueModel>
    {
        public CoreUserConfirmTypeController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            catalogueService = serviceProvider.GetRequiredService<IUserConfirmTypeService>();
            domainService = catalogueService;
        }
    }
}