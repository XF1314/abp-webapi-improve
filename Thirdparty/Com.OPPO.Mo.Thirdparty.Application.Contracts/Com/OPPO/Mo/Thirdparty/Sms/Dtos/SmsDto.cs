namespace Com.OPPO.Mo.Thirdparty.Sms.Dtos
{
    /// <summary>
    /// 发送短信，消息返回实体信息
    /// </summary>
    public class SmsDto
    {
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public int Ret { get; set; }
    }
}
