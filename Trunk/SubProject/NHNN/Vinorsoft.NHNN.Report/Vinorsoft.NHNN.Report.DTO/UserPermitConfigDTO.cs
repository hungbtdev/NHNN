using System;
using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.NHNN.Report.DTO
{
    public class UserPermitConfigDTO : DomainObjectDTO
    {
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserPermitConfig_Id), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        public Guid UserId { set; get; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_Phong), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        public string DeptName { set; get; }
    }
}
