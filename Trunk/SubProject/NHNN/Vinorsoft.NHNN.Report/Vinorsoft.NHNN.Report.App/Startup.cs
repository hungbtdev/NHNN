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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetCore.AutoRegisterDi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using Vinorsoft.Core.App;
using Vinorsoft.NHNN.Report.App.Automapper;

namespace Vinorsoft.NHNN.Report.App
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
            services.AddMemoryCache();
            //Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(CoreAutoMapperProfiles).Assembly);
            services.AddAutoMapper(typeof(NHNNAutoMapperProfile).Assembly);

            var assemblieService = Configuration.GetSection("AppSettings:RegisterAssembly").AsEnumerable()
                    .Where(e => !string.IsNullOrEmpty(e.Value)).Select(e => e.Value).ToList();
            foreach (var assemblyFile in assemblieService)
            {
                services.RegisterAssemblyPublicNonGenericClasses(Assembly.Load(assemblyFile)).Where(c => c.Name.EndsWith("Service") || (c.Name.EndsWith("DbContext") && !c.Name.StartsWith("M"))).AsPublicImplementedInterfaces();
            }

            IList<Assembly> asems = new List<Assembly>();
            var asemsMediatR = Configuration.GetSection("AppSettings:MediatR").AsEnumerable()
                    .Where(e => !string.IsNullOrEmpty(e.Value)).Select(e => e.Value).ToList();

            foreach (var assemblyFile in asemsMediatR)
            {
                asems.Add(Assembly.Load(assemblyFile));
            }
            if (asems.Count > 0)
            {
                services.AddMediatR(asems.ToArray());
            }

            // Add framework services.
            services
               .AddMvc(option => option.EnableEndpointRouting = false)
               .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
               .ConfigureApplicationPartManager(apm =>
               {
                   var assemblies = Configuration.GetSection("AppSettings:ApplicationPartManager").AsEnumerable()
                   .Where(e => !string.IsNullOrEmpty(e.Value)).Select(e => e.Value).ToList();
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

            services.AddCoreDatabase(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            loggerFactory.AddSerilog();

            serviceProvider.MigrationDatabase(Configuration);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UsePathBase(Configuration["AppSettings:SubDomain"]);
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
