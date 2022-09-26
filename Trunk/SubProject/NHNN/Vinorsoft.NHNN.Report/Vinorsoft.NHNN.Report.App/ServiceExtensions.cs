using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Vinorsoft.Core;
using Vinorsoft.Core.Context;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Utils;
using Vinorsoft.Core.VDbContext;
using Vinorsoft.NHNN.Report.Service;

namespace Vinorsoft.NHNN.Report.App
{
    public static class ServiceExtensions
    {
        public static void AddCoreDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.AddSingleton<IAuthContext, AuthContext>();
            services.AddTransient<ITenantProvider, DatabaseTenantProvider>();
            services.AddScoped<ITenantsDbContext, TenantsDbContext>();


            #region Migration
            services.AddDbContext<AuthDbContext>(x => x.UseSqlServer(configuration.GetConnectionString(nameof(NHNNDbContext)), opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)));
            services.AddDbContext<CoreConfigDbContext>(x => x.UseSqlServer(configuration.GetConnectionString(nameof(NHNNDbContext)), opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)));
            services.AddDbContext<CoreUploadDbContext>(x => x.UseSqlServer(configuration.GetConnectionString(nameof(NHNNDbContext)), opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)));
            services.AddDbContext<NHNNDbContext>(x => x.UseSqlServer(configuration.GetConnectionString(nameof(NHNNDbContext)), opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)));
            services.AddDbContext<ProfileDbContext>(x => x.UseSqlServer(configuration.GetConnectionString(nameof(NHNNDbContext)), opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)));
            services.AddDbContext<NotificationDbContext>(x => x.UseSqlServer(configuration.GetConnectionString(nameof(NHNNDbContext)), opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)));
            services.AddDbContext<TenantsDbContext>(x => x.UseSqlServer(configuration.GetConnectionString(nameof(NHNNDbContext)), opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)));
            #endregion
        }

        public static void MigrationDatabase(this IServiceProvider services, IConfiguration configuration)
        {
            using (var context = services.GetRequiredService<AuthDbContext>())
            {
                context.Database.Migrate();
            }

            using (var context = services.GetRequiredService<CoreConfigDbContext>())
            {
                context.Database.Migrate();
            }

            using (var context = services.GetRequiredService<CoreUploadDbContext>())
            {
                context.Database.Migrate();
            }

            using (var context = services.GetRequiredService<NHNNDbContext>())
            {
                context.Database.Migrate();
            }

            using (var context = services.GetRequiredService<TenantsDbContext>())
            {
                context.Database.Migrate();
            }
        }
    }
}
