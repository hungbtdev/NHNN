using System;
using System.Collections.Generic;
using System.Text;

namespace KTApps.Domain
{
    public class KTAppDomainImportResult : KTAppDomainResult
    {
        public byte[] ResultFile { set; get; }
        public string DownloadFileName { set; get; }
    }
}
