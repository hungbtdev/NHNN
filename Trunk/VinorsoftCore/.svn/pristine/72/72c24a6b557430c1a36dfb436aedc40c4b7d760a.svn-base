using System;
using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class PermitObjectSidebarDTO : DomainObjectDTO
    {
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.PermitObjectSidebar_PermitObject), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        public Guid PermitObjectId { set; get; }

        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.PermitObjectSidebar_SidebarMenu), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        public string SidebarMenuIds { set; get; }

        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.PermitObjectSidebar_Module), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        public Guid? ModuleId { set; get; }
        public PermitObjectDTO PermitObjects { set; get; }
    }
}
