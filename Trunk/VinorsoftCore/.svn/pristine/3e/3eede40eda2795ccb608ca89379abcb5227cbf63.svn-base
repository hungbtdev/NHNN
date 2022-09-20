using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
    public class CoreSlidebarItems : VinorsoftCatalogueDomain
    {
        public int? Position { set; get; }
        public Guid? ParentId { set; get; }
        [ForeignKey("CoreModules")]
        public Guid? ModuleId { set; get; }
        [MaxLength(255)]
        public string Icon { set; get; }
        [MaxLength(1000)]
        public string Url { set; get; }
        public CoreModules CoreModules { set; get; }
    }
}
