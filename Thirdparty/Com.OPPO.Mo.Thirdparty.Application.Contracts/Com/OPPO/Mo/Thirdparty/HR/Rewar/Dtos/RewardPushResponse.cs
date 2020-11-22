using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Hr.Rewar.Dtos
{
    /// <summary>
    /// 奖励推送输出信息
    /// </summary>
    public class RewardPushDto
    {
        /// <summary>
        /// 薪资组
        /// </summary>
        [JsonProperty("GP_PAYGROUP")] 
        public string Gppaygroup { get; set; }

        /// <summary>
        /// 日历ID
        /// </summary>
        [JsonProperty("AL_ID")]
        public string CalId { get; set; }

        /// <summary>
        /// 员工ID
        /// </summary>
        [JsonProperty("EMPLID")]
        public string EmplId { get; set; }

        /// <summary>
        /// 员工记录号
        /// </summary>
        [JsonProperty("EMPL_RCD")]
        public string EmplRcd { get; set; }

        /// <summary>
        /// 工资项编码
        /// </summary>      
        [JsonProperty("PIN_NUM")]
        public string Pinnum { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [JsonProperty("AMT")]
        public string Amount { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty("STATUS")]
        public string Status { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [JsonProperty("DESCR")]
        public string Descr { get; set; }

    }

}
