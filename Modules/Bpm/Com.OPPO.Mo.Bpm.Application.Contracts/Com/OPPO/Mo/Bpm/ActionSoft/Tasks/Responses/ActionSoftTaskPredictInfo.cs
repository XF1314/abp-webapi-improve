using Com.OPPO.Mo.Bpm.ActionSoft.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Responses
{
    /// <summary>
    /// ActionSoft任务预测信息
    /// </summary>
    public class ActionSoftTaskPredictInfo
    {
        #region 任务
        /// <summary>
        /// 任务实例Id
        /// </summary>
        [JsonProperty("taskInstId")]
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 任务标题
        /// </summary>
        [JsonProperty("title")]
        public string TaskTitle { get; set; }

        /// <summary>
        /// 任务分组Id，同一审批环节的任务归属于同一个分组，注：任务分组Id大小并不能用作审批环节的排序依据
        /// </summary>
        [JsonProperty("no")]
        public int TaskGroupId { get; set; }

        /// <summary>
        /// <see cref="ActionSoftActivityType"/>
        /// </summary>
        [JsonProperty("activityType")]
        public ActionSoftActivityType ActivityType { get; set; }

        /// <summary>
        /// 任务完成时间
        /// </summary>
        [JsonProperty("endTime")]
        public DateTime? TaskCompleteTime { get; set; }

        /// <summary>
        /// 任务完成说明
        /// </summary>
        [JsonProperty("avgTime")]
        public string TaskCompleteDescription { get; set; }

        /// <summary>
        /// 是否并行任务
        /// </summary>
        [JsonProperty("parallel")]
        public bool IsParallelTask { get; set; }

        /// <summary>
        /// 是否顺序任务
        /// </summary>
        [JsonProperty("sequential")]
        public bool IsSequentialTask { get; set; }

        ///// <summary>
        ///// 审批完成的最后一个任务实例Id
        ///// </summary>
        //[JsonProperty("finishedUID")]
        //public string FinishTaskInstanceId { get; set; }

        /// <summary>
        /// 任务定义Id
        /// </summary>
        [JsonProperty("activityDefId")]
        public string TaskDefinitionId { get; set; }

        /// <summary>
        /// 父级任务定义Id
        /// </summary>
        [JsonProperty("parentActivityDefId")]
        public string ParentTaskDefinitionId { get; set; }

        #endregion

        #region 流程
        /// <summary>
        /// 流程实例Id
        /// </summary>
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 流程定义Id
        /// </summary>
        [JsonProperty("processDefId")]
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 流程定义版本Id
        /// </summary>
        [JsonProperty("processDefVerId")]
        public string ProcessDefinitionVersionId { get; set; }

        /// <summary>
        /// 流程定义类型
        /// </summary>
        [JsonProperty("processNodeType")]
        public string ProcessDefinitionType { get; set; }
        #endregion

        #region 用户
        /// <summary>
        /// 创建人工号
        /// </summary>
        [JsonProperty("userid")]
        public string CreateUserCode { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        [JsonProperty("createUser")]
        public string CreateUserName { get; set; }


        /// <summary>
        /// 认领人工号
        /// </summary>
        [JsonProperty("userid2")]
        public string ClaimUserCode { get; set; }

        /// <summary>
        /// 认领人姓名
        /// </summary>
        [JsonProperty("executor")]
        public string ClaimUserName { get; set; }
        #endregion
    }
}
