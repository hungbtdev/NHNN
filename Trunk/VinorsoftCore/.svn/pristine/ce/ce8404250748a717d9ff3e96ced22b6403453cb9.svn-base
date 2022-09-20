using System;
using System.ComponentModel;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.Core.App.Controllers;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.App.Areas.System.Controllers
{
    [Area("System")]
    [Description("Quản lý Tiêu đề trang")]
    [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
    public class PageTitleController : VinorsoftCatalogueCoreController<CorePageTitleDTO, CorePageTitles>
    {
        public PageTitleController(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider, mapper)
        {
            coreService = serviceProvider.GetRequiredService<ICorePageTitleService>();
        }

        [HttpGet]
        [AllowAnonymous]
        [VinorsoftAuthorize2(allowAnonymous:true)]
        public IActionResult FormTitle(string key)
        {
            var pageTitle = coreService.Get(e=>e.Code == key).FirstOrDefault();
            if (pageTitle == null)
            {
                pageTitle = new CorePageTitles()
                {
                    Name = $"{key} {Resources.NotFound}"
                };
            }
            return PartialView("_FormTitle", pageTitle);
        }
    }
}