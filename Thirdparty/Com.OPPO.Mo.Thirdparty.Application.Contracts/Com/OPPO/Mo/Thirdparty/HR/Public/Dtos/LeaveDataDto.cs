using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Dtos
{
    public class LeaveChangeDto : LeaveDataDto
    {
        /// <summary>
        /// 与请假是否相符,默认值为Y
        /// </summary>
        [Required] 
        public string IsItConsistentWithLeaveInfo { get; set; }
        /// <summary>
        /// 是否有销假资料,默认值为N
        /// </summary>
        [Required] 
        public string IsHasFile { get; set; }

        /// <summary>
        /// 销假日期
        /// </summary>
        public string ApprovelDate { get; set; }

    }

    public class LeaveDataDto
    {
        /// <summary>
        /// 工号
        /// </summary>
        [Required]
        public string EmployeeId { get; set; }
        /// <summary>
        /// 文件编号
        /// </summary>
        [Required] 
        public string FormInstanceCode { get; set; }
        /// <summary>
        /// 请假开始日期
        /// </summary>
        [Required] 
        public string BeginDate { get; set; }
        /// <summary>
        /// 请假开始时间
        /// </summary>
        [Required] 
        public string BeginTime { get; set; }
        /// <summary>
        /// 请假结束日期
        /// </summary>
        [Required] 
        public string EndDate { get; set; }
        /// <summary>
        /// 请假结束日期
        /// </summary>
        [Required] 
        public string EndTime { get; set; }
        /// <summary>
        /// 请假总天数
        /// </summary>
        [Required] 
        public float TotalDays { get; set; }
        /// <summary>
        /// 事假
        /// </summary>
        [Required]
        public float DaysOfPersonalLeave { get; set; }
        /// <summary>
        /// 年休假
        /// </summary>
        [Required] 
        public float DaysOfAnnualLeave { get; set; }
        /// <summary>
        /// 周末假
        /// </summary>
        [Required] 
        public float DaysOfWeekend { get; set; }
        /// <summary>
        /// 看护假
        /// </summary>
        [Required] 
        public float DaysOfNursingLeave { get; set; }
        /// <summary>
        /// 婚假
        /// </summary>
        [Required] 
        public float DaysOfMarriageLeave { get; set; }
        /// <summary>
        /// 产检假
        /// </summary>
        [Required] 
        public float DaysOfAntenatalExaminationLeave { get; set; }
        /// <summary>
        /// 产假
        /// </summary>
        [Required] 
        public float DaysOfMaternityLeave { get; set; }
        /// <summary>
        /// 病假
        /// </summary>
        [Required] 
        public float DaysOfSickLeave { get; set; }
        /// <summary>
        /// 公司特殊放假或法定节假日+多胞胎假+流产假+难产假+探亲假
        /// </summary>
        [Required] 
        public float DaysOfSpecialLeave { get; set; }
        /// <summary>
        /// 工伤假
        /// </summary>
        [Required] 
        public float DaysOfInjuryLeave { get; set; }
        /// <summary>
        /// 丧假
        /// </summary>
        [Required] 
        public float DaysOfFuneralLeave { get; set; }
        /// <summary>
        /// 审批日期
        /// </summary>
        [Required] 
        public string ApproveDate { get; set; }
        /// <summary>
        /// 请假事由
        /// </summary>
        [Required] 
        public string LeaveCause { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Required] 
        public string Comments { get; set; }

    }

}
