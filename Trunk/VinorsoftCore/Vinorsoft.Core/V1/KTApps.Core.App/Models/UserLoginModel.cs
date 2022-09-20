using System;

namespace KTApps.Core.App.Models
{
    public class UserLoginModel
    {
        public Guid UserId { set; get; }
        /// <summary>
        /// Chi nhánh cấp 1
        /// </summary>
        public Guid? DepartmentId { set; get; }
        public string DepartmentCode { set; get; }
        /// <summary>
        /// Chi nhánh cấp 2
        /// </summary>
        public Guid? Department2Id { get; set; }
        public string Department2Code { set; get; }
        /// <summary>
        /// Chi nhánh cấp 3
        /// </summary>
        public Guid? Department3Id { get; set; }
        public string Department3Code { set; get; }
        /// <summary>
        /// Chi nhánh cấp 4
        /// </summary>
        public Guid? Department4Id { get; set; }
        public string Department4Code { set; get; }
        public string UserName { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
    }
}
