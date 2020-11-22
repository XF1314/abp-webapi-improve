using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpSrm.Requests
{
    public class UpdateIfreceiving
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        [JsonProperty("doc_id")]
        public string DocId { get; set; }
        /// <summary>
        /// 收据编号
        /// </summary>
        [JsonProperty("receipt_num")]
        public string ReceiptNumber { get; set; }
        /// <summary>
        /// 物料编号
        /// </summary>
        [JsonProperty("segment1")]
        public string MaterialCode { get; set; }
    }

}
