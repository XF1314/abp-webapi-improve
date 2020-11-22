namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos
{
    /// <summary>
    /// 认证信息输出类
    /// </summary>
    public class PsQualificationDto
    {
        /// <summary>
        /// 成功或是失败消息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 0表示成功，大于0表示失败
        /// </summary>
        public int Code { get; set; }
    }
}
