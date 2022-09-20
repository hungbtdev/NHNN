using System;
using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class CoreSlidebarItemDTO : CatalogueObjectDTO
    {
        [Display(Name = nameof(Resources.CoreSlidebarItem_Position), ResourceType = typeof(Resources))]
        public int? Position { set; get; }

        [Display(Name = nameof(Resources.CoreSlidebarItem_Parent), ResourceType = typeof(Resources))]
        public Guid? ParentId { set; get; }

        [Display(Name = nameof(Resources.CoreSlidebarItem_Module), ResourceType = typeof(Resources))]
        public Guid? ModuleId { set; get; }

        [Display(Name = nameof(Resources.CoreSlidebarItem_Icon), ResourceType = typeof(Resources))]
        [StringLength(maximumLength: 255, MinimumLength = 1, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string Icon { set; get; }
        
        [Display(Name = nameof(Resources.CoreSlidebarItem_Url), ResourceType = typeof(Resources))]
        [StringLength(maximumLength: 1000, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string Url { set; get; }
    }
}
