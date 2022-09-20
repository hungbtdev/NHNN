using AutoMapper;
using KTApps.AuthService.Entities;
using KTApps.Core.App.Models;
using KTApps.Core.Paging;
using KTApps.Models;
using KTApps.Models.Auth;
using KTApps.ShareService.Entities;

namespace KTApps.Core.App
{
    public class DomainMapperProfiles : Profile
    {
        public DomainMapperProfiles()
        {
            CreateMap<Permissions, PermissionModel>().ReverseMap();
            CreateMap<Permissions, PermissionModel>().ReverseMap();
            CreateMap<PermitObjects, PermitObjectModel>().ReverseMap();
            CreateMap<PermitObjectSidebars, PermitObjectSidebarModel>().ReverseMap();
            CreateMap<PermitObjectPermissions, PermitObjectPermissionModel>().ReverseMap();
            CreateMap<Departments, DepartmentModel>().ReverseMap();
            CreateMap<JobTitles, JobTitleModel>().ReverseMap();
            CreateMap<UserDepartments, UserDepartmentModel>().ReverseMap();

            CreateMap<UserConfirmCodes, UserConfirmCodeModel>().ReverseMap();
            CreateMap<UserConfirmStatus, UserConfirmStatusModel>().ReverseMap();
            CreateMap<UserConfirmTypes, UserConfirmTypeModel>().ReverseMap();

            CreateMap<UserGroups, UserGroupModel>().ReverseMap();
            CreateMap<UserInGroups, UserInGroupModel>().ReverseMap();
            CreateMap<Users, UserModel>().ReverseMap();
            CreateMap<CoreSlidebarItems, CoreSlidebarItemModel>().ReverseMap();
            CreateMap<CoreModules, CoreModuleModel>().ReverseMap();
            CreateMap<CorePageTitles, CorePageTitleModel>().ReverseMap();
            CreateMap<CoreTenantConnections, CoreTenantConnectionModel>().ReverseMap();
            CreateMap<CoreSystemConfigs, SystemConfigModel>().ReverseMap();

            CreateMap<CoreUploadFiles, CoreUploadFileModel>().ReverseMap();
            CreateMap<UserStatus, UserStatusModel>().ReverseMap();

            CreateMap<PagedList<UserConfirmCodes>, PagedList<UserConfirmCodeModel>>().ReverseMap();
            CreateMap<PagedList<UserConfirmStatus>, PagedList<UserConfirmStatusModel>>().ReverseMap();
            CreateMap<PagedList<UserConfirmTypes>, PagedList<UserConfirmTypeModel>>().ReverseMap();


        }
    }
}
