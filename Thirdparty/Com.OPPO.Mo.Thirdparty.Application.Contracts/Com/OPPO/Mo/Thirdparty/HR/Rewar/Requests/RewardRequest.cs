using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Hr.Rewar.Requests
{
    /// <summary>
    /// 奖励请求发送
    /// </summary>
    public class RewardRequest : PsHrBaseRequest
    {
        public RewardRequest()
        {
            Data = new List<RewardInfo>();
        }

        /// <summary>
        /// 奖励请求信息
        /// </summary>
        [JsonProperty("data")]
        public List<RewardInfo> Data { get; set; }
    }

    public class RewardInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty(PropertyName = "CAL_ID")]
        public string Id { get; set; }

        /// <summary>
        /// 员工编码
        /// </summary>
        [JsonProperty("EMPLID")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// 员工类型
        /// </summary>
        [JsonProperty("EMPL_RCD")]
        public string EmployeeType { get; set; }

        /// <summary>
        /// Pin Number
        /// </summary>
        [JsonProperty("PIN_NUM")]
        public string PinNumber { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [JsonProperty("AMT")]
        public string Amount { get; set; }

        /// <summary>
        /// 货币类型
        /// </summary>
        [JsonProperty("CURRENCY_CD")]
        public string CurrencyType { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [JsonProperty("TYPE")]
        public string Type { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        [JsonProperty("ACTION_TYPE")]
        public string ActionType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("REMARK")]
        public string Remark { get; set; }

        /// <summary>
        /// 发文编码
        /// </summary>
        [JsonProperty("FILE_NUMBER")]
        public string FormInstanceCode { get; set; }

        /// <summary>
        /// 原因
        /// </summary>
        [JsonProperty("REASON")]
        public string Reason { get; set; }

        /// <summary>
        /// 奖分
        /// </summary>
        [JsonProperty("POINT")]
        public string Point { get; set; }

    }
}
