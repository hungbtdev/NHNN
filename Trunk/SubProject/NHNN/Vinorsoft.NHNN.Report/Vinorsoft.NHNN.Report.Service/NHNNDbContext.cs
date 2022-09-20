using Microsoft.EntityFrameworkCore;
using Vinorsoft.NHNN.Report.Service.Entities;
using Vinorsoft.NHNN.Report.Service.Interface;

namespace Vinorsoft.NHNN.Report.Service
{
    public class NHNNDbContext : DbContext, INHNNDbContext
    {
        public NHNNDbContext(DbContextOptions<NHNNDbContext> options) : base(options)
        {
        }
        public DbQuery<UserViewDetail> UserViewDetail { get; set; }
        public DbQuery<UserViewList> UserViewList { get; set; }
        public DbSet<UserConfigs> UserConfigs { get; set; }
        public DbSet<UserPermitConfigs> UserPermitConfigs { get; set; }
        public DbQuery<VwLogAccess> VwLogAccesses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Query<UserViewList>().ToView("VwEmp_GetAll_V2");
            //modelBuilder.Query<UserViewDetail>().ToView("VwEmp_LogAccess_V2");
            //modelBuilder.Query<VwLogAccess>().ToView("VwEmp_LogAccess_V2");

            modelBuilder.Query<UserViewList>().ToView("VwEmp_GetAll_Alizes");
            modelBuilder.Query<UserViewDetail>().ToView("VwEmp_LogAccess_Alizes");
            modelBuilder.Query<VwLogAccess>().ToView("VwEmp_LogAccess_Alizes");

            modelBuilder.Entity<UserConfigs>(x => x.ToTable("SecP_UserConfigs"));
            modelBuilder.Entity<UserPermitConfigs>(x => x.ToTable("SecP_UserPermitConfigs"));
        }

    }
}
