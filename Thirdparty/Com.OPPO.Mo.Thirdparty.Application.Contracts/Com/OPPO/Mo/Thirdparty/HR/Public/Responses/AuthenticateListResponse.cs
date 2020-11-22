using Com.OPPO.Mo.Thirdparty.Hr.Public.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Responses
{


    public class AuthenticateListBody
    {
        /// <summary>
        /// 条数
        /// </summary>
        public int RowCount { get; set; }
        /// <summary>
        /// 认证信息
        /// </summary>
        public List<Authenticate> Datas { get; set; }

    }

    public class AuthenticateListResponse
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        [JsonProperty("response")]
        public AuthenticateListBodyDto Response { get; set; }
    }
}
