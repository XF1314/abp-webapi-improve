using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OTravel.Dto
{

    /// <summary>
    /// 行程信息
    /// </summary>
    public class JourneyData
    {
        /// <summary>
        /// 行程序号
        /// </summary>
        public string seqNo { get; set; }
        /// <summary>
        /// 出发城市
        /// </summary>
        public string fromCity { get; set; }
        /// <summary>
        /// 目的城市
        /// </summary>
        public string toCity { get; set; }
        /// <summary>
        /// 地区类别（缺省“COMMON”）
        /// </summary>
        public string areaType { get; set; }
        /// <summary>
        /// 交通工具（plane/train/boat/bus/car/other：飞机/火车/轮船/汽车/自备车/其他）
        /// </summary>
        public string trafficTool { get; set; }
        /// <summary>
        /// 开始日期：YYYY-MM-DD
        /// </summary>
        public string startDate { get; set; }
        /// <summary>
        /// 结束日期：YYYY-MM-DD
        /// </summary>
        public string endDate { get; set; }
    }

    /// <summary>
    /// 同行人信息
    /// </summary>
    public class CompanionData
    {
        /// <summary>
        /// 人员类型（EMPLOYEE/RELATIVE：员工/亲友）
        /// </summary>
        public string personnelType { get; set; }
        /// <summary>
        /// 员工编码（人员类型为员工，则此值为必填）
        /// </summary>
        public string empNum { get; set; }
        /// <summary>
        /// 人员姓名
        /// </summary>
        public string personnelName { get; set; }
        /// <summary>
        /// 证件姓名（证件上的姓名）
        /// </summary>
        public string passName { get; set; }
        /// <summary>
        /// 证件类型（0/1/2：身份证/护照/其他）
        /// </summary>
        public string passType { get; set; }
        /// <summary>
        /// 证件编码
        /// </summary>
        public string passNum { get; set; }
        /// <summary>
        /// 人员手机号
        /// </summary>
        public string mobilePhone { get; set; }
        /// <summary>
        /// 人员邮箱
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 费用归属部门ID
        /// </summary>
        public string sourceDeptId { get; set; }
        /// <summary>
        /// 费用归属部门名称
        /// </summary>
        public string deptName { get; set; }
    }

    public class TravelDetailsDto
    {
        /// <summary>
        /// 来源类型，固定为SYSTEM
        /// </summary>
        public string sourceType { get; set; }
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
        /// 出差人员工编号，客户系统流程单出差负责人，如果没有则填写流程单创建人
        /// </summary>
        public string errandEmpNum { get; set; }
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
        /// 出差单是否能修改 
        /// </summary>
        public string isCanModify { get; set; }
        /// <summary>
        /// 同行人信息
        /// </summary>
        public IList<CompanionData> companionInfos { get; set; }
        /// <summary>
        /// 行程信息
        /// </summary>
        public IList<JourneyData> journeyInfos { get; set; }

        /// <summary>
        /// 预算类型 
        /// </summary>
        public string budgetType { get; set; }
        /// <summary>
        /// 预算编码 
        /// </summary>
        public string budgetCode { get; set; }
        /// <summary>
        /// 事业部 
        /// </summary>
        public string businessUnit { get; set; }
        /// <summary>
        /// 产品线 
        /// </summary>
        public string productLine { get; set; }
        /// <summary>
        /// 区域 
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// 渠道 
        /// </summary>
        public string channel { get; set; }
    }

}
