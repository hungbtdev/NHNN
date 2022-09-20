using AutoMapper;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Core.Services;

namespace KTApps.AuthService
{
    public class UserDepartmentService : DomainService<UserDepartments>, IUserDepartmentService
    {
        public UserDepartmentService(IAuthUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
