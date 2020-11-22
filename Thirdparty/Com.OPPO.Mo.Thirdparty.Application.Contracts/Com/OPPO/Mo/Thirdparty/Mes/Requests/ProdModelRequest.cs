using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Mes.Requests
{
    public class ProdModelRequest: BaseEsbRequest
    {
        /// <summary>
        /// 认证机型
        /// </summary>
        
        [JsonProperty("prod_model")]
        public string ProdModel { get; set; }
    }
}
