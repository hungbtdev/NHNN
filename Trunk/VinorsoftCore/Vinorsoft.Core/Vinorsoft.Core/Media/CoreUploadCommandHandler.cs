using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vinorsoft.Core.Command;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Entities.Media;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core
{
    public class CoreUploadCommandHandler : VBaseCommand<CoreUploadFileDTO, CoreUploadFiles, ICoreUploadFileService>, IRequestHandler<DeleteFileByRefIdComand, CoreUploadFileDTO>
    {
        public CoreUploadCommandHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public Task<CoreUploadFileDTO> Handle(DeleteFileByRefIdComand request, CancellationToken cancellationToken)
        {
            //if (!service.Queryable.Any(e => e.RefId == request.RefId))
            //    throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, request.RefId));

            service.DeleteByRefId(request.RefId);
            return null;
        }
    }
}
