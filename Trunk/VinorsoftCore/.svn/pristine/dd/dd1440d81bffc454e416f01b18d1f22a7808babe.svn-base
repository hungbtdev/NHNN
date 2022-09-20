using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class BaseTemplateDTO : DomainObjectDTO
    {
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Resources.CatalogueObject_Code), ResourceType = typeof(Resources))]
        [StringLength(maximumLength: 255, MinimumLength = 1, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string Code { set; get; }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Resources.Subject), ResourceType = typeof(Resources))]
        [StringLength(maximumLength: 1000, MinimumLength = 1, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string Subject { set; get; }

        [Display(Name = nameof(Resources.TemplateBody), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        public string Body { set; get; }

        [Display(Name = nameof(Resources.AppName), ResourceType = typeof(Resources))]
        [StringLength(maximumLength: 1000, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string AppName { set; get; }

        //[Display(Name = nameof(Resources.TemplateType), ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        //public string Discriminator { set; get; }
    }
}
