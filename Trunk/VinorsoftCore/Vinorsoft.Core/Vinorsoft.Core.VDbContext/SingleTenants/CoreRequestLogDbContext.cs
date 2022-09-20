using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.VDbContext
{
    public class CoreRequestLogDbContext : CoreDbContext, ICoreRequestLogDbContext
    {
        public CoreRequestLogDbContext(DbContextOptions<CoreRequestLogDbContext> options, IHttpContextAccessor httpContextAccessor, ITenantProvider tenantProvider) : base(options, httpContextAccessor, tenantProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoreRequestLogs>(x => x.ToTable("Sys_CoreRequestLogs"));
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CoreRequestLogs> CoreRequestLogs { get; set; }
    }
}
