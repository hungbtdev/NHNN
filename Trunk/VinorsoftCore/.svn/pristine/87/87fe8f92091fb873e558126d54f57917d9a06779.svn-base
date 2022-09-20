using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Models
{

    public class PermitObjectModel : KTAppDomainCatalogueModel
    {
        public PermitObjectModel()
        {
            PermitObjectSidebars = new List<PermitObjectSidebarModel>();
            Controllers = new List<string>();
        }
        public IList<PermitObjectSidebarModel> PermitObjectSidebars { set; get; }

        public string ControllerNames { set; get; }

        public IList<string> Controllers { set; get; }

        public void ToModel()
        {
            ControllerNames = string.Join(";", Controllers);
        }

        public void Toview()
        {
            if (!string.IsNullOrEmpty(ControllerNames))
            {
                Controllers = ControllerNames.Split(";");
            }
        }
    }
}
