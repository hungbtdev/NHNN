using System;
using System.Collections.Generic;
using System.Text;

namespace KTApps.Models.Import
{
    public interface IImportDataModel
    {
        byte[] FileContent { set; get; }
        IList<ImportMappingPropertyModel> ImportMappings { set; get; }
        int StartRowIndex { set; get; }
        int LogColumnIndex { set; get; }

    }
}
