using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Responses
{
    /// <summary>
    /// 达观搜索响应状态
    /// </summary>
    public enum DataGrandResponseStatus
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Display(Name = "未知")]
        UNKOWN = 0,

        /// <summary>
        /// 成功
        /// </summary>
        [Display(Name = "成功")]
        OK = 1,

        /// <summary>
        /// 失败
        /// </summary>
        [Display(Name = "失败")]
        FAIL = 2,

        /// <summary>
        /// 警告
        /// </summary>
        [Display(Name = "警告")]
        WARN = 3

        ///// <summary>
        ///// 成功
        ///// </summary>
        //public const string Ok = "OK";

        ///// <summary>
        ///// 失败
        ///// </summary>
        //public const string Fail = "FAIL";

        ///// <summary>
        ///// 警告
        ///// </summary>
        //public const string Warn = "WARN";
    }
}
