using AutoMapper;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Entities;

namespace Vinorsoft.Core.App
{
    public class CoreAutoMapperProfiles : Profile
    {
        public CoreAutoMapperProfiles()
        {
            CreateMap<CorePageTitles, CorePageTitleDTO>().ReverseMap().MaxDepth(1);
            CreateMap<CoreModules, CoreModuleDTO>().ReverseMap().MaxDepth(1);
            CreateMap<CoreSlidebarItems, CoreSlidebarItemDTO>().ReverseMap().MaxDepth(1);
            CreateMap<CoreSystemConfigs, CoreSystemConfigDTO>().ReverseMap().MaxDepth(1);
            CreateMap<UserGroupDTO, UserGroups>().ReverseMap().MaxDepth(1);
            CreateMap<PermitObjectPermissionDTO, PermitObjectPermissions>().ReverseMap().MaxDepth(1);
            CreateMap<UserInGroupDTO, UserInGroups>().ReverseMap().MaxDepth(1);
            CreateMap<PermissionDTO, Permissions>().ReverseMap().MaxDepth(1);
            CreateMap<PermitObjectDTO, PermitObjects>().ReverseMap().MaxDepth(1);
            CreateMap<PermitObjectSidebarDTO, PermitObjectSidebars>().ReverseMap().MaxDepth(1);
            CreateMap<TenantDTO, Tenants>().ReverseMap().MaxDepth(1);
            CreateMap<UserDTO, Users>()
                .ForMember(e=>e.UserGroupIds, d=>d.Ignore()).MaxDepth(1);
            CreateMap<Users, UserDTO>()
              .ForMember(e => e.UserGroupIds, d => d.Ignore()).MaxDepth(1);
        }
    }
}
