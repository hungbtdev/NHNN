using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
    [Table("GeoAreas")]
    public class GeoAreas : VinorsoftCatalogueDomain
    {
        public GeoAreas()
        {
            Cities = new HashSet<Cities>();
        }
        public ICollection<Cities> Cities { get; set; }
    }
}
