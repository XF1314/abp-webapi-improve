using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// MO费用报销驳回处理输入参数
    /// </summary>
    public class ErpProcessRejectInput
    {
        /// <summary>
        /// 单据id
        /// </summary>
        [Required]
        public string DocId { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        [Required]
        public string Language { get; set; }

        /// <summary>
        /// 来源类型
        /// </summary>
        [Required]
        public string SouceType { get; set; }
    }
}
