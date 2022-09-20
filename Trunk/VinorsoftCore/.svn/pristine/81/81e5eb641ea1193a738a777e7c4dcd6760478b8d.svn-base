using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Models
{
    public class PermitObjectSidebarModel : KTAppDomainModel
    {

        public PermitObjectSidebarModel()
        {
            SidebarIds = new List<string>();
        }

        [Required]
        public Guid PermitObjectId { set; get; }
        public string SidebarMenuIds { set; get; }
        public Guid? ModuleId { set; get; }
        public PermitObjectModel PermitObjects { set; get; }
        public IList<string> SidebarIds { set; get; }

        public void ToModel()
        {
            SidebarMenuIds = string.Join(";", SidebarIds);
        }

        public void Toview()
        {
            if (!string.IsNullOrEmpty(SidebarMenuIds))
            {
                SidebarIds = SidebarMenuIds.Split(";");
            }
        }

    }
}
