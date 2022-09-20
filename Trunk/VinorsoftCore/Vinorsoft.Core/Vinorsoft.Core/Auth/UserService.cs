using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Resx;
using Vinorsoft.Core.Utils;

namespace Vinorsoft.Core
{
    public class UserService : CoreService<Users>, IUserService
    {
        protected readonly IAuthDbContext authDbContext;
        public static Guid FullControlID = Guid.Parse("0A0D1EB5-882A-4E88-B171-FF15CFE1E9DD");
        protected readonly AppSettings _appSettings;
        protected readonly IConfiguration configuration;
        public UserService(
            IAuthDbContext coreDbContext, 
            IOptions<AppSettings> appSettings,
            IConfiguration configuration
            ) : base(coreDbContext)
        {
            this.configuration = configuration;
            authDbContext = coreDbContext;
            _appSettings = appSettings.Value;
        }

        public bool ChangePassword(string username, string password, string newPassword, string confirmPassword)
        {
            var user = Queryable
                .Where(e => e.Username == username)
                .FirstOrDefault();
            if (user != null)
            {
                if (user.Password == SecurityUtils.HashSHA1(password))
                {
                    if (password == newPassword)
                    {
                        throw new Exception(CoreErrorResource.ERROR_AUTH_PWD_DIFF_PWDO);
                    }
                    user.Password = SecurityUtils.HashSHA1(newPassword);
                    authDbContext.Set<Users>().Update(user);
                    authDbContext.SaveChanges();
                    return true;

                }
                else
                {
                    throw new Exception(CoreErrorResource.ERROR_AUTH_ACC_PWD_WRONG);
                }
            }
            else
            {
                throw new Exception(string.Format(CoreErrorResource.ERROR_NOT_FOUND, username));
            }
        }

        public string CreateToken(Users user)
        {
            if (Verify(user.Id, user.Password))
            {
                var storeUser = GetById(user.Id);
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = configuration["Jwt:Issuer"],
                    Audience = configuration["Jwt:Audience"],
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, storeUser.Username),
                        new Claim(ClaimTypes.UserData, Newtonsoft.Json.JsonConvert.SerializeObject(new {
                              UserId = storeUser.Id,
                              UserName = storeUser.Username,
                              FullName = $"{storeUser.FirstName} { storeUser.LastName}"
                        }))
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            throw new Exception(CoreErrorResource.ERROR_AUTH_ACC_PWD_WRONG);
        }

        public string CreateToken(string username, string password)
        {
            var user = Queryable.FirstOrDefault(e => !string.IsNullOrEmpty(username) && e.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (user == null)
                throw new Exception(string.Format(CoreErrorResource.ERROR_NOT_FOUND, username));
            return CreateToken(new Users()
            {
                Id = user.Id,
                Password = password
            });
        }

        public bool EmailExists(Guid userId, string email)
        {
            return Queryable.Any(e => e.Id != userId && e.Email == email);
        }

        public bool FailedLogin(Guid userId)
        {
            var user = Queryable.FirstOrDefault(e => e.Id == userId);
            if (user != null)
            {
                user.FailedCount += 1;
                if (user.FailedCount >= 5)
                {
                    return LockUser(userId);
                }
                authDbContext.Set<Users>().Update(user);
                authDbContext.SaveChanges();
                return true;
            }
            throw new Exception(string.Format(CoreErrorResource.ERROR_NOT_FOUND, userId));

        }

        public bool HasPermission(Guid userId, string controller, IList<string> permission)
        {
            if (userId == FullControlID)
                return true;

            bool hasPermit = false;
            var permitObjects = authDbContext.Set<UserGroups>()
                  .Where(e => e.UserInGroups.Any(s => s.UserId == userId))
                  .Select(e => new UserGroups()
                  {
                      PermitObjectPermissions = e.PermitObjectPermissions.Where(s => s.Permissions != null && s.PermitObjects != null).Select(s => new PermitObjectPermissions()
                      {
                          Permissions = s.Permissions,
                          PermitObjects = s.PermitObjects
                      }).ToList()
                  }).AsNoTracking().ToList();

            if (permitObjects.Count > 0)
            {
                hasPermit = permitObjects.Any(e => e.PermitObjectPermissions.Any(s =>
                s.PermitObjects != null
                && !string.IsNullOrEmpty(s.PermitObjects.ControllerNames)
                && s.PermitObjects.ControllerNames.Split(new char[] { ',', ';' }, StringSplitOptions.None).Contains(controller)
                && s.Permissions != null
                && permission.Contains(s.Permissions.Code)));
            }
            return hasPermit;
        }

        public bool IsLocked(Guid userId)
        {
            return Queryable.Any(e => e.Id == userId && e.Locked);
        }

        public bool LockUser(Guid userId)
        {
            var user = Queryable.FirstOrDefault(e => e.Id == userId);
            if (user != null)
            {
                user.Locked = true;
                user.LockedEnd = DateTime.Now.AddMinutes(5);
                authDbContext.Set<Users>().Update(user);
                authDbContext.SaveChanges();
                return true;
            }
            throw new Exception(string.Format(CoreErrorResource.ERROR_NOT_FOUND, userId));

        }

        public bool Login(string username, string password)
        {
            return Verify(username, password, null);
        }

        public bool PhoneExists(Guid userId, string phone)
        {
            return Queryable.Any(e => e.Id != userId && e.Phone == phone);
        }

        public bool Register(Users user)
        {
            throw new NotImplementedException();
        }

        public bool ResetFailedLogin(Guid userId)
        {
            var user = Queryable.FirstOrDefault(e => e.Id == userId);
            if (user != null)
            {
                user.Locked = false;
                user.LockedEnd = null;
                user.FailedCount = 0;
                authDbContext.Set<Users>().Update(user);
                authDbContext.SaveChanges();
                return true;
            }

            throw new Exception(CoreErrorResource.ERROR_UNKNOWN);
        }

        public bool UnLockUser(Guid userId)
        {
            var user = Queryable.FirstOrDefault(e => e.Id == userId);
            if (user != null)
            {
                user.Locked = false;
                user.LockedEnd = null;
                user.FailedCount = 0;
                authDbContext.Set<Users>().Update(user);
                authDbContext.SaveChanges();
                return true;
            }

            throw new Exception(string.Format(CoreErrorResource.ERROR_NOT_FOUND, userId));
        }

        public bool UpdateProfileUser(Users user)
        {
            var updateUser = Queryable.FirstOrDefault(e => e.Id == user.Id);
            if (updateUser == null)
            {
                throw new Exception(string.Format(CoreErrorResource.ERROR_NOT_FOUND, user.Username));
            }

            updateUser.FirstName = user.FirstName;
            updateUser.LastName = user.LastName;
            updateUser.Email = user.Email;
            updateUser.Phone = user.Phone;
            authDbContext.Set<Users>().Update(updateUser);
            authDbContext.SaveChanges();

            return true;
        }

        public bool Validate(string userName, string password)
        {
            return Verify(userName, password, null);
        }

        public bool Verify(string userName, string password, Guid? departmentId)
        {
            var user = Queryable
                .Where(e =>
                e.Username.ToLower().Trim() == userName.ToLower().Trim())
                .FirstOrDefault();
            if (user != null)
            {
                if (user.Locked && user.LockedEnd.HasValue && user.LockedEnd > DateTime.Now)
                {
                    throw new Exception(CoreErrorResource.ERROR_AUTH_ACC_LOCKED);
                }
                if (user.Password == SecurityUtils.HashSHA1(password))
                {
                    user.Locked = false;
                    user.FailedCount = 0;
                    user.LockedEnd = null;
                    authDbContext.Set<Users>().Update(user);
                    authDbContext.SaveChanges();
                    authDbContext.Entry(user).State = EntityState.Detached;
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
                    authDbContext.Set<Users>().Update(user);
                    authDbContext.SaveChanges();
                    authDbContext.Entry(user).State = EntityState.Detached;
                    throw new Exception(CoreErrorResource.ERROR_AUTH_ACC_PWD_WRONG);
                }
            }
            else
            {
                throw new Exception(string.Format(CoreErrorResource.ERROR_NOT_FOUND, userName));
            }
        }

        public bool Verify(Guid userId, string password)
        {
            var user = Queryable.FirstOrDefault(e => e.Id == userId);
            return user != null && Verify(user.Username, password, null);
        }

        public bool VerifyEmail(string email, Guid id)
        {
            return !Any(e => e.Id != id && e.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public bool VerifyPhone(string phone, Guid id)
        {
            return !Any(e => e.Id != id && e.Phone.Equals(phone, StringComparison.OrdinalIgnoreCase));

        }

        public bool VerifyUserName(string userName, Guid id)
        {
            return !Any(e => e.Id != id && e.Username.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }

        public override int Update(Users entity)
        {
            var currentGroups = coreDbContext.Set<UserInGroups>().Where(e => e.UserId == entity.Id);
            if (currentGroups.Any())
            {
                foreach (var item in currentGroups)
                {
                    coreDbContext.Set<UserInGroups>().Remove(item);
                }
            }

            if (entity.UserInGroups.Count > 0)
            {
                foreach (var item in entity.UserInGroups)
                {
                    coreDbContext.Set<UserInGroups>().Add(item);
                }
            }

            var exists = GetById(entity.Id);
            if (exists == null)
            {
                throw new Exception(string.Format(CoreErrorResource.ERROR_NOT_FOUND, entity.Id));
            }
            coreDbContext.Set<Users>().Update(entity);
            coreDbContext.Entry(entity).Property(e => e.Password).IsModified = false;
            coreDbContext.Entry(entity).Property(e => e.Username).IsModified = false;
            return coreDbContext.SaveChanges();
        }

        public int ResetPassword(Guid id, string newPassword)
        {
            var user = Queryable.FirstOrDefault(e => e.Id == id);
            if (user != null)
            {
                user.Password = newPassword;
                coreDbContext.Set<Users>().Update(user);
                return coreDbContext.SaveChanges();
            }
            return 0;
        }

        public int UpdateProfile(Guid id, Guid profileId)
        {
            var user = Queryable.FirstOrDefault(e => e.Id == id);
            if (user != null)
            {
                var commandText = "UPDATE USERS SET ProfileId = @ProfileId WHERE Id = @Id";
                var param1 = new SqlParameter("@ProfileId", profileId);
                var param2 = new SqlParameter("@Id", id);
                return authDbContext.Database.ExecuteSqlCommand(commandText, param1, param2);
            }
            return 0;
        }
    }
}
