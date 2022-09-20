using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class CoreModuleDTO : CatalogueObjectDTO
    {
        public CoreModuleDTO()
        {
            CoreSlidebarItems = new List<CoreSlidebarItemDTO>();
        }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Resources.CoreModule_Position), ResourceType = typeof(Resources))]
        public int Position { set; get; }

        public IList<CoreSlidebarItemDTO> CoreSlidebarItems { set; get; }
    }
}
