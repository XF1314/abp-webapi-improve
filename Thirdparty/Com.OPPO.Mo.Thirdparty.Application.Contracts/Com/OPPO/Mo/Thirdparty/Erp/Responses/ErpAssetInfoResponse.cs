using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    public class ErpAssetInfoResponse
    {
        [JsonProperty("response")]
        public ResponseBody Body { get; set; }
    }

    public class ResponseBody
    {
        [JsonProperty("assets")]
        public AssetInfo Info { get; set; }
    }

    public class AssetInfo
    {
        /// <summary>
        /// 资产代码
        /// </summary>
        [JsonProperty("asset_number")] 
        public string AssetNumber { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [JsonProperty("description")] 
        public string Description { get; set; }
        /// <summary>
        /// uom编码
        /// </summary>
        [JsonProperty("primary_uom_code")] 
        public string UomCode { get; set; }
    }
}
