namespace Com.OPPO.Mo.Thirdparty.DiDi.Dtos
{
    /// <summary>
    /// DiDi创建审批输出类
    /// </summary>
    public class DiDiCreateDto
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public string Errno { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        public string Errmsg { get; set; }

        /// <summary>
        /// 审批信息
        /// </summary>
        public DiDiData Data { get; set; }
    }

    public class DiDiData
    {
        /// <summary>
        /// 审批单ID
        /// </summary>
        public string ApprovalId { get; set; }
    }
}
