using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Ocsm.Requests
{
    /// <summary>
    /// 加密的Ocsm刷机工具编译信息新增Request
    /// </summary>
    public class OcsmEncryptedBrushToolCompileInfoAddRequest : BaseOcsmRequest
    {
        /// <summary>
        /// 【必填项】来源，固定为4
        /// </summary>
        [JsonProperty("sourceplatform")]
        public string SourcePlatform { get; private set; } = "4";

        /// <summary>
        /// 【必填项】状态，固定为1
        /// </summary>
        [JsonProperty("state")]
        public string State { get; private set; } = "1";

        /// <summary>
        /// 加密后的编译信息
        /// </summary>
        [JsonProperty("brush_info")]
        public string EncryptedCompileInfo { get; set; }
    }
}
