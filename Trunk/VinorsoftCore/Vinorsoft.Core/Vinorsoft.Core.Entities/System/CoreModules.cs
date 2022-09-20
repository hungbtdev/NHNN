using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
    public class CoreModules : VinorsoftCatalogueDomain
    {
        public CoreModules()
        {
            CoreSlidebarItems = new List<CoreSlidebarItems>();
        }

        [Required]
        public int Position { set; get; }
        public IList<CoreSlidebarItems> CoreSlidebarItems { set; get; }
    }
}
