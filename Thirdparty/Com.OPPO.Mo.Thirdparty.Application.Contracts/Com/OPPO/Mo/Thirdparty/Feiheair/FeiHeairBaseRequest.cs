namespace Com.OPPO.Mo.Thirdparty.Feiheair
{
    /// <summary>
    /// 滴滴基础请求Request
    /// </summary>
    public class FeiHeairBaseRequest : ICompanyCode, IUserCode
    {
        /// <summary>
        /// 企业代号
        /// </summary>
        public string CompanyCode { get; set; }

        /// <summary>
        /// 用户代码
        /// </summary>
        public string UserCode { get; set; }
    }
}
