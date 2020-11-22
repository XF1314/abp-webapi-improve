using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    public class ErpPurchaseOrder
    {
        /// <summary>
        /// 文件编码
        /// </summary>
        [JsonProperty("doc_id")]
        public string DocId { get; set; }
        /// <summary>
        /// 不合格类别
        /// </summary>
        [JsonProperty("type")]
        public string DisqualificationType { get; set; }
        /// <summary>
        /// 不合格内容
        /// </summary>
        [JsonProperty("comments")]
        public string DisqualificationContent { get; set; }
        /// <summary>
        /// 缺陷数量
        /// </summary>
        [JsonProperty("qty_dec")]
        public string DefectNumber { get; set; }
        /// <summary>
        /// 样本数量
        /// </summary>
        [JsonProperty("qty_sam")]
        public string ExampleNumber { get; set; }
        /// <summary>
        /// 比例(%)
        /// </summary>
        [JsonProperty("percent")]
        public string Proportion { get; set; }
    }
}
