using KTApps.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KTApps.ShareService.Entities
{
    public class CoreTenants : KTAppDomainCatalogue
    {
        public CoreTenants()
        {
            CoreTenantConnections = new List<CoreTenantConnections>();
        }

        [Required]
        [MaxLength(1000)]
        public Guid RefId { set; get; }
        public IList<CoreTenantConnections> CoreTenantConnections { set; get; }
    }
}
