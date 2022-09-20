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
    [Description("Quản lý Module")]
    [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
    public class ModuleController : VinorsoftCatalogueCoreController<CoreModuleDTO, CoreModules>
    {
        public ModuleController(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider, mapper)
        {
            coreService = serviceProvider.GetRequiredService<ICoreModuleService>();
        }

        [HttpGet]
        public override IActionResult Index()
        {
            return View();
        }
    }
}