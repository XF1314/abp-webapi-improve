namespace Com.OPPO.Mo.Thirdparty.Hr.LMS.Dtos
{
    /// <summary>
    /// 离职同步审批信息
    /// </summary>
    public class SyncMsgDto
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 成功或失败（success）
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string Datetime { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
    }
}
