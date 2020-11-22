using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos
{
    /// <summary>
    /// ActionSoft任务预测信息Dto
    /// </summary>
    public class ActionSoftTaskPredictInfoDto
    {
        #region 任务
        /// <summary>
        /// 任务实例Id
        /// </summary>
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 任务标题
        /// </summary>
        public string TaskTitle { get; set; }

        /// <summary>
        /// 任务分组Id，同一审批环节的任务归属于同一个分组，注：任务分组Id大小并不能用作审批环节的排序依据
        /// </summary>
        public int TaskGroupId { get; set; }

        /// <summary>
        /// <see cref="ActionSoftActivityType"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftActivityType ActivityType { get; set; }

        /// <summary>
        /// 任务完成时间
        /// </summary>
        public DateTime? TaskCompleteTime { get; set; }

        /// <summary>
        /// 任务完成描述
        /// </summary>
        public string TaskCompleteDescription { get; set; }

        /// <summary>
        /// 是否并行任务
        /// </summary>
        public bool IsParallelTask { get; set; }

        /// <summary>
        /// 是否顺序任务
        /// </summary>
        public bool IsSequentialTask { get; set; }

        /// <summary>
        /// 任务定义Id
        /// </summary>
        public string TaskDefinitionId { get; set; }

        /// <summary>
        /// 父级任务定义Id
        /// </summary>
        public string ParentTaskDefinitionId { get; set; }

        #endregion

        #region 流程
        /// <summary>
        /// 流程实例Id
        /// </summary>
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 流程定义Id
        /// </summary>
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 流程定义版本Id
        /// </summary>
        public string ProcessDefinitionVersionId { get; set; }

        /// <summary>
        /// 流程定义类型
        /// </summary>
        public string ProcessDefinitionType { get; set; }
        #endregion

        #region 用户
        /// <summary>
        /// 创建人工号
        /// </summary>
        public string CreateUserCode { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string CreateUserName { get; set; }


        /// <summary>
        /// 认领人工号
        /// </summary>
        public string ClaimUserCode { get; set; }

        /// <summary>
        /// 认领人姓名
        /// </summary>
        public string ClaimUserName { get; set; }
        #endregion
    }
}
