using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vinorsoft.Core.Entities.Media;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.VDbContext
{
    public class CoreUploadDbContext : CoreDbContext, ICoreUploadDbContext
    {
        public CoreUploadDbContext(DbContextOptions<CoreUploadDbContext> options, IHttpContextAccessor httpContextAccessor, ITenantProvider tenantProvider) : base(options, httpContextAccessor, tenantProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoreUploadFiles>(x => x.ToTable("Sys_CoreUploadFiles"));
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CoreUploadFiles> CoreUploadFiles { get; set; }
    }
}
