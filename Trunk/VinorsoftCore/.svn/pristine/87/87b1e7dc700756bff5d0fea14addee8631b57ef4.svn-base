using System;
using System.Threading;
using System.Threading.Tasks;
using Vinorsoft.Core.Command;
using Vinorsoft.Core.Domain.Comands;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Resx;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core
{
    public class SMSTemplateCommandHandler : VBaseCommand<SMSTemplateDTO, SMSTemplates, ISMSTemplateService>
    {
        public SMSTemplateCommandHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override Task<SMSTemplateDTO> Handle(CreateComand<SMSTemplateDTO> request, CancellationToken cancellationToken)
        {
            if (service.Any(e => e.Id != request.Data.Id && e.Code == request.Data.Code))
                throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, request.Data.Code));

            return base.Handle(request, cancellationToken);
        }

        public override Task<SMSTemplateDTO> Handle(UpdateComand<SMSTemplateDTO> request, CancellationToken cancellationToken)
        {
            if (service.Any(e=>e.Id != request.Data.Id && e.Code == request.Data.Code))
                throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, request.Data.Code));

            return base.Handle(request, cancellationToken);
        }
    }
}
