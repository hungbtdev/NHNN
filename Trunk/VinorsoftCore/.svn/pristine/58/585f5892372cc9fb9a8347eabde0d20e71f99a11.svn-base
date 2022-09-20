using System;
using System.Security.Claims;
using System.Threading.Tasks;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Domain;
using KTApps.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using KTApps.Core.App.Attribute;
using KTApps.Core.App.Context;
using KTApps.Core.App.Models;
using System.Linq.Expressions;
using System.Linq;
using KTApps.Core.Utils;
using KTApps.Core.NotificationService.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace KTApps.Core.App.Controllers
{
    [Authorize]
    public abstract class AuthCoreController : KTAppCore2Controller<Users, UserModel, SearchUserModel>
    {
        protected readonly IDepartmentService departmentService;
        protected readonly IJobTitleService jobTitleService;
        protected readonly IUserGroupService userGroupService;
        protected readonly IUserInGroupService userInGroupService;
        protected readonly IUserStatusService userStatusService;
        protected readonly IUserConfirmCodeService userConfirmCodeService;
        protected readonly ICoreSMSPendingService coreSMSPendingService;

        public AuthCoreController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            userInGroupService = serviceProvider.GetRequiredService<IUserInGroupService>();
            departmentService = serviceProvider.GetRequiredService<IDepartmentService>();
            jobTitleService = serviceProvider.GetRequiredService<IJobTitleService>();
            userGroupService = serviceProvider.GetRequiredService<IUserGroupService>();
            userStatusService = serviceProvider.GetRequiredService<IUserStatusService>();
            coreSMSPendingService = serviceProvider.GetRequiredService<ICoreSMSPendingService>();
            userConfirmCodeService = serviceProvider.GetRequiredService<IUserConfirmCodeService>();
            domainService = serviceProvider.GetRequiredService<IUserService>();
        }

        [AllowAnonymous]
        [HttpGet]
        public virtual IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        public override IActionResult NewItem()
        {
            return View("NewUser");
        }

        [HttpGet]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.AddNew })]
        public virtual IActionResult NewUser()
        {
            return View();
        }

        [HttpGet]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit })]
        public virtual IActionResult UpdateUser()
        {
            return View();
        }

        [HttpGet]
        public virtual IActionResult ChangePassword()
        {
            return View();
        }

        [HttpGet]
        public virtual IActionResult UpdateProfile(Guid? id)
        {
            return View();
        }

        [HttpPost]
        [ActionName("Save")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit, CoreConstants.AddNew })]
        public override ActionResult<KTAppDomainResult> Save([FromBody] UserModel user)
        {
            KTAppDomainResult appDomainResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {
                    var exists = userService.Get(e => e.Id == user.Id).FirstOrDefault();
                    if ((exists == null || user.IsResetPassword) && !string.IsNullOrEmpty(user.Password))
                    {
                        user.Password = SecurityUtils.HashSHA1(user.Password);
                    }
                    Users userToSave = mapper.Map<Users>(user);

                    appDomainResult.Success = userService.Save(userToSave);
                }
            }
            catch (KTAppException ex)
            {
                logger.LogError(default(EventId), ex, ex.Message);
                appDomainResult.Messages.Add(ex.Message);
            }

            return appDomainResult;
        }

        [HttpGet]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.View })]
        [ActionName("GetData")]
        public virtual ActionResult<KTAppDomainResult> GetData([FromQuery] string query)
        {
            KTAppDomainResult appDomainResult = new KTAppDomainResult();
            try
            {
                query = query.ToLower();
                Expression<Func<Users, bool>> condition = e =>
           e.Username.ToLower().Contains(query);

                Expression<Func<Users, Users>> select = e => new Users()
                {
                    Id = e.Id,
                    Username = e.Username,
                };
                var users = userService.Get(condition, select, 1, 20, "Username");
                appDomainResult.Success = true;
                appDomainResult.Data = users.Items;
            }
            catch (KTAppException ex)
            {
                logger.LogError(default(EventId), ex, ex.Message);
                appDomainResult.Messages.Add(ex.Message);
            }

            return appDomainResult;
        }

        [HttpGet]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.View })]
        [ActionName("GetById")]
        public override ActionResult<KTAppDomainResult> GetById([FromQuery]Guid? id)
        {
            KTAppDomainResult appDomainResult = new KTAppDomainResult();
            try
            {
                Expression<Func<Users, Users>> select = e => new Users()
                {
                    Id = e.Id,
                    Active = e.Active,
                    Created = e.Created,
                    CreatedBy = e.CreatedBy,
                    Deleted = e.Deleted,
                    FailedCount = e.FailedCount,
                    Locked = e.Locked,
                    LockedEnd = e.LockedEnd,
                    Password = e.Password,
                    UserDepartments = e.UserDepartments,
                    Email = e.Email,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Phone = e.Phone,
                    StatusId = e.StatusId,
                    UserGroupIds = e.UserInGroups.Select(x => x.GroupId.ToString().ToLower()).ToList(),
                    UserInGroups = e.UserInGroups.Where(g => !g.Deleted).Select(g => new UserInGroups()
                    {
                        Id = g.Id,
                        Active = g.Active,
                        Created = g.Created,
                        CreatedBy = g.CreatedBy,
                        Deleted = g.Deleted,
                        UserId = g.UserId,
                        GroupId = g.GroupId,
                        UserGroups = g.UserGroups,
                    }).ToList(),
                    Username = e.Username,
                };
                var users = userService.Get(e => !e.Deleted && e.Id == id, select).FirstOrDefault();
                appDomainResult.Data = users;
                appDomainResult.Success = true;
            }
            catch (KTAppException ex)
            {
                logger.LogError(default(EventId), ex, ex.Message);
                appDomainResult.Messages.Add(ex.Message);
                appDomainResult.Success = false;
            }

            return appDomainResult;
        }

        [HttpPost]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.View })]
        [ActionName("GetData")]
        public override ActionResult<KTAppDomainResult> GetData([FromBody] SearchUserModel searchUser)
        {
            KTAppDomainResult appDomainResult = new KTAppDomainResult();
            try
            {
                Expression<Func<Users, bool>> condition = e => !e.Deleted &&
                (string.IsNullOrEmpty(searchUser.SearchContent)
                || e.Username.ToLower().Trim().Contains(searchUser.SearchContent.ToLower().Trim())
                || e.FirstName.ToLower().Trim().Contains(searchUser.SearchContent.ToLower().Trim())
                || e.LastName.ToLower().Trim().Contains(searchUser.SearchContent.ToLower().Trim())
                || e.Email.ToLower().Trim().Contains(searchUser.SearchContent.ToLower().Trim())
                || e.Phone.ToLower().Trim().Contains(searchUser.SearchContent.ToLower().Trim())
                );
                Expression<Func<Users, Users>> select = e => new Users()
                {
                    Id = e.Id,
                    Active = e.Active,
                    Created = e.Created,
                    CreatedBy = e.CreatedBy,
                    Deleted = e.Deleted,
                    FailedCount = e.FailedCount,
                    Locked = e.Locked,
                    LockedEnd = e.LockedEnd,
                    Password = string.Empty,
                    UserDepartments = e.UserDepartments,
                    Username = e.Username,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    Phone = e.Phone
                };
                appDomainResult.Data = userService.Get(condition, select, searchUser.PageIndex, searchUser.PageSize, searchUser.OrderBy);
                appDomainResult.Success = true;
            }
            catch (KTAppException ex)
            {
                logger.LogError(default(EventId), ex, ex.Message);
                appDomainResult.Messages.Add(ex.StackTrace);
            }

            return appDomainResult;
        }

        [HttpPost]
        [ActionName("ChangePassword")]
        public virtual async Task<ActionResult<KTAppDomainResult>> ChangePasswordAsync([FromBody]ChangePasswordModel model)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                model.UserName = LoginContext.Instance.CurrentUser.UserName;
                if (ModelState.IsValid)
                {
                    if (model.ConfirmPassword != model.NewPassword)
                    {
                        appResult.Messages.Add("Xác nhận mật khẩu không chính xác");
                        return appResult;
                    }
                    //string username = LoginContext.Instance.CurrentUser.UserName;
                    appResult.Success = userService.ChangePassword(model.UserName, model.Password, model.NewPassword, model.ConfirmPassword);
                    await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync(HttpContext);
                }
                else
                {
                    appResult.Messages = GetModelStateError();
                }
            }
            catch (KTAppException ex)
            {
                appResult.Messages.Add(ex.Message);
                logger.LogError(default(EventId), ex, ex.Message);
            }

            return appResult;
        }

        [HttpPost]
        [ActionName("UpdateProfile")]
        public virtual ActionResult<KTAppDomainResult> UpdateProfile([FromBody]UserModel model)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {
                    var user = mapper.Map<Users>(model);
                    appResult.Success = userService.UpdateProfileUser(user);
                }
                else
                {
                    appResult.Messages = GetModelStateError();
                }
            }
            catch (KTAppException ex)
            {
                appResult.Messages.Add(ex.Message);
                logger.LogError(default(EventId), ex, ex.Message);
            }

            return appResult;
        }

        [HttpGet]
        [ActionName("GetProfileInfo")]
        public virtual ActionResult<KTAppDomainResult> GetProfileInfo()
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                var currentUserId = LoginContext.Instance.CurrentUser.UserId;

                Expression<Func<Users, Users>> select = e => new Users()
                {
                    Id = e.Id,
                    Active = e.Active,
                    Created = e.Created,
                    CreatedBy = e.CreatedBy,
                    Deleted = e.Deleted,
                    FailedCount = e.FailedCount,
                    Locked = e.Locked,
                    LockedEnd = e.LockedEnd,
                    Password = e.Password,
                    UserDepartments = e.UserDepartments,
                    Email = e.Email,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Phone = e.Phone,
                    Username = e.Username,
                    //UserGroupIds = e.UserInGroups.Select(x => x.Id.ToString()).ToList(),
                    //UserInGroups = e.UserInGroups.Select(g => new UserInGroups()
                    //{
                    //    Id = g.Id,
                    //    Active = g.Active,
                    //    Created = g.Created,
                    //    CreatedBy = g.CreatedBy,
                    //    Deleted = g.Deleted,
                    //    UserId = g.UserId,
                    //    GroupId = g.GroupId,
                    //    UserGroups = g.UserGroups,
                    //}).ToList(),
                };
                var users = userService.Get(e => !e.Deleted && e.Id == currentUserId, select).FirstOrDefault();
                var userModel = mapper.Map<UserModel>(users);
                if (userModel.UserDepartments.Any())
                {
                    Expression<Func<Departments, Departments>> selectDepartment = e => new Departments()
                    {
                        Id = e.Id,
                        Name = e.Name
                    };

                    Expression<Func<JobTitles, JobTitles>> selectJobTitle = e => new JobTitles()
                    {
                        Id = e.Id,
                        Name = e.Name
                    };

                    foreach (var userDepartment in userModel.UserDepartments)
                    {
                        var department = departmentService.GetById(userDepartment.DepartmentId, selectDepartment);
                        if (department != null)
                            userDepartment.DepartmentName = department.Name;
                        else
                            userDepartment.DepartmentName = string.Empty;
                        //Chi nhánh cấp 2
                        if (userDepartment.Department2Id.HasValue)
                        {
                            var department2 = departmentService.GetById(userDepartment.Department2Id.Value, selectDepartment);
                            if (department2 != null)
                                userDepartment.Department2Name = department2.Name;
                            else
                                userDepartment.Department2Name = string.Empty;
                        }
                        //Chi nhánh cấp 3
                        if (userDepartment.Department3Id.HasValue)
                        {
                            var department3 = departmentService.GetById(userDepartment.Department3Id.Value, selectDepartment);
                            if (department3 != null)
                                userDepartment.Department3Name = department3.Name;
                            else
                                userDepartment.Department3Name = string.Empty;
                        }
                        //Chi nhánh cấp 4
                        if (userDepartment.Department4Id.HasValue)
                        {
                            var department4 = departmentService.GetById(userDepartment.Department4Id.Value, selectDepartment);
                            if (department4 != null)
                                userDepartment.Department4Name = department4.Name;
                            else
                                userDepartment.Department4Name = string.Empty;
                        }
                        //Chi nhánh cấp 5
                        if (userDepartment.Department5Id.HasValue)
                        {
                            var department5 = departmentService.GetById(userDepartment.Department5Id.Value, selectDepartment);
                            if (department5 != null)
                                userDepartment.Department5Name = department5.Name;
                            else
                                userDepartment.Department5Name = string.Empty;
                        }

                        //Lấy ra thông tin chức danh
                        var jobTitle = jobTitleService.GetById(userDepartment.JobTitleId, selectJobTitle);
                        if (jobTitle != null)
                            userDepartment.JobTitleName = jobTitle.Name;
                    }
                }
                appResult.Data = userModel;
                appResult.Success = true;
            }
            catch (KTAppException ex)
            {
                appResult.Messages.Add(ex.Message);
                logger.LogError(default(EventId), ex, ex.Message);
            }

            return appResult;
        }

        [HttpGet]
        [ActionName("logout")]
        public virtual async Task<IActionResult> LogOutAsync()
        {
            await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync(HttpContext, CookieAuthenticationDefaults.AuthenticationScheme);
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        [ActionName("lockuser")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit })]
        public virtual ActionResult<KTAppDomainResult> LockUser([FromBody]Guid userId)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {
                    appResult.Success = userService.LockUser(userId);
                }
                else
                {
                    appResult.Messages = GetModelStateError();
                }
            }
            catch (KTAppException ex)
            {
                appResult.Messages.Add(ex.Message);
                logger.LogError(default(EventId), ex, ex.Message);
            }

            return appResult;
        }

        [HttpPost]
        [ActionName("UnLockUser")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit })]
        public virtual ActionResult<KTAppDomainResult> UnLockUser([FromBody]Guid userId)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {
                    appResult.Success = userService.UnLockUser(userId);
                }
                else
                {
                    appResult.Messages = GetModelStateError();
                }
            }
            catch (KTAppException ex)
            {
                appResult.Messages.Add(ex.Message);
                logger.LogError(default(EventId), ex, ex.Message);
            }

            return appResult;
        }

        [HttpPost]
        [ActionName("ResetPassword")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit })]
        public virtual ActionResult<KTAppDomainResult> ResetPassword([FromBody]ResetPasswordModel resetPwd)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {
                    appResult.Success = userService.ResetPassword(resetPwd);
                }
                else
                {
                    appResult.Messages = GetModelStateError();
                }
            }
            catch (KTAppException ex)
            {
                appResult.Messages.Add(ex.Message);
                logger.LogError(default(EventId), ex, ex.Message);
            }

            return appResult;
        }

        [HttpPost]
        [ActionName("deleteUser")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Delete })]
        public ActionResult<KTAppDomainResult> DeleteUser([FromBody]Guid userId)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {
                    appResult.Success = userService.Delete(userId);
                }
                else
                {
                    appResult.Messages = GetModelStateError();
                }
            }
            catch (KTAppException ex)
            {
                appResult.Messages.Add(ex.Message);
                logger.LogError(default(EventId), ex, ex.Message);
            }

            return appResult;
        }

        [HttpPost]
        [ActionName("Delete2")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Delete })]
        public override ActionResult<KTAppDomainResult> Delete([FromBody] UserModel model)
        {
            return base.Delete(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Delete })]
        public virtual ActionResult<KTAppDomainResult> Delete([FromBody]DeleteUserModel user)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {
                    appResult.Success = userService.Delete(user.Id);
                }
                else
                {
                    appResult.Messages = GetModelStateError();
                }
            }
            catch (KTAppException ex)
            {
                appResult.Messages.Add(ex.Message);
                logger.LogError(default(EventId), ex, ex.Message);
            }

            return appResult;
        }

        [HttpPost]
        [ActionName("forgotpassword")]
        [AllowAnonymous]
        public virtual ActionResult<KTAppDomainResult> ForgotPassword([FromBody] ForgotPwdModel forgotPwd)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {
                    //1. Check username & phone is valid: username and phone valid, not locked
                    var user = userService.Get(e =>
                    !e.Deleted &&
                    e.Username.ToLower().Trim() == forgotPwd.UserName.ToLower().Trim())
                    .FirstOrDefault();
                    if (user == null)
                    {
                        throw new KTAppException(10001, sharedLocalizer["_10001"]);
                    }

                    if (user.Phone.Trim().ToLower() != forgotPwd.Phone.Trim().ToLower())
                    {
                        throw new KTAppException(10023, sharedLocalizer["_10023"]);
                    }
                    if (user.Locked)
                    {
                        throw new KTAppException(10021, sharedLocalizer["_10021"]);
                    }
                    if (user.StatusId.HasValue)
                    {
                        throw new KTAppException(10024, sharedLocalizer["_10024"]);
                    }

                    //2. Check Confirm Code is valid
                    if (userConfirmCodeService.ConfirmCodeIsValid(user.Id, forgotPwd.ConfirmCode, CoreConstants.UserConfirmType.ForgotPassword.ToString()))
                    {
                        //3. Remove Confirm Code
                        bool success = userConfirmCodeService.UpdateConfirmCodeStatus(user.Id, forgotPwd.ConfirmCode, CoreConstants.UserConfirmType.ForgotPassword.ToString());
                        if (!success)
                        {
                            throw new KTAppException(10025, sharedLocalizer["_10025"]);
                        }
                        //4. Update new Password
                        success &= userService.ResetPassword(new ResetPasswordModel()
                        {
                            UserId = user.Id,
                            ConfirmPassword = forgotPwd.ConfirmPassword,
                            Password = forgotPwd.Password
                        });

                        if (!success)
                        {
                            throw new KTAppException(10026, sharedLocalizer["_10026"]);
                        }
                        appResult.Success = success;
                    }
                    else
                    {
                        throw new KTAppException(10006, sharedLocalizer["_10006"]);
                    }
                }
                else
                {
                    appResult.Messages = GetModelStateError();
                }
            }
            catch (KTAppException ex)
            {
                appResult.ResultCode = ex.ErrorCode;
                appResult.Messages.Add(ex.Message);
                logger.LogError(default(EventId), ex, ex.Message);
            }

            return appResult;
        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("login")]
        public virtual async Task<ActionResult<KTAppDomainResult>> LoginAsync([FromBody]LoginModel login)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (AppSettings.Value.EnableCaptCha)
                {
                    if (login.SessionId.HasValue)
                    {
                        var captchaCode = cache.Get<string>(login.SessionId.ToString());
                        cache.Remove(login.SessionId.ToString());

                        if (string.IsNullOrEmpty(captchaCode) || !captchaCode.Equals(login.CaptchaCode, StringComparison.OrdinalIgnoreCase))
                        {
                            throw new KTAppException(10003, sharedLocalizer["_10003"]);
                        }
                    }
                    else
                    {
                        throw new KTAppException(10004, sharedLocalizer["_10004"]);
                    }
                }

                if (ModelState.IsValid)
                {
                    appResult.Success = userService.Verify(login.UserName, login.Password, login.DepartmentId);
                    if (appResult.Success)
                    {
                        var user = userService.Get(e => e.Username.ToLower() == login.UserName.ToLower(), e => new Users()
                        {
                            Username = e.Username,
                            Id = e.Id,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                        }).FirstOrDefault();

                        var department = departmentService.Get(e => e.Id == login.DepartmentId).FirstOrDefault();

                        var claims = new[] {
                            new Claim(ClaimTypes.Name, login.UserName),
                            new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(new UserLoginModel {
                                UserId = user.Id,
                                UserName = user.Username,
                                DepartmentId = login.DepartmentId,
                                DepartmentCode = department != null ? department.Code :string.Empty,
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                            }))
                        };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignInAsync(HttpContext, CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                    }
                }
                else
                {
                    appResult.Messages = GetModelStateError();
                }
            }
            catch (KTAppException ex)
            {
                appResult.ResultCode = ex.ErrorCode;
                appResult.Messages.Add(ex.Message);
                logger.LogError(default(EventId), ex, ex.Message);
            }

            return appResult;
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("GetUserStatus")]
        public virtual ActionResult<KTAppDomainResult> GetUserStatus([FromQuery]string username)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                var user = userService.Get(e => !e.Deleted && !e.Locked && e.Username.ToLower().Trim() == username.ToLower().Trim(), e => new Users()
                {
                    UserStatus = e.UserStatus
                }).FirstOrDefault();

                if (user != null)
                    appResult.Data = user.UserStatus;
                appResult.Success = true;
            }
            catch (KTAppException ex)
            {
                appResult.Messages.Add(ex.Message);
                logger.LogError(default(EventId), ex, ex.Message);
            }

            return appResult;
        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("register")]
        public virtual ActionResult<KTAppDomainResult> Register([FromBody]RegisterModel register)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {
                    var pendingStatus = userStatusService.GetByCode(CoreConstants.UserStatusCode.RegPending.ToString());
                    Guid userId = Guid.NewGuid();
                    var user = new Users()
                    {
                        Username = register.UserName,
                        Password = register.Password,
                        Id = userId,
                        FirstName = register.FirstName,
                        LastName = register.LastName,
                        Email = register.Email,
                        Phone = register.Phone,
                        StatusId = pendingStatus.Id
                    };

                    if (userService.PhoneExists(user.Id, user.Phone) && !string.IsNullOrEmpty(user.Phone))
                    {
                        throw new KTAppException(10017, sharedLocalizer["_10017"]);
                    }

                    if (userService.EmailExists(user.Id, user.Email) && !string.IsNullOrEmpty(user.Email))
                    {
                        throw new KTAppException(10029, sharedLocalizer["_10029"]);
                    }

                    bool success = userService.Register(user);
                    if (success)
                    {
                        var userGroup = userGroupService.GetByCode(CoreConstants.UserGroups.User.ToString());
                        if (userGroup == null)
                        {
                            throw new KTAppException(10016, sharedLocalizer["_10016"]);
                        }
                        success &= userInGroupService.Save(new UserInGroups()
                        {
                            Id = Guid.NewGuid(),
                            GroupId = userGroup.Id,
                            UserId = user.Id,
                            Active = true,
                            Created = DateTime.Now,
                            CreatedBy = "System"
                        });

                        var sysParams = systemConfigService.GetByCode(CoreConstants.SystemParameter.SMSRegConfirm.ToString());
                        if (sysParams != null)
                        {
                            bool valid = bool.TryParse(sysParams.Value, out bool enable);
                            if (valid && enable)
                            {
                                var userConfirmCode = userConfirmCodeService.Generate(userId, CoreConstants.UserConfirmType.RegisterConfirm.ToString());
                                if (userConfirmCode == null)
                                {
                                    throw new KTAppException(10005, sharedLocalizer["_10005"]);
                                }
                                success &= coreSMSPendingService.SaveSMSPending(register.Phone, CoreConstants.NotificationTemplate.RegPhoneConfirm.ToString(), userConfirmCode);
                            }
                        }
                    }

                    appResult.Success = success;
                    user.Password = string.Empty;
                    if (success)
                    {
                        appResult.Data = user;
                    }
                }
                else
                {
                    appResult.Messages = GetModelStateError();
                }
            }
            catch (KTAppException ex)
            {
                appResult.ResultCode = ex.ErrorCode;
                appResult.Messages.Add(ex.Message);
                logger.LogError(default(EventId), ex, ex.Message);
            }

            return appResult;
        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("ResendActiveCode")]
        public virtual ActionResult<KTAppDomainResult> ResendActiveCode([FromBody]ResendActiveCodeModel resendActiveCode)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {

                    if (resendActiveCode.ConfirmTypeCode == CoreConstants.UserConfirmType.RegisterConfirm.ToString())
                    {
                        appResult = ResendRegistrationCode(resendActiveCode);
                    }
                    if (resendActiveCode.ConfirmTypeCode == CoreConstants.UserConfirmType.ForgotPassword.ToString())
                    {
                        appResult = ResendForGotPasswordCode(resendActiveCode);
                    }
                }
                else
                {
                    appResult.Messages = GetModelStateError();
                }
            }
            catch (KTAppException ex)
            {
                appResult.ResultCode = ex.ErrorCode;
                appResult.Messages.Add(ex.Message);
                logger.LogError(default(EventId), ex, ex.Message);
            }

            return appResult;
        }

        [HttpGet]
        [ActionName("InitDropdown")]
        [AllowAnonymous]
        public override ActionResult<KTAppDomainResult> InitDropdown()
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                var departments = departmentService.Get(e => !e.Deleted)
                    .Select(e => new
                    {
                        Id = e.Id.ToString(),
                        e.Name,
                        ParentId = e.ParentId.ToString(),
                        DepartmentType = e.DepartmentTypes != null ? e.DepartmentTypes.Name : string.Empty
                    }).OrderBy(e => e.Name).ToList();

                departments.Insert(0, new
                {
                    Id = string.Empty,
                    Name = "-- Vui lòng chọn phòng ban-- ",
                    ParentId = string.Empty,
                    DepartmentType = string.Empty
                });

                var userGroups = userGroupService.Get(e => !e.Deleted)
                    .Select(e => new
                    {
                        Id = e.Id.ToString(),
                        e.Name
                    }).OrderBy(e => e.Name).ToList();


                appResult.Data = new
                {
                    Departments = departments,
                    JobTitles = jobTitleService.Get(e => !e.Deleted).OrderBy(e => e.Name),
                    UserGroups = userGroups
                };
                appResult.Success = true;
            }
            catch (KTAppException ex)
            {
                logger.LogError(default(EventId), ex, ex.Message);
                appResult.Messages.Add(ex.Message);
            }

            return appResult;
        }

        #region Private methods

        private KTAppDomainResult ResendForGotPasswordCode(ResendActiveCodeModel resendActiveCode)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            bool success = false;
            var user = userService.Get(e =>
            e.Username.ToLower().Trim() == resendActiveCode.UserName.ToLower().Trim() && e.Phone == resendActiveCode.Phone, select:
            e => new Users()
            {
                Id = e.Id,
                StatusId = e.StatusId,
                Phone = e.Phone,
                Email = e.Email,
                UserStatus = e.UserStatus
            })
            .FirstOrDefault();
            if (user == null)
            {
                throw new KTAppException(10001, sharedLocalizer["_10001"]);
            }

            bool hasCode = userConfirmCodeService.HasActiveCode(user.Id, CoreConstants.UserConfirmType.ForgotPassword.ToString());
            if (hasCode)
            {
                throw new KTAppException(10011, sharedLocalizer["_10011"]);
            }

            var sysParams = systemConfigService.GetByCode(CoreConstants.SystemParameter.SMSRegConfirm.ToString());
            if (sysParams != null)
            {
                bool valid = bool.TryParse(sysParams.Value, out bool enable);
                if (valid && enable)
                {
                    if (string.IsNullOrEmpty(user.Phone))
                    {
                        throw new KTAppException(10015, sharedLocalizer["_10015"]);
                    }

                    if (resendActiveCode.ConfirmTypeCode == CoreConstants.UserConfirmType.ForgotPassword.ToString())
                    {
                        var userConfirmCode = userConfirmCodeService.Generate(user.Id, CoreConstants.UserConfirmType.ForgotPassword.ToString());
                        if (userConfirmCode == null)
                        {
                            throw new KTAppException(10005, sharedLocalizer["_10005"]);
                        }
                        success = coreSMSPendingService.SaveSMSPending(user.Phone, CoreConstants.NotificationTemplate.RegPhoneConfirm.ToString(), userConfirmCode);
                    }
                    else
                    {
                        throw new KTAppException(10009, sharedLocalizer["_10009"]);
                    }
                }
            }

            appResult.Success = success;

            return appResult;
        }

        private KTAppDomainResult ResendRegistrationCode(ResendActiveCodeModel resendActiveCode)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            bool success = true;
            var user = userService.Get(e =>
            e.Username.ToLower().Trim() == resendActiveCode.UserName.ToLower().Trim(), select:
            e => new Users()
            {
                Id = e.Id,
                StatusId = e.StatusId,
                Phone = e.Phone,
                Email = e.Email,
                UserStatus = e.UserStatus
            })
            .FirstOrDefault();
            if (user == null)
            {
                throw new KTAppException(10001, sharedLocalizer["_10001"]);
            }
            if (!user.StatusId.HasValue)
            {
                throw new KTAppException(10008, sharedLocalizer["_10008"]);
            }

            bool hasCode = userConfirmCodeService.HasActiveCode(user.Id, CoreConstants.UserConfirmType.RegisterConfirm.ToString());
            if (hasCode)
            {
                throw new KTAppException(10011, sharedLocalizer["_10011"]);
            }

            var sysParams = systemConfigService.GetByCode(CoreConstants.SystemParameter.SMSRegConfirm.ToString());
            if (sysParams != null)
            {
                bool valid = bool.TryParse(sysParams.Value, out bool enable);
                if (valid && enable)
                {

                    if (string.IsNullOrEmpty(user.Phone))
                    {
                        throw new KTAppException(10015, sharedLocalizer["_10015"]);
                    }

                    // nếu user mới đăng ký, gửi mã xác nhận đăng ký
                    if (user.UserStatus.Code == CoreConstants.UserStatusCode.RegPending.ToString())
                    {
                        if (resendActiveCode.ConfirmTypeCode == CoreConstants.UserConfirmType.RegisterConfirm.ToString())
                        {
                            var userConfirmCode = userConfirmCodeService.Generate(user.Id, CoreConstants.UserConfirmType.RegisterConfirm.ToString());
                            if (userConfirmCode == null)
                            {
                                throw new KTAppException(10005, sharedLocalizer["_10005"]);
                            }
                            success &= coreSMSPendingService.SaveSMSPending(user.Phone, CoreConstants.NotificationTemplate.RegPhoneConfirm.ToString(), userConfirmCode);
                        }
                        else
                        {
                            throw new KTAppException(10009, sharedLocalizer["_10009"]);
                        }
                    }
                    else
                    {
                        throw new KTAppException(10008, sharedLocalizer["_10008"]);
                    }
                }
            }

            appResult.Success = success;

            return appResult;
        }

        protected override Expression<Func<Users, Users>> BuildSelectQuery()
        {
            return e => new Users()
            {
                Id = e.Id,
                Active = e.Active,
                Created = e.Created,
                CreatedBy = e.CreatedBy,
                Deleted = e.Deleted,
                FailedCount = e.FailedCount,
                Locked = e.Locked,
                LockedEnd = e.LockedEnd,
                UserInGroups = e.UserInGroups.Where(g => !g.Deleted).Select(g => new UserInGroups()
                {
                    UserGroups = g.UserGroups
                }).ToList(),
                Password = string.Empty,
                UserDepartments = e.UserDepartments,
                Username = e.Username,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Phone = e.Phone
            };
        }

        #endregion

    }
}