using Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Responses
{

    public class PoLineBody
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        [JsonProperty("lines")]
        public List<PoLineRetDto> Datas { get; set; }

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

    public class PoLineResponse
    {
        /// <summary>
        /// 返回信息体
        /// </summary>
        [JsonProperty("response")]
        public PoLineBody Response { get; set; }
    }
}
