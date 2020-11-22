using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks
{
    /// <summary>
    /// ActionSoft任务相关命令
    /// </summary>
    public class ActionSoftTaskCommands
    {
        /// <summary>
        /// 创建一个Eai任务(此类任务不由本地工作流引擎驱动）
        /// </summary>
        public const string EaiTaskCreate = "oppo.task.eaiTasks.create";// "task.eaiTasks.create";

        /// <summary>
        /// 删除一个Eai任务(仅支持活动任务删除)
        /// </summary>
        public const string EaiTaskDelete = "oppo.task.delete";

        /// <summary>
        /// 通过业务标识删除一个Eai任务(仅支持活动任务删除)
        /// </summary>
        public const string EaiTaskDeleteByBizId = "oppo.task.delete.eai";//"task.delete.eai";

        /// <summary>
        /// 完成一个Eai任务
        /// </summary>
        public const string EaiTaskComplete = "oppo.task.eai.complete";//"task.eai.complete";

        /// <summary>
        /// 通过业务标识完成一个Eai任务
        /// </summary>
        public const string EaiTaskCompleteByBizId = "oppo.task.eai.complete.outer";//"task.eai.complete.outer";

        /// <summary>
        /// 根据业务标识获取单个Eai任务
        /// </summary>
        public const string EaiTaskGetByBizId = "task.eai.get";

        /// <summary>
        /// 判断任务是否已结束
        /// </summary>
        public const string TaskCloseCheck = "task.close.check";

        /// <summary>
        /// 提交任务记录
        /// </summary>
        public const string TaskRecordCommit = "task.comment.commit";

        /// <summary>
        /// 完成一个任务
        /// </summary>
        public const string TaskComplete = "task.complete";

        /// <summary>
        /// 回退任务到目标节点（必须是历史处理过的节点）
        /// </summary>
        public const string TaskRollback = "task.rollback";

        /// <summary>
        /// 查询任务
        /// </summary>
        public const string TaskQuery = "task.query";

        /// <summary>
        /// 分页查询任务
        /// </summary>
        public const string TaskPageQuery = "task.query.page";

        /// <summary>
        /// 获取任务数量
        /// </summary>
        public const string TaskCountGet = "task.count";

        /// <summary>
        /// 获取单个任务
        /// </summary>
        public const string TaskGet = "task.get";

        /// <summary>
        /// 查询历史任务
        /// </summary>
        public const string HistoryTaskQuery = "task.history.query";

        /// <summary>
        /// 分页查询历史任务
        /// </summary>
        public const string HistoryTaskPageQuery = "task.history.query.page";

        /// <summary>
        /// 获取历史任务数量
        /// </summary>
        public const string HistoryTaskCountGet = "task.history.count";

        /// <summary>
        /// 获取单个历史任务
        /// </summary>
        public const string HistoryTaskGet = "task.history.get";

        /// <summary>
        /// 模拟获取当前任务之后可能推进到的人工节点或服务节点，不产生任何实例数据，不触发非路由类的业务事件
        /// 用于查询引擎将要做什么，模拟推演后继路径。开发者可根据模拟执行来做出更灵活的处理，例如根据即将到达的节点指定办理人； 
        /// 执行跳转API来改变引擎的执行路线等。当需要种程序干涉引擎执行路线时，请在调用completeTask方法时，将isBranch设置为false
        /// 当模拟的路径评估可到达一个流程对象（如UserTask节点、ServiceTask节点、中间事件等）后，不再继续评估其后继路线
        /// </summary>
        public const string TaskSimulate = "task.simulation";

        /// <summary>
        /// 获得指定节点路由方案配置的参与者
        /// 该方法调用路由方案接口的getHumanPerformer（执行人）+getPotentialOwner（候选人 ），然后去重
        /// </summary>
        public const string TaskParticipantsGet = "task.participants.get";

        /// <summary>
        /// 创建传阅任务
        /// </summary>
        public const string CirculationTaskCreate = "task.userCCTask.create";

    }
}
