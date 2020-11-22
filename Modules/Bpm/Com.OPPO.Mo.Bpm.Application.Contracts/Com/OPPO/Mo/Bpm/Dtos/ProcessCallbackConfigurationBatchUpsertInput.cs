using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 流程回调配置批量新增/更新Input
    /// </summary>
    public class ProcessCallbackConfigurationBatchUpsertInput
    {
        /// <summary>
        /// <see cref="ProcessCallbackConfigurationBatchUpsertInput"/>
        /// </summary>
        public ProcessCallbackConfigurationBatchUpsertInput()
        {
            ParamsPaths = new List<string>();
            SuccessAssertions = new List<string>();
            Headers = new Dictionary<string, string>();
        }

        /// <summary>
        /// 【必填项】应用Id
        /// </summary>
        [JsonRequired]
        public string AppId { get; set; }

        /// <summary>
        /// 【必填项】应用名称
        /// </summary>
        [JsonRequired]
        public string AppName { get; set; }

        /// <summary>
        /// 【必填项】流程定义Id
        /// </summary>
        [JsonRequired]
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 【必填项】流程名称
        /// </summary>
        [JsonRequired]
        public string ProcessName { get; set; }

        /// <summary>
        /// 【必填项】流程事件名称
        /// </summary>
        [JsonRequired]
        public List<string> ProcessEventNames { get; set; }

        /// <summary>
        /// 【必填项】参数路径s，属性嵌套以:标识，该路径用于访问<see cref="ProcessEventMessageDto"/>中的属性
        /// 譬如：<see cref="ProcessEventMessageDto"/>中的<see cref="ProcessEventMessageDto.ProcessDefinition"/>对象的<see cref="ProcessDefinitionInfoDto.ProcessDefinitionId"/>
        /// 参数路径则配置为processDefinition:processDefinitionId
        /// </summary>
        [JsonRequired]
        public List<string> ParamsPaths { get; set; }

        /// <summary>
        /// 是否需要携带Paas平台Token
        /// </summary>
        public bool IsNeedPaasToken { get; set; } = false;

        /// <summary>
        /// 【非必填项】成功断言s（多个断言取与），通过验证响应内容是否包含特定内容，来判断回调是否成功，通过<see cref="Regex.Match(string)"/>实现
        /// 譬如：响应内容为：{  "code": 1000,  "message": "成功",  "isSuccess": true}，判断成功的依据是code值为1000
        /// 成功判断条件可配置为：["\"code\": 1000","\"isSuccess\": true"]
        /// </summary>
        [JsonRequired]
        public List<string> SuccessAssertions { get; set; }

        /// <summary>
        /// 【必填项】回调地址
        /// </summary>
        [JsonRequired]
        public string CallbackUrl { get; set; }

        /// <summary>
        /// 【非必填项】请求头s
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// 【非必填项】暗号
        /// </summary>
        public string Cipher { get; set; }
    }
}
