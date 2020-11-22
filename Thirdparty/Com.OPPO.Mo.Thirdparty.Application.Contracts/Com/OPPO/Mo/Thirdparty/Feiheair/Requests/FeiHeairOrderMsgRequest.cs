namespace Com.OPPO.Mo.Thirdparty.Feiheair.Requests
{
    /// <summary>
    /// 主动获取消息输入参数
    /// </summary>
    public class FeiHeairOrderMsgRequest : FeiHeairBaseRequest
    {
        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 消息ID 最后一个ID，上一次获取的最大ID作为下一次请求ID，第一次获取时，ID为0
        /// </summary>
        public string LastID { get; set; }
    }
}
