using KTApps.Models;
using System;

namespace KTApps.Core.App.Models
{
    public class CoreUploadFileModel : KTAppDomainCatalogueModel
    {
        public byte[] FileContent { set; get; }
        public string FileExtension { set; get; }
        public string MimeType { set; get; }
        public Guid RefId { set; get; }

        public string TempName { set; get; }
    }
}
