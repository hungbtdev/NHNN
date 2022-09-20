namespace KTApps.ProfileService.Entities
{
    using KTApps.Domain;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Thành phố
    /// </summary>
    public class CatCities : KTAppDomainCatalogue
    {
        [ForeignKey("CatCountries")]
        public Guid CountryId { set; get; }
        public CatCountries CatCountries { set; get; }     
        public CityRegions CityRegions { get; set; }
    }
}
