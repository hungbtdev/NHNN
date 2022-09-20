using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.ProfileService.Entities
{
    /// <summary>
    /// Phường xã
    /// </summary>
    public class CatWards : KTAppDomainCatalogue
    {
        [ForeignKey("CatDistricts")]
        public Guid DistrictId { set; get; }
        public CatDistricts CatDistricts { set; get; }
    }
}
