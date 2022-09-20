using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Core.EF;
using KTApps.Domain;
using Microsoft.EntityFrameworkCore;

namespace KTApps.AuthService.Repository
{
    public class AuthRepository<T> : DomainRepository<T> where T : KTAppDomain
    {
        public AuthRepository(IAuthDbContext context) : base(context)
        {
        }
    }
}
