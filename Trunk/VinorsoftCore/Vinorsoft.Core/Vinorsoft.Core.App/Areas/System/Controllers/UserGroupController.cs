using System;
using System.ComponentModel;
using System.Linq;
using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Vinorsoft.Core.App.Context;
using Vinorsoft.Core.App.Controllers;
using Vinorsoft.Core.App.Extensions;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.App.Areas.System.Controllers
{
    [Area("System")]
    [Description("Quản lý nhóm người dùng")]
    public class UserGroupController : VinorsoftCatalogueCoreController<UserGroupDTO, UserGroups>
    {
        readonly IUserService userService;
        readonly IUserGroupService userGroupService;
        readonly IPermitObjectService permitObjectService;
        readonly IPermissionService permissionService;
        readonly IPermitObjectPermissionService permitObjectPermissionService;
        public UserGroupController(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider, mapper)
        {
            coreService = serviceProvider.GetRequiredService<IUserGroupService>();
            userService = serviceProvider.GetRequiredService<IUserService>();
            userGroupService = serviceProvider.GetRequiredService<IUserGroupService>();
            permitObjectService = serviceProvider.GetRequiredService<IPermitObjectService>();
            permissionService = serviceProvider.GetRequiredService<IPermissionService>();
            permitObjectPermissionService = serviceProvider.GetRequiredService<IPermitObjectPermissionService>();
        }

        [HttpGet]
        public override IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewUserGroup()
        {
            return View(new UserGroupDTO()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                CreatedBy = LoginContext.Instance.CurrentUser.UserName
            });
        }

        [HttpPost]
        public IActionResult NewUserGroup(UserGroupDTO userGroup)
        {
            try
            {
                if (!TryValidateModel(userGroup))
                {
                    SetError(ModelState.GetFullErrorMessage());
                    return View(userGroup);
                }
                bool exist = userGroupService.Any(userGroup.Id);
                if (!exist)
                {
                    userGroup.ToValue();
                    int result = userGroupService.Insert(mapper.Map<UserGroups>(userGroup));
                    if (result > 0)
                        return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return View(new UserGroupDTO());
        }

        [HttpGet]
        public IActionResult UpdateUserGroup(Guid id)
        {
            var userGroup = userGroupService.Queryable.Where(e => e.Id == id)
                .Select(e => new UserGroupDTO()
                {
                    Id = e.Id,
                    Active = e.Active,
                    Code = e.Code,
                    Created = e.Created,
                    CreatedBy = e.CreatedBy,
                    Deleted = e.Deleted,
                    Description = e.Description,
                    Name = e.Name,
                    Updated = DateTime.Now,
                    UpdatedBy = LoginContext.Instance.CurrentUser.UserName
                }).FirstOrDefault();

            return View(userGroup);
        }

        [HttpPost]
        public IActionResult UpdateUserGroup(UserGroupDTO userGroup)
        {
            try
            {
                if (!TryValidateModel(userGroup))
                {
                    SetError(ModelState.GetFullErrorMessage());
                    return View(userGroup);
                }
                bool exist = userGroupService.Any(userGroup.Id);
                if (exist)
                {
                    userGroup.ToValue();
                    int result = userGroupService.Update(mapper.Map<UserGroups>(userGroup));
                    if (result > 0)
                        return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception( string.Format(CoreErrorResource.ERROR_NOT_FOUND, userGroup.Id));
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return View(userGroup);
        }

        [HttpGet]
        public object GetUserGroupPermit(DataSourceLoadOptions loadOptions, Guid groupId)
        {
            var query = permitObjectPermissionService.Queryable.Where(e => e.GroupId == groupId && !e.Permissions.Deleted && !e.PermitObjects.Deleted).Select(e => new PermitObjectPermissionDTO()
            {
                Id = e.Id,
                Permissions = new PermissionDTO()
                {
                    Id = e.Permissions.Id,
                    Name = e.Permissions.Name
                },
                PermitObjects = new PermitObjectDTO()
                {
                    Id = e.PermitObjects.Id,
                    Name = e.PermitObjects.Name
                }
            }).Distinct();
            return DataSourceLoader.Load(query, loadOptions);
        }

        [HttpGet]
        public virtual object GetPermit(DataSourceLoadOptions loadOptions, Guid userGroupId)
        {
            //var hasPermitItems = permitObjectPermissionService.Queryable.Where(e => e.GroupId == userGroupId)
            //    .ToList();
            //var query = permitObjectService.Queryable.Select(e => new PermitObjectTreeNodeDTO()
            //{
            //    Id = e.Id,
            //    Name = e.Name,
            //    Type = TreeNodeType.PermitObject,
            //    Items = permissionService.Queryable.Select(s => new PermitObjectTreeNodeDTO()
            //    {
            //        Id = s.Id,
            //        Name = s.Name,
            //        Type = TreeNodeType.Permission,
            //        Checked = hasPermitItems.Any(x => x.PermissionId == s.Id && e.Id == x.PermitObjectId)
            //    })
            //});
            var query = permitObjectService.BuildTreeNode(userGroupId);
            return DataSourceLoader.Load(query, loadOptions);
        }
    }
}