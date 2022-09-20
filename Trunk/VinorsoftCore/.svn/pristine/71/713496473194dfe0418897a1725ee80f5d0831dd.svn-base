using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class PermitObjectDTO : CatalogueObjectDTO
    {
        public PermitObjectDTO()
        {
            PermitObjectSidebars = new List<PermitObjectSidebarDTO>();
        }
        public IList<PermitObjectSidebarDTO> PermitObjectSidebars { set; get; }

        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.PermitObject_ControllerName), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
      //  [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        public string ControllerNames { set; get; }

        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.PermitObject_ControllerName), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        public string[] ControllerList { set; get; }

        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.PermitObject_SelectedSidebars), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        public IList<Guid> SelectedSidebars { set; get; }


        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.PermitObject_SelectedSidebars), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        public IList<Guid> DisplayGridSidebars {
            get
            {
                var result = new List<Guid>();
                foreach (var item in PermitObjectSidebars)
                {
                    if(!string.IsNullOrEmpty(item.SidebarMenuIds))
                    {
                        result.AddRange(item.SidebarMenuIds.Split(new char[] { ',', ';' }).Select(e => Guid.Parse(e)));
                    }
                }
                return result;
            }
        }


        public void ToValue(IList<PermitObjectSidebarDTO> sidebars)
        {
            var permitObject = this;
            if (permitObject.ControllerList != null && permitObject.ControllerList.Length > 0)
            {
                permitObject.ControllerNames = string.Join(",", permitObject.ControllerList);
            }
            if (permitObject.SelectedSidebars != null && permitObject.SelectedSidebars.Count > 0)
            {
                var sidebarGroups = sidebars.Where(e => permitObject.SelectedSidebars.Contains(e.Id))
                    .GroupBy(e => new
                    {
                        e.ModuleId,
                    });

                permitObject.PermitObjectSidebars = sidebarGroups.Select(e => new PermitObjectSidebarDTO()
                {
                    Id = Guid.NewGuid(),
                    Created = DateTime.Now,
                    PermitObjectId = permitObject.Id,
                    SidebarMenuIds = string.Join(",", e.Select(s => s.Id)),
                    ModuleId = e.Key.ModuleId,
                }).ToList();
            }
        }
    }
}
