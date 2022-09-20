using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KTApps.Domain
{
    public class KTAppDomain
    {
        public KTAppDomain()
        {
            Created = DateTime.Now;
        }

        public const string Field_Id = "Id";
        public const string Field_Created = "Created";
        public const string Field_Updated = "Updated";
        public const string Field_Deleted = "Deleted";
        public const string Field_CreatedBy = "CreatedBy";
        public const string Field_UpdatedBy = "UpdatedBy";
        public const string Field_Active = "Active";

        /// <summary>
        /// Khóa chính, không trùng
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public Guid Id { set; get; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        [Required]
        public DateTime Created { set; get; }

        /// <summary>
        /// Ngày cập nhật
        /// </summary>
        public DateTime? Updated { set; get; }

        /// <summary>
        /// Dánh dấu xóa hay chưa
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Tên đăng nhập người tạo
        /// </summary>
        [MaxLength(255)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Tên đăng nhập người cập nhật
        /// </summary>
        [MaxLength(255)]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Kích hoạt
        /// </summary>
        public bool Active { set; get; }

    }
}
