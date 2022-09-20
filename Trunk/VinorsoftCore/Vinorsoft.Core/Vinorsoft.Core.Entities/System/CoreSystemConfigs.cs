using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
    public class CoreSystemConfigs : VinorsoftCatalogueDomain
    {
        [MaxLength(1000)]
        [Required]
        public string Value { set; get; }
    }
}
