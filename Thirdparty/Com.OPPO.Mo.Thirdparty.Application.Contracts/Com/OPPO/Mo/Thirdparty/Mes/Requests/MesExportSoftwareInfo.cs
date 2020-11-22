using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Mes.Requests
{
    /// <summary>
    /// Mes外销软体信息
    /// </summary>
    public class MesExportSoftwareInfo
    {
        /// <summary>
        /// 【必填项】机型
        /// </summary>
        [JsonProperty("product_model")]
        public string ProductModel { get; set; }

        /// <summary>
        /// 【必填项】软件名称
        /// </summary>
        [JsonProperty("software_name")]
        public string SoftwareName { get; set; }

        /// <summary>
        /// 【必填项】软件版本
        /// </summary>
        [JsonProperty("software_version")]
        public string SoftwareVersion { get; set; }

        /// <summary>
        ///  【必填项】Y:失效历史软件，N:不失效历史软件
        /// </summary>
        [JsonProperty("invalid_flag")]
        public string InvalidFlag => IfInvalidHistoryVersion ? "Y" : "N";

        /// <summary>
        /// 【必填项】是否失效历史软件
        /// </summary>
        [JsonIgnore]
        public bool IfInvalidHistoryVersion { get; set; }

        /// <summary>
        /// 创建应用标识，填写当前系统标识即可
        /// </summary>
        [JsonProperty("user_id")]
        public string AppId { get; set; }
    }
}
