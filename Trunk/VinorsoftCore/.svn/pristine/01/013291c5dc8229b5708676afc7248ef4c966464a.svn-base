using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using DevExpress.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCore.AutoRegisterDi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using Vinorsoft.Core.App;
using Vinorsoft.Core.Context;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.VDbContext;
using Vinorsoft.Core.VDbContext.DataSeeder;
using Vinorsoft.Notification.AutoMapper;

namespace Vinorsoft.Core.NotiApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDevExpressControls();
            services.AddLog(Configuration);
            services.AddLazyCache();
            services.AddCoreService();
            //API
            //services.AddApiCore(Configuration);

            //Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(NotificationAutoMapperProfiles));
            
            //services.AddAutoMapper(typeof(CatalogueProfiles).Assembly);
            //services.AddAutoMapper(typeof(CRMAutoMapperProfile).Assembly);
            //services.AddAutoMapper(typeof(OrderProfiles).Assembly);
            //services.AddAutoMapper(typeof(InventoryProfiles).Assembly);
            //services.AddAutoMapper(typeof(CoreAutoMapperProfiles).Assembly);
            //services.AddAutoMapper(typeof(AutoMapperImportProfile).Assembly);
            //services.AddAutoMapper(typeof(DebtProfiles).Assembly);
            //services.AddAutoMapper(typeof(VAutoMapper).Assembly);
            services.AddCoreDatabase(Configuration);

            var assemblieService = new string[] {
                "Vinorsoft.Core.Interface",
                "Vinorsoft.Core",
                "Vinorsoft.Notify",
                "Vinorsoft.Core.VDbContext",
                "Vinorsoft.Notify.Interface"
            };
            foreach (var assemblyFile in assemblieService)
            {
                services.RegisterAssemblyPublicNonGenericClasses(Assembly.Load(assemblyFile)).Where(c => c.Name.EndsWith("Service") || c.Name.EndsWith("DbContext")).AsPublicImplementedInterfaces();
            }

            var assemblieService2 = new string[] {
                "Vinorsoft.Core",
                "Vinorsoft.Notify",
            };

            IList<Assembly> asems = new List<Assembly>();

            foreach (var assemblyFile in assemblieService2)
            {
                asems.Add(Assembly.Load(assemblyFile));
            }

            services.AddMediatR(asems.ToArray());
            services.AddSingleton<IAuthContext, AuthContext>();
            
            // Add framework services.
            services
               .AddMvc(option => option.EnableEndpointRouting = false)
               .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
               .ConfigureApplicationPartManager(apm =>
                {
                    var assemblies = new string[] {
                        "Vinorsoft.Core.App"
                    };
                    foreach (var assemblyFile in assemblies)
                    {
                        //main assembly
                        var assembly = Assembly.Load(assemblyFile);
                        apm.ApplicationParts.Add(new AssemblyPart(assembly));
                    }
                })
               .AddJsonOptions(options =>
               {
                   options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                   options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                   options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;
                   options.SerializerSettings.StringEscapeHandling = StringEscapeHandling.Default;
               });

            DevExtreme.AspNet.Data.DataSourceLoadOptionsBase.StringToLowerDefault = true;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider, IServiceScopeFactory serviceScopeFactory)
        {
            loggerFactory.AddSerilog();

            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<AuthDbContext>())
                {
                    context.Database.Migrate();
                    AuthDataSeeder.Seed(context);
                }

                using (var context = serviceScope.ServiceProvider.GetRequiredService<CoreConfigDbContext>())
                {
                    context.Database.Migrate();
                }

                using (var context = serviceScope.ServiceProvider.GetRequiredService<CoreUploadDbContext>())
                {
                    context.Database.Migrate();
                }

                using (var context = serviceScope.ServiceProvider.GetRequiredService<NotificationDbContext>())
                {
                    context.Database.Migrate();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var option = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(option.Value);
            app.UsePathBase(Configuration["SubDomain"]); 
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseStaticHttpContext();
            app.UseDevExpressControls();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                      name: "Config",
                      template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseDefaultFiles();
        }
    }
}
