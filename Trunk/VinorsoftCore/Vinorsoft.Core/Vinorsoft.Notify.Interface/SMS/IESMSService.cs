using System.Threading.Tasks;
using Vinorsoft.Notify.Entities;

namespace Vinorsoft.Notify.Interface
{
    public interface IESMSService
    {
        Task<SMSResult> SendAsync(PhoneMessage phoneMessage);
    }
}
