using Com.OPPO.Mo.Thirdparty.Erp.ErpEam.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpEam.Responses
{

    public class AssetRetirementBody     {
        /// <summary>
        /// 数据集合
        /// </summary>
        public List<AssetRetirementInfoDto> results { get; set; }

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

    public class AssetRetirementResponse
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        [JsonProperty("response")]
        public AssetRetirementBody Response { get; set; }
    }
}
