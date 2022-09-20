using KTApps.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Core.App.Models
{
    public class CoreSlidebarItemModel : KTAppDomainCatalogueModel
    {
        public CoreSlidebarItemModel()
        {
        }
        public int? Position { set; get; }
        public Guid? ParentId { set; get; }
        public Guid? ModuleId { set; get; }
        [MaxLength(255)]
        public string Icon { set; get; }
        [MaxLength(1000)]
        public string Url { set; get; }
        public CoreModuleModel CoreModules { set; get; }
        public bool ActiveLink { set; get; }
    }
}
