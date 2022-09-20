using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KTApps.Core.App.Models
{
    public class ResendActiveCodeModel
    {
        [Required]
        public string UserName { set; get; }
        [Required]
        public string ConfirmTypeCode { set; get; }
        public string Phone { get; set; }
    }
}
