using Newtonsoft.Json;
using System;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Requests
{
    /// <summary>
    /// 核算主体查询输入参数
    /// </summary>
    public class OnePlusErpBodyRequest : BaseEsbRequest
    {
        /// <summary>
        /// 起止 
        /// </summary>
        [JsonProperty("between")]
        public int Between { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// 结束
        /// </summary>
        [JsonProperty("from")]
        public int From { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }


        /// <summary>
        /// 组织编码
        /// </summary>
        [JsonProperty("org_code")]
        public string OrgCode { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        [JsonProperty("org_name")]
        public string OrgName { get; set; }

        /// <summary>
        /// 主体在PS系统中的ID
        /// </summary>
        [JsonProperty("ps_le_id")]
        public string PsLeId { get; set; }

    }
}
