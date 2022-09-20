using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KTApps.Models.Import
{
    public class ImportDataModel : KTAppDomainModel, IImportDataModel
    {
        public byte[] FileContent { set; get; }
        public IList<ImportMappingPropertyModel> ImportMappings { set; get; }
        public int LogColumnIndex { get; set; }
        public int StartRowIndex { get; set; }
        public string SheetName { get; set; }

        public bool IsUsingTemplate { get; set; }
        public Guid CampaignId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string MimeType { get; set; }
        public string FileExtension { get; set; }
        public string TempName { get; set; }
    }
}
