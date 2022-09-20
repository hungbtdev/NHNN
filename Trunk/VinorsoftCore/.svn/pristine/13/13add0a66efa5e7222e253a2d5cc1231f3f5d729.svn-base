using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
    public class PermitObjectSidebars : VinorsoftDomain
    {
        [ForeignKey("PermitObjects")]
        [Required]
        public Guid PermitObjectId { set; get; }

        public string SidebarMenuIds { set; get; }

        public Guid? ModuleId { set; get; }
        public PermitObjects PermitObjects { set; get; }
    }
}
