using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Requests
{

    public class ErpOrderLine
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        [JsonProperty("doc_id")]
        public string DocId { get; set; }
        /// <summary>
        /// 源代码
        /// </summary>
        [JsonProperty("source_code")]
        public string SourceCode { get; set; }
        /// <summary>
        /// 国家
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }
        /// <summary>
        /// 客户编码
        /// </summary>
        [JsonProperty("customer_code")]
        public string CustomerCode { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [JsonProperty("line_num")]
        public int LineNum { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        [JsonProperty("item_code")]
        public string ItemCode { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [JsonProperty("quantity")]
        public string Quantity { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [JsonProperty("price")]
        public double Price { get; set; }
        /// <summary>
        /// <summary>
        /// 组织代码
        /// </summary>
        [JsonProperty("organization_code")]
        public string OrgCode { get; set; }
        /// <summary>
        /// 子库
        /// </summary>
        [JsonProperty("subinventory")]
        public string Subinventory { get; set; }
        /// <summary>
        /// 定位
        /// </summary>
        [JsonProperty("locator")]
        public string Locator { get; set; }
        /// <summary>
        /// 货币代码
        /// </summary>
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
        /// <summary>
        /// 解释
        /// </summary>
        [JsonProperty("comments")]
        public string Comments { get; set; }
    }
}
