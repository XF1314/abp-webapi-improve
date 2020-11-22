using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Fdc.Dto
{
    public class FinanceQueryDto
    {
        /// <summary>
        /// 表单名称
        /// </summary>
        [Required]
        public string FormName { get; set; }
        /// <summary>
        /// 语言集
        /// </summary>
        [Required]
        public string Language { get; set; }
        /// <summary>
        /// Api编码
        /// </summary>
        [Required]
        public string ApiCode { get; set; }

        public string FlexValueSetName { get; set; }

        public string PFlexValueSetName { get; set; }

        public string ParentFlexValue { get; set; }
    }
}
