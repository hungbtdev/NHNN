using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class CoreUploadFileDTO : CatalogueObjectDTO
    {
        public byte[] FileContent { get; set; }
        [Display(Name = nameof(Resources.FileExtension), ResourceType = typeof(Resources))]
        public string FileExtension { get; set; }
        [Display(Name = nameof(Resources.MimeType), ResourceType = typeof(Resources))]
        public string MimeType { get; set; }
        public string Link { get; set; }
        public System.Guid RefId { get; set; }
    }
}
