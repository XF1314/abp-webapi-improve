using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks
{
    /// <summary>
    /// ActionSoft任务WebApi服务接口
    /// </summary>
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(BpmSettingNames.ActiontSoftWebApiHost)]
    public interface IActionSoftTaskWebApiService : IHttpApi
    {
        /// <summary>
        /// 创建Eai任务
        /// </summary>
        /// <param name="actionSoftEaiTaskCreateRequest"><see cref="ActionSoftEaiTaskCreateRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<ActionSoftEaiTaskInfo>> CreateEaiTask([FormContent] ActionSoftEaiTaskCreateRequest actionSoftEaiTaskCreateRequest);

        /// <summary>
        /// 删除Eai任务
        /// </summary>
        /// <param name="actionSoftEaiTaskDeleteRequest"><see cref="ActionSoftEaiTaskDeleteRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<bool>> DeleteEaiTask([FormContent] ActionSoftEaiTaskDeleteRequest actionSoftEaiTaskDeleteRequest);

        /// <summary>
        /// 根据业务标识删除Eai任务
        /// </summary>
        /// <param name="actionSoftEaiTaskDeleteByBizId"><see cref="ActionSoftEaiTaskDeleteByBizIdRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<bool>> DeleteEaiTaskByBizId([FormContent] ActionSoftEaiTaskDeleteByBizIdRequest actionSoftEaiTaskDeleteByBizId);

        /// <summary>
        /// 完成Eai任务
        /// </summary>
        /// <param name="actionSoftEaiTaskCompleteRequest"><see cref="ActionSoftEaiTaskCompleteRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse> CompleteEaiTask([FormContent] ActionSoftEaiTaskCompleteRequest actionSoftEaiTaskCompleteRequest);

        /// <summary>
        /// 根据业务标识完成Eai任务
        /// </summary>
        /// <param name="actionSoftEaiTaskCompleteByBizIdRequest"></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse> CompleteEaiTaskByBizId([FormContent] ActionSoftEaiTaskCompleteByBizIdRequest actionSoftEaiTaskCompleteByBizIdRequest);

        /// <summary>
        /// 根据Eai任务业务Id获取Eai任务
        /// </summary>
        /// <param name="actionSoftEaiTaskGetByBizIdRequest"><see cref="ActionSoftEaiTaskGetByBizIdRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<ActionSoftEaiTaskInfo>> GetEaiTaskByBizId([FormContent] ActionSoftEaiTaskGetByBizIdRequest actionSoftEaiTaskGetByBizIdRequest);

        /// <summary>
        /// 提交任务记录
        /// </summary>
        /// <param name="actionSoftTaskRecordCommitRequest"><see cref="ActionSoftTaskRecordCommitRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<bool>> CommitTaskApprovalRecord([FormContent] ActionSoftTaskRecordCommitRequest actionSoftTaskRecordCommitRequest);

        /// <summary>
        /// 检查任务是否结束
        /// </summary>
        /// <param name="actionSoftTaskCloseCheckRequest"><see cref="ActionSoftTaskCloseCheckRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<bool>> TaskCloseCheck([FormContent] ActionSoftTaskCloseCheckRequest actionSoftTaskCloseCheckRequest);

        /// <summary>
        /// 模拟任务执行，以获取当前任务之后可能推进到的人工节点或服务节点，不产生任何实例数据，不触发非路由类的业务事件
        /// 用于查询引擎将要做什么，模拟推演后继路径。开发者可根据模拟执行来做出更灵活的处理，例如根据即将到达的节点指定办理人；
        /// 执行跳转API来改变引擎的执行路线等。当需要种程序干涉引擎执行路线时，请在调用completeTask方法时，将isBranch设置为false
        /// 当模拟的路径评估可到达一个流程对象（如UserTask节点、ServiceTask节点、中间事件等）后，不再继续评估其后继路线
        /// </summary>
        /// <param name="actionSoftTaskSimulationRequest"><see cref="ActionSoftTaskSimulateRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<List<ActionSoftTaskSimulationInfo>>> SimulateTask([FormContent] ActionSoftTaskSimulateRequest actionSoftTaskSimulationRequest);

        /// <summary>
        /// 回退任务
        /// </summary>
        /// <param name="actionSoftTaskRollbackRequest"><see cref="ActionSoftTaskRollbackRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<ActionSoftTaskInfo>> RollbackTask([FormContent] ActionSoftTaskRollbackRequest actionSoftTaskRollbackRequest);

        /// <summary>
        /// 完成任务
        /// </summary>
        /// <param name="actionSoftTaskCompleteRequest"><see cref="ActionSoftTaskCompleteRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<ActionSoftTaskExecutionResultInfo>> CompleteTask([FormContent] ActionSoftTaskCompleteRequest actionSoftTaskCompleteRequest);

        /// <summary>
        /// 获取任务数量
        /// </summary>
        /// <param name="actionSoftTaskCountGetRequest"><see cref="ActionSoftTaskCountGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<long>> GetTaskCount([FormContent] ActionSoftTaskCountGetRequest actionSoftTaskCountGetRequest);

        /// <summary>
        /// 查询任务
        /// </summary>
        /// <param name="actionSoftTaskQueryRequest"><see cref="ActionSoftTaskQueryRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<List<ActionSoftTaskInfo>>> QueryTask([FormContent] ActionSoftTaskQueryRequest actionSoftTaskQueryRequest);

        /// <summary>
        /// 分页查询任务
        /// </summary>
        /// <param name="actionSoftTaskPageQueryRequest"><see cref="ActionSoftTaskPageQueryRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<List<ActionSoftTaskInfo>>> PageQueryTask([FormContent] ActionSoftTaskPageQueryRequest actionSoftTaskPageQueryRequest);

        /// <summary>
        /// 获取任务
        /// </summary>
        /// <param name="actionSoftTaskGetRequest"><see cref="ActionSoftTaskGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<ActionSoftTaskInfo>> GetTask([FormContent] ActionSoftTaskGetRequest actionSoftTaskGetRequest);

        /// <summary>
        /// 获取历史任务数量
        /// </summary>
        /// <param name="actionSoftHistoryTaskCountGetRequest"><see cref="ActionSoftHistoryTaskCountGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<long>> GetHistoryTaskCount([FormContent] ActionSoftHistoryTaskCountGetRequest actionSoftHistoryTaskCountGetRequest);

        /// <summary>
        /// 查询历史任务
        /// </summary>
        /// <param name="actionSoftHistoryTaskQueryRequest"><see cref="ActionSoftHistoryTaskQueryRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<List<ActionSoftTaskInfo>>> QueryHistoryTask([FormContent] ActionSoftHistoryTaskQueryRequest actionSoftHistoryTaskQueryRequest);

        /// <summary>
        /// 分页查询历史任务
        /// </summary>
        /// <param name="actionSoftHistoryTaskPageQueryRequest"><see cref="ActionSoftHistoryTaskPageQueryRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<List<ActionSoftTaskInfo>>> PageQueryHistoryTask([FormContent] ActionSoftHistoryTaskPageQueryRequest actionSoftHistoryTaskPageQueryRequest);

        /// <summary>
        /// 获取历史任务
        /// </summary>
        /// <param name="actionSoftHistoryTaskGetRequest"><see cref="ActionSoftHistoryTaskGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<ActionSoftTaskInfo>> GetHistoryTask([FormContent] ActionSoftHistoryTaskGetRequest actionSoftHistoryTaskGetRequest);

        /// <summary>
        /// 创建传阅任务
        /// </summary>
        /// <param name="actionSoftCirculationTaskCreateRequest"><see cref="ActionSoftCirculationTaskCreateRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<List<ActionSoftTaskInfo>>> CreateCirculationTask([FormContent] ActionSoftCirculationTaskCreateRequest actionSoftCirculationTaskCreateRequest);

        /// <summary>
        /// 获得指定节点路由方案配置的参与者s
        /// </summary>
        /// <param name="actionSoftTaskParticipantsGetRequest"><see cref="ActionSoftTaskParticipantsGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<string>> GetTaskParticipants([FormContent] ActionSoftTaskParticipantsGetRequest actionSoftTaskParticipantsGetRequest);

    }
}
