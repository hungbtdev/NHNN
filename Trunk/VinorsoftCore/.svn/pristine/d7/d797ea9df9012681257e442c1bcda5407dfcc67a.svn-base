using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vinorsoft.Core.Context;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Utils;
using Vinorsoft.Core.VDbContext;

namespace Vinorsoft.Core.NotiApp
{
    public static class ServiceExtensions
    {
        public static void AddCoreDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ITenantProvider, DatabaseTenantProvider>();

            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.AddDbContext<AuthDbContext>(x => x.UseSqlServer(configuration.GetConnectionString(nameof(AuthDbContext))));
            services.AddDbContext<CoreConfigDbContext>(x => x.UseSqlServer(configuration.GetConnectionString(nameof(CoreConfigDbContext))));
            services.AddDbContext<CoreUploadDbContext>(x => x.UseSqlServer(configuration.GetConnectionString(nameof(CoreUploadDbContext))));
            services.AddDbContext<NotificationDbContext>(x => x.UseSqlServer(configuration.GetConnectionString(nameof(NotificationDbContext))));
            services.AddDbContext<TenantsDbContext>(x => x.UseSqlServer(configuration.GetConnectionString(nameof(TenantsDbContext))));
            services.AddSingleton<IAuthContext,AuthContext>();
        }
    }
}
