using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KTApps.Models
{
    public class KTAppDomainModel
    {
        public KTAppDomainModel()
        {
            Created = DateTime.Now;
            Id = Guid.NewGuid();
        }

        [Required]
        public Guid Id { get; set; }
        [Required]
        public bool Deleted { get; set; }
        public DateTime Created { set; get; }
        public string CreatedBy { set; get; }
        public DateTime? Updated { set; get; }
        public string UpdatedBy { set; get; }
        public bool Active { set; get; }

    }
}
