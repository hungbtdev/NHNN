using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.NHNN.Report.Service.Entities
{
    public class AccessHistorical : VinorsoftDomain
    {
        [Required]
        public DateTime Dat { set; get; }
        public int? IdCircuit { set; get; }
        public string LibelleCircuit { set; get; }
        public string DescriptionCircuit { set; get; }
        public byte? CircType { set; get; }
        public int? IdModeCrise { set; get; }
        public string LibCrise { set; get; }
        public string Nom { set; get; }
        public string Prenom { set; get; }
        public string Codelogique { set; get; }
        public int? IdUsager { set; get; }

        public string LibHisto { get; set; }
        [NotMapped]
        public new int Deleted { set; get; }
    }
}
