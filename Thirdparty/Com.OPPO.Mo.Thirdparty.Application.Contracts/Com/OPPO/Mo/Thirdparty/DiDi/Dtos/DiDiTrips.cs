using System;

namespace Com.OPPO.Mo.Thirdparty.DiDi.Dtos
{
    /// <summary>
    /// 旅行信息
    /// </summary>
    public class DiDiTrips
    {
        /// <summary>
        /// 出发地城市名称，如北京市
        /// </summary>
        public string DepartureCity { get; set; }

        /// <summary>
        /// 出发地城市id(地级市id)
        /// </summary>
        public int DepartureCityId { get; set; }

        /// <summary>
        /// 目的地城市名称，如上海市
        /// </summary>
        public string DestinationCity { get; set; }

        /// <summary>
        /// 目的地城市id(地级市id)
        /// </summary>
        public int DestinationCityId { get; set; }

        /// <summary>
        /// 行程开始日期，如2017-01-10
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 行程结束日期，如2017-01-20
        /// </summary>
        public DateTime EndDate { get; set; }

    }
}
