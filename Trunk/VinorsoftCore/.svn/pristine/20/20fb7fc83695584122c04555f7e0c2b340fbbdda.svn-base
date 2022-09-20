using System;
using System.Collections.Generic;
using System.Text;

namespace Vinorsoft.Notify.Entities
{
    public class SMSResult
    {
        public SMSResultCode CodeResult { get; set; }
        public int CountRegenerate { get; set; }
        public long SMSID { get; set; }

        public enum SMSResultCode
        {
            Success = 100,
            BrandnameInvalid = 104,
            SMSTypeInvalid = 118,
            AtLeast20PhoneNum = 119,
            SMSLength442 = 131,
            NoPermiss8755 = 131,
            Unknown = 99,
            NotRegistry = 177,
            RequestIdToLong = 159,
            TemplateIsValid = 145,
        }
    }
}
