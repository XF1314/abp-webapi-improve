using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks
{
    /// <summary>
    /// ActionSoft任务应用服务接口
    /// </summary>
    public interface IActionSoftTaskAppService : IApplicationService
    {
        /// <summary>
        /// 创建Eai任务
        /// </summary>
        /// <param name="actionSoftEaiTaskCreateInput"><see cref="ActionSoftEaiTaskCreateInput"/></param>
        /// <returns></returns>
        Task<Result<string>> CreateEaiTask(ActionSoftEaiTaskCreateInput actionSoftEaiTaskCreateInput);

        /// <summary>
        /// 删除Eai任务
        /// </summary>
        /// <param name="eaiTaskInstanceId">Eai任务实例Id</param>
        /// <returns></returns>
        Task<Result<bool>> DeleteEaiTask(string eaiTaskInstanceId);

        /// <summary>
        /// 根据业务Id删除Eai任务
        /// </summary>
        /// <param name="appName">应用名称</param>
        /// <param name="eaiTaskBizId">Eai任务业务Id</param>
        /// <returns></returns>
        Task<Result<bool>> DeleteEaiTaskByBizId(string appName, string eaiTaskBizId);

        /// <summary>
        /// 完成Eai任务
        /// </summary>
        /// <param name="eaiTaskInstanceId">Eai任务实例Id</param>
        /// <returns></returns>
        Task<Result> CompleteEaiTask(string eaiTaskInstanceId);

        /// <summary>
        /// 根据业务Id完成Eai任务
        /// </summary>
        /// <param name="appName">应用名称</param>
        /// <param name="eaiTaskBizId">Eai任务业务Id</param>
        /// <returns></returns>
        Task<Result> CompleteEaiTaskByBizId(string appName, string eaiTaskBizId);

        /// <summary>
        /// 根据业务Id获取Eai任务
        /// </summary>
        /// <param name="appName">应用名称</param>
        /// <param name="eaiTaskBizId">Eai任务业务Id</param>
        /// <returns></returns>
        Task<Result<ActionSoftEaiTaskDto>> GetEaiTaskByBizId(string appName, string eaiTaskBizId);

        /// <summary>
        /// 模拟任务执行，以获取当前任务之后可能推进到的人工节点或服务节点，不产生任何实例数据，不触发非路由类的业务事件
        /// 用于查询引擎将要做什么，模拟推演后继路径。开发者可根据模拟执行来做出更灵活的处理，例如根据即将到达的节点指定办理人；
        /// 执行跳转API来改变引擎的执行路线等。当需要种程序干涉引擎执行路线时，请在调用completeTask方法时，将isBranch设置为false
        /// 当模拟的路径评估可到达一个流程对象（如UserTask节点、ServiceTask节点、中间事件等）后，不再继续评估其后继路线
        /// </summary>
        /// <param name="actionSoftTaskSimulateInput"><see cref="ActionSoftTaskSimulateInput"/></param>
        /// <returns></returns>
        Task<Result<List<ActionSoftTaskSimulationInfoDto>>> SimulateTask(ActionSoftTaskSimulateInput actionSoftTaskSimulateInput);

        /// <summary>
        /// 提交任务记录
        /// </summary>
        /// <param name="actionSoftTaskRecordCommitInput"><see cref="ActionSoftTaskRecordCommitInput"/></param>
        /// <returns></returns>
        Task<Result<bool>> CommitTaskRecord(ActionSoftTaskRecordCommitInput actionSoftTaskRecordCommitInput);

        /// <summary>
        /// 检查任务是否结束
        /// </summary>
        /// <param name="taskInstanceId">任务实例Id</param>
        /// <returns></returns>
        Task<Result<bool>> TaskCloseCheck(string taskInstanceId);

        /// <summary>
        /// 完成任务
        /// </summary>
        /// <param name="actionSoftTaskCompleteInput"><see cref="ActionSoftTaskCompleteInput"/></param>
        /// <returns></returns>
        Task<Result<ActionSoftTaskExecuteResultDto>> CompleteTask(ActionSoftTaskCompleteInput actionSoftTaskCompleteInput);

        /// <summary>
        /// 完成任务并添加记录
        /// </summary>
        /// <param name="actionSoftTaskCompleteWithRecordInput"><see cref="ActionSoftTaskCompleteWithRecordInput"/></param>
        /// <returns></returns>
        Task<Result<ActionSoftTaskExecuteResultDto>> CompleteTaskWithRecord(ActionSoftTaskCompleteWithRecordInput actionSoftTaskCompleteWithRecordInput);

        /// <summary>
        /// 获取任务数量
        /// </summary>
        /// <param name="actionSoftTaskCountGetInput"><see cref="ActionSoftTaskCountGetInput"/></param>
        /// <returns></returns>
        Task<Result<long>> GetTaskCount(ActionSoftTaskCountGetInput actionSoftTaskCountGetInput);

        /// <summary>
        /// 【无权限控制】查询任务
        /// </summary>
        /// <param name="actionSoftTaskQueryInput"><see cref="ActionSoftTaskQueryInput"/></param>
        /// <returns></returns>
        Task<Result<List<ActionSoftSimplifiedTaskDto>>> QueryTask(ActionSoftTaskQueryInput actionSoftTaskQueryInput);

        /// <summary>
        /// 【无权限控制】分页查询任务
        /// </summary>
        /// <param name="actionSoftTaskPageQueryInput"><see cref="ActionSoftTaskPageQueryInput"/></param>
        /// <returns></returns>
        Task<Result<List<ActionSoftSimplifiedTaskDto>>> PageQueryTask(ActionSoftTaskPageQueryInput actionSoftTaskPageQueryInput);

        /// <summary>
        /// 获取任务
        /// </summary>
        /// <param name="taskInstanceId">任务实例Id</param>
        /// <returns></returns>
        Task<Result<ActionSoftTaskDto>> GetTask(string taskInstanceId);

        /// <summary>
        /// 获取历史任务数量
        /// </summary>
        /// <param name="actionSoftHistoryTaskCountGetInput"><see cref="ActionSoftHistoryTaskCountGetInput"/></param>
        /// <returns></returns>
        Task<Result<long>> GetHistoryTaskCount(ActionSoftHistoryTaskCountGetInput actionSoftHistoryTaskCountGetInput);

        /// <summary>
        /// 【无权限控制】查询历史任务
        /// </summary>
        /// <param name="actionSoftHistoryTaskQueryInput"><see cref="ActionSoftHistoryTaskQueryInput"/></param>
        /// <returns></returns>
        Task<Result<List<ActionSoftSimplifiedTaskDto>>> QueryHistoryTask(ActionSoftHistoryTaskQueryInput actionSoftHistoryTaskQueryInput);

        /// <summary>
        /// 【无权限控制】分页查询历史任务
        /// </summary>
        /// <param name="actionSoftHistoryTaskPageQueryInput"><see cref="ActionSoftHistoryTaskPageQueryInput"/></param>
        /// <returns></returns>
        Task<Result<List<ActionSoftSimplifiedTaskDto>>> PageQueryHistoryTask(ActionSoftHistoryTaskPageQueryInput actionSoftHistoryTaskPageQueryInput);

        /// <summary>
        /// 获取历史任务
        /// </summary>
        /// <param name="taskInstanceId">任务实例Id</param>
        /// <returns></returns>
        Task<Result<ActionSoftTaskDto>> GetHistoryTask(string taskInstanceId);

        /// <summary>
        /// 创建传阅任务
        /// </summary>
        /// <param name="actionSoftCirculationTaskCreateInput"><see cref="ActionSoftCirculationTaskCreateInput"/></param>
        /// <returns></returns>
        Task<Result<List<ActionSoftTaskDto>>> CreateCirculationTask( ActionSoftCirculationTaskCreateInput actionSoftCirculationTaskCreateInput);

        /// <summary>
        /// 获得指定节点路由方案配置的参与者
        /// </summary>
        /// <param name="actionSoftTaskParticipantsGetInput"><see cref="ActionSoftTaskParticipantsGetInput"/></param>
        /// <returns></returns>
        Task<Result<string>> GetTaskParticipants(ActionSoftTaskParticipantsGetInput actionSoftTaskParticipantsGetInput);
    }
}
