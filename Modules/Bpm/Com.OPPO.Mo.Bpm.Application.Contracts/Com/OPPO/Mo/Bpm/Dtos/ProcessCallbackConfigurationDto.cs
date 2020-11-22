using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Volo.Abp.Domain.Entities;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 流程回调配置Dto
    /// </summary>
    public class ProcessCallbackConfigurationDto
    {
        /// <summary>
        /// <see cref="IEntity{Guid}.Id"/>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// 流程定义Id
        /// </summary>
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 流程名称
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// 流程事件名称
        /// </summary>
        public string ProcessEventName { get; set; }

        /// <summary>
        /// 【必填项】参数路径s，属性嵌套以:标识，该路径用于访问<see cref="ProcessEventMessageDto"/>中的属性
        /// 譬如：<see cref="ProcessEventMessageDto"/>中的<see cref="ProcessEventMessageDto.ProcessDefinition"/>对象的<see cref="ProcessDefinitionInfoDto.ProcessDefinitionId"/>
        /// 参数路径则配置为processDefinition:processDefinitionId
        /// </summary>
        public List<string> ParamsPaths { get; set; }

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
        /// 回调地址
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// 暗号
        /// </summary>
        public string Cipher { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }
    }
}
