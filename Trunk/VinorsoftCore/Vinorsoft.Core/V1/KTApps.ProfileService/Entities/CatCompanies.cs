namespace KTApps.ProfileService.Entities
{
    using KTApps.Domain;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Công ty, nghiệp đoàn, xí nghiệp
    /// </summary>
    public class CatCompanies : KTAppDomainCatalogue
    {
        [Required]
        [ForeignKey("CatCompanyTypes")]
        public Guid CompanyTypeId { set; get; }
        public CatCompanyTypes CatCompanyTypes { set; get; }
    }
}
