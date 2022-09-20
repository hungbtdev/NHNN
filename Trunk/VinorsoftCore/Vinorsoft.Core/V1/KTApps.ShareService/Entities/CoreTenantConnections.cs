using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.ShareService.Entities
{
    public class CoreTenantConnections : KTAppDomain
    {
        [ForeignKey("CoreTenants")]
        [Required]
        public Guid TenantId { set; get; }
        [ForeignKey("CoreModules")]
        [Required]
        public Guid ModuleId { set; get; }
        [Required]
        [MaxLength(4000)]
        public string ConectionString { set; get; }
        public CoreModules CoreModules { set; get; }
        public CoreTenants CoreTenants { set; get; }
    }
}
