using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos
{
    /// <summary>
    ///  ActionSoft指定节点任务参与者获取Input
    /// </summary>
    public class ActionSoftTaskParticipantsGetInput
    {
        /// <summary>
        /// 【必填项】合法工号
        /// </summary>
        public string UserCode { get; set; } = MoBpmConsts.ActionSoftAdminUserCode;

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】任务实例Id
        /// </summary>
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 【必填项】下一个人工任务定义（要预测的任务节点）Id
        /// </summary>
        public string NextUserTaskActivityId { get; set; }
    }
}
