using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.App.ViewComponents
{
    [ViewComponent]
    public class TopMenuViewComponent : ViewComponent
    {
        private readonly ICoreModuleService coreModuleService;
        private readonly ICoreSlidebarItemService coreSlidebarItemService;
        public TopMenuViewComponent(ICoreModuleService coreModuleService,
            ICoreSlidebarItemService coreSlidebarItemService)
        {
            this.coreModuleService = coreModuleService;
            this.coreSlidebarItemService = coreSlidebarItemService;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("_TopMenu"));
        }
    }
}
