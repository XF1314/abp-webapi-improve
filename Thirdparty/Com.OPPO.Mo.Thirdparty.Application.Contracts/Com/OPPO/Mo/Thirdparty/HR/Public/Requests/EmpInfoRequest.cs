
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Requests
{
    public class EmpInfoRequest: BaseEsbRequest
    {
        /// <summary>
        /// 身份证
        /// </summary>
        [JsonProperty("national_id")]
        public string NationalId { get; set; }
    }
}
