using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.RealmeOpenApi.Requests
{
    /// <summary>
    /// Realme刷机工具编译信息新增Request
    /// </summary>
    public class RealmeBrushToolsCompileInfoAddRequest: RealmeOpenApiBaseRequest
    {
        /// <summary>
        /// 【必填项】编译信息
        /// </summary>
        [JsonProperty("brush_info")]
        public string CompileInfo { get; set; }
    }
}
