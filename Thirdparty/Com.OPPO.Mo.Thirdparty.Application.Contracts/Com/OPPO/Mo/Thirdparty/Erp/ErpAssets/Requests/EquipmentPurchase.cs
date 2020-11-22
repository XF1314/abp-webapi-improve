using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Requests
{
    public class EquipmentPurchase
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        [JsonProperty("doc_id")]
        public string DocId { get; set; }
        /// <summary>
        /// 部门编码
        /// </summary>
        [JsonProperty("dept_number")]
        public string DeptNumber { get; set; }
        /// <summary>
        /// 请求人
        /// </summary>
        [JsonProperty("requester")]
        public string Requester { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("create_date")]
        [JsonConverter(typeof(DateStringConverter))]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
