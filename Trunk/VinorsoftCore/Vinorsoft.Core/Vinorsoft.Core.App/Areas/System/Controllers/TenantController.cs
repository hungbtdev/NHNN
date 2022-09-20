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
    [Description("Tenant")]
    [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
    public class TenantController : VinorsoftCoreController<TenantDTO, Tenants>
    {
        public TenantController(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider, mapper)
        {
            coreService = serviceProvider.GetRequiredService<ITenantService>();
        }

        public override IActionResult Index()
        {
            return View();
        }
    }
}