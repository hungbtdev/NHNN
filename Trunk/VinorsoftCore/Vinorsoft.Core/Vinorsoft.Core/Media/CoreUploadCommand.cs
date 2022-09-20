using System;
using Vinorsoft.Core.Domain.Comands;
using Vinorsoft.Core.DTO;

namespace Vinorsoft.Core
{
    public class DeleteFileByRefIdComand : CommandBase<CoreUploadFileDTO>
    {
        public Guid RefId { set; get; }
        public DeleteFileByRefIdComand(Guid refId)
        {
            RefId = refId;
        }
    }
}