using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// ActionSoft流程相关命令
    /// </summary>
    public class ActionSoftProcessCommands
    {
        /// <summary>
        /// 创建长流程，指流程由人工任务或人工任务与系统任务混合的流程，这类流程一定有人的干预，不会执行即结束
        /// </summary>
        public const string ProcessCreate = "oppo.process.create";//"process.create";

        /// <summary>
        /// 创建短流程（也简称“集成流”、“逻辑流”）实例并启动，与ESB的服务编排相似。
        /// 在AWS BPM PaaS中指全部是由各种系统任务组合的流程，没有人工的干预，可能无需等待瞬间执行完毕
        /// </summary>
        public const string ShortProcessCreate = "process.short.create";

        /// <summary>
        /// 创建仅存储流程，用于DW添加，无需人的干预
        /// </summary>
        public const string BoProcessCreate = "process.bo.create";

        /// <summary>
        /// 创建子流程，子流程与父流程拥有等同的行为，可以从子流程上下文中获得父流程信息
        /// </summary>
        public const string SubProcessCreate = "process.sub.create";

        /// <summary>
        /// 根据流程实例Id启动流程
        /// </summary>
        public const string ProcessStart = "process.start";

        /// <summary>
        /// 根据流程实例Id取消流程
        /// </summary>
        public const string ProcessCancel = "process.cancel";

        /// <summary>
        /// 根据流程实例Id作废/终止流程
        /// </summary>
        public const string ProcessTerminate = "process.terminate";

        /// <summary>
        /// 根据流程实例id重置流程到第一个节点，将任务创建给流程启动者，
        /// 等同于由启动者撤销重办业务（适用于开始事件后是UserTask的人工流程）。
        /// 撤销操作将删除令牌、 所有待办已办任务等流程数据， 如果给定了reStartReason值 ，
        /// 将撤销原因初始化成审批记录。如果该流程启动了子流程一并将子流程删除
        /// </summary>
        public const string ProcessRestart = "process.restart";

        /// <summary>
        /// 根据流程实例Id检查流程是否允许撤销重办
        /// </summary>
        public const string ProcessRestartCheck = "process.restart.check";

        /// <summary>
        /// 根据流程实例Id重新激活已结束的流程
        /// </summary>
        public const string ProcessReactive = "process.reactivate";

        /// <summary>
        /// 根据流程实例Id删除流程
        /// </summary>
        public const string ProcessDelete = "process.delete";

        /// <summary>
        /// 根据流程实例Id判断流程是否已结束
        /// </summary>
        public const string ProcessEndCheck = "process.end.check";

        /// <summary>
        /// 根据流程实例Id获取特定流程变量
        /// </summary>
        public const string SpecifiedProcessVarGet = "process.var.get";

        /// <summary>
        /// 根据流程实例Id获取所有流程变量s
        /// </summary>
        public const string ProcessVarsGet = "process.vars.get";

        /// <summary>
        /// 根据流程实例Id设置特定流程变量
        /// </summary>
        public const string SpecifiedProcessVarSet = "process.var.set";

        /// <summary>
        /// 根据流程实例Id批量设置流程变量s
        /// </summary>
        public const string ProcessVarBatchSet = "process.vars.set";

        /// <summary>
        /// 根据流程实例Id发送催办邮件给当前办理者
        /// </summary>
        public const string ProcessRemindMailSend = "process.remindMail";

        /// <summary>
        /// 根据流程实例Id获取流程
        /// </summary>
        public const string ProcessGet = "process.inst.get";

        /// <summary>
        /// 获取流程数量
        /// </summary>
        public const string ProcessCountGet = "process.count";

        /// <summary>
        /// 查询流程
        /// </summary>
        public const string ProcessQuery = "process.query";

        /// <summary>
        /// 分页查询流程
        /// </summary>
        public const string ProcessPageQuery = "process.query.page";


        /// <summary>
        /// 审批留言记录获取
        /// </summary>
        public const string ProcessCommentsGet = "process.comments.get";

    }
}
