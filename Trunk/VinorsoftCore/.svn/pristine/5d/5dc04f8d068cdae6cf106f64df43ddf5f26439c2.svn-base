using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.VDbContext
{
    public class AuthDbContext : CoreDbContext, IAuthDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options, 
            IHttpContextAccessor httpContextAccessor, 
            ITenantProvider tenantProvider
            ) : base(options, httpContextAccessor, tenantProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permissions>(x => x.ToTable("Sys_Permissions"));
            modelBuilder.Entity<Users>(x => x.ToTable("Sys_Users"));
            modelBuilder.Entity<UserInGroups>(x => x.ToTable("Sys_UserInGroups"));
            modelBuilder.Entity<UserGroups>(x => x.ToTable("Sys_UserGroups"));
            modelBuilder.Entity<PermitObjectPermissions>(x => x.ToTable("Sys_PermitObjectPermissions"));
            modelBuilder.Entity<PermitObjects>(x => x.ToTable("Sys_PermitObjects"));
            modelBuilder.Entity<PermitObjectSidebars>(x => x.ToTable("Sys_PermitObjectSidebars"));
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserInGroups> UserInGroups { get; set; }
        public DbSet<UserGroups> UserGroups { get; set; }
        public DbSet<PermitObjectPermissions> PermitObjectPermissions { get; set; }
        public DbSet<PermitObjects> PermitObjects { get; set; }
        public DbSet<PermitObjectSidebars> PermitObjectSidebars { get; set; }
    }
}
