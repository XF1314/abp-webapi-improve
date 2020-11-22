using Com.OPPO.Mo.Thirdparty;
using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Ocsm.Requests
{
    /// <summary>
    /// Ocsm刷机工具编译信息新增Request
    /// </summary>
    public class OcsmBrushToolsCompileInfoAddRequest : BaseEsbRequest
    {
        /// <summary>
        /// 【必填项】编译信息
        /// </summary>
        [JsonProperty("brush_info")]
        public string CompileInfo { get; set; }
    }
}
