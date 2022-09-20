using KTApps.Domain;
using System;
using System.Runtime.Serialization;

namespace KTApps.Core
{
    public class KTAppException : Exception
    {
        public int ErrorCode { set; get; }

        public KTAppException(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public KTAppException()
        {
        }

        public KTAppException(string message) : base(message)
        {
        }

        public KTAppException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected KTAppException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public static class KTAppExceptionExtensions
    {
        public static KTAppDomainResult ToKTAppResult(this KTAppException ex)
        {
            return new KTAppDomainResult()
            {
                Success = false,
                Messages = new string[] { $"{ex.Message} :[{ex.ErrorCode}]" },
                ResultCode = ex.ErrorCode,
            };
        }
    }

}
