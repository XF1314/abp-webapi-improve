
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos
{
    /// <summary>
    /// 请求data
    /// </summary>
    public class OfficeLocationDto
    {
        /// <summary>
        /// 集合ID，非必填
        /// </summary>
        public string SetId { get; set; }

        /// <summary>
        /// 国家/地区代码，非必填
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// 办公城市代码，非必填
        /// </summary>
        public string LocationCode { get; set; }
    }


}
