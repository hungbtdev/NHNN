using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Claims;
using Vinorsoft.Core.Domain;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.VDbContext
{
    public abstract class CoreDbContext : DbContext
    {
        protected readonly IHttpContextAccessor httpContextAccessor;
        protected readonly ITenantProvider tenantProvider;
        public CoreDbContext(DbContextOptions options,
            IHttpContextAccessor httpContextAccessor,
            ITenantProvider tenantProvider) : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.tenantProvider = tenantProvider;
        }

        protected AuditUser CurrentUser
        {
            get
            {
                if (httpContextAccessor != null && httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.User != null && httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    var claim = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.UserData);
                    if (claim != null)
                    {
                        return JsonConvert.DeserializeObject<AuditUser>(claim.Value);
                    }
                }
                return null;
            }
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            var addedItems = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
            var modified = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
            foreach (var item in addedItems)
            {
                if (item.Entity is VinorsoftDomain entity)
                {
                    if (CurrentUser != null)
                        item.CurrentValues[nameof(entity.CreatedBy)] = CurrentUser.UserName;
                    if (tenantProvider != null && tenantProvider.GetTenantId().HasValue)
                    {
                        item.CurrentValues[nameof(entity.TenantId)] = tenantProvider.GetTenantId();
                    }

                    item.CurrentValues[nameof(entity.Created)] = DateTime.Now;
                }
            }

            foreach (var item in modified)
            {
                if (item.Entity is VinorsoftDomain entity)
                {
                    if (CurrentUser != null)
                        item.CurrentValues[nameof(entity.UpdatedBy)] = CurrentUser.UserName;

                    if (tenantProvider != null && tenantProvider.GetTenantId().HasValue)
                    {
                        item.CurrentValues[nameof(entity.TenantId)] = tenantProvider.GetTenantId();
                    }

                    item.CurrentValues[nameof(entity.Updated)] = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }

    public class AuditUser
    {
        public Guid UserId { set; get; }
        public string UserName { set; get; }
        public string FullName { set; get; }
    }

}
