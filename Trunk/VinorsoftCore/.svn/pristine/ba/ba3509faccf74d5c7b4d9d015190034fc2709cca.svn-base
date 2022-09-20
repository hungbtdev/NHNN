using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.ShareService.Entities
{
    public class CoreSlidebarItems : KTAppDomainCatalogue
    {
        public int? Position { set; get; }
        public Guid? ParentId { set; get; }
        [ForeignKey("CoreModules")]
        public Guid? ModuleId { set; get; }
        [MaxLength(255)]
        public string Icon { set; get; }
        [MaxLength(1000)]
        public string Url { set; get; }
        public string Roles { set; get; }
        public CoreModules CoreModules { set; get; }
    }
}
