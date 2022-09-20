using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.VDbContext
{
    public class ProfileDbContext: CoreDbContext, IProfileDbContext
    {
        public ProfileDbContext(DbContextOptions<ProfileDbContext> options, IHttpContextAccessor httpContextAccessor, ITenantProvider tenantProvider) : base(options, httpContextAccessor, tenantProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Cities>(x => x.ToTable("Prf_Cities"));
                modelBuilder.Entity<Countries>(x => x.ToTable("Prf_Countries"));
                modelBuilder.Entity<Districts>(x => x.ToTable("Prf_Districts"));
                modelBuilder.Entity<GeoAreas>(x => x.ToTable("Prf_GeoAreas"));
                modelBuilder.Entity<Profiles>(x => x.ToTable("Prf_Profiles"));
                modelBuilder.Entity<Wards>(x => x.ToTable("Prf_Wards"));

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cities> Cities { set; get; }
        public DbSet<Countries> Countries { set; get; }
        public DbSet<Districts> Districts { set; get; }
        public DbSet<GeoAreas> GeoAreas { set; get; }
        public DbSet<Profiles> Profiles { set; get; }
        public DbSet<Wards> Wards { set; get; }
    }
}
