using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo
{
    /// <summary>
    ///结果状态码
    /// </summary>
    public enum ResultCode
    {
        /// <summary>
        /// 操作成功
        ///</summary>
        [Display(Name = "操作成功", GroupName = Result.Successfull)]
        Ok = MoConsts.BaseResultCode + 0,

        /// <summary>
        /// 操作失败
        ///</summary>
        [Display(Name = "操作失败")]
        Fail = MoConsts.BaseResultCode + 1,

        /// <summary>
        /// 服务器异常
        ///</summary>
        [Display(Name = "服务异常")]
        ServerError = MoConsts.BaseResultCode + 10,

        /// <summary>
        /// 未认证
        ///</summary>
        [Display(Name = "未认证")]
        Unauthencatied = MoConsts.BaseResultCode + 20,

        /// <summary>
        /// 未授权
        ///</summary>
        [Display(Name = "未授权")]
        Unauthorized = MoConsts.BaseResultCode+30,

        /// <summary>
        /// 禁止访问
        /// </summary>
        [Display(Name = "禁止访问")]
        Forbidden = MoConsts.BaseResultCode + 40,

        /// <summary>
        /// Token 验证失败
        /// </summary>
        [Display(Name = "无效Token")]
        InvalidToken = MoConsts.BaseResultCode + 50,

        /// <summary>
        /// 签名验证失败
        /// </summary>
        [Display(Name = "签名验证失败")]
        InvalidSign = MoConsts.BaseResultCode + 100,

        /// <summary>
        /// 参数验证失败
        /// </summary>
        [Display(Name = "参数验证失败")]
        InvalidParams = MoConsts.BaseResultCode + 200,

        /// <summary>
        /// 没有数据
        ///</summary>
        [Display(Name = "没有数据")]
        NoData = MoConsts.BaseResultCode + 404,

        /// <summary>
        /// 数据重复
        /// </summary>
        [Display(Name = "数据重复")]
        DuplicateData = MoConsts.BaseResultCode + 405,

        /// <summary>
        /// 关键数据缺失
        /// </summary>
        [Display(Name = "关键数据缺失")]
        MissEssentialData = MoConsts.BaseResultCode + 406,
    }
}