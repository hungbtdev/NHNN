using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.NHNN.Report.Service.Entities
{
    public class VueHisto
    {
        public System.DateTime Dat { get; set; }
        public Nullable<int> Idcircuit { get; set; }
        public string LibelleCircuit { get; set; }
        public string DescriptionCircuit { get; set; }
        public Nullable<byte> CircType { get; set; }
        public Nullable<int> Idmodecrise { get; set; }
        public string Libcrise { get; set; }
        public Nullable<int> Idronde { get; set; }
        public string Libronde { get; set; }
        public Nullable<int> Idoperateur { get; set; }
        public string LibelleOperateur { get; set; }
        public Nullable<int> Idevenement { get; set; }
        public Nullable<byte> TypeEvenement { get; set; }
        public bool Modedegrade { get; set; }
        public Nullable<int> Parametre { get; set; }
        public string Nomposte { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Nullable<int> Idfamille { get; set; }
        public string Famille { get; set; }
        public Nullable<int> Idsociete { get; set; }
        public Nullable<int> Societe { get; set; }
        public Nullable<int> Idservice { get; set; }
        public Nullable<int> Service { get; set; }
        public Nullable<int> Type { get; set; }
        public string LibBadge { get; set; }
        public string LibHisto { get; set; }
        public string Libequip { get; set; }
        public string Infoalarme { get; set; }
        public Nullable<int> Listerouge { get; set; }
        public Nullable<int> Idcommutationvideo { get; set; }
        public string Libvideo { get; set; }
        public Nullable<int> Idpropriete { get; set; }
        public string Libellepropriete { get; set; }
        public string Codelogique { get; set; }
        public Nullable<byte> Residencetype { get; set; }
        public string NomConfirm { get; set; }
        public string PrenomConfirm { get; set; }
        public Nullable<int> Idusager { get; set; }
    }
}
