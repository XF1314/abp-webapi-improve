using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索推送的提示词类型
    /// </summary>
    public enum DataGrandSuggestionSource
    {
        /// <summary>
        /// 系统定义
        /// </summary>
        [Display(Name = "系统定义")]
        System = 0,

        /// <summary>
        /// 流程模块
        /// </summary>
        [Display(Name = "流程模块")]
        ProcessModule = 1,

        /// <summary>
        /// 功能模块
        /// </summary>
        [Display(Name = "功能模块")]
        FunctionModule = 2,

        /// <summary>
        /// 扩展模块
        /// </summary>
        [Display(Name = "扩展模块")]
        ExtensionModule = 3,

        /// <summary>
        /// 用户习惯
        /// </summary>
        [Display(Name = "用户习惯")]
        Custom =4
    }
}
