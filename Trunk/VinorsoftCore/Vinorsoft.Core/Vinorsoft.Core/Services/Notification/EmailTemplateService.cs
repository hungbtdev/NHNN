using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core
{
    public class EmailTemplateService : CoreService<EmailTemplates>, IEmailTemplateService
    {
        public EmailTemplateService(INotificationDbContext coreDbContext) : base(coreDbContext)
        {
        }
    }
}
