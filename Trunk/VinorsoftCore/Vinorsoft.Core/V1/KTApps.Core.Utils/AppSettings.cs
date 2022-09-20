using System;
using System.Collections.Generic;
using System.Text;

namespace KTApps.Core.Utils
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string SubDomain { get; set; }
        public bool GrantPermissionDebug { get; set; }
        public bool EnableCaptCha { get; set; }
    }
}
