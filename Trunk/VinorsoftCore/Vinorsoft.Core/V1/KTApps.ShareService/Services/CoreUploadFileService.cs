using AutoMapper;
using KTApps.Core.EF;
using KTApps.Core.Services;
using KTApps.ShareService.Entities;
using KTApps.ShareService.Interface;

namespace KTApps.ShareService
{
    public class CoreUploadFileService : DomainService<CoreUploadFiles>, ICoreUploadFileService
    {
        public CoreUploadFileService(ICoreUploadUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
