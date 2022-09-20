using System;
using System.ComponentModel.DataAnnotations.Schema;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
    [Table("Wards")]
    public class Wards : VinorsoftCatalogueDomain
    {
        [ForeignKey("Districts")]
        public Guid DistrictId { get; set; }
        public Districts Districts { get; set; }
    }
}
