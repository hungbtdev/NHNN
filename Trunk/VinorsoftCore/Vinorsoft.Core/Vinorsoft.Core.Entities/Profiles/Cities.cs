using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{

    [Table("Cities")]
    public class Cities : VinorsoftCatalogueDomain
    {
        public Cities()
        {
            Districts = new HashSet<Districts>();
        }

        [ForeignKey("Countries")]
        public Guid CountryId { get; set; }
        [ForeignKey("GeoAreas")]
        public Guid? GeoAreaId { get; set; }
        public Countries Countries { get; set; }
        public GeoAreas GeoAreas { get; set; }
        public ICollection<Districts> Districts { get; set; }
    }
}
