using System;

namespace KTApps.Models
{
    public class SearchUserModel : DomainSearchModel, IDomainSearchModel
    {
        public Guid? DepartmentId { set; get; }
    }
}
