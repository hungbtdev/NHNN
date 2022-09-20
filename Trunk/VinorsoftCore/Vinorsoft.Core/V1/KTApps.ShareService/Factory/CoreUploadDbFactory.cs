using KTApps.Core.EF;
using KTApps.Core.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace KTApps.ShareService.Factory
{
    public class CoreUploadDbFactory : DbContextFactory, ICoreUploadDbFactory
    {
        public CoreUploadDbFactory(string connectionString, IHttpContextAccessor httpContextAccessor) : base(connectionString, httpContextAccessor)
        {
        }

        public override ICoreDbContext Create()
        {
            if (httpContext != null)
            {
                var currentUser = GetCurrentUser();
                if (currentUser != null && !string.IsNullOrEmpty(currentUser.DepartmentCode))
                {
                    ConnectionString = string.Format(ConnectionString, currentUser.DepartmentCode);
                }
                if (!string.IsNullOrEmpty(ConnectionString))
                {
                    var optionsBuilder = new DbContextOptionsBuilder<CoreUploadDbContext>();
                    optionsBuilder.UseSqlServer(ConnectionString);
                    return new CoreUploadDbContext(optionsBuilder.Options);
                }
            }
            return null;
        }
    }
}
