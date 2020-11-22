using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OTravel.Response
{

    public class TravelAreaResponse 
    {

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("success")]
        public bool IsSuccess { get; set; }

    }

    public class TravelAreaResponse<TData>: TravelAreaResponse
    {
        [JsonProperty("data")]
        public TData Data { get; set; }
    }

        public class TravelArea
    {
        /// <summary>
        /// 地区唯一ID
        /// </summary>
        public int areaId { get; set; }

        /// <summary>
        ///父地区ID
        /// </summary>
        public int parentAreaId { get; set; }
        /// <summary>
        /// 地区编码
        /// </summary>
        public string areaCode { get; set; }
        /// <summary>
        /// 地区名称
        /// </summary>
        public string areaName { get; set; }
        /// <summary>
        /// 地区英文名
        /// </summary>
        public string enName { get; set; }
        /// <summary>
        /// 国家拼音
        /// </summary>
        public string shortEnName { get; set; }
    }
}
