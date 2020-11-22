
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Requests
{
    /// <summary>
    /// PeopleSoft请假信息更新Request
    /// </summary>
    public class PeopleSoftLeaveInfoUpdateRequest : BaseEsbRequest
    {
        /// <summary>
        /// 单据编码
        /// </summary>
        [JsonProperty("formInstance_code")]
        public string FormInstanceCode { get; set; }

        /// <summary>
        /// 请假人工号
        /// </summary>
        [JsonProperty("employee_id")]
        public string LeaverUserCode { get; set; }

        /// <summary>
        /// 请假单审批完成时间
        /// </summary>
        [JsonProperty("approval_date")]
        public DateTime ApprovalFinishTime { get; set; }

        /// <summary>
        /// 实际休假是否与请假一致
        /// </summary>
        [JsonIgnore]
        public bool IsConsistent { get; set; }

        /// <summary>
        /// 实际休假是否与请假一致
        /// </summary>
        [JsonProperty("flag")]
        public string IsConsitent_Temp => IsConsistent ? "Y" : "N";

        /// <summary>
        /// 是否有销假资料
        /// </summary>
        [JsonIgnore]
        public bool HasReportBackMaterial { get; set; }

        /// <summary>
        /// 是否有销假资料
        /// </summary>
        [JsonProperty("flag1")]
        public string HasReportBackMaterial_Temp => HasReportBackMaterial ? "Y" : "N";
    }
}
