using Com.OPPO.Mo.Bpm.ActionSoft.Processes;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiClient.DataAnnotations;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoft Eai任务创建Request
    /// </summary>
    public class ActionSoftEaiTaskCreateRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftEaiTaskCreateRequest"/>
        /// </summary>
        public ActionSoftEaiTaskCreateRequest() : base(ActionSoftTaskCommands.EaiTaskCreate)
        { }

        /// <summary>
        ///【必填项】应用系统简称，最长36个字符
        /// </summary>
        [JsonRequired]
        [JsonProperty("applicationName")]
        public string AppName { get; set; }

        /// <summary>
        ///【必填项】Eai任务业务标识（由业务系统提供）
        /// </summary>
        [JsonRequired]
        [JsonProperty("outerId")]
        public string EaiTaskBizId { get; set; }

        /// <summary>
        ///【必填项】Eai任务标题
        /// </summary>
        [JsonRequired]
        [JsonProperty("title")]
        public string EaiTaskTitle { get; set; }

        /// <summary>
        /// 【必填项】在待办中构建和点击该任务时，该任务提供的配置参数
        /// PS：因为字段长度不够，废弃该字段使用，改用EXT4字段存放ActionParams相关参数
        /// </summary>
        [JsonRequired]
        [JsonProperty("actionParameter")]
        private string ActionParams_Abandon { get; set; } = "{}";

        /// <summary>
        /// <see cref="ActionSoftEaiTaskExtensionInfo"/>
        /// </summary>
        [JsonIgnore]
        public ActionSoftEaiTaskExtensionInfo ExtensionInfo { get; set; }

        /// <summary>
        /// <see cref="ActionSoftEaiTaskExtensionInfo"/>
        /// </summary>
        [JsonRequired]
        [JsonProperty("params")]
        private string extensionInfo => JsonConvert.SerializeObject(ExtensionInfo);

        /// <summary>
        /// 【必填项】<see cref="ActionSoftPriority"/>
        /// </summary>
        [JsonRequired]
        public ActionSoftPriority Priority { get; set; }

        /// <summary>
        ///【必填项】Eai任务实例创建人工号
        /// </summary>
        [JsonRequired]
        [JsonProperty("createUid")]
        public string CreatorUserCode { get; set; }

        /// <summary>
        ///【必填项】Eai任务实例认领人工号
        /// </summary>
        [JsonRequired]
        [JsonProperty("targetUid")]
        public string ClaimToUserCode { get; set; }

        /// <summary>
        /// 【选填项】<see cref="ActionSoftClassifyType"/>
        /// </summary>
        [JsonProperty("advanceType")]
        public ActionSoftClassifyType? ClassifyType { get; set; }

        /// <summary>
        /// 【选填项】分类定义Id，IOX扩展属性中定义
        /// </summary>
        [JsonProperty("valueId")]
        public string ClassifyId { get; set; }
    }

    /// <summary>
    /// ActionSoft Eai任务扩展信息
    /// </summary>
    public class ActionSoftEaiTaskExtensionInfo
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
        [JsonProperty("EXT4")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftProcessState ProcessState { get; set; }

        /// <summary>
        /// 关键字s，用于模糊搜索
        /// </summary>
        [JsonProperty("EXT5")]
        public string Keywords { get; set; }

        /// <summary>
        /// 【必填项】<see cref="ActionSoftEaiTaskActionParameterInfo"/>
        /// </summary>
        [JsonIgnore]
        public ActionSoftEaiTaskActionParameterInfo ActionParams { get; set; }

        /// <summary>
        /// <see cref="ActionSoftEaiTaskActionParameterInfo"/>
        /// </summary>
        [JsonRequired]
        [JsonProperty("EXT6")]
        private string actionParams => JsonConvert.SerializeObject(ActionParams);

        /// <summary>
        /// 【必填项】是否支持移动端
        /// </summary>
        [JsonIgnore]
        public bool IsMobileSupport { get; set; }

        /// <summary>
        ///【必填项】是否支持移动端,取值： 0:是，1:否
        /// </summary>
        [JsonProperty("EXT7")]
        public string isMobileSupport => IsMobileSupport ? "0" : "1";

        /// <summary>
        /// 【必填项】创建时间
        /// </summary>
        [DateTimeFormat("yyyy-MM-dd HH:mm:ss")]
        public DateTime CreateTime { get; set; }
    }


    /// <summary>
    /// ActionSoft Eai任务行为参数信息，用于控制其在前端页面的表现效果
    /// </summary>
    public class ActionSoftEaiTaskActionParameterInfo
    {
        /// <summary>
        /// <see cref="ActionSoftEaiTaskActionParameterInfo"/>
        /// </summary>
        public ActionSoftEaiTaskActionParameterInfo()
        {
            Options = new List<string>();
        }

        /// <summary>
        /// 【必填项】Pc端表单Url
        /// </summary>
        [JsonRequired]
        [JsonProperty("pcUrl")]
        public string PcFormUrl { get; set; }

        /// <summary>
        /// 【必填项】移动端表单Url
        /// </summary>
        [JsonRequired]
        [JsonProperty("mobileUrl")]
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
        [JsonProperty("quickOpts")]
        public List<string> Options { get; set; }
    }


}
