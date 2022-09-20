using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Core.EF;
using Microsoft.EntityFrameworkCore;

namespace KTApps.AuthService.Repository
{
    public class UserRepository : DomainRepository<Users>, IUserRepository
    {
        public UserRepository(IAuthDbContext context) : base(context)
        {
        }
    }
}
