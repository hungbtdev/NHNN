using KTApps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Core.App.Models
{
    public class CoreTenantModel : KTAppDomainCatalogueModel
    {
        public CoreTenantModel()
        {
            CoreTenantConnections = new List<CoreTenantConnectionModel>();
        }
        [Required]
        public Guid RefId { set; get; }
        public IList<CoreTenantConnectionModel> CoreTenantConnections { set; get; }
    }
}
