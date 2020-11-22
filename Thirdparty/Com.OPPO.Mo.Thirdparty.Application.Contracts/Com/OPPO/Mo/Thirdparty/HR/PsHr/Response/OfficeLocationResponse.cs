using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Response
{
    public class OfficeLocationResponse
    {
        /// <summary>
        /// 请求状态码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 数组名
        /// </summary>
        public List<ResponseData> Datas { get; set; }

        /// <summary>
        /// 请求标志
        /// </summary>
        public bool Success { get; set; }

    
    }

    public class ResponseData
    {
        /// <summary>
        /// 集合ID
        /// </summary>
        public string HhrSetId { get; set; }

        /// <summary>
        /// 数组名
        /// </summary>
        public List<Country> Country { get; set; }

        /// <summary>
        /// 集合描述
        /// </summary>
        public string HhrSetDescr { get; set; }
    }

    public class Country
    {
        /// <summary>
        /// 国家/地区代码
        /// </summary>
        public string HhrCountry { get; set; }

        /// <summary>
        /// 国家/地区描述
        /// </summary>
        public string HhrCountryDescr { get; set; }

        /// <summary>
        /// 数组名
        /// </summary>
        public List<Location> Location { get; set; }
    }

    public class Location
    {
        /// <summary>
        ///办公城市代码
        /// </summary>
        public string HhrLocation { get; set; }

        /// <summary>
        /// 办公城市描述
        /// </summary>
        public string HhrLocationDescr { get; set; }

        /// <summary>
        /// 数组名
        /// </summary>
        public List<OffcLocn> OffcLocn { get; set; }
    }

    public class OffcLocn
    {
        /// <summary>
        ///办公地点代码
        /// </summary>
        public string HhrOffcLocn { get; set; }

        /// <summary>
        /// 办公地点描述
        /// </summary>
        public string HhrOffcLocnDescr { get; set; }
    }
}
