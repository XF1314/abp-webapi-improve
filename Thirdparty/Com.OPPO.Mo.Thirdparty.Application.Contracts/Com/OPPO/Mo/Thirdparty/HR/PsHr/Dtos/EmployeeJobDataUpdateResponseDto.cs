using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos
{

    public class EmployeeJobDataUpdateResponseDto
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        [JsonProperty("hhrEmplid")]
        public string EmployeeId { get; set; }

        /// <summary>
        /// 数据更新标识
        /// </summary>
        [JsonProperty("hhrDataFlag")]
        public bool DataFlag { get; set; }

        /// <summary>
        /// 错误原因
        /// </summary>
        [JsonProperty("hhrMsgText")]
        public string ErrorMsg { get; set; }
    }
}
