using System;
using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 核算主体查询输入参数
    /// </summary>
    public class OnePlusErpBodyInput
    {
        /// <summary>
        /// 起止时间
        /// </summary>
        [Required]
        public int Between { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [Required]
        public int From { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; }


        /// <summary>
        /// 组织编码
        /// </summary>
        public string OrgCode { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrgName { get; set; }

        /// <summary>
        /// 主体在PS系统中的ID
        /// </summary>
        public string PsLeId { get; set; }
    }
}
