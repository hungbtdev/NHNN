using KTApps.AuthService.Entities;
using KTApps.Core;
using KTApps.Models;
using System;
using System.Collections.Generic;

namespace KTApps.AuthService.Interface
{
    public interface IUserService : IDomainService<Users>
    {
        bool Login(string username, string password);
        bool ChangePassword(string username, string password, string newPassword, string confirmPassword);
        bool Register(Users user);
        bool LockUser(Guid userId);
        bool FailedLogin(Guid userId);
        bool ResetFailedLogin(Guid userId);
        bool Validate(string userName, string password);
        bool Verify(string userName, string password, Guid? departmentId);
        bool UnLockUser(Guid userId);
        bool ResetPassword(ResetPasswordModel resetPwd);
        bool HasPermission(Guid userId, string controller, IList<string> permission);
        bool UpdateProfileUser(Users user);
        bool UpdateUserStatus(Guid userId, string userStatusCode);
        string CreateToken(Users user, string secret);
        bool PhoneExists(Guid userId, string phone);
        bool EmailExists(Guid userId, string email);
        bool IsLocked(Guid userId);
    }
}
