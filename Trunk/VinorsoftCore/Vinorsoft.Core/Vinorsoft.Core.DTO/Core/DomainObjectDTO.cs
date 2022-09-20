using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vinorsoft.Core.Domain;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class DomainObjectDTO : VinorsoftDomain
    {
        public DomainObjectDTO() : base()
        {

        }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Resources.DomainObject_Id), ResourceType = typeof(Resources))]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public virtual new Guid Id { set; get; }

        //[Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Resources.DomainObject_Created), ResourceType = typeof(Resources))]
        [DataType(DataType.DateTime, ErrorMessageResourceName = nameof(Resources.DataType_Invalid), ErrorMessageResourceType = typeof(Resources))]
        public virtual new DateTime Created { set; get; }

        [Required]
        public virtual new bool Deleted { set; get; }

        [Display(Name = nameof(Resources.DomainObject_Updated), ResourceType = typeof(Resources))]
        [DataType(DataType.DateTime, ErrorMessageResourceName = nameof(Resources.DataType_Invalid), ErrorMessageResourceType = typeof(Resources))]
        public virtual new DateTime? Updated { set; get; }

        [Display(Name = nameof(Resources.DomainObject_CreatedBy), ResourceType = typeof(Resources))]
        [StringLength(maximumLength: 1000, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public virtual new string CreatedBy { set; get; }

        [Display(Name = nameof(Resources.DomainObject_UpdatedBy), ResourceType = typeof(Resources))]
        [StringLength(maximumLength: 1000, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public virtual new string UpdatedBy { set; get; }

        [Required]
        [Display(Name = nameof(Resources.DomainObject_Active), ResourceType = typeof(Resources))]
        public virtual new bool Active { set; get; }
    }
}
