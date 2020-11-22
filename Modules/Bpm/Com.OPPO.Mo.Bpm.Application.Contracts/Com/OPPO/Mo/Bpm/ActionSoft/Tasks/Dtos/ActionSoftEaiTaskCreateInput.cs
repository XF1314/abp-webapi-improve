using Com.OPPO.Mo.Bpm.ActionSoft.Processes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos
{
    /// <summary>
    /// ActionSoft Eai任务创建Input
    /// </summary>
    public class ActionSoftEaiTaskCreateInput
    {
        /// <summary>
        ///【必填项】应用系统简称，最长36个字符
        /// </summary>
        [JsonRequired]
        public string AppName { get; set; }

        /// <summary>
        ///【必填项】Eai任务实例的业务标识Id
        /// </summary>
        [JsonRequired]
        public string EaiTaskBizId { get; set; }

        /// <summary>
        ///【必填项】Eai任务标题
        /// </summary>
        [JsonRequired]
        public string EaiTaskTitle { get; set; }

        /// <summary>
        /// 【必填项】<see cref="ActionSoftEaiTaskActionParameterInfoDto"/>
        /// </summary>
        [JsonRequired]
        public ActionSoftEaiTaskExtensionInfoDto ExtensionInfo { get; set; }

        /// <summary>
        /// 【必填项】<see cref="ActionSoftPriority"/>
        /// </summary>
        [JsonRequired]
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftPriority Priority { get; set; }

        /// <summary>
        ///【必填项】Eai任务实例创建人工号
        /// </summary>
        [JsonRequired]
        public string CreatorUserCode { get; set; }

        /// <summary>
        ///【必填项】Eai任务实例认领人工号
        /// </summary>
        [JsonRequired]
        public string ClaimToUserCode { get; set; }

        /// <summary>
        /// 【选填项】<see cref="ActionSoftClassifyType"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftClassifyType? ClassifyType { get; set; }

        /// <summary>
        /// 【选填项】分类定义Id，IOX扩展属性中定义
        /// </summary>
        public string ClassifyId { get; set; }
    }

    /// <summary>
    /// ActionSoft Eai任务扩展信息Dto
    /// </summary>
    public class ActionSoftEaiTaskExtensionInfoDto
    {
        /// <summary>
        /// 【必填项】Eai任务所关联的业务流程实例编码
        /// </summary>
        [JsonRequired]
        public string ProcessInstanceCode { get; set; }

        /// <summary>
        /// 【必填项】Eai任务所关联的流程状态<see cref="ActionSoftProcessState"/>
        /// </summary>
        [JsonRequired]
        public ActionSoftProcessState ProcessState { get; set; }

        /// <summary>
        /// 【非必填项】关键字s，用于模糊搜索
        /// </summary>
        [JsonRequired]
        public string Keywords { get; set; }

        /// <summary>
        /// 【必填项】<see cref="ActionSoftEaiTaskActionParameterInfoDto"/>
        /// </summary>
        [JsonRequired]
        public ActionSoftEaiTaskActionParameterInfoDto ActionParams { get; set; }

        /// <summary>
        /// 【必填项】是否支持移动端
        /// </summary>
        public bool IsMobileSupport { get; set; }

        /// <summary>
        /// 【非必填项】创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }

    /// <summary>
    /// ActionSoft Eai任务行为参数信息Dto，用于控制其在前端页面的表现效果
    /// </summary>
    public class ActionSoftEaiTaskActionParameterInfoDto
    {
        /// <summary>
        /// <see cref="ActionSoftEaiTaskActionParameterInfoDto"/>
        /// </summary>
        public ActionSoftEaiTaskActionParameterInfoDto()
        {
            Options = new List<string>();
        }

        /// <summary>
        /// 【必填项】Pc端表单Url
        /// </summary>
        [JsonRequired]
        public string PcFormUrl { get; set; }

        /// <summary>
        /// 【必填项】移动端表单Url
        /// </summary>
        [JsonRequired]
        public string MobileFormUrl { get; set; }

        /// <summary>
        /// 【必填项】流程名称
        /// </summary>
        [JsonRequired]
        public string ProcessName { get; set; }

        /// <summary>
        /// 【必填项】节点名称
        /// </summary>
        [JsonRequired]
        public string ActivityName { get; set; }

        /// <summary>
        /// 【必填项】拟制人所在部门名称
        /// </summary>
        [JsonRequired]
        public string DepartmentName { get; set; }

        /// <summary>
        /// 【选填项】选项s，通常用于标识该任务支持哪些动作，譬如：agree、reject等
        /// </summary>
        public List<string> Options { get; set; }
    }
}
