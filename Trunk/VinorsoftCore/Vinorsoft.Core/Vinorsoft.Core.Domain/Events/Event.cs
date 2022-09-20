using System;
using System.ComponentModel.DataAnnotations;

namespace Vinorsoft.Core.Domain.Events
{
    public class Event : VinorsoftDomain
    {
        [Required]
        public string Type { set; get; }
        [Required]
        public string DataJson { set; get; }
        public string Description { set; get; }
        public Guid? RefId { set; get; }
        public Guid? RefId1 { set; get; }
        public Guid? RefId2 { set; get; }
        public Guid? RefId3 { set; get; }
    }
}
