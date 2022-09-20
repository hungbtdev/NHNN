using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.VDbContext
{
    public class VEventDbContext : CoreDbContext, IVEventDbContext
    {
        public VEventDbContext(DbContextOptions<VEventDbContext> options, IHttpContextAccessor httpContextAccessor, ITenantProvider tenantProvider) : base(options, httpContextAccessor, tenantProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VEvents>(x => x.ToTable("Sys_VEvents"));
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<VEvents> VEvents { get; set; }
    }
}
