using KTApps.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KTApps.AuthService.Entities
{
    public class UserConfirmCodes : KTAppDomain
    {
        [Required]
        [ForeignKey("Users")]
        public Guid UserId { set; get; }
        [Required]
        [ForeignKey("UserConfirmStatus")]
        public Guid StatusId { set; get; }
        [Required]
        [ForeignKey("UserConfirmTypes")]
        public Guid ConfirmTypeId { set; get; }
        [Required]
        public string ConfirmCode { set; get; }
        [Required]
        public DateTime Issued { set; get; }
        [Required]
        public DateTime Expired { set; get; }

        public Users Users { set; get; }
        public UserConfirmStatus UserConfirmStatus { set; get; }
        public UserConfirmTypes UserConfirmTypes { set; get; }
    }
}
