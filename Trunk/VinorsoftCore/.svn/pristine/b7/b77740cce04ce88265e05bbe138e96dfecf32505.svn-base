using System;
using System.Collections.Generic;
using System.Text;

namespace KTApps.Domain
{
    public class KTAppDomainResult
    {
        public KTAppDomainResult()
        {
            Messages = new List<string>();
        }
        public bool Success { set; get; }
        public object Data { set; get; }

        public int ResultCode { set; get; }
        public IList<string> Messages { set; get; }

        public string ResultMessage
        {
            get
            {
                return string.Format("{0} :[{1}]", string.Join(", ", Messages), ResultCode);
            }
        }
    }
}
