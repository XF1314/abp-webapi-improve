using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Requests
{

    public class PoWarehousing
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        [JsonProperty("doc_id")]
        public string DocId { get; set; }
        /// <summary>
        /// PO码
        /// </summary>
        [JsonProperty("po_num")]
        public string PoNum { get; set; }
        /// <summary>
        /// 提单
        /// </summary>
        [JsonProperty("bill_lading")]
        public string BillLading { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        [JsonProperty("item_code")]
        public string ItemCode { get; set; }
        /// <summary>
        /// 调整价格
        /// </summary>
        [JsonProperty("adjust_price")]
        public double AdjustPrice { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        /// <summary>
        /// 次级投资
        /// </summary>
        [JsonProperty("subinv")]
        public string Subinv { get; set; }
        /// <summary>
        /// 定位
        /// </summary>
        [JsonProperty("locator")]
        public string Locator { get; set; }
        /// <summary>
        /// 资产数量
        /// </summary>
        [JsonProperty("asset_num_f")]
        public string AssetNumF { get; set; }
        /// <summary>
        /// 资产数量
        /// </summary>
        [JsonProperty("asset_num_t")]
        public string AssetNumT { get; set; }
        /// <summary>
        /// 资产类型
        /// </summary>
        [JsonProperty("asset_type")]
        public string AssetType { get; set; }
        /// <summary>
        /// 部门代码
        /// </summary>
        [JsonProperty("dept_code")]
        public string DeptCode { get; set; }
        /// <summary>
        /// 接管人
        /// </summary>
        [JsonProperty("receiver")]
        public string Receiver { get; set; }
    }
}
