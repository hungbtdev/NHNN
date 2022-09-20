using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.VDbContext
{
    public class TenantsDbContext : CoreDbContext, ITenantsDbContext
    {
        public TenantsDbContext(DbContextOptions<TenantsDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options, httpContextAccessor, null)
        {
        }

        public DbSet<Tenants> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenants>(x => x.ToTable("Sys_Tenants"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
