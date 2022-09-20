using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
    public class PermitObjects : VinorsoftCatalogueDomain
    {
        public PermitObjects()
        {
            PermitObjectSidebars = new List<PermitObjectSidebars>();
        }
        public IList<PermitObjectSidebars> PermitObjectSidebars { set; get; }

        //[Required]
        public string ControllerNames { set; get; }
    }
}
