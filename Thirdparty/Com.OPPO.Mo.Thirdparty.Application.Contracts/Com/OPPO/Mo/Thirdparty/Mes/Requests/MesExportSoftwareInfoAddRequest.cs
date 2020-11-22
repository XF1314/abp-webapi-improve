using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Mes.Requests
{
    /// <summary>
    /// Mes 外销软件信息新增 request
    /// </summary>
    public class MesExportSoftwareInfoAddRequest : BaseEsbRequest
    {
        /// <summary>
        /// 序列化后的外销软件信息s
        /// </summary>
        [JsonProperty("software_info")]
        public string SerializedSoftwareInfos => JsonConvert.SerializeObject(SoftwareInfos);

        /// <summary>
        /// 外销软件信息s
        /// </summary>
        [JsonIgnore]
        public List<MesExportSoftwareInfo> SoftwareInfos { get; set; }

    }
}
