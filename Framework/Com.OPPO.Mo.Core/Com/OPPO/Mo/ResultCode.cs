using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo
{
    /// <summary>
    ///结果状态码
    /// </summary>
    public enum ResultCode
    {
        /// <summary>
        /// 成功
        ///</summary>
        [Display(Name = "成功", GroupName = Result.Successfull)]
        Ok = MoBpmConsts.BaseResultCode + 0,

        /// <summary>
        /// 失败
        ///</summary>
        [Display(Name = "失败")]
        Fail = MoBpmConsts.BaseResultCode + 1,

        /// <summary>
        /// 服务器异常
        ///</summary>
        [Display(Name = "服务异常")]
        ServerError = MoBpmConsts.BaseResultCode + 10,

        /// <summary>
        /// 未认证
        ///</summary>
        [Display(Name = "未认证")]
        Unauthenticatied = MoBpmConsts.BaseResultCode + 20,

        /// <summary>
        /// 未授权
        ///</summary>
        [Display(Name = "未授权")]
        Unauthorized = MoBpmConsts.BaseResultCode + 30,

        /// <summary>
        /// 禁止访问
        /// </summary>
        [Display(Name = "禁止访问")]
        Forbidden = MoBpmConsts.BaseResultCode + 40,

        /// <summary>
        /// Token 验证失败
        /// </summary>
        [Display(Name = "无效Token")]
        InvalidToken = MoBpmConsts.BaseResultCode + 50,

        /// <summary>
        /// 签名验证失败
        /// </summary>
        [Display(Name = "签名验证失败")]
        InvalidSign = MoBpmConsts.BaseResultCode + 100,

        /// <summary>
        /// 参数验证失败
        /// </summary>
        [Display(Name = "参数验证失败")]
        InvalidParams = MoBpmConsts.BaseResultCode + 200,

        /// <summary>
        /// 没有数据
        ///</summary>
        [Display(Name = "没有数据")]
        NoData = MoBpmConsts.BaseResultCode + 404,

        /// <summary>
        /// 数据重复
        /// </summary>
        [Display(Name = "数据重复")]
        DuplicateData = MoBpmConsts.BaseResultCode + 405,

        /// <summary>
        /// 关键数据缺失
        /// </summary>
        [Display(Name = "关键数据缺失")]
        MissEssentialData = MoBpmConsts.BaseResultCode + 406,
    }
}