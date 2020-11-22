
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Requests
{
    /// <summary>
    /// PeopleSoft请假信息新增Request
    /// </summary>
    public class PeopleSoftLeaveInfoAddRequest : BaseEsbRequest
    {
        /// <summary>
        /// <see cref="PeopleSoftLeaveInfoAddRequest"/>
        /// </summary>
        public PeopleSoftLeaveInfoAddRequest()
        {
        }

        [JsonProperty("leave_data")]
        public string LeaveData { get; set; }


    }

    public class LeaveChangeInfo: LeaveDataInfo
    {
        /// <summary>
        /// 是否与请假相符合
        /// </summary>
        [JsonProperty("hhrFlag")]
        public string IsItConsistentWithLeaveInfo { get; set; }

        /// <summary>
        /// 是否有销假资料
        /// </summary>
        [JsonProperty("hhrFlag1")]
        public string IsHasFile { get; set; }

        /// <summary>
        /// 销假日期
        /// </summary>
        [JsonProperty("hhrApprovalDate")]
        public string ApprovelDate { get; set; }

    }

    public class LeaveDataInfo
    {
      
        /// <summary>
        /// 人员工号
        /// </summary>
        [JsonProperty("hhrEmplid")]
        public string EmployeeId { get; set; }

        /// <summary>
        /// 单据编码
        /// </summary>
        [JsonProperty("hhrInstanceId")]
        public string FormInstanceCode { get; set; }

        /// <summary>
        /// 请假开始日期
        /// </summary>
        [JsonProperty("hhrBeginDate")]
        public string BeginDate { get; set; }
        /// <summary>
        /// 请假开始时间
        /// </summary>
        [JsonProperty("hhrBeginDateTime")]
        public string BeginTime { get; set; }

        /// <summary>
        /// 请假结束日期
        /// </summary>
        [JsonProperty("hhrEndDate")]
        public string EndDate { get; set; }

        /// <summary>
        /// 请假结束时间
        /// </summary>
        [JsonProperty("hhrEndDateTime")]
        public string EndTime { get; set; }

        /// <summary>
        /// 请假天数
        /// </summary>
        [JsonProperty("hhrleaveDays")]
        public float TotalDays { get; set; }


        /// <summary>
        /// 请事假天数
        /// </summary>
        [JsonProperty("hhrleaveDays01")]
        public float DaysOfPersonalLeave { get; set; }

        /// <summary>
        /// 请年休假天数
        /// </summary>
        [JsonProperty("hhrleaveDays02")]
        public float DaysOfAnnualLeave { get; set; }

        /// <summary>
        /// 请周末假天数
        /// </summary>
        [JsonProperty("hhrleaveDays03")]
        public float DaysOfWeekend { get; set; }

        /// <summary>
        /// 请看护假天数
        /// </summary>
        [JsonProperty("hhrleaveDays04")]
        public float DaysOfNursingLeave { get; set; }

        /// <summary>
        /// 请婚假天数
        /// </summary>
        [JsonProperty("hhrleaveDays05")]
        public float DaysOfMarriageLeave { get; set; }

        /// <summary>
        /// 请产检假天数
        /// </summary>
        [JsonProperty("hhrleaveDays06")]
        public float DaysOfAntenatalExaminationLeave { get; set; }

        /// <summary>
        /// 请产假天数
        /// </summary>
        [JsonProperty("hhrleaveDays07")]
        public float DaysOfMaternityLeave { get; set; }

        /// <summary>
        /// 病假
        /// </summary>
        [JsonProperty("hhrleaveDays08")]
        public float DaysOfSickLeave { get; set; }

        /// <summary>
        /// 请特殊假(探亲假+难产假+流产假+多胞胎假)天数
        /// </summary>
        [JsonProperty("hhrleaveDays09")]
        public float DaysOfSpecialLeave { get; set; }

        /// <summary>
        /// 请工伤假天数
        /// </summary>
        [JsonProperty("hhrleaveDays10")]
        public float DaysOfInjuryLeave { get; set; }

        /// <summary>
        /// 请丧假天数
        /// </summary>
        [JsonProperty("hhrleaveDays11")]
        public float DaysOfFuneralLeave { get; set; }

        /// <summary>
        /// 请假公布时间
        /// </summary>
        [JsonProperty("hhrApproveDate")]
        public string ApproveDate { get; set; }

        /// <summary>
        /// 请假事由
        /// </summary>
        [JsonProperty("hhrleaveCause")]
        public string LeaveCause { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("hhrComments")]
        public string Comments { get; set; }
    }

}
