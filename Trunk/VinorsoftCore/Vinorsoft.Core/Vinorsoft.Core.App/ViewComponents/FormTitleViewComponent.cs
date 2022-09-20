using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.App.ViewComponents
{
    [ViewComponent]
    public class FormTitleViewComponent : ViewComponent
    {
        private readonly ICorePageTitleService corePageTitleService;
        private readonly IMapper mapper;
        public FormTitleViewComponent(ICorePageTitleService corePageTitleService, IMapper mapper)
        {
            this.corePageTitleService = corePageTitleService;
            this.mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string key = $"{ViewContext.RouteData.Values["controller"]}_{ViewContext.RouteData.Values["action"]}";
            CorePageTitleDTO result = null;
            var pageTitle = corePageTitleService.GetByCode(key);
            if (pageTitle == null)
            {
                result = new CorePageTitleDTO()
                {
                    Name = $"{key} {Resources.NotFound}"
                };
            }
            else
            {
                result = mapper.Map<CorePageTitleDTO>(pageTitle);
            }
            return await Task.FromResult((IViewComponentResult)View("_FormTitle", result));
        }
    }
}
