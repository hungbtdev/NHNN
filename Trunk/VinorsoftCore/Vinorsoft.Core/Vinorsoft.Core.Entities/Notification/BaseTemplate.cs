using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Entities
{
    public abstract class BaseTemplates : VinorsoftDomain
    {
        public string Code { set; get; }
        public string Subject { set; get; }
        public string Body { set; get; }
        public string AppName { set; get; }
        public string Discriminator { set; get; }
    }
}
