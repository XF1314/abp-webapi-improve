using Com.OPPO.Mo.Thirdparty.Erp.ErpSrm.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{

    public class MtrlItem
    {
        /// <summary>
        /// 组织信息
        /// </summary>
        public string OrgCode { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public double Quantity { get; set; }
    }

    public class ErpSrmCheckBillInfoResponse
    {

        /// <summary>
        /// 返回数据
        /// </summary>
        [JsonProperty("response")]
        public ErpSrmCheckBillInfoBodyDto Response { get; set; }
    }


}
