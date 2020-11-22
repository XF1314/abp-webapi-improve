using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Dtos
{

    public class AuthenticateListBodyDto
    {
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

        /// <summary>
        /// 条数
        /// </summary>
        [JsonProperty("total_results")]
        public int RowCount { get; set; }
        /// <summary>
        /// 认证信息
        /// </summary>
        [JsonProperty("records")]
        public List<AuthenticateDto> Datas { get; set; }

    }
}
