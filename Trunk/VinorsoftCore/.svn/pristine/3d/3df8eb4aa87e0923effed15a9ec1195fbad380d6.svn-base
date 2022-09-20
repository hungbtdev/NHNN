using KTApps.AuthService.Interface;
using KTApps.AuthService.Repository;
using KTApps.Core.EF;

namespace KTApps.AuthService
{
    public class AuthUnitOfWork : UnitOfWork, IAuthUnitOfWork
    {
        readonly IAuthDbContext authDbContext;
        public AuthUnitOfWork(IAuthDbContext context) : base(context)
        {
            authDbContext = context;
        }
        public override IDomainRepository<T> Repository<T>()
        {
            return new AuthRepository<T>(authDbContext);
        }
    }
}
