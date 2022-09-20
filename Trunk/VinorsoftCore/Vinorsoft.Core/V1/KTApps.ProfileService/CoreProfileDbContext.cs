using KTApps.ProfileService.Entities;
using KTApps.ProfileService.Interface;
using Microsoft.EntityFrameworkCore;

namespace KTApps.ProfileService
{
    public class CoreProfileDbContext : DbContext, ICoreProfileDbContext
    {
        public CoreProfileDbContext(DbContextOptions<CoreProfileDbContext> options) : base(options)
        {
        }

        public DbSet<CatAddressTypes> CatAddressTypes { get; set; }
        public DbSet<CatBloodTypes> CatBloodTypes { get; set; }
        public DbSet<CatCities> CatCities { get; set; }
        public DbSet<CatCompanies> CatCompanies { get; set; }
        public DbSet<CatCompanyTypes> CatCompanyTypes { get; set; }
        public DbSet<CatCountries> CatCountries { get; set; }
        public DbSet<CatDegreeTypes> CatDegreeTypes { get; set; }
        public DbSet<CatDistricts> CatDistricts { get; set; }
        public DbSet<CatEducationLevels> CatEducationLevels { get; set; }
        public DbSet<CatEducationStatus> CatEducationStatus { get; set; }
        public DbSet<CatGenders> CatGenders { get; set; }
        public DbSet<CatIdentificationTypes> CatIdentificationTypes { get; set; }
        public DbSet<CatLanguages> CatLanguages { get; set; }
        public DbSet<CatRelationTypes> CatRelationTypes { get; set; }
        public DbSet<CatReligions> CatReligions { get; set; }
        public DbSet<CatSchools> CatSchools { get; set; }
        public DbSet<CatWards> CatWards { get; set; }
        public DbSet<ProfileAddress> ProfileAddress { get; set; }
        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<ProfileDegrees> ProfileDegrees { get; set; }
        public DbSet<ProfileEducationHistories> ProfileEducationHistories { get; set; }
        public DbSet<ProfileHealths> ProfileHealths { get; set; }
        public DbSet<ProfileIdentications> ProfileIdentications { get; set; }
        public DbSet<ProfilePhones> ProfilePhones { get; set; }
        public DbSet<ProfileRelatives> ProfileRelatives { get; set; }
        public DbSet<ProfileWorkingHistories> ProfileWorkingHistories { get; set; }
        public DbSet<CatTattooStatus> CatTattooStatus { get; set; }
        public DbSet<CatMaritalStatus> CatMaritalStatus { get; set; }
        public DbSet<CatPhoneTypes> CatPhoneTypes { get; set; }
        public DbSet<CatMajors> CatMajors { get; set; }
        public DbSet<CatHealthStatus> CatHealthStatus { get; set; }
        public DbSet<CatHands> CatHands { get; set; }
        public DbSet<CatAddress> CatAddress { get; set; }
    }
}
