using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using Microsoft.EntityFrameworkCore;

namespace KTApps.AuthService
{
    public class AuthContext : DbContext, IAuthDbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserInGroups> UserInGroups { get; set; }
        public DbSet<UserGroups> UserGroups { get; set; }
        public DbSet<Areas> Areas { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<JobTitles> JobTitles { get; set; }
        public DbSet<DepartmentTypes> DepartmentTypes { get; set; }
        public DbSet<UserDepartments> UserDepartments { get; set; }
        public DbSet<PermitObjectPermissions> PermitObjectPermissions { get; set; }
        public DbSet<PermitObjects> PermitObjects { get; set; }
        public DbSet<PermitObjectSidebars> PermitObjectSidebars { get; set; }
        public DbSet<UserConfirmCodes> UserConfirmCodes { get; set; }
        public DbSet<UserConfirmStatus> UserConfirmStatus { get; set; }
        public DbSet<UserConfirmTypes> UserConfirmTypes { get; set; }

    }
}
