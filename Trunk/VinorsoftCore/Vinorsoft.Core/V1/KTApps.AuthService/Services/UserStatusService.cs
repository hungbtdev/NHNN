using AutoMapper;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;

namespace KTApps.AuthService
{
    public class UserStatusService : AuthCatalogueService<UserStatus>,IUserStatusService
    {
        public UserStatusService(IAuthUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
