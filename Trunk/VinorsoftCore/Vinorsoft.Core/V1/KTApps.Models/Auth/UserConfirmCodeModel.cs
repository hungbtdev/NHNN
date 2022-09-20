using System;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Models
{
    public class UserConfirmCodeModel : KTAppDomainModel
    {
        [Required]
        public Guid UserId { set; get; }
        [Required]
        public Guid StatusId { set; get; }
        [Required]
        public Guid ConfirmTypeId { set; get; }
        [Required]
        public string ConfirmCode { set; get; }
        [Required]
        public DateTime Issued { set; get; }
        [Required]
        public DateTime Expired { set; get; }

        public UserModel Users { set; get; }
        public UserConfirmStatusModel UserConfirmStatus { set; get; }
        public UserConfirmTypeModel UserConfirmTypes { set; get; }
    }
}
