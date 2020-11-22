using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Mes.Responses
{

    public class CountryInfo
    {
        /// <summary>
        /// 国家代码
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        /// <summary>
        /// 国家中文名
        /// </summary>
        [JsonProperty("name_cn")] 
        public string ChinsesName { get; set; }
        /// <summary>
        /// 国家英文名
        /// </summary>
        [JsonProperty("name_en")] 
        public string EnglishName { get; set; }
        /// <summary>
        /// 国家类型
        /// </summary>
        [JsonProperty("country_type")]
        public string CountryType { get; set; }
        /// <summary>
        /// 类型描述
        /// </summary>
        [JsonProperty("type_desc")] 
        public string TypeDesc { get; set; }
    }

    public class MesCountryDataBody
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
        /// 返回记录总数
        /// </summary>
        [JsonProperty("total_results")] 
        public string ResultCount { get; set; }
        /// <summary>
        /// 数据集合
        /// </summary>
        [JsonProperty("country_info")] 
        public List<CountryInfo> Countrys { get; set; }

    }

    public class MesCountryDataResponse
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        [JsonProperty("response")] 
        public MesCountryDataBody Response { get; set; }
    }


}
