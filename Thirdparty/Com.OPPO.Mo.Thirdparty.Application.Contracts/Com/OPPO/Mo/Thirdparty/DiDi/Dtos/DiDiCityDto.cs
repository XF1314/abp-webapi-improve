using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.DiDi.Dtos
{
    /// <summary>
    /// DiDi城市输出类
    /// </summary>
    public class DiDiCityDto
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public string Errno { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        public string Errmsg { get; set; }

        /// <summary>
        /// 城市信息
        /// </summary>
        public List<DiDiCity> Data { get; set; }
    }

    public class DiDiCity
    {
        /// <summary>
        /// 地级市ID
        /// </summary>
        public string CityId { get; set; }

        /// <summary>
        /// 地级市ID
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 区县列表
        /// </summary>
        public List<CountyDto> CountyList { get; set; }
    }

    public class CountyDto
    {
        /// <summary>
        /// 区县ID
        /// </summary> 
        public string CountyId { get; set; }
        /// <summary>
        /// 区县名称
        /// </summary>
      
        public string CountyName { get; set; }
    }
}
