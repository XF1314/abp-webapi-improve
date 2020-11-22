using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Request
{
    public class AuthorizationSystemQuery:BaseEsbRequest
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("role_perm_flag")]
        public QueryTypeEnum QueryType { get; set; }
    }
}
