using Com.OPPO.Mo.Thirdparty.Hr.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Dtos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Responses
{
    public class BatchLeavePushInfo
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        [Required]
        public string ProcessInstanceCode { get; set; }
        /// <summary>
        /// 请假信息,,参数格式：[{"EmployeeId ":"工号 ","FormInstanceCode ":"文件编号 ","BeginDate ":"2020-06-19"（请假开始日期）,"BeginTime ":"08:00"（请假开始时间）,"EndDate ":"2020-06-19"（请假结束日期）,"EndTime ":"12:00"（请假结束时间）,"TotalDays ":0.5（请假总天数）,"DaysOfPersonalLeave ":0.5（事假）,"DaysOfAnnualLeave ":0.0（年休假）,"DaysOfWeekend ":0.0（周末假）,"DaysOfNursingLeave ":0.0（看护假）,"DaysOfMarriageLeave ":0.0（婚假）,"DaysOfAntenatalExaminationLeave ":0.0（产检假）,"DaysOfMaternityLeave ":0.0（产假）,"DaysOfSickLeave ":0.0（病假）,"DaysOfSpecialLeave ":0.0（公司特殊放假或法定节假日+多胞胎假+流产假+难产假+探亲假）,"DaysOfInjuryLeave ":0.0（工伤假）,"DaysOfFuneralLeave ":0.0（丧假）,"ApproveDate ":"2020-06-18 "（审批时间）,"LeaveCause ":"请假原因","Comments ":"备注","IsItConsistentWithLeaveInfo ":"Y "（与请假是否相符,默认值为Y）,"CancelLeave ":"N "（是否有销假资料,默认值为N）}]
        /// </summary>
        [Required]
        public List<BatchLeaveDto> LeaveDatas { get; set; }
    }
}
