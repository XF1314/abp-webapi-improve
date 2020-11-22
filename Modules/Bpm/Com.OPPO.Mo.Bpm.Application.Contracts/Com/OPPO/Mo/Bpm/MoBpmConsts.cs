using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Com.OPPO.Mo.Bpm
{
    public class MoBpmConsts
    {
        #region ActionSoft
        public const string ActionSoftSignParameterName = "sig";
        public const string ActionSoftSignAlgorithm = "HmacMD5";
        public const string ActionSoftParamsFormat = "json";
        public const string ActionSoftAdminUserCode = "admin";

        public const string ActionSoftUserTask = "UserTask";//人工任务
        public const string ActionSoftSystemTask = "ServiceTask";//系统任务

        public const string ActionSoftCustomApprovers = "CustomApprovers";//自定义审批人

        #endregion

        /// <summary>
        /// 流程事件Topic
        /// </summary>
        public const string ProcessEventMessageTopic = "link.mo.bpm.process.event";

        /// <summary>
        /// 流程回调事件Topic
        /// </summary>
        public const string ProcessCallbackEventTopic = "link.mo.bpm.process.callback.event";


        /// <summary>
        /// 任务事件Topic
        /// </summary>
        public const string TaskEventMessageTopic = "link.mo.bpm.task.event";

        /// <summary>
        /// 任务回调事件Topic
        /// </summary>
        public const string TaskCallbackEventTopic = "link.mo.bpm.task.callback.event";

        /// <summary>
        /// 传阅流程定义Id
        /// </summary>
        public const string CirculationProcessDefinitionId = "obj_974e9ff1b2fc477d8a542a879c33d239";

        /// <summary>
        /// 传阅流程业务对象表名称
        /// </summary>
        public const string CirculationBusinessObjectTableName = "BO_EU_OPPO_COMMEMT_READ";

        /// <summary>
        /// 传阅流程业务对象“Pc端链接”字段名称
        /// </summary>
        public const string CirculationBusinessObjectPcLinkFieldName = "PCLINK";

        /// <summary>
        /// 传阅流程业务对象表“移动端链接”字段名称
        /// </summary>
        public const string CirculationBusinessObjectMobileLinkFieldName = "MOBILELINK";
    }
}
