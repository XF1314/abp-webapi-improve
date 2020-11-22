using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Adap.Dto
{

    /// <summary>
    /// 行程信息
    /// </summary>
    public class JourneyInfo
    {
        /// <summary>
        /// 行程序号
        /// </summary>
        public string seqNo { get; set; }
        /// <summary>
        /// 出发地三字码
        /// </summary>
        public string departurePlace { get; set; }
        /// <summary>
        /// 出发地中文名
        /// </summary>
        public string departurePlaceCn { get; set; }
        /// <summary>
        /// 目的地三字码
        /// </summary>
        public string destination { get; set; }
        /// <summary>
        /// 目的地中文名
        /// </summary>
        public string destinationCn { get; set; }
        /// <summary>
        /// 开始日期：yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string startDate { get; set; }
        /// <summary>
        /// 结束日期：yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string endDate { get; set; }
        /// <summary>
        /// 是否乘坐飞机 Y-是 N-否
        /// </summary>
        public string isPlane { get; set; }
        /// <summary>
        /// 是否住宿 Y-是 N-否
        /// </summary>
        public string isAccommodation { get; set; }
        /// <summary>
        /// 目的地详细地址，选填
        /// </summary>
        public string destinationAddress { get; set; }
    }

    public class TravelInfoDto
    {
        /// <summary>
        /// 来源Key，客户系统的流程单号
        /// </summary>
        public string sourceKey { get; set; }
        /// <summary>
        /// 出差单状态
        /// </summary>
        public string currentStatus { get; set; }
        /// <summary>
        /// 经办人员工编码，客户系统流程单创建人
        /// </summary>
        public string applyEmpNum { get; set; }
        /// <summary>
        /// 派遣人，选填
        /// </summary>
        public string dispatchPeople { get; set; }
        /// <summary>
        /// 出差人员工编号，客户系统流程单出差负责人，如果没有则填写流程单创建人
        /// </summary>
        public List<string> travelEmpNums { get; set; }
        /// <summary>
        /// 行程类型，INLAND/ OVERSEAS：国内/国际，如果是2，出差类型为境外，否则境内
        /// </summary>
        public string journeyType { get; set; }
        /// <summary>
        /// 出差事由 
        /// </summary>
        public string reason { get; set; }
        /// <summary>
        /// 开始时间 
        /// </summary>
        public string startTime { get; set; }
        /// <summary>
        /// 结束时间 
        /// </summary>
        public string endTime { get; set; }
        /// <summary>
        /// 行程信息
        /// </summary>
        public IList<JourneyInfo> journeyInfos { get; set; }

        /// <summary>
        /// 预算类型 
        /// </summary>
        public string budgetTypes { get; set; }
        /// <summary>
        /// 预算编码 
        /// </summary>
        public string budgetCode { get; set; }
        /// <summary>
        /// 所在部门 
        /// </summary>
        public string businessUnit { get; set; }
        /// <summary>
        /// 事业部 
        /// </summary>
        public string businessDivision { get; set; }
        /// <summary>
        /// 产品线 
        /// </summary>
        public string productLine { get; set; }
        /// <summary>
        /// 区域 
        /// </summary>
        public string area { get; set; }
        /// <summary>
        /// 渠道 
        /// </summary>
        public string channel { get; set; }
    }
}
