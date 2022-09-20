using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Vinorsoft.Notify.Entities;
using Vinorsoft.Notify.Interface;

namespace Vinorsoft.Notify
{
    public class ESMSService : IESMSService
    {
        private readonly ISMSConfiguration _smsConfiguration;

        public ESMSService(ISMSConfiguration smsConfiguration)
        {
            _smsConfiguration = smsConfiguration;
        }

        public async Task<SMSResult> SendAsync(PhoneMessage phoneMessage)
        {
            string URL = $"{_smsConfiguration.ApiUrl}?Phone={phoneMessage.ToPhone}&Content={phoneMessage.Content}&ApiKey={_smsConfiguration.ApiKey}&SecretKey={_smsConfiguration.SecretKey}";
            if (phoneMessage.IsUnicode)
                URL += "&IsUnicode=1";
            else
                URL += "&IsUnicode=0";

            if (phoneMessage.Type == PhoneMessage.SMSType.Brandname)
                URL += $"&Brandname={_smsConfiguration.Brandname}";

            URL += $"&SmsType={(int)phoneMessage.Type}";

            string result = await SendGetRequestAsync(URL);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<SMSResult>(result);
            }
            return null;
        }

        private async Task<string> SendGetRequestAsync(string requestUrl)
        {
            Uri address = new Uri(requestUrl);
            HttpWebRequest request;
            HttpWebResponse response = null;
            StreamReader reader;
            if (address == null) { throw new ArgumentNullException("address"); }
            try
            {
                request = WebRequest.Create(address) as HttpWebRequest;
                request.UserAgent = ".NET";
                request.KeepAlive = false;
                request.Timeout = 15 * 1000;
                response = await request.GetResponseAsync() as HttpWebResponse;
                if (request.HaveResponse == true && response != null)
                {
                    reader = new StreamReader(response.GetResponseStream());
                    string result = reader.ReadToEnd();
                    result = result.Replace("</string>", "");
                    return result;
                }
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (HttpWebResponse errorResponse = (HttpWebResponse)wex.Response)
                    {
                        throw new Exception(string.Format("The server returned '{0}' with the status code {1} ({2:d}).",
                            errorResponse.StatusDescription, errorResponse.StatusCode,
                            errorResponse.StatusCode));
                    }
                }
            }
            finally
            {
                if (response != null) { response.Close(); }
            }
            return null;
        }
    }
}
