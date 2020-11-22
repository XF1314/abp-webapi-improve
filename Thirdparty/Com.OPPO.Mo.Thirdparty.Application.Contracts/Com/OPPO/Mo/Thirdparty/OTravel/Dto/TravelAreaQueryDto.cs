using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OTravel.Dto
{
    public class TravelAreaQueryDto
    {
        /// <summary>
        /// 类型（1国家 2省份 3城市 4行政区）,必填
        /// </summary>
        [Required]
        public int areaType { get; set; }

        /// <summary>
        /// 父地区ID
        /// </summary>
        public string parentAreaId { get; set; }
    }
}
