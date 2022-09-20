using KTApps.Models;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Core.App.Notifications.Models
{
    public class CoreContentReplaceModel : KTAppDomainModel
    {
        [Required]
        [MaxLength(255)]
        public string OldChars { set; get; }
        [Required]
        [MaxLength(255)]
        public string NewChars { set; get; }
        [Required]
        [MaxLength(1000)]
        public string Description { set; get; }
    }
}
