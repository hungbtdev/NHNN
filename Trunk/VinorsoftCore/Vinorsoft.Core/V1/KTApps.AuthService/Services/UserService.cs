using AutoMapper;
using KTApp.Core.Resources;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Core;
using KTApps.Core.Services;
using KTApps.Core.Utils;
using KTApps.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace KTApps.AuthService
{
    public class UserService : DomainService<Users>, IUserService
    {
        private readonly AppSettings appSettings;
        private readonly IAuthUnitOfWork authUnitOfWork;
        private readonly IStringLocalizer<SharedResource> sharedLocalizer;
        public UserService(IStringLocalizer<SharedResource> sharedLocalizer, IAuthUnitOfWork unitOfWork, IMapper mapper, IOptions<AppSettings> appSettings) : base(unitOfWork, mapper)
        {
            this.appSettings = appSettings.Value;
            authUnitOfWork = unitOfWork;
            this.sharedLocalizer = sharedLocalizer;
        }

        public string CreateToken(Users user, string secret)
        {
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                                new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(new {
                                     UserId = user.Id,
                                     UserName = user.Username,
                                     DepartmentCode = string.Empty
                                }))
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        /// <summary>
        /// Cập nhật thông tin Profile User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UpdateProfileUser(Users user)
        {
            bool result = false;
            var userUpdate = unitOfWork.Repository<Users>().GetQueryable()
                .Where(e => !e.Deleted && e.Id == user.Id)
                .AsNoTracking().FirstOrDefault();
            if (userUpdate != null)
            {
                userUpdate = mapper.Map<Users>(user);
                userUpdate.UserDepartments = null;
                userUpdate.UserInGroups = null;
                unitOfWork.Repository<Users>().Update(userUpdate);
                unitOfWork.Save();
                result = true;
            }
            else
            {
                throw new KTAppException(10001, sharedLocalizer["_10001"]);
            }

            return result;
        }

        /// <summary>
        /// Thay đổi mật khẩu người dùng
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="newPassword"></param>
        /// <param name="confirmPassword"></param>
        /// <returns></returns>
        public bool ChangePassword(string username, string password, string newPassword, string confirmPassword)
        {
            var user = authUnitOfWork.Repository<Users>().GetQueryable()
                .Where(e => e.Username == username)
                .FirstOrDefault();
            if (user != null)
            {
                if (user.Password == SecurityUtils.HashSHA1(password))
                {
                    if (password == newPassword)
                    {
                        throw new KTAppException(10018, sharedLocalizer["_10018"]);
                    }
                    user.Password = SecurityUtils.HashSHA1(newPassword);
                    authUnitOfWork.Repository<Users>().Update(user);
                    authUnitOfWork.Save();
                    return true;

                }
                else
                {
                    throw new KTAppException(10019, sharedLocalizer["_10019"]);
                }
            }
            else
            {
                throw new KTAppException(10002, sharedLocalizer["_10002"]);
            }

        }

        public bool FailedLogin(Guid userId)
        {
            bool appResult = new bool();
            var user = authUnitOfWork.Repository<Users>()
                .GetQueryable()
                .FirstOrDefault(e => e.Id == userId);
            if (user != null)
            {
                user.FailedCount++;
                if (user.FailedCount >= 5)
                {
                    user.Locked = true;
                    user.LockedEnd = DateTime.Now.AddMinutes(15);
                }
                authUnitOfWork.Repository<Users>().Update(user);
                authUnitOfWork.Save();
            }
            else
            {
                throw new KTAppException(10001, sharedLocalizer["_10001"]);
            }

            return appResult;
        }

        public bool LockUser(Guid userId)
        {
            bool appResult = new bool();
            var user = authUnitOfWork.Repository<Users>()
                .GetQueryable()
                .FirstOrDefault(e => e.Id == userId);
            if (user != null)
            {
                user.Locked = true;
                user.LockedEnd = DateTime.Now.AddMinutes(15);
                authUnitOfWork.Repository<Users>().Update(user);
                authUnitOfWork.Save();
            }
            else
            {
                throw new KTAppException(10001, sharedLocalizer["_10001"]);
            }

            return appResult;
        }

        public bool Login(string username, string password)
        {
            var user = authUnitOfWork.Repository<Users>().GetQueryable()
                .Where(e => e.Username == username)
                .FirstOrDefault();
            if (user != null)
            {
                if (user.Password == SecurityUtils.HashSHA1(password))
                {
                    if (user.Locked && user.LockedEnd.HasValue && user.LockedEnd > DateTime.Now)
                    {
                        throw new KTAppException(10021, sharedLocalizer["_10021"]);
                    }
                    else
                    {
                        user.Locked = false;
                        user.FailedCount = 0;
                        user.LockedEnd = null;
                        authUnitOfWork.Repository<Users>().Update(user);
                        authUnitOfWork.Save();
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes(appSettings.Secret);
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                                new Claim(ClaimTypes.Name, user.Id.ToString())
                            }),
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        return true;
                    }
                }
                else
                {
                    throw new KTAppException(10007, sharedLocalizer["_10007"]);
                }
            }
            else
            {
                throw new KTAppException(10007, sharedLocalizer["_10007"]);
            }
        }

        public bool Register(Users user)
        {
            var exists = authUnitOfWork.Repository<Users>().GetQueryable()
                .Any(e => e.Username.Equals(user.Username, StringComparison.OrdinalIgnoreCase));
            if (exists)
            {
                throw new KTAppException(10020, sharedLocalizer["_10020"]);
            }
            else
            {
                user.Password = SecurityUtils.HashSHA1(user.Password);
                authUnitOfWork.Repository<Users>().Create(user);
                authUnitOfWork.Save();
                return true;
            }
        }

        public bool ResetFailedLogin(Guid userId)
        {
            var user = authUnitOfWork.Repository<Users>()
                .GetQueryable()
                .FirstOrDefault(e => e.Id == userId);
            if (user != null)
            {
                user.Locked = false;
                user.FailedCount = 0;
                user.LockedEnd = null;
                authUnitOfWork.Repository<Users>().Update(user);
                authUnitOfWork.Save();
                return true;
            }
            else
            {
                throw new KTAppException(10001, sharedLocalizer["_10001"]);
            }
        }

        public bool Validate(string username, string password)
        {
            var user = authUnitOfWork.Repository<Users>().GetQueryable()
                .Where(e => !e.Deleted && e.Username == username)
                .FirstOrDefault();
            if (user != null)
            {
                if (user.Password == SecurityUtils.HashSHA1(password))
                {
                    if (user.Locked && user.LockedEnd.HasValue && user.LockedEnd > DateTime.Now)
                    {
                        throw new KTAppException(10021, sharedLocalizer["_10021"]);
                    }
                    else
                    {
                        user.Locked = false;
                        user.FailedCount = 0;
                        user.LockedEnd = null;
                        authUnitOfWork.Repository<Users>().Update(user);
                        authUnitOfWork.Save();
                        return true;
                    }
                }
                else
                {
                    throw new KTAppException(10002, sharedLocalizer["_10002"]);

                }
            }
            else
            {
                throw new KTAppException(10002, sharedLocalizer["_10002"]);
            }
        }

        public bool UnLockUser(Guid userId)
        {
            var user = authUnitOfWork.Repository<Users>()
                .GetQueryable()
                .FirstOrDefault(e => e.Id == userId);
            if (user != null)
            {
                user.Locked = false;
                user.LockedEnd = null;
                authUnitOfWork.Repository<Users>().Update(user);
                authUnitOfWork.Save();
                return true;
            }
            else
            {
                throw new Exception(userId + " not exists");
            }
        }

        public bool ResetPassword(ResetPasswordModel resetPwd)
        {
            var user = authUnitOfWork.Repository<Users>()
                .GetQueryable()
                .FirstOrDefault(e => e.Id == resetPwd.UserId);
            if (user != null)
            {
                user.Password = SecurityUtils.HashSHA1(resetPwd.Password);
                authUnitOfWork.Repository<Users>().Update(user);
                authUnitOfWork.Save();
                return true;
            }
            else
            {
                throw new KTAppException(10001, sharedLocalizer["_10001"]);
            }
        }

        public bool HasPermission(Guid userId, string controller, IList<string> permission)
        {
            bool hasPermit = false;
            var permitObjects = authUnitOfWork.Repository<UserGroups>()
                  .GetQueryable()
                  .AsNoTracking()
                  .Where(e => e.UserInGroups.Any(s => s.UserId == userId))
                  .Select(e => new UserGroups()
                  {
                      PermitObjectPermissions = e.PermitObjectPermissions.Select(s => new PermitObjectPermissions()
                      {
                          Permissions = s.Permissions,
                          PermitObjects = s.PermitObjects
                      }).ToList()
                  }).ToList();

            if (permitObjects.Count > 0)
            {
                hasPermit = permitObjects.Any(e => e.PermitObjectPermissions.Any(s => s.PermitObjects.ControllerNames.Split(";", StringSplitOptions.None).Contains(controller) && permission.Contains(s.Permissions.Code)));
            }
            return hasPermit;
        }

        public override bool Save(Users user)
        {
            var exists = authUnitOfWork.Repository<Users>().GetQueryable()
                .AsNoTracking()
               .FirstOrDefault(e => e.Username.Equals(user.Username, StringComparison.OrdinalIgnoreCase));
            if (exists != null && exists.Id != user.Id)
            {
                throw new KTAppException(10020, sharedLocalizer["_10020"]);
            }
            else
            {
                var updateUser = authUnitOfWork.Repository<Users>()
                    .GetQueryable()
                    .AsNoTracking()
                    .FirstOrDefault(e => e.Id == user.Id);
                user.UserInGroups = new List<UserInGroups>();
                if (user.UserGroupIds.Any())
                {
                    var queryableGroup = authUnitOfWork.Repository<UserGroups>().GetQueryable();
                    foreach (var UserGroupId in user.UserGroupIds)
                    {
                        user.UserInGroups.Add(new UserInGroups()
                        {
                            Id = Guid.NewGuid(),
                            UserId = user.Id,
                            GroupId = Guid.Parse(UserGroupId),
                            Created = DateTime.Now,
                            CreatedBy = user.CreatedBy
                        });
                    }
                }

                if (updateUser != null)
                {
                    //Xóa tất cả UserGroup cũ
                    var oldUserInGroups = authUnitOfWork.Repository<UserInGroups>()
                                .GetQueryable()
                                .AsNoTracking()
                                .Where(e => e.UserId == updateUser.Id)
                                .ToList();
                    if (oldUserInGroups.Any())
                    {
                        foreach (var oldUserInGroup in oldUserInGroups)
                        {
                            authUnitOfWork.Repository<UserInGroups>().Delete(oldUserInGroup);
                        }
                    }
                    //Thêm lại user mới
                    if (user.UserInGroups.Any())
                    {
                        foreach (var userInGroup in user.UserInGroups)
                        {
                            authUnitOfWork.Repository<UserInGroups>().Create(userInGroup);
                        }
                    }

                    if (user.UserDepartments.Count > 0)
                    {
                        foreach (var dept in user.UserDepartments)
                        {
                            var existDept = authUnitOfWork.Repository<UserDepartments>()
                               .GetQueryable()
                               .AsNoTracking()
                               .FirstOrDefault(e => e.Id == dept.Id);
                            if (existDept != null)
                            {
                                if (dept.Deleted)
                                {
                                    authUnitOfWork.Repository<UserDepartments>().Delete(existDept);
                                }
                                else
                                {
                                    existDept = mapper.Map<UserDepartments>(dept);
                                    authUnitOfWork.Repository<UserDepartments>().Update(existDept);
                                }
                            }
                            else
                            {
                                authUnitOfWork.Repository<UserDepartments>().Create(dept);
                            }
                        }
                    }
                    updateUser = mapper.Map<Users>(user);
                    updateUser.UserDepartments = null;
                    updateUser.UserInGroups = null;
                    updateUser.UserGroupIds = null;
                    authUnitOfWork.Repository<Users>().Update(updateUser);
                }
                else
                {
                    authUnitOfWork.Repository<Users>().Create(user);
                }
                authUnitOfWork.Save();
                return true;
            }
        }

        public bool Verify(string userName, string password, Guid? departmentId)
        {
            var user = authUnitOfWork.Repository<Users>().GetQueryable()
                .Where(e => !e.Deleted &&
                e.Username.ToLower().Trim() == userName.ToLower().Trim()
                && (!departmentId.HasValue || e.UserDepartments.Any(d => d.DepartmentId == departmentId.Value)))
                .FirstOrDefault();
            if (user != null)
            {
                if (user.Locked && user.LockedEnd.HasValue && user.LockedEnd > DateTime.Now)
                {
                    throw new KTAppException(10021, sharedLocalizer["_10021"]);
                }

                if (user.Password == SecurityUtils.HashSHA1(password))
                {
                    user.Locked = false;
                    user.FailedCount = 0;
                    user.LockedEnd = null;
                    authUnitOfWork.Repository<Users>().Update(user);
                    authUnitOfWork.Save();
                    return true;
                }
                else
                {

                    user.FailedCount += 1;
                    int modFailed = user.FailedCount % 5;
                    if (modFailed == 0)
                    {
                        user.Locked = true;
                        user.LockedEnd = DateTime.Now.AddMinutes(15);
                    }
                    authUnitOfWork.Repository<Users>().Update(user);
                    authUnitOfWork.Save();
                    throw new KTAppException(10002, sharedLocalizer["_10002"]);
                }

            }
            else
            {
                throw new KTAppException(10002, sharedLocalizer["_10002"]);
            }
        }

        public bool UpdateUserStatus(Guid userId, string userStatusCode)
        {
            if (string.IsNullOrEmpty(userStatusCode))
            {
                authUnitOfWork.Repository<Users>().ExecuteNonQuery("Update Users set StatusId = null where Id =@Id",
                    new Dictionary<string, object>()
                                            {
                                                {"@Id",userId}
                                            });
            }
            else
            {
                var status = authUnitOfWork.Repository<UserStatus>().GetQueryable().FirstOrDefault(e => !e.Deleted && e.Code == userStatusCode);
                if (status != null)
                {
                    authUnitOfWork.Repository<Users>().ExecuteNonQuery("Update user set StatusId = @StatusId where Id =@Id",
                        new Dictionary<string, object>(){
                                                {"@Id",userId},
                                                {"@StatusId",status.Id}
                        });
                }
                else
                {
                    throw new KTAppException(10022, sharedLocalizer["_10022"]);
                }
            }
            return true;
        }

        public bool PhoneExists(Guid userId, string phone)
        {
            return authUnitOfWork.Repository<Users>().GetQueryable().Any(e => !e.Deleted && e.Id != userId && e.Phone == phone);
        }

        public bool EmailExists(Guid userId, string email)
        {
            return authUnitOfWork.Repository<Users>().GetQueryable().Any(e => !e.Deleted && e.Id != userId && e.Email == email);
        }

        public bool IsLocked(Guid userId)
        {
            return authUnitOfWork.Repository<Users>().GetQueryable().Any(e => e.Id == userId && !e.Deleted && e.Locked);
        }
    }
}
