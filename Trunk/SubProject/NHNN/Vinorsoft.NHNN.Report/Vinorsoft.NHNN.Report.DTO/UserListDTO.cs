using System;
using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.NHNN.Report.DTO
{
    public class UserListDTO : DomainObjectDTO
    {

        public int IdUser { set; get; }

        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_Name), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        [StringLength(maximumLength: 1000, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string Name { set; get; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_FirstName), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        [StringLength(maximumLength: 1000, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string FirstName { set; get; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_LogicalCode), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        [StringLength(maximumLength: 1000, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string LogicalCode { set; get; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_IDNumber), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        [StringLength(maximumLength: 1000, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string IDNumber { set; get; }

        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_CreationDate), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        [StringLength(maximumLength: 1000, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public DateTime CreationDate { set; get; }
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_Cuc), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        [StringLength(maximumLength: 1000, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string Cuc { set; get; }

        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_Phong), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        [StringLength(maximumLength: 1000, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string Phong { set; get; }

        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_ChucVu), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        [StringLength(maximumLength: 1000, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string ChucVu { set; get; }

        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.UserList_Name), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public string FullName
        {
            get
            {
                return $"{FirstName} {Name}";
            }
        }

        /// <summary>
        /// Không tính đi trễ về sớm
        /// </summary>
        /// 
        [Display(Name = nameof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource.AccessHistorical_IsNoCaculate), ResourceType = typeof(Vinorsoft_NHNN_Report_DevEx_DTO_Resource))]
        public bool IsNoCaculate { set; get; }

        public string IsNoCaculateText {
            get
            {
                if (IsNoCaculate)
                {
                    return "X";
                }
                return string.Empty;
            }
        }



        public new int Deleted { set; get; }

        public const string Prefix_THE = "THE";

    }
}
