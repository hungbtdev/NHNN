using System;
using System.ComponentModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.Core.App.Controllers;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.App.Areas.System.Controllers
{
    [Area("System")]
    [Description("Tham số hệ thống")]
    [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
    public class SystemConfigController : VinorsoftCatalogueCoreController<CoreSystemConfigDTO, CoreSystemConfigs>
    {
        public SystemConfigController(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider, mapper)
        {
            coreService = serviceProvider.GetRequiredService<ICoreSystemConfigService>();
        }

        [HttpGet]
        public override IActionResult Index()
        {
            return View();
        }
    }
}