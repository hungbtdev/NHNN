using System;
using System.Linq;
using AutoMapper;
using KTApp.Core.Resources;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Core;
using KTApps.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace KTApps.AuthService
{
    public class UserConfirmCodeService : DomainService<UserConfirmCodes>, IUserConfirmCodeService
    {
        readonly IStringLocalizer<SharedResource> sharedLocalizer;
        public UserConfirmCodeService(
            IAuthUnitOfWork unitOfWork,
            IMapper mapper,
            IStringLocalizer<SharedResource> sharedLocalizer
            ) : base(unitOfWork, mapper)
        {
            this.sharedLocalizer = sharedLocalizer;
        }

        public bool ConfirmCodeIsValid(Guid userId, string confirmCode, string confirmTypeCode)
        {
            return unitOfWork.Repository<UserConfirmCodes>().GetQueryable()
                .AsNoTracking()
                .Any(e =>
            !e.Deleted &&
            e.UserId == userId &&
            e.ConfirmCode == confirmCode &&
            e.Expired >= DateTime.Now &&
            e.UserConfirmStatus.Code == CoreConstants.UserConfirmStatus.Pending.ToString() &&
            e.UserConfirmTypes.Code == confirmTypeCode);
        }

        public UserConfirmCodes Generate(Guid userId, string userConfirmType)
        {
            var confirmType = unitOfWork.Repository<UserConfirmTypes>().GetQueryable()
                .AsNoTracking()
                .Where(e => e.Code == userConfirmType)
                .FirstOrDefault();
            var confirmStatus = unitOfWork.Repository<UserConfirmStatus>().GetQueryable()
                .AsNoTracking()
                .Where(e => e.Code == CoreConstants.UserConfirmStatus.Pending.ToString()).FirstOrDefault();

            if (confirmType == null)
            {
                throw new KTAppException(10009, sharedLocalizer["_10009"]);
            }

            if (confirmStatus == null)
            {
                throw new KTAppException(10010, sharedLocalizer["_10010"]);
            }
            var randomCode = new Random().Next(100000, 999999).ToString();

            while (ConfirmCodeIsValid(userId, randomCode, confirmType.Code))
            {
                randomCode = new Random().Next(100000, 999999).ToString();
            }

            var newItem = new UserConfirmCodes()
            {
                Id = Guid.NewGuid(),
                ConfirmCode = randomCode,
                Issued = DateTime.Now,
                Expired = DateTime.Now.AddMinutes(5),
                StatusId = confirmStatus.Id,
                UserId = userId,
                ConfirmTypeId = confirmType.Id,
                Active = true,
                Created = DateTime.Now,
                CreatedBy = "System"
            };

            bool success = Save(newItem);
            if (success)
            {
                return newItem;
            }
            return null;
        }

        public bool UpdateConfirmCodeStatus(Guid userId, string confirmCode, string confirmTypeCode)
        {
            var exist = unitOfWork.Repository<UserConfirmCodes>().GetQueryable()
                .AsNoTracking()
                .Where(e =>
                        !e.Deleted &&
                        e.UserId == userId &&
                        e.ConfirmCode == confirmCode &&
                        e.UserConfirmStatus.Code == CoreConstants.UserConfirmStatus.Pending.ToString() &&
                        e.UserConfirmTypes.Code == confirmTypeCode)
                .FirstOrDefault();
            var confirmStatus = unitOfWork.Repository<UserConfirmStatus>().GetQueryable()
                .AsNoTracking()
                .Where(e => e.Code == CoreConstants.UserConfirmStatus.Confirm.ToString())
                .FirstOrDefault();
            if (exist != null)
            {
                exist.StatusId = confirmStatus.Id;
                unitOfWork.Repository<UserConfirmCodes>().Update(exist);
                unitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool HasActiveCode(Guid userId, string confirmTypeCode)
        {
            var exist = unitOfWork.Repository<UserConfirmCodes>().GetQueryable()
                .AsNoTracking()
               .Where(e => !e.Deleted &&
                           e.UserId == userId &&
                           e.Expired >= DateTime.Now &&
                           e.UserConfirmTypes.Code == confirmTypeCode &&
                           e.UserConfirmStatus.Code == CoreConstants.UserConfirmStatus.Pending.ToString())
               .FirstOrDefault();
            return exist != null;
        }
    }
}
