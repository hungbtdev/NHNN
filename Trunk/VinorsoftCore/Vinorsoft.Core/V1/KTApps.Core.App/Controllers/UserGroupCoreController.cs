using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Core.App.Attribute;
using KTApps.Domain;
using KTApps.Models;
using KTApps.Models.Import;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace KTApps.Core.App.Controllers
{
    [KTAppAuthorize2(permission: new string[] { CoreConstants.View })]
    public abstract class UserGroupCoreController : CatalogueCoreController<UserGroups, UserGroupModel, SearchCatalogueModel>
    {
        readonly IPermitObjectService permitObjectService;
        readonly IPermissionService permissionService;
        readonly IPermitObjectPermissionService permitObjectPermissionService;
        public UserGroupCoreController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            catalogueService = serviceProvider.GetRequiredService<IUserGroupService>();
            permitObjectPermissionService = serviceProvider.GetRequiredService<IPermitObjectPermissionService>();
            permissionService = serviceProvider.GetRequiredService<IPermissionService>();
            permitObjectService = serviceProvider.GetRequiredService<IPermitObjectService>();
            domainService = catalogueService;
        }


        [HttpGet]
        public override IActionResult Index()
        {
            return base.Index();
        }

        [KTAppAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        public override IActionResult NewItem()
        {
            return View();
        }

        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit })]
        public override IActionResult UpdateItem(Guid id)
        {
            return View();
        }

        [KTAppAuthorize2(permission: new string[] { CoreConstants.Delete })]
        [HttpPost]
        [ActionName("Delete")]
        public override ActionResult<KTAppDomainResult> Delete([FromBody]UserGroupModel item)
        {
            return base.Delete(item);
        }

        [HttpGet]
        [ActionName("GetById")]
        public override ActionResult<KTAppDomainResult> GetById([FromQuery] Guid? id)
        {
            KTAppDomainResult domainResult = new KTAppDomainResult();
            try
            {
                UserGroupModel item = null;
                if (id.HasValue)
                {
                    var doc = catalogueService.GetById(id.Value, e => new UserGroups()
                    {
                        Active = e.Active,
                        Code = e.Code,
                        Created = e.Created,
                        CreatedBy = e.CreatedBy,
                        Description = e.Description,
                        Id = e.Id,
                        Name = e.Name,
                        PermitObjectPermissions = e.PermitObjectPermissions,
                        UserInGroups = e.UserInGroups.Select(s => new UserInGroups()
                        {
                            Id = s.Id,
                            UserId = s.UserId,
                            GroupId = s.GroupId,
                            Users = new Users()
                            {
                                Id = s.Users.Id,
                                Username = s.Users.Username,
                                FirstName = s.Users.FirstName,
                                LastName = s.Users.LastName,
                            }
                        }).ToList(),
                    });
                    if (doc != null)
                    {
                        item = mapper.Map<UserGroupModel>(doc);
                        item.ToView();
                    }
                }
                domainResult.Data = item;
                domainResult.Success = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                domainResult.Success = true;
                domainResult.Messages.Add(ex.Message);
            }
            return domainResult;
        }

        [HttpPost]
        [ActionName("Save")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit, CoreConstants.AddNew })]
        public override ActionResult<KTAppDomainResult> Save([FromBody]UserGroupModel item)
        {
            item.ToModel();
            return base.Save(item);
        }

        [HttpGet]
        [ActionName("InitDropdown")]
        public override ActionResult<KTAppDomainResult> InitDropdown()
        {
            return new KTAppDomainResult()
            {
                Data = new
                {
                    PermitObjects = permitObjectService.Get(e => !e.Deleted),
                    Permissions = permissionService.Get(e => !e.Deleted),
                },
                Success = true
            };
        }
    }
}
