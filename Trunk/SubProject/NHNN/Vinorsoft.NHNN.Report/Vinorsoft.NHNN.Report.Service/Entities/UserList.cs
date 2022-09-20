using System;
using System.ComponentModel.DataAnnotations.Schema;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.NHNN.Report.Service.Entities
{
    public class UserList : VinorsoftDomain
    {
        public int IdUser { set; get; }
        public string Name { set; get; }
        public string FirstName { set; get; }
        public string LogicalCode { set; get; }
        public string IDNumber { set; get; }
        public DateTime CreationDate { set; get; }
        public string Cuc { set; get; }
        public string Phong { set; get; }
        public string ChucVu { set; get; }
        [NotMapped]
        public new int Deleted { set; get; }
    }
}
