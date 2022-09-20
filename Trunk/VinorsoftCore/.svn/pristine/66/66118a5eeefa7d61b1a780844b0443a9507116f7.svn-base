using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class SendLogDTO : DomainObjectDTO
    {
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

        [Display(Name = nameof(Resources.TemplateType), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        public int TemplateType { set; get; }

        [Display(Name = nameof(Resources.From), ResourceType = typeof(Resources))]
        public string From { set; get; }

        [Display(Name = nameof(Resources.To), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        public string To { set; get; }

        [Display(Name = nameof(Resources.StartDate), ResourceType = typeof(Resources))]
        public DateTime? StartDate { set; get; }
        [Display(Name = nameof(Resources.EndDate), ResourceType = typeof(Resources))]
        public DateTime? EndDate { set; get; }
        [Display(Name = nameof(Resources.Success), ResourceType = typeof(Resources))]
        public bool Success { set; get; }
        [Display(Name = nameof(Resources.Error), ResourceType = typeof(Resources))]
        public string Error { set; get; }
        [Display(Name = nameof(Resources.Opened), ResourceType = typeof(Resources))]
        public string Opened { set; get; }

    }
}
