namespace Com.OPPO.Mo.Thirdparty.Feiheair.Requests
{
    /// <summary>
    /// 获取飞鹤key输入参数
    /// </summary>
    public class FeiHeairKeyRequest : FeiHeairBaseRequest, IPassword
    {
        public FeiHeairKeyRequest()
        {
            //此接口为系统调用，所以工号固定为“system”
            UserCode = "system";
        }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }

    }
}
