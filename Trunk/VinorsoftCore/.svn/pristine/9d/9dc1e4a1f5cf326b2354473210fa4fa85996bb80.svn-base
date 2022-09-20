using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
  
    [Table("Countries")]
    public class Countries : VinorsoftCatalogueDomain
    {
        public Countries()
        {
            Cities = new HashSet<Cities>();
        }
    
        public ICollection<Cities> Cities { get; set; }
    }
}
