using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Dtos
{
   public class BatchLeaveDto
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string EmployeeId { get; set; }
        /// <summary>
        /// 文件编号
        /// </summary>
        public string ProcessInstanceCode { get; set; }
        /// <summary>
        /// 请假开始日期
        /// </summary>
        public string BeginDate { get; set; }
        /// <summary>
        /// 请假开始时间
        /// </summary>
        public string BeginTime { get; set; }
        /// <summary>
        /// 请假结束日期
        /// </summary>
        public string EndDate { get; set; }
        /// <summary>
        /// 请假结束日期
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 请假总天数
        /// </summary>
        public float TotalDays { get; set; }
        /// <summary>
        /// 事假
        /// </summary>
        public float DaysOfPersonalLeave { get; set; }
        /// <summary>
        /// 年休假
        /// </summary>
        public float DaysOfAnnualLeave { get; set; }
        /// <summary>
        /// 周末假
        /// </summary>
        public float DaysOfWeekend { get; set; }
        /// <summary>
        /// 看护假
        /// </summary>
        public float DaysOfNursingLeave { get; set; }
        /// <summary>
        /// 婚假
        /// </summary>
        public float DaysOfMarriageLeave { get; set; }
        /// <summary>
        /// 产检假
        /// </summary>
        public float DaysOfAntenatalExaminationLeave { get; set; }
        /// <summary>
        /// 产假
        /// </summary>
        public float DaysOfMaternityLeave { get; set; }
        /// <summary>
        /// 病假
        /// </summary>
        public float DaysOfSickLeave { get; set; }
        /// <summary>
        /// 公司特殊放假或法定节假日+多胞胎假+流产假+难产假+探亲假
        /// </summary>
        public float DaysOfSpecialLeave { get; set; }
        /// <summary>
        /// 工伤假
        /// </summary>
        public float DaysOfInjuryLeave { get; set; }
        /// <summary>
        /// 丧假
        /// </summary>
        public float DaysOfFuneralLeave { get; set; }
        /// <summary>
        /// 当前日期
        /// </summary>
        public string ApproveDate { get; set; }
        /// <summary>
        /// 请假事由
        /// </summary>
        public string LeaveCause { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// 与请假是否相符,默认值为Y
        /// </summary>
        public string IsItConsistentWithLeaveInfo { get; set; }
        /// <summary>
        /// 是否有销假资料,默认值为N
        /// </summary>
        public string CancelLeave { get; set; }
    }
}
