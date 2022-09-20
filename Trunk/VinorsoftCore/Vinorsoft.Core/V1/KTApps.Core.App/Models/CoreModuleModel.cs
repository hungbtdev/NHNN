using KTApps.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Core.App.Models
{
    public class CoreModuleModel : KTAppDomainCatalogueModel
    {
        public CoreModuleModel()
        {
            CoreSlidebarItems = new List<CoreSlidebarItemModel>();
        }

        [Required]
        public int Position { set; get; }
        public IList<CoreSlidebarItemModel> CoreSlidebarItems { set; get; }

        public string ActiveCssClass { set; get; }

    }
}
