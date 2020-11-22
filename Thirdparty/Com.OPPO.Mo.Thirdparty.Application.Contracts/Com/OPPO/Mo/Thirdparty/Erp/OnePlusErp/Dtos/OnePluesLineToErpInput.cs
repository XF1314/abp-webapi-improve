using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 抛送报销行信息至ERP,输入参数
    /// </summary>
    public class OnePluesLineToErpInput
    {
        /// <summary>
        /// json 格式数据:[{ "sourceHeaderId":"94052", "sourceLineId":"2661", "sourceLineNum":"1", "lineType":"ITEM", "amount":"80", "comments":"2018-3-24号加班打车", "refInvoceNum":"", "accountCode":"10.0000.406.004.310605.000000", "status":"NEW", "lastUpdateDate":"2018-04-17 15:42:38", "lastUpdatedBy":"-1", "lastUpdateLogin":"-1", "creationDate":"2018-04-17 15:42:38", "createdBy":"-1" }]
        /// </summary>
        [Required]
        public string Lines { get; set; }

        /// <summary>
        /// 返回格式，支持json/xml两种格式，默认为json格式
        /// </summary>
        [JsonIgnore]
        public string RespType { get; set; }
    }
}
