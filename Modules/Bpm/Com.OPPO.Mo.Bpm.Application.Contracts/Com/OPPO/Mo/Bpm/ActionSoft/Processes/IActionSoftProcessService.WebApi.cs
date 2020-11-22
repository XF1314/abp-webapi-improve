using Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes.Responses;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes
{
    /// <summary>
    /// ActionSoft流程WebApi服务接口
    /// </summary>
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(BpmSettingNames.ActiontSoftWebApiHost)]
    public interface IActionSoftProcessWebApiService : IHttpApi
    {
        /// <summary>
        /// 创建ActionSoft流程
        /// </summary>
        /// <param name="actionSoftProcessCreateRequest"><see cref="ActionSoftProcessCreateRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<ActionSoftProcessInfo>> CreateProcess([FormContent] ActionSoftProcessCreateRequest actionSoftProcessCreateRequest);

        /// <summary>
        /// 启动ActionSoft流程
        /// </summary>
        /// <param name="actionSoftProcessStartRequest"><see cref="ActionSoftProcessStartRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse> StartProcess([FormContent] ActionSoftProcessStartRequest actionSoftProcessStartRequest);

        /// <summary>
        /// 检查ActionSoft流程是否可撤回性
        /// </summary>
        /// <param name="processRevocabilityCheckRequest"><see cref="ActionSoftProcessRevocabilityCheckRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<bool>> CheckProcessRevocability([FormContent] ActionSoftProcessRevocabilityCheckRequest processRevocabilityCheckRequest);

        /// <summary>
        /// 撤回ActionSoft流程
        /// </summary>
        /// <param name="actionSoftProcessRevokeRequest"><see cref="ActionSoftProcessRevokeRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<ActionSoftTaskInfo>> RevokeProcess([FormContent] ActionSoftProcessRevokeRequest actionSoftProcessRevokeRequest);

        /// <summary>
        /// 取消ActionSoft流程
        /// </summary>
        /// <param name="actionSoftProcessCancelRequest"><see cref="ActionSoftProcessCancelRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse> CancelProcess([FormContent] ActionSoftProcessCancelRequest actionSoftProcessCancelRequest);

        /// <summary>
        /// 终止/作废ActionSoft流程
        /// </summary>
        /// <param name="actionSoftProcessTerminateRequest"><see cref="ActionSoftProcessTerminateRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse> TerminateProcess([FormContent] ActionSoftProcessTerminateRequest actionSoftProcessTerminateRequest);

        /// <summary>
        /// 删除ActionSoft流程
        /// </summary>
        /// <param name="actionSoftProcessDeleteRequest">ActionSoftProcessDeleteRequest</param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<bool>> DeleteProcess([FormContent] ActionSoftProcessDeleteRequest actionSoftProcessDeleteRequest);

        ///// <summary>
        ///// 重置ActionSoft流程
        ///// </summary>
        ///// <param name="actionSoftProcessRestartRequest"><see cref="ActionSoftProcessRestartRequest"/></param>
        ///// <returns></returns>
        //[HttpPost("/portal/openapi")]
        //Task<ActionSoftWebApiResponse<ActionSoftTaskInfo>> RestartProcess([FormContent] ActionSoftProcessRestartRequest actionSoftProcessRestartRequest);

        /// <summary>
        /// 重新激活ActionSoft流程
        /// </summary>
        /// <param name="actionSoftProcessReactiveRequest"><see cref="ActionSoftProcessReactivateRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<ActionSoftTaskInfo>> ReActivateProcess([FormContent] ActionSoftProcessReactivateRequest actionSoftProcessReactiveRequest);

        /// <summary>
        /// 检查ActionSoft流程是否已结束
        /// </summary>
        /// <param name="actionSoftProcessEndCheckRequest"><see cref="ActionSoftProcessEndCheckRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<bool>> ProcessEndCheck([FormContent] ActionSoftProcessEndCheckRequest actionSoftProcessEndCheckRequest);

        /// <summary>
        /// 获取流程
        /// </summary>
        /// <param name="actionSoftProcessGetRequest"><see cref="ActionSoftProcessGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<ActionSoftProcessInfo>> GetProcess([FormContent] ActionSoftProcessGetRequest actionSoftProcessGetRequest);

        /// <summary>
        /// 获取流程数量
        /// </summary>
        /// <param name="actionSoftProcessCountGetRequest"><see cref="ActionSoftProcessGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<int>> GetProcessCount([FormContent] ActionSoftProcessCountGetRequest actionSoftProcessCountGetRequest);

        /// <summary>
        /// 查询流程
        /// </summary>
        /// <param name="actionSoftProcessQueryRequest"><see cref="ActionSoftProcessQueryRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<List<ActionSoftProcessInfo>>> QueryProcess([FormContent] ActionSoftProcessQueryRequest actionSoftProcessQueryRequest);

        /// <summary>
        /// 分页查询流程
        /// </summary>
        /// <param name="actionSoftProcessPageQueryRequest"><see cref="ActionSoftProcessPageQueryRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<List<ActionSoftProcessInfo>>> PageQueryProcess([FormContent] ActionSoftProcessPageQueryRequest actionSoftProcessPageQueryRequest);

        /// <summary>
        /// 获取特定流程变量
        /// </summary>
        /// <param name="actionSoftSpecifiedProcessVarGetRequest"><see cref="ActionSoftSpecifiedProcessIntanceVarGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<string>> GetSpecifiedProcessVar([FormContent] ActionSoftSpecifiedProcessIntanceVarGetRequest actionSoftSpecifiedProcessVarGetRequest);

        /// <summary>
        /// 设置特定流程变量
        /// </summary>
        /// <param name="actionSoftSpecifiedProcessVarSetRequest"><see cref="ActionSoftSpecifiedProcessVarSetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse> SetSpecifiedProcessVar([FormContent] ActionSoftSpecifiedProcessVarSetRequest actionSoftSpecifiedProcessVarSetRequest);

        /// <summary>
        /// 获取流程变量
        /// </summary>
        /// <param name="actionSoftProcessVarsGetRequest"><see cref="ActionSoftProcessVarsGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<Dictionary<string, string>>> GetAllProcessVar([FormContent] ActionSoftProcessVarsGetRequest actionSoftProcessVarsGetRequest);

        /// <summary>
        /// 批量设置流程变量
        /// </summary>
        /// <param name="actionSoftProcessVarBatchSetRequest"><see cref="ActionSoftProcessVarBatchSetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse> BatchSetProcessVar([FormContent] ActionSoftProcessVarBatchSetRequest actionSoftProcessVarBatchSetRequest);

        /// <summary>
        /// 获取流程审批留言
        /// </summary>
        /// <param name="processCommentsGetRequest"><see cref="ActionSoftProcessCommentsGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<List<ActionSoftTaskCommentInfo>>> GetProcessComments([FormContent] ActionSoftProcessCommentsGetRequest processCommentsGetRequest);
    }
}
