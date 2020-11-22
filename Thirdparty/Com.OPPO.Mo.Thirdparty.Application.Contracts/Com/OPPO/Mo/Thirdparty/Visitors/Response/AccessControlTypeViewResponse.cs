using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Visitors.Response
{

    public class Devices
    {
        /// <summary>
        /// 设备id
        /// </summary>
        public int DevID { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DevName { get; set; }
        /// <summary>
        /// 门ID
        /// </summary>
        public int DoorID { get; set; }
        /// <summary>
        /// 门名称
        /// </summary>
        public string DoorName { get; set; }
        /// <summary>
        /// 设备类型
        /// </summary>
        public string DevType { get; set; }
        /// <summary>
        /// 设备类型名称
        /// </summary>
        public string DevTypeName { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string RegionName { get; set; }
        /// <summary>
        /// 地区1
        /// </summary>
        public string Area1 { get; set; }
        /// <summary>
        /// 地区2
        /// </summary>
        public string Area2 { get; set; }
        /// <summary>
        /// 地区3
        /// </summary>
        public string Area3 { get; set; }
    }

    public class AccessControlTypeViewBody
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
        /// 返回数据
        /// </summary>
        public List<Devices> devices { get; set; }
    }

    public class AccessControlTypeViewResponse
    {
        /// <summary>
        /// 返回信息
        /// </summary>
        public AccessControlTypeViewBody response { get; set; }
    }

}
