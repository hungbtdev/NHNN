using System;
using KTApps.Models;
using KTApps.ShareService.Entities;
using KTApps.ShareService.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Controllers
{
    public abstract class PageTitleCoreController : CatalogueCoreController<CorePageTitles, CorePageTitleModel, SearchCatalogueModel>
    {
        public PageTitleCoreController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            catalogueService = (ICorePageTitleService)serviceProvider.GetRequiredService(typeof(ICorePageTitleService));
            domainService = catalogueService;
        }
    }
}