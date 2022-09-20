using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
    [Table("Districts")]
    public class Districts : VinorsoftCatalogueDomain
    {
        public Districts()
        {
            Wards = new HashSet<Wards>();
        }
    
        [ForeignKey("Cities")]
        public Guid CityId { get; set; }
        public Cities Cities { get; set; }
        public ICollection<Wards> Wards { get; set; }
    }
}
