using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using System;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Utils;
using Vinorsoft.Core.VDbContext;

namespace Vinorsoft.Core.App
{
    public static class ServiceExtensions
    {
        public static void AddSystemConfigService(this IServiceCollection services)
        {
            services.AddScoped<ICorePageTitleService, CorePageTitleService>();
            services.AddScoped<ICoreModuleService, CoreModuleService>();
            services.AddScoped<ICoreSystemConfigService, CoreSystemConfigService>();
            services.AddScoped<ICoreSlidebarItemService, CoreSlidebarItemService>();
            services.AddScoped<ICoreConfigDbContext, CoreConfigDbContext>();
        }

        public static void AddAuthService(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IAuthDbContext, AuthDbContext>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserGroupService, UserGroupService>();
            services.AddScoped<IPermitObjectService, PermitObjectService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IPermitObjectPermissionService, PermitObjectPermissionService>();
        }

        public static void AddCoreService(this IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] {
                    new CultureInfo("vi-VN"),
                    new CultureInfo("vi")
                };

                options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(async context =>
                {
                    return await Task.FromResult(new ProviderCultureResult("vi"));
                }));

                options.DefaultRequestCulture = new RequestCulture(culture: "vi-VN", uiCulture: "vi-VN");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options =>
              {
                  options.LoginPath = new PathString("/System/Login");
                  options.AccessDeniedPath = new PathString("/Error/403");
                  options.Cookie.Name = typeof(ServiceExtensions).GetType().Namespace;
                  options.ExpireTimeSpan = TimeSpan.FromHours(8);
                  options.Cookie.Expiration = TimeSpan.FromHours(8);
              });

            // API 
            services.AddCors();

            services
                .AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddViewLocalization(option =>
                {
                    option.ResourcesPath = "Resources";
                })
                .AddDataAnnotationsLocalization()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                });
        }

        public static void AddApiCore(this IServiceCollection services, IConfiguration configuration)
        {
            // configure strongly typed settings objects
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                //x.Audience = configuration["Jwt:Audience"];
                //x.ClaimsIssuer = configuration["Jwt:Issuer"];
                //x.Authority = configuration["Jwt:Authority"];
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidIssuer = configuration["Jwt:Issuer"],
                };
            });

        }

        public static void AddLog(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
           .ReadFrom.Configuration(configuration)
           .CreateLogger();
        }
    }
}
