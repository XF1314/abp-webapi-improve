using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Metadatas
{
    /// <summary>
    /// ActionSoft元数据相关命令
    /// </summary>
    public class ActionSoftMetadataCommands
    {
        /// <summary>
        /// 人工任务定义获取
        /// </summary>
        public const string UserTaskDefinitionGet = "repository.usertask.get";

        /// <summary>
        /// 流程定义获取
        /// </summary>
        public const string ProcessDefinitionGet = "repository.process.get";

        /// <summary>
        /// 流程文档获取
        /// </summary>
        public const string ProcessDocumentGet = "repository.process.document.get";

        /// <summary>
        /// 流程主版本（正在运行的版本）Id获取
        /// </summary>
        public const string ProcessMainVersionIdGet = "repository.processVerId.get";

        /// <summary>
        /// 流程定义（唯一标识一支流程）Id获取
        /// </summary>
        public const string ProcessDefinitionIdGet = "repository.processDefId.get";

        /// <summary>
        /// 流程根踪Url获取
        /// </summary>
        public const string ProcessTrackingUrlGet = "repository.trackurl.get ";
    }
}
