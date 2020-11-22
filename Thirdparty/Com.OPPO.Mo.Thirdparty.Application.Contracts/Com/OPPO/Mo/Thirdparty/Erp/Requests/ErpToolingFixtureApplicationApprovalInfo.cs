using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    public class ErpToolingFixtureApplicationApprovalInfo
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        [JsonProperty("doc_id")] 
        public string FormInstanceCode { get; set; }
        /// <summary>
        /// 类型：默认COMMON
        /// </summary>
        [JsonProperty("type")] 
        public string Type { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        [JsonProperty("item_code")] 
        public string MaterialCode { get; set; }
        /// <summary>
        /// 财务十一段合成：公司代码.事业部代码.部门代码.区域代码.渠道代码.产品线代码.主科目代码.子科目代码.预算编码代码.贸易伙伴代码.保留代码.
        /// </summary>
        [JsonProperty("account_code")]
        public string AccountCode { get; set; }

        public string attribute1 { get; set; }
        public string attribute2 { get; set; }
        public string attribute3 { get; set; }
        public string attribute4 { get; set; }
        public string attribute5 { get; set; }
    }
}
