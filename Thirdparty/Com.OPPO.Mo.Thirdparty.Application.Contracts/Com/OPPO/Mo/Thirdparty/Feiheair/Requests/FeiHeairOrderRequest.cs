namespace Com.OPPO.Mo.Thirdparty.Feiheair.Requests
{
    /// <summary>
    /// 获取申请单（订单）对应订单数据输入参数
    /// </summary>
    public class FeiHeairOrderRequest : FeiHeairBaseRequest
    {
        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 类型
        /// 1：申请单号,2：订单号列表（多个订单号用英文,隔开）
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 单号(值取决于type参数)
        /// </summary>
        public string Id { get; set; }

    }
}
