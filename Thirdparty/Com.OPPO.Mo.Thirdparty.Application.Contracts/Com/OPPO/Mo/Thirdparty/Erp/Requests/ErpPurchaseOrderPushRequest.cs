using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    public class ErpPurchaseOrderPushRequest : BaseEsbRequest
    {
        /// <summary>
        /// 写入进货检验报告数据
        /// </summary>
        [JsonProperty("approver")]
        public string Data { get; set; }
    }
}
