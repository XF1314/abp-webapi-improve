using Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Responses
{

    public class LatestUnitPriceBody 
    {
        /// <summary>
        /// bbk数据
        /// </summary>
        public bbkInfoDto bbk { get; set; }

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

    public class LatestUnitPriceResponse
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        [JsonProperty("response")]
        public LatestUnitPriceBody Response { get; set; }
    }
}
