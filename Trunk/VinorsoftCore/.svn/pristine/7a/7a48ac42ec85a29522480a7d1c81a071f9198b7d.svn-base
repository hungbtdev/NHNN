namespace KTApps.ProfileService.Entities
{
    using KTApps.Domain;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Quận huyện
    /// </summary>
    public class CatDistricts : KTAppDomainCatalogue
    {
        [ForeignKey("CatCities")]
        public Guid CityId { set; get; }
        public CatCities CatCities { set; get; }
    }
}
