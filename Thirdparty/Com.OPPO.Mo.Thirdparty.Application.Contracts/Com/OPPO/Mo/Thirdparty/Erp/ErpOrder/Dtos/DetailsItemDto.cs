using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpOrder.Dtos
{
    public class DetailsItemDto
    {
        /// <summary>
        /// 文件id
        /// </summary>
        [JsonProperty("doc_id")]
        public string DocId { get; set; }
        /// <summary>
        /// 客户编码
        /// </summary>
        [JsonProperty("customer_code")]
        public string CustomerCode { get; set; }
        /// <summary>
        /// ERP订单号
        /// </summary>
        [JsonProperty("erp_order")]
        public string ErpOrderNumber { get; set; }
        /// <summary>
        /// ERP交货编号
        /// </summary>
        [JsonProperty("erp_delivery_num")]
        public string ErpDeliveryNumber { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        [JsonProperty("total_amount")]
        public double TotalAmount { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [JsonProperty("line_num")]
        public int LineNum { get; set; }
    }
}
