using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class TenantDTO : DomainObjectDTO
    {
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Resources.Tenant_Name), ResourceType = typeof(Resources))]
        [DataType(DataType.DateTime, ErrorMessageResourceName = nameof(Resources.DataType_Invalid), ErrorMessageResourceType = typeof(Resources))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Resources.Tenant_HostName), ResourceType = typeof(Resources))]
        [DataType(DataType.DateTime, ErrorMessageResourceName = nameof(Resources.DataType_Invalid), ErrorMessageResourceType = typeof(Resources))]
        public string HostName { get; set; }
    }
}
