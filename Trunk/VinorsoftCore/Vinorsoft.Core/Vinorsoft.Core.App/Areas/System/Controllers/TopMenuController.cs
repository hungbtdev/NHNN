using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.Core.App.Context;
using Vinorsoft.Core.App.Controllers;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Utils;

namespace Vinorsoft.Core.App.Areas.System.Controllers
{
    [Area("System")]
    [Description("Quản lý menu")]
    public class TopMenuController : VinorsoftCoreController<CoreSlidebarItemDTO, CoreSlidebarItems>
    {
        protected readonly ICoreModuleService coreModuleService;
        protected readonly IPermitObjectPermissionService permitObjectPermissionService;
        private readonly IOptions<AppSettings> configuration;
        public TopMenuController(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider, mapper)
        {
            coreService = serviceProvider.GetRequiredService<ICoreSlidebarItemService>();
            coreModuleService = serviceProvider.GetRequiredService<ICoreModuleService>();
            permitObjectPermissionService = serviceProvider.GetRequiredService<IPermitObjectPermissionService>();
            configuration = serviceProvider.GetRequiredService<IOptions<AppSettings>>();
        }

        [VinorsoftAuthorize2(allowAnonymous: true)]
        public IActionResult MenuRender()
        {
            return View();
        }

        [HttpGet]
        [VinorsoftAuthorize2(allowAnonymous: true)]
        [Authorize]
        public ActionResult GetMenus(DataSourceLoadOptions loadOptions)
        {
            var userId = LoginContext.Instance.CurrentUser.UserId;
            var modules = coreModuleService.Queryable.OrderBy(e => e.Position).ToList();
            var slidebarItems = coreService.Queryable.OrderBy(e => e.Position).ToList();
            var subDomain = configuration.Value.SubDomain;
            //Tìm menu trong danh sách chức năng được phân quyền 
            var permitItems = permitObjectPermissionService.Queryable.Where(e => e.Permissions.Code == CoreConstants.View && (e.UserId == userId || (e.GroupId.HasValue && e.UserGroups.UserInGroups.Any(g => g.UserId == userId)))).SelectMany(s => s.PermitObjects.PermitObjectSidebars.Select(p => p.SidebarMenuIds));
            List<Guid> sidebarMenuIds = new List<Guid>();
            foreach (var item in permitItems)
            {
                var splits = item.Split(new char[] { ',', ';' });
                foreach (var splitItem in splits)
                {
                    if (Guid.TryParse(splitItem, out Guid id))
                    {
                        sidebarMenuIds.Add(id);
                    }
                }
            }
            slidebarItems = slidebarItems.Where(e => sidebarMenuIds.Contains(e.Id)).ToList();

            IEnumerable<MenuItemDTO> menus = modules.Select(e => new MenuItemDTO()
            {
                Text = e.Name.ToUpper(),
                Level = 0,
                Items = slidebarItems.Where(s => s.ModuleId == e.Id && !s.ParentId.HasValue).Select(s => new MenuItemDTO()
                {
                    Level = 1,
                    Text = s.Name.ToUpper(),
                    Icon = s.Icon,
                    Url = $"{subDomain}{s.Url}",
                    Items = slidebarItems.Where(child => child.ModuleId == e.Id && child.ParentId.HasValue && child.ParentId == s.Id).Select(child => new MenuItemDTO()
                    {
                        Level = 2,
                        Url = $"{subDomain}{child.Url}",
                        Text = child.Name.ToUpper(),
                        Icon = child.Icon
                    })
                })
            }).Where(e => e.Items.Count() > 0);
            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(menus, loadOptions), new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), "application/json");
        }

    }
}