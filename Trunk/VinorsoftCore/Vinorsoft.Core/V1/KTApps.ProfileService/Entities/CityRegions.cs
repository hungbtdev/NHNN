using KTApps.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KTApps.ProfileService.Entities
{
   public class CityRegions: KTAppDomain
    {
        [ForeignKey("Cities")]
        public Guid CityId { get; set; }
        public CatCities Cities { get; set; }

        [ForeignKey("Regions")]
        public Guid RegionId { get; set; }
        public CatRegions Regions { get; set; }
    }
}
