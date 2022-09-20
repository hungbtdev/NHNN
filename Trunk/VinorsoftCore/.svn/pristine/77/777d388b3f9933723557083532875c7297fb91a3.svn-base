using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.Domain
{
    public class KTAppDomainCatalogue : KTAppDomain
    {
        public const string Field_Code = "Code";
        public const string Field_Name = "Name";
        public const string Field_Description = "Description";

        /// <summary>
        /// Mã không trùng
        /// </summary>
        [MaxLength(255)]
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Tên 
        /// </summary>
        [MaxLength(4000)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        [MaxLength(4000)]
        public string Description { get; set; }


        [NotMapped]
        public bool AutoGenerateCode { set; get; }

       
    }
}
