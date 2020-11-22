using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Responses
{
    /// <summary>
    /// ActionSoft任务留言Info
    /// </summary>
    public class ActionSoftTaskCommentInfo
    {
        /// <summary>
        /// 留言Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 流程实例Id
        /// </summary>
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 任务实例Id
        /// </summary>
        [JsonProperty("taskInstId")]
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 环节名称
        /// </summary>
        public string ActivityName { get; set; }

        /// <summary>
        /// 审批动作名称
        /// </summary>
        public string ActionName { get; set; }


        /// <summary>
        /// 留言创建时间
        /// </summary>
        [JsonProperty("createDate")]
        [JsonConverter(typeof(DateTimeMillisecondConverter))]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 留言人工号
        /// </summary>
        [JsonProperty("createUser")]
        public string CreatorUserCode { get; set; }

        /// <summary>
        ///  留言人部门名称
        /// </summary>
        [JsonProperty("departmentName")]
        public string CreatorDepartmentName { get; set; }


        /// <summary>
        ///  留言人职位名称
        /// </summary>
        [JsonProperty("positionName")]
        public string CreatorPositionName { get; set; }

        /// <summary>
        ///  留言信息
        /// </summary>
        [JsonProperty("msg")]
        public string Comment { get; set; }
    }
}
