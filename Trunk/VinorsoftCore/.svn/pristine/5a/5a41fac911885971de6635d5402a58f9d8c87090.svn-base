namespace KTApps.AuthService.Entities
{
    using KTApps.Domain;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Phòng ban
    /// </summary>
    public class Departments : KTAppDomainCatalogue
    {
        public Departments()
        {
        }

        /// <summary>
        /// Khu vực
        /// </summary>
        [ForeignKey("Areas")]
        public Guid? AreaId { get; set; }
        [ForeignKey("ParentDepartments")]
        public Guid? ParentId { get; set; }
        [ForeignKey("DepartmentTypes")]
        public Guid? DepartmentTypeId { get; set; }
        public Areas Areas { get; set; }
        public string FaIcon { set; get; }
        public Departments ParentDepartments { set; get; }
        public DepartmentTypes DepartmentTypes { set; get; }
    }
}
