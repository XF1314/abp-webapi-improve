using Newtonsoft.Json;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.DiDi.Dtos
{
    /// <summary>
    /// DiDi城市输出类
    /// </summary>
    public class DiDiCityInfo
    {
        /// <summary>
        /// 响应码
        /// </summary>
        [JsonProperty("errno")]
        public string Errno { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        [JsonProperty("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// 城市信息
        /// </summary>
        public List<DiDiCityData> Data { get; set; }
    }

    public class DiDiCityData
    {
        /// <summary>
        /// 地级市ID
        /// </summary>
        [JsonProperty("city_id")]
        public string CityId { get; set; }

        /// <summary>
        /// 地级市ID
        /// </summary>
        [JsonProperty("city_name")]
        public string CityName { get; set; }

        /// <summary>
        /// 区县列表
        /// </summary>
        [JsonProperty("county_list")]
        public List<CountyInfo> CountyList { get; set; }
    }

    public class CountyInfo
    {
        /// <summary>
        /// 区县ID
        /// </summary>
        [JsonProperty("county_id")]
        public string CountyId { get; set; }

        /// <summary>
        /// 区县名称
        /// </summary>
        [JsonProperty("county_name")]
        public string CountyName { get; set; }
    }
}
