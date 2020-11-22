using Com.OPPO.Mo.Bpm.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Com.OPPO.Mo.Bpm.Etos
{
    /// <summary>
    /// 流程回调Eto
    /// </summary>
    public class ProcessCallbackEto
    {
        /// <summary>
        /// 流程事件Id<see cref="ProcessEventMessageDto.Id"/>
        /// </summary>
        public string ProcessEventMessageId { get; set; }

        /// <summary>
        /// 回调地址
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// 参数s
        /// </summary>
        public Dictionary<string, string> @Params { get; set; }

        /// <summary>
        /// 是否需要携带Paas平台Token
        /// </summary>
        public bool IsNeedPaasToken { get; set; } = false;

        /// <summary>
        /// 请求头s
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// 成功断言s（多个断言取与），通过验证响应内容是否包含特定内容，来判断回调是否成功，通过<see cref="Regex.Match(string)"/>实现
        /// 譬如：响应内容为：{  "code": 1000,  "message": "成功",  "isSuccess": true}，判断成功的依据是code值为1000
        /// 成功判断条件可配置为：["\"code\": 1000","\"isSuccess\": true"]
        /// </summary>
        public List<string> SuccessAssertions { get; set; }

        /// <summary>
        /// 事件时间
        /// </summary>
        public DateTime EventTime { get; set; } = DateTime.Now;
    }
}
