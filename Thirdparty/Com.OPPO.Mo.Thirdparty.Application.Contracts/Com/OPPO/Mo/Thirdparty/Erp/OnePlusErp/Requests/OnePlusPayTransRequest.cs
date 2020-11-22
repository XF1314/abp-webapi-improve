using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Requests
{

    /// <summary>
    /// 根据流程单号id查询付款信息,输入参数
    /// </summary>
    public class OnePlusPayTransRequest : BaseEsbRequest
    {
        /// <summary>
        /// 语言
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// 流程单号id
        /// </summary>
        [JsonProperty("oa_header_id")]
        public string Id { get; set; }

    }

}
