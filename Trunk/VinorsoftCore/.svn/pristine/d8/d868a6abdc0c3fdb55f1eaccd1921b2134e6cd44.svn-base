using System;
using System.Linq;
using System.Linq.Expressions;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Core.App.Attribute;
using KTApps.Core.App.Context;
using KTApps.Core.App.Models;
using KTApps.Domain;
using KTApps.ShareService.Entities;
using KTApps.ShareService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Controllers
{
    [Authorize]
    public class NavCoreController : KTAppCore2Controller<CoreSlidebarItems, CoreSlidebarItemModel, SearchSlidebarModel>
    {
        readonly ICoreModuleService coreModuleService;
        readonly ICoreSlidebarItemService coreSlidebarItemService;
        readonly IPermitObjectPermissionService permitObjectPermissionService;

        public NavCoreController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            domainService = serviceProvider.GetRequiredService<ICoreSlidebarItemService>();
            coreModuleService = serviceProvider.GetRequiredService<ICoreModuleService>();
            coreSlidebarItemService = serviceProvider.GetRequiredService<ICoreSlidebarItemService>();
            permitObjectPermissionService = serviceProvider.GetRequiredService<IPermitObjectPermissionService>();
        }

        [KTAppAuthorize2(permission: new string[] { CoreConstants.Delete })]
        [HttpPost]
        public override ActionResult<KTAppDomainResult> Delete([FromBody] CoreSlidebarItemModel item)
        {
            return base.Delete(item);
        }

        [KTAppAuthorize2(permission: new string[] { CoreConstants.View })]
        [HttpGet]
        public override IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        public override IActionResult NewItem()
        {
            return View();
        }

        [HttpGet]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit })]
        public override IActionResult UpdateItem(Guid id)
        {
            return View();
        }

        [KTAppAuthorize2(permission: new string[] { CoreConstants.View })]
        [HttpGet]
        public override ActionResult<KTAppDomainResult> InitDropdown()
        {
            KTAppDomainResult appDomainResult = new KTAppDomainResult();
            try
            {
                var modules = coreModuleService.Get(e => !e.Deleted)
                   .Select(e => new
                   {
                       Id = e.Id.ToString(),
                       e.Name,
                       e.Position,
                   }).OrderBy(e => e.Name)
                   .ToList();
                
                var slideBarItems = domainService.Get(e => !e.Deleted)
                  .Select(e => new
                  {
                      Id = e.Id.ToString(),
                      Name = e.Name + "(" + e.Code + ")",
                      Position = e.Position ?? 1000,
                  }).OrderBy(e => e.Position).ToList();

                slideBarItems.Insert(0, new
                {
                    Id = string.Empty,
                    Name = "-- Vui lòng chọn-- ",
                    Position = 0,
                });

                appDomainResult.Data = new
                {
                    Modules = modules.OrderBy(e => e.Position),
                    SlideBarItems = slideBarItems.OrderBy(e => e.Position),
                };
                appDomainResult.Success = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
            }
            return appDomainResult;
        }

        [HttpGet]
        [AllowAnonymous]
        public virtual ActionResult<KTAppDomainResult> GetNavigations()
        {
            KTAppDomainResult appDomainResult = new KTAppDomainResult();
            try
            {
                Guid userId = LoginContext.Instance.CurrentUser.UserId;
                var permitObjects = permitObjectPermissionService.Get(e => !e.Deleted && e.UserGroups.UserInGroups.Any(u => u.UserId == userId), e => new PermitObjectPermissions()
                {
                    PermitObjects = new PermitObjects()
                    {
                        PermitObjectSidebars = e.PermitObjects.PermitObjectSidebars
                    }
                })
                .ToList();

                var coreSlidebarItems = coreSlidebarItemService.Get(e => !e.Deleted && e.ModuleId.HasValue)
                    .ToList()
                    .Where(e => permitObjects.Any(s => s.PermitObjects.PermitObjectSidebars.Any(p => p.SidebarMenuIds.Split(";").Contains(e.Id.ToString()))));

                var refererUrl = Request.Headers["Referer"].ToString();
                var items = coreModuleService.Get(e => !e.Deleted, e => new CoreModules()
                {
                    Id = e.Id,
                    Code = e.Code,
                    Name = e.Name,
                    Position = e.Position,
                    CoreSlidebarItems = coreSlidebarItems.Where(s => s.ModuleId == e.Id).OrderBy(s => s.Position).ThenBy(s => s.Name).ToList()
                }).Where(e => e.CoreSlidebarItems.Count > 0).Select(e => new CoreModuleModel()
                {
                    Id = e.Id,
                    Code = e.Code,
                    Name = e.Name,
                    Position = e.Position,
                    CoreSlidebarItems = e.CoreSlidebarItems.OrderBy(s => s.Position).ThenBy(s => s.Name).Select(s => new CoreSlidebarItemModel()
                    {
                        ModuleId = s.ModuleId,
                        Id = s.Id,
                        Code = s.Code,
                        Name = s.Name,
                        Icon = s.Icon,
                        ParentId = s.ParentId,
                        Position = s.Position,
                        Url = s.Url,
                        ActiveLink = refererUrl.Contains(s.Url) || e.CoreSlidebarItems.Any(c => refererUrl.Contains(c.Url) && s.Id == c.ParentId)
                    }).OrderBy(s => s.Position).ThenBy(s => s.Name).ToList()
                }).OrderBy(e => e.Position).ThenBy(e => e.Name).ToList();

                appDomainResult.Data = items;
                appDomainResult.Success = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
            }
            return appDomainResult;
        }

        protected override Expression<Func<CoreSlidebarItems, CoreSlidebarItems>> BuildSelectQuery()
        {
            return e => new CoreSlidebarItems()
            {
                CoreModules = e.CoreModules,
                Id = e.Id,
                Code = e.Code,
                Name = e.Name,
                Description = e.Description,
                Position = e.Position,
                Url = e.Url
            };
        }
    }
}