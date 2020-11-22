using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Dtos
{
    public class PoLineBaseDto
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        [JsonProperty("doc_id")]
        public string DocId { get; set; }
        /// <summary>
        /// 文件名称 
        /// </summary>
        [JsonProperty("doc_name")]
        public string DocName { get; set; }
       
        /// <summary>
        /// 供应商代码
        /// </summary>
        [JsonProperty("vendor_code")]
        public string VendorCode { get; set; }
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
        /// 状态
        /// </summary>
        [JsonProperty("state")]
        public int State { get; set; }
        /// <summary>
        /// PO码
        /// </summary>
        [JsonProperty("po_num")]
        public string PoNum { get; set; }
        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("po_line_num")]
        public int? PoLineNum { get; set; }
        /// <summary>
        /// 接受数量
        /// </summary>
        [JsonProperty("receive_qty")]
        public int? ReceiveQty { get; set; }
    }
}
