using KTApps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KTApps.Core.App.Models
{
    public class CoreTenantConnectionModel : KTAppDomainModel
    {
        [Required]
        public Guid TenantId { set; get; }
        [Required]
        public Guid ModuleId { set; get; }
        [Required]
        [MaxLength(4000)]
        public string ConectionString { set; get; }
    }
}
