using Com.OPPO.Mo.Bpm.ActionSoft.Tasks;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft任务
    /// </summary>
    [Area("actionsoft")]
    [Route("openapi/actionsoft")]
    public class ActionSoftTaskController : AbpController
    {
        private readonly IActionSoftTaskAppService _actionSoftTaskAppService;

        /// <summary>
        /// <see cref="ActionSoftTaskController"/>
        /// </summary>
        public ActionSoftTaskController(IActionSoftTaskAppService actionSoftTaskAppService)
        {
            _actionSoftTaskAppService = actionSoftTaskAppService;
        }

        /// <summary>
        /// 创建Eai任务
        /// </summary>
        /// <param name="eaiTaskCreateInput"><see cref="ActionSoftEaiTaskCreateInput"/></param>
        /// <returns></returns>
        [HttpPost("eai-task/create")]
        public async Task<Result<string>> CreateEaiTask([FromBody] ActionSoftEaiTaskCreateInput eaiTaskCreateInput)
        {
            return await _actionSoftTaskAppService.CreateEaiTask(eaiTaskCreateInput);
        }

        /// <summary>
        /// 删除Eai任务
        /// </summary>
        /// <param name="eaiTaskInstanceId">Eai任务实例Id</param>
        /// <returns></returns>
        [HttpPost("eai-task/delete")]
        public async Task<Result<bool>> DeleteEaiTask([FromForm] string eaiTaskInstanceId)
        {
            return await _actionSoftTaskAppService.DeleteEaiTask(eaiTaskInstanceId);
        }

        /// <summary>
        /// 根据业务Id删除Eai任务
        /// </summary>
        /// <param name="appName">应用名称</param>
        /// <param name="eaiTaskBizId">Eai任务业务Id</param>
        /// <returns></returns>
        [HttpPost("eai-task/delete-by-biz-id")]
        public async Task<Result<bool>> DeleteEaiTaskByBizId(string appName, string eaiTaskBizId)
        {
            return await _actionSoftTaskAppService.DeleteEaiTaskByBizId(appName, eaiTaskBizId);
        }

        /// <summary>
        /// 完成Eai任务
        /// </summary>
        /// <param name="eaiTaskInstanceId">Eai任务实例Id</param>
        /// <returns></returns>
        [HttpPost("eai-task/complete")]
        public async Task<Result> CompleteEaiTask(string eaiTaskInstanceId)
        {
            return await _actionSoftTaskAppService.CompleteEaiTask(eaiTaskInstanceId);
        }

        /// <summary>
        /// 根据业务Id完成Eai任务
        /// </summary>
        /// <param name="appName">应用名称</param>
        /// <param name="eaiTaskBizId">Eai任务业务Id</param>
        /// <returns></returns>
        [HttpPost("eai-task/complete-by-biz-id")]
        public async Task<Result> CompleteEaiTaskByBizId(string appName, string eaiTaskBizId)
        {
            return await _actionSoftTaskAppService.CompleteEaiTaskByBizId(appName, eaiTaskBizId);
        }

        /// <summary>
        /// 根据业务Id获取Eai任务信息
        /// </summary>
        /// <param name="appName">应用名称</param>
        /// <param name="EaiTaskBizId">Eai任务业务Id</param>
        /// <returns></returns>
        [HttpGet("eai-task/get-by-biz-id")]
        public async Task<Result<ActionSoftEaiTaskDto>> GetEaiTaskByBizId(string appName, string EaiTaskBizId)
        {
            return await _actionSoftTaskAppService.GetEaiTaskByBizId(appName, EaiTaskBizId);
        }

        /// <summary>
        /// 创建传阅任务
        /// </summary>
        /// <param name="actionSoftCirculationTaskCreateInput"><see cref="ActionSoftCirculationTaskCreateInput"/></param>
        /// <returns></returns>
        [HttpPost("circulation-task/create")]
        public async Task<Result<List<ActionSoftTaskDto>>> CreateCirculationTask([FromBody] ActionSoftCirculationTaskCreateInput actionSoftCirculationTaskCreateInput)
        {
            return await _actionSoftTaskAppService.CreateCirculationTask(actionSoftCirculationTaskCreateInput);
        }

        /// <summary>
        /// 提交任务记录
        /// </summary>
        /// <param name="taskRecordCommitInput"><see cref="ActionSoftTaskRecordCommitInput"/></param>
        /// <returns></returns>
        [HttpPost("task/record/commit")]
        public async Task<Result<bool>> CommitTaskApprovalRecord([FromBody] ActionSoftTaskRecordCommitInput taskRecordCommitInput)
        {
            return await _actionSoftTaskAppService.CommitTaskRecord(taskRecordCommitInput);
        }

        /// <summary>
        /// 检查任务是否结束
        /// </summary>
        /// <param name="taskInstanceId">任务实例Id</param>
        /// <returns></returns>
        [HttpPost("task/end-check")]
        public async Task<Result<bool>> TaskCloseCheck(string taskInstanceId)
        {
            return await _actionSoftTaskAppService.TaskCloseCheck(taskInstanceId);
        }

        /// <summary>
        /// 完成任务
        /// </summary>
        /// <param name="taskCompleteInput"><see cref="ActionSoftTaskCompleteInput"/></param>
        /// <returns></returns>
        [HttpPost("task/complete")]
        public async Task<Result<ActionSoftTaskExecuteResultDto>> CompleteTask([FromBody] ActionSoftTaskCompleteInput taskCompleteInput)
        {
            return await _actionSoftTaskAppService.CompleteTask(taskCompleteInput);
        }

        /// <summary>
        /// 模拟任务执行，以获取当前任务之后可能推进到的人工节点或服务节点，不产生任何实例数据，不触发非路由类的业务事件
        /// 用于查询引擎将要做什么，模拟推演后继路径。开发者可根据模拟执行来做出更灵活的处理，例如根据即将到达的节点指定办理人；
        /// 执行跳转API来改变引擎的执行路线等。当需要种程序干涉引擎执行路线时，请在调用completeTask方法时，将isBranch设置为false
        /// 当模拟的路径评估可到达一个流程对象（如UserTask节点、ServiceTask节点、中间事件等）后，不再继续评估其后继路线
        /// </summary>
        /// <param name="taskSimulateInput"><see cref="ActionSoftTaskSimulateInput"/></param>
        /// <returns></returns>
        [HttpPost("task/simulate")]
        public async Task<Result<List<ActionSoftTaskSimulationInfoDto>>> SimulateTask([FromBody] ActionSoftTaskSimulateInput taskSimulateInput)
        {
            return await _actionSoftTaskAppService.SimulateTask(taskSimulateInput);
        }

        /// <summary>
        /// 完成任务并添加记录
        /// </summary>
        /// <param name="taskCompleteWithRecordInput"><see cref="ActionSoftTaskCompleteWithRecordInput"/></param>
        /// <returns></returns>
        [HttpPost("task/complete-with-record")]
        public async Task<Result<ActionSoftTaskExecuteResultDto>> CompleteTaskWithRecord([FromBody] ActionSoftTaskCompleteWithRecordInput taskCompleteWithRecordInput)
        {
            return await _actionSoftTaskAppService.CompleteTaskWithRecord(taskCompleteWithRecordInput);
        }

        /// <summary>
        /// 获取任务数量（无权限控制）
        /// </summary>
        /// <param name="taskCountGetInput"><see cref="ActionSoftTaskCountGetInput"/></param>
        /// <returns></returns>
        [HttpPost("task/count")]
        public async Task<Result<long>> GetTaskCount([FromBody] ActionSoftTaskCountGetInput taskCountGetInput)
        {
            return await _actionSoftTaskAppService.GetTaskCount(taskCountGetInput);
        }

        /// <summary>
        /// 查询任务（无权限控制）
        /// </summary>
        /// <param name="taskQueryInput"><see cref="ActionSoftTaskQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("task/query")]
        public async Task<Result<List<ActionSoftSimplifiedTaskDto>>> QueryTask([FromBody] ActionSoftTaskQueryInput taskQueryInput)
        {
            return await _actionSoftTaskAppService.QueryTask(taskQueryInput);
        }

        /// <summary>
        /// 分页查询任务（无权限控制）
        /// </summary>
        /// <param name="taskPageQueryInput"><see cref="ActionSoftTaskPageQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("task/page-query")]
        public async Task<Result<List<ActionSoftSimplifiedTaskDto>>> PageQueryTask([FromBody] ActionSoftTaskPageQueryInput taskPageQueryInput)
        {
            return await _actionSoftTaskAppService.PageQueryTask(taskPageQueryInput);
        }

        /// <summary>
        /// 获取任务
        /// </summary>
        /// <param name="taskInstanceId">任务实例Id</param>
        /// <returns></returns>
        [HttpGet("task/get-by-id")]
        public async Task<Result<ActionSoftTaskDto>> GetTask(string taskInstanceId)
        {
            return await _actionSoftTaskAppService.GetTask(taskInstanceId);
        }

        /// <summary>
        /// 获取历史任务数量
        /// </summary>
        /// <param name="historyTaskCountGetInput"><see cref="ActionSoftHistoryTaskCountGetInput"/></param>
        /// <returns></returns>
        [HttpPost("history-task/count")]
        public async Task<Result<long>> GetHistoryTaskCount([FromBody] ActionSoftHistoryTaskCountGetInput historyTaskCountGetInput)
        {
            return await _actionSoftTaskAppService.GetHistoryTaskCount(historyTaskCountGetInput);
        }

        /// <summary>
        /// 查询历史任务
        /// </summary>
        /// <param name="historyTaskQueryInput"><see cref="ActionSoftHistoryTaskQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("history-task/query")]
        public async Task<Result<List<ActionSoftSimplifiedTaskDto>>> QueryHistoryTask([FromBody] ActionSoftHistoryTaskQueryInput historyTaskQueryInput)
        {
            return await _actionSoftTaskAppService.QueryHistoryTask(historyTaskQueryInput);
        }

        /// <summary>
        /// 分页查询历史任务
        /// </summary>
        /// <param name="historyTaskPageQueryInput"><see cref="ActionSoftHistoryTaskPageQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("history-task/page-query")]
        public async Task<Result<List<ActionSoftSimplifiedTaskDto>>> PageQueryHistoryTask([FromBody] ActionSoftHistoryTaskPageQueryInput historyTaskPageQueryInput)
        {
            return await _actionSoftTaskAppService.PageQueryHistoryTask(historyTaskPageQueryInput);
        }

        /// <summary>
        /// 获取历史任务
        /// </summary>
        /// <param name="taskInstanceId">任务实例Id</param>
        /// <returns></returns>
        [HttpGet("history-task/get-by-id")]
        public async Task<Result<ActionSoftTaskDto>> GetHistoryTask(string taskInstanceId)
        {
            return await _actionSoftTaskAppService.GetHistoryTask(taskInstanceId);
        }

        /// <summary>
        /// 获得指定节点路由方案配置的参与者s
        /// </summary>
        /// <param name="taskParticipantsGetInput"><see cref="ActionSoftTaskParticipantsGetInput"/></param>
        /// <returns></returns>
        [HttpGet("participant/get")]
        public async Task<Result<string>> GetTaskParticipants([FromQuery] ActionSoftTaskParticipantsGetInput taskParticipantsGetInput)
        {
            return await _actionSoftTaskAppService.GetTaskParticipants(taskParticipantsGetInput);
        }
    }
}
