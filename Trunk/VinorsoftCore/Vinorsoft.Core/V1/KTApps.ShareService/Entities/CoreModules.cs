using KTApps.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KTApps.ShareService.Entities
{
    public class CoreModules : KTAppDomainCatalogue
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
