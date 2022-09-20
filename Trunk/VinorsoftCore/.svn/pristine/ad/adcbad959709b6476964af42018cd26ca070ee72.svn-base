using KTApps.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KTApps.AuthService.Entities
{
    public class PermitObjects : KTAppDomainCatalogue
    {
        public PermitObjects()
        {
            PermitObjectSidebars = new List<PermitObjectSidebars>();
        }
        public IList<PermitObjectSidebars> PermitObjectSidebars { set; get; }

        [Required]
        public string ControllerNames { set; get; }
    }
}
