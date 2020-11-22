using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpSrm.Requests
{

    public class PurchaseReport
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        [JsonProperty("doc_id")]
        public string DocId { get; set; }
        /// <summary>
        /// 组织code
        /// </summary>
        [JsonProperty("organization_code")]
        public string OrganizationCode { get; set; }
        /// <summary>
        /// 物料编号
        /// </summary>
        [JsonProperty("segment1")]
        public string MaterialCode { get; set; }
        /// <summary>
        /// 收据编号
        /// </summary>
        [JsonProperty("receipt_num")]
        public string ReceiptNumber { get; set; }
        /// <summary>
        /// "检验员"+拟制人名字+送审时间戳
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("creattion_date")]
        [JsonConverter(typeof(DateTimeStringConverter))]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 文件编号
        /// </summary>
        [JsonProperty("doc_no")]
        public string DocNo { get; set; }
        /// <summary>
        /// 供应商批次
        /// </summary>
        [JsonProperty("lot")] 
        public string SupplierBatch { get; set; }
    }

}
