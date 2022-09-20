using System;
using System.Collections.Generic;
using Vinorsoft.Core.Entities;

namespace Vinorsoft.Core.Interface
{
    public interface IUserService : ICoreService<Users>
    {
        bool Login(string username, string password);
        bool ChangePassword(string username, string password, string newPassword, string confirmPassword);
        bool Register(Users user);
        bool LockUser(Guid userId);
        bool FailedLogin(Guid userId);
        bool ResetFailedLogin(Guid userId);
        bool Validate(string userName, string password);
        bool Verify(Guid userId, string password);
        bool Verify(string userName, string password, Guid? departmentId);
        bool VerifyUserName(string userName, Guid id);
        bool VerifyEmail(string email, Guid id);
        bool VerifyPhone(string phone, Guid id);
        bool UnLockUser(Guid userId);
        bool HasPermission(Guid userId, string controller, IList<string> permission);
        bool UpdateProfileUser(Users user);
        string CreateToken(Users user);
        string CreateToken(string username, string password);
        bool PhoneExists(Guid userId, string phone);
        bool EmailExists(Guid userId, string email);
        bool IsLocked(Guid userId);
        int ResetPassword(Guid id, string newPassword);
        int UpdateProfile(Guid id, Guid profileId);
    }
}
