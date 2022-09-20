using System;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Query;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core
{
    public class QueryEmailTemplateHandler : CoreVQueryHandler<EmailTemplateDTO, EmailTemplates, IEmailTemplateService>
    {
        public QueryEmailTemplateHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
