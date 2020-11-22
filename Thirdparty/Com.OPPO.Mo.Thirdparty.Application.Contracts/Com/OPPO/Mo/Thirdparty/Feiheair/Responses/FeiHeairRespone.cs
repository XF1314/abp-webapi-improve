namespace Com.OPPO.Mo.Thirdparty.Feiheair.Dtos
{
    /// <summary>
    ///返回信息
    /// </summary>
    public class FeiHeairRespone
    {
        /// <summary>
        /// 错误代码(0表示成功，其它为失败)
        /// </summary>
        public int ErrCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }
    }

    /// <inheritdoc/>
    public class FeiHeairRespone<TData> : FeiHeairRespone
    {
        /// <summary>
        /// <see cref="FeiHeairRespone{TData}"/>
        /// </summary>
        public FeiHeairRespone()
        {
            Body = default;
        }

        /// <summary>
        /// 响应体
        /// </summary>
        public FeiHeairRespone<TData> Body { get; set; }
    }
}
