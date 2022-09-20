using System;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Controllers
{
    public abstract class CoreUserConfirmStatusController : CatalogueCoreController<UserConfirmStatus, UserConfirmStatusModel, SearchCatalogueModel>
    {
        public CoreUserConfirmStatusController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            catalogueService = serviceProvider.GetRequiredService<IUserConfirmStatusService>();
            domainService = catalogueService;
        }
    }
}