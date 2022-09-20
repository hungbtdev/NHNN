using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public abstract class CatalogueObjectDTO : DomainObjectDTO
    {
        public CatalogueObjectDTO() : base()
        {

        }
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Resources.CatalogueObject_Code), ResourceType = typeof(Resources))]
        [StringLength(maximumLength: 255, MinimumLength = 1, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string Code { set; get; }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Resources.CatalogueObject_Name), ResourceType = typeof(Resources))]
        [StringLength(maximumLength: 255, MinimumLength = 1, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string Name { set; get; }

        [StringLength(maximumLength: 1000, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Resources.CatalogueObject_Description), ResourceType = typeof(Resources))]
        public string Description { set; get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
