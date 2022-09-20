using System;
using Vinorsoft.Core.Entities.Media;

namespace Vinorsoft.Core.Interface
{
    public interface ICoreUploadFileService : ICoreCatalogueService<CoreUploadFiles>
    {
        void DeleteByRefId(Guid id);
    }
}
