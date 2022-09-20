using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Utils;

namespace Vinorsoft.Core.App.ViewComponents
{
    [ViewComponent]
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ICoreSystemConfigService systemConfigService;
        private readonly IMapper mapper;
        private readonly ICorePageTitleService corePageTitleService;
        private readonly IOptions<AppSettings> configuration;

        public HeaderViewComponent(
            ICoreSystemConfigService systemConfigService,
            ICorePageTitleService corePageTitleService,
            IOptions<AppSettings> configuration,
            IMapper mapper)
        {
            this.systemConfigService = systemConfigService;
            this.corePageTitleService = corePageTitleService;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string key = $"{ViewContext.RouteData.Values["controller"]}_{ViewContext.RouteData.Values["action"]}";
            HeaderDTO header = new HeaderDTO()
            {
                FaviIcon = $"{configuration.Value.SubDomain}/favicon.ico",
                Title = key
            };
            var pageTitle = corePageTitleService.GetByCode(key);
            if (pageTitle != null)
            {
                header.Title = pageTitle.Name;
            }

            var systemConfigValues = systemConfigService.Get(e => !e.Deleted);
            if (systemConfigValues.Count() > 0)
            {
                var appname = systemConfigValues.FirstOrDefault(e => e.Code == CoreConstants.SysKey_AppName);
                if (appname != null)
                {
                    header.AppName = appname.Value;
                    header.AppDescription = appname.Description;
                }

                var author = systemConfigValues.FirstOrDefault(e => e.Code == CoreConstants.SysKey_Author);
                if (author != null)
                {
                    header.Author = author.Value;
                }

                var favicon = systemConfigValues.FirstOrDefault(e => e.Code == CoreConstants.SysKey_FaviIcon);
                if (favicon != null)
                {
                    header.FaviIcon = favicon.Value;
                }
            }
            return await Task.FromResult((IViewComponentResult)View("_Header", header));
        }
    }
}
