using System;
using System.ComponentModel;
using System.Linq;
using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.Core.App.Context;
using Vinorsoft.Core.App.Controllers;
using Vinorsoft.Core.App.Extensions;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.App.Areas.System.Controllers
{
    [Area("System")]
    [Description("Quản lý người dùng")]
    [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
    public class UserController : VinorsoftCoreController<UserDTO, Users>
    {
        readonly IUserService userService;
        readonly IUserGroupService userGroupService;
        public UserController(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider, mapper)
        {
            coreService = serviceProvider.GetRequiredService<IUserService>();
            userService = serviceProvider.GetRequiredService<IUserService>();
            userGroupService = serviceProvider.GetRequiredService<IUserGroupService>();
        }

        public override IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual object GetUserGroup(DataSourceLoadOptions loadOptions)
        {
            loadOptions.DefaultSort = "Name";
            var query = userGroupService.Queryable.ToList();
            return DataSourceLoader.Load(query, loadOptions);
        }

        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        public IActionResult NewUser()
        {
            return View(new NewUserDTO()
            {
                Id = Guid.NewGuid(),
                CreatedBy = LoginContext.Instance.CurrentUser.UserName,
                Created = DateTime.Now
            });
        }

        [HttpPost]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        public IActionResult NewUser(NewUserDTO newUser)
        {
            try
            {
                if (!TryValidateModel(newUser))
                {
                    SetError(ModelState.GetFullErrorMessage());
                    return View(newUser);
                }

                if (!userService.VerifyEmail(newUser.Email, newUser.Id))
                {
                    throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, newUser.Email));
                }

                if (!userService.VerifyPhone(newUser.Phone, newUser.Id))
                {
                    throw new Exception( string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, newUser.Phone));
                }

                if (!userService.VerifyUserName(newUser.Username, newUser.Id))
                {
                    throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, newUser.Username));
                }

                bool exist = userService.Any(newUser.Id);
                if (!exist)
                {
                    newUser.ToValue();
                    int result = userService.Insert(mapper.Map<Users>(newUser));
                    if (result > 0)
                        return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, newUser.Id));
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return View(newUser);
        }

        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.Edit })]
        public IActionResult UpdateUser(Guid id)
        {
            var user = userService.Queryable.Where(e => e.Id == id)
              .Select(e => new UpdateUserDTO()
              {
                  Id = e.Id,
                  Active = e.Active,
                  Created = e.Created,
                  CreatedBy = e.CreatedBy,
                  Deleted = e.Deleted,
                  FirstName = e.FirstName,
                  LastName = e.LastName,
                  Email = e.Email,
                  FailedCount = e.FailedCount,
                  Locked = e.Locked,
                  LockedEnd = e.LockedEnd,
                  Phone = e.Phone,
                  UserGroupIds = e.UserInGroups.Where(s => !s.Deleted).Select(s => s.GroupId).ToList(),
                  Username = e.Username,
                  Updated = DateTime.Now,
                  UpdatedBy = LoginContext.Instance.CurrentUser.UserName
              }).FirstOrDefault();

            return View(user);
        }

        [HttpPost]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.Edit })]
        public IActionResult UpdateUser(UpdateUserDTO updateUser)
        {
            try
            {
                if (!TryValidateModel(updateUser))
                {
                    SetError(ModelState.GetFullErrorMessage());
                    return View(updateUser);
                }

                if (!userService.VerifyEmail(updateUser.Email, updateUser.Id))
                {
                    throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, updateUser.Email));
                }

                if (!userService.VerifyPhone(updateUser.Phone, updateUser.Id))
                {
                    throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, updateUser.Phone));
                }

                if (!userService.VerifyUserName(updateUser.Username, updateUser.Id))
                {
                    throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, updateUser.Username));
                }

                bool exist = userService.Any(updateUser.Id);
                if (exist)
                {
                    updateUser.ToValue();
                    int result = userService.Update(mapper.Map<Users>(updateUser));
                    if (result > 0)
                        return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, updateUser.Id));
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return View(updateUser);
        }

        [HttpGet]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.Edit })]
        public IActionResult ResetPassword(Guid id)
        {
            return View(new ResetPasswordDTO()
            {
                Id = id
            });
        }

        [HttpPost]
        [VinorsoftAuthorize2(permission: new string[] { CoreConstants.Edit })]
        public IActionResult ResetPassword(ResetPasswordDTO resetPassword)
        {
            try
            {
                if (!TryValidateModel(resetPassword))
                {
                    SetError(ModelState.GetFullErrorMessage());
                    return View(resetPassword);
                }

                resetPassword.ToValue();

                bool exist = userService.Any(resetPassword.Id);
                if (exist)
                {
                    int result = userService.ResetPassword(resetPassword.Id, resetPassword.NewPassword);
                    if (result > 0)
                        return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, resetPassword.Id));
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return View(resetPassword);
        }

    }
}