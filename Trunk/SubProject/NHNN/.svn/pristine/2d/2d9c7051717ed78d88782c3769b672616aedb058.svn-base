
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vinorsoft.Core.Domain;
namespace Vinorsoft.NHNN.Report.Service.Entities
{
    public class Circuit : VinorsoftDomain
    {
        public Circuit()
        {
            Acces = new HashSet<Acces>();
            Historique = new HashSet<Historique>();
        }

        [NotMapped]
        public new Guid Id { get; set; }
        [NotMapped]
        public new DateTime Created { get; set; }
        [NotMapped]
        public new DateTime? Updated { get; set; }
        [NotMapped]
        public new bool Deleted { get; set; }
        [NotMapped]
        public new string CreatedBy { get; set; }
        [NotMapped]
        public new string UpdatedBy { get; set; }
        [NotMapped]
        public new bool Active { get; set; }

        [Key]
        public int Idcircuit { get; set; }
        public ICollection<Acces> Acces { get; set; }
        public ICollection<Historique> Historique { get; set; }
    }
}
