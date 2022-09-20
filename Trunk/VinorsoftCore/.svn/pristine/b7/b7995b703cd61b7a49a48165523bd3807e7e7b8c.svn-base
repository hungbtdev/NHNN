using KTApps.Core.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KTApps.Models
{
    public class KTAppDomainCatalogueModel : KTAppDomainModel
    {
        [MaxLength(255, ErrorMessage = "Mã tối đa 255 ký tự")]
        [Required(ErrorMessage = "Mã là trường bắt buộc nhập")]
        [Description("Mã")]
        public string Code { get; set; }

        [MaxLength(255, ErrorMessage = "Tên tối đa 255 ký tự")]
        [Required(ErrorMessage = "Tên là trường bắt buộc nhập")]
        [Description("Tên")]
        public string Name { get; set; }

        [MaxLength(1000, ErrorMessage = "Mô tả tối đa 1000 ký tự")]
        [Description("Mô tả")]
        public string Description { get; set; }

        private bool _autoGenerateCode;
        /// <summary>
        /// Tự động tạo mã từ tên
        /// </summary>
        /// 
        public bool AutoGenerateCode
        {
            set
            {
                _autoGenerateCode = value;
                if (_autoGenerateCode && !string.IsNullOrEmpty(Name))
                {
                    Code = StringUtils.ReplaceSpecialChar(Name);
                }
            }

            get
            {
                return _autoGenerateCode;
            }
        }

        public void GenerateCode()
        {
            AutoGenerateCode = true;
        }
    }
}
