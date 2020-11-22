using Com.OPPO.Mo.Thirdparty.Erp.ErpOrder.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpOrder.Responses
{

    public class DetailsItem
    {
        /// <summary>
        /// 文件id
        /// </summary>
        public string DocId { get; set; }
        /// <summary>
        /// 客户编码
        /// </summary>
        public string CustomerCode { get; set; }
        /// <summary>
        /// ERP订单号
        /// </summary>
        public string ErpOrderNumber { get; set; }
        /// <summary>
        /// ERP交货编号
        /// </summary>
        public string ErpDeliveryNumber { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public double TotalAmount { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int LineNum { get; set; }
    }

    public class ErpOrderDeliverInfoBody
    {
        /// <summary>
        /// 数据集合
        /// </summary>
        public List<DetailsItemDto> results { get; set; }

        /// <summary>
        /// 返回编码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }

    }

    public class ErpOrderDeliverInfoResponse
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        [JsonProperty("response")]
        public ErpOrderDeliverInfoBody Response { get; set; }
    }


}
