using KTApps.AuthService.Entities;
using KTApps.Core;
using System;

namespace KTApps.AuthService.Interface
{
    public interface IUserConfirmCodeService : IDomainService<UserConfirmCodes>
    {
        UserConfirmCodes Generate(Guid userId, string userConfirmType);
        bool ConfirmCodeIsValid(Guid userId, string confirmCode, string confirmTypeCode);
        bool UpdateConfirmCodeStatus(Guid userId, string confirmCode, string confirmTypeCode);
        bool HasActiveCode(Guid userId, string confirmTypeCode);
    }
}
