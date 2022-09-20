using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.AuthService.Entities
{
    public class PermitObjectSidebars : KTAppDomain
    {
        [ForeignKey("PermitObjects")]
        [Required]
        public Guid PermitObjectId { set; get; }

        public string SidebarMenuIds { set; get; }

        public Guid? ModuleId { set; get; }
        public PermitObjects PermitObjects { set; get; }
    }
}
