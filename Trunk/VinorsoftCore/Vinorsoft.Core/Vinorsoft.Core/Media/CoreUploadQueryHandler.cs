using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vinorsoft.Core.Domain.Queries;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Entities.Media;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Query;

namespace Vinorsoft.Core.Media
{
    public class CoreUploadQueryHandler : CoreVQueryHandler<CoreUploadFileDTO, CoreUploadFiles, ICoreUploadFileService>
    {
        public CoreUploadQueryHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override Task<IQueryable<CoreUploadFileDTO>> Handle(VQueryable<IQueryable<CoreUploadFileDTO>> request, CancellationToken cancellationToken)
        {
            var result = service.Queryable.Select(e => new CoreUploadFileDTO()
            {
                Id = e.Id,
                Code = e.Code,
                Created = e.Created,
                CreatedBy = e.CreatedBy,
                Description = e.Description,
                FileExtension = e.FileExtension,
                Link = e.Link,
                MimeType = e.MimeType,
                Name = e.Name,
                RefId = e.RefId,
            });
            return Task.FromResult(result);
        }
    }
}
