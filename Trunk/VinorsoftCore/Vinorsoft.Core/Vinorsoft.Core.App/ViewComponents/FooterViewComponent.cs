using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Utils;

namespace Vinorsoft.Core.App.ViewComponents
{
    [ViewComponent]
    public class FooterViewComponent : ViewComponent
    {
        private readonly ICoreSystemConfigService systemConfigService;
        private readonly IMapper mapper;
        private readonly IOptions<AppSettings> appSettings;
        private readonly IConfiguration configuration;
        public FooterViewComponent(ICoreSystemConfigService systemConfigService, IMapper mapper, IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            this.systemConfigService = systemConfigService;
            this.mapper = mapper;
            this.appSettings = appSettings;
            this.configuration = configuration;
        }

        public Version GetVersion(string assemblyName)
        {
            // Get all the assemblies currently loaded in the application domain.
            Assembly[] assemblies = Thread.GetDomain().GetAssemblies();

            for (int i = 0; i < assemblies.Length; i++)
            {
                if (string.Compare(assemblies[i].GetName().Name, assemblyName) == 0)
                {
                    return assemblies[i].GetName().Version;
                }
            }

            return Assembly.GetExecutingAssembly().GetName().Version; // return current version assembly or return null;
        }

        public async Task<IViewComponentResult> InvokeAsync(string key)
        {
            var systemConfigValues = systemConfigService.Get(e => !e.Deleted);
            FooterDTO footer = new FooterDTO()
            {
                LogoUrl = $"{appSettings.Value.SubDomain}/css/images/logo.png",
            };
            if (configuration["AppSettings:MainAppDLL"] != null)
                footer.BuildVersion = GetVersion(configuration["AppSettings:MainAppDLL"])?.ToString();

            if (systemConfigValues.Count() > 0)
            {
                var appname = systemConfigValues.FirstOrDefault(e => e.Code == CoreConstants.SysKey_AppName);
                if (appname != null)
                {
                    footer.AppName = appname.Value;
                    footer.AppDescription = appname.Description;
                }

                var footerAddress = systemConfigValues.FirstOrDefault(e => e.Code == CoreConstants.SysKey_Footer_Address);
                if (footerAddress != null)
                {
                    footer.CompanyAddress = footerAddress.Value;
                }

                var logo = systemConfigValues.FirstOrDefault(e => e.Code == CoreConstants.SysKey_LogoUrl);
                if (logo != null)
                {
                    footer.LogoUrl = $"{appSettings.Value.SubDomain}{logo.Value}";
                }

                var copyright = systemConfigValues.FirstOrDefault(e => e.Code == CoreConstants.SysKey_Copyright);
                if (copyright != null)
                {
                    footer.Copyright = copyright.Value;
                }
            }
            return await Task.FromResult((IViewComponentResult)View("_Footer", footer));
        }
    }
}
