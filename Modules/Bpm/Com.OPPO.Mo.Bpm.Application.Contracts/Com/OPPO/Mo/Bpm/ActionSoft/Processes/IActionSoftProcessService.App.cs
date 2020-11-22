using Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes
{
    /// <summary>
    /// ActionSoft流程应用服务接口
    /// </summary>
    public interface IActionSoftProcessAppService : IApplicationService
    {
        /// <summary>
        /// 创建流程
        /// </summary>
        /// <param name="actionsoftProcessInstanceCreateInput"><see cref="ActionSoftProcessCreateInput"/></param>
        /// <returns></returns>
        Task<Result<ActionSoftProcessCreateOutput>> CreateProcess(ActionSoftProcessCreateInput actionsoftProcessInstanceCreateInput);

        /// <summary>
        /// 启动流程
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <returns></returns>
        Task<Result<ActionSoftProcessStartOutput>> StartProcess(string processInstanceId);

        /// <summary>
        /// 创建并启动流程
        ///     Step1:创建流程
        ///     Step2:创建业务对象
        ///     Step3:启动流程
        /// </summary>
        /// <param name="actionSoftProcessInstanceCreateAndStartInput"><see cref="ActionSoftProcessCreateAndStartInput"/></param>
        /// <returns></returns>
        Task<Result<ActionSoftProcessCreateAndStartOutput>> CreateAndStartProcess(ActionSoftProcessCreateAndStartInput actionSoftProcessInstanceCreateAndStartInput);


        /// <summary>
        /// 提交(送审)流程
        /// </summary>
        /// <param name="actionSoftProcessSubmitInput"><see cref="ActionSoftProcessSubmitInput"/></param>
        /// <returns></returns>
        Task<Result<ActionSoftTaskExecuteResultDto>> SubmitProcess(ActionSoftProcessSubmitInput actionSoftProcessSubmitInput);

        /// <summary>
        /// 检查流程是否可撤回性
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <returns></returns>
        Task<Result<bool>> CheckProcessRevocability(string processInstanceId);

        /// <summary>
        /// 撤回流程
        /// </summary>
        /// <param name="actionSoftProcessRevokeInput"><see cref="ActionSoftProcessRevokeInput"/></param>
        /// <returns></returns>
        Task<Result<ActionSoftTaskDto>> RevokeProcess(ActionSoftProcessRevokeInput actionSoftProcessRevokeInput);

        /// <summary>
        /// 驳回流程
        /// </summary>
        /// <param name="actionSoftProcessRollbackInput"><see cref="ActionSoftProcessRollbackInput"/></param>
        /// <returns></returns>
        Task<Result<ActionSoftTaskDto>> RollbackProcess(ActionSoftProcessRollbackInput actionSoftProcessRollbackInput);

        /// <summary>
        /// 取消流程
        /// </summary>
        /// <param name="actionSoftProcessInstanceCancelInput"><see cref="ActionSoftProcessCancelInput"/></param>
        /// <returns></returns>
        Task<Result> CancelProcess(ActionSoftProcessCancelInput actionSoftProcessInstanceCancelInput);

        /// <summary>
        /// 终止/作废流程
        /// </summary>
        /// <param name="actionSoftProcessTerminateInput"><see cref="ActionSoftProcessTerminateInput"/></param>
        /// <returns></returns>
        Task<Result> TerminateProcess(ActionSoftProcessTerminateInput actionSoftProcessTerminateInput);

        /// <summary>
        /// 删除流程
        /// </summary>
        /// <param name="actionSoftProcessInstanceDeleteInput"><see cref="ActionSoftProcessDeleteInput"/></param>
        /// <returns></returns>
        Task<Result> DeleteProcess(ActionSoftProcessDeleteInput actionSoftProcessInstanceDeleteInput);

        /// <summary>
        /// 获取流程预测信息
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <param name="isUserTaskOnly">是否只预测人工任务</param>
        /// <returns></returns>
        Task<Result<ActionSoftProcessPredictInfoDto>> GetProcessPredictInfo(string processInstanceId, bool isUserTaskOnly = false);

        /// <summary>
        /// 自定义流程审批人
        /// </summary>
        /// <param name="processApproverCustomizeInput"><see cref="ActionSoftProcessApproverCustomizeInput"/></param>
        /// <returns></returns>
        Task<Result> CustomizeProcessApprovers(ActionSoftProcessApproverCustomizeInput processApproverCustomizeInput);

        /// <summary>
        /// 根据流程实例Id获取流程信息
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <returns></returns>
        Task<Result<ActionSoftProcessDto>> GetProcessById(string processInstanceId);

        /// <summary>
        /// 根据一组流程实例Id获取一组信息
        /// </summary>
        /// <param name="processInstanceIds">一组流程实例Id</param>
        /// <returns></returns>
        Task<Result<List<ActionSoftProcessDto>>> GetProcessByIds(List<string> processInstanceIds);

        /// <summary>
        /// 根据流程实例编码获取流程信息
        /// </summary>
        /// <param name="processInstanceCode">流程实例编码</param>
        /// <returns></returns>
        Task<Result<ActionSoftProcessDto>> GetProcessByCode(string processInstanceCode);

        /// <summary>
        /// 根据一组流程实例编码获取一组流程信息
        /// </summary>
        /// <param name="processInstanceCodes">一组流程实例编码</param>
        /// <returns></returns>
        Task<Result<List<ActionSoftProcessDto>>> GetProcessByCodes(List<string> processInstanceCodes);

        /// <summary>
        /// 【无归属权限控制】查询流程信息
        /// </summary>
        /// <param name="actionSoftProcessInstanceQueryInput"><see cref="ActionSoftProcessQueryInput"/></param>
        /// <returns></returns>
        Task<Result<List<ActionSoftSimplifiedProcessDto>>> QueryProcess(ActionSoftProcessQueryInput actionSoftProcessInstanceQueryInput);

        /// <summary>
        /// 【无归属权限控制】分页查询流程信息
        /// </summary>
        /// <param name="actionSoftProcessInstancePageQueryInput"><see cref="ActionSoftProcessPageQueryInput"/></param>
        /// <returns></returns>
        Task<Result<List<ActionSoftSimplifiedProcessDto>>> PageQueryProcess(ActionSoftProcessPageQueryInput actionSoftProcessInstancePageQueryInput);

        /// <summary>
        /// 获取流程数量
        /// </summary>
        /// <param name="actionSoftProcessCountGetInput"><see cref="ActionSoftProcessCountGetInput"/></param>
        /// <returns></returns>
        Task<Result<int>> GetProcessCount(ActionSoftProcessCountGetInput actionSoftProcessCountGetInput);

        /// <summary>
        /// 设置流程变量
        /// </summary>
        /// <param name="actionSoftSpecifiedProcessVarSetInput"><see cref="ActionSoftSpecifiedProcessVarSetInput"/></param>
        /// <returns></returns>
        Task<Result> SetSpecifiedProcessVar(ActionSoftSpecifiedProcessVarSetInput actionSoftSpecifiedProcessVarSetInput);

        /// <summary>
        /// 批量设置流程变量
        /// </summary>
        /// <param name="actionSoftProcessVarBatchSetInput"><see cref="ActionSoftProcessVarBatchSetInput"/></param>
        /// <returns></returns>
        Task<Result> BatchSetProcessVar(ActionSoftProcessVarBatchSetInput actionSoftProcessVarBatchSetInput);

        /// <summary>
        /// 获取流程变量
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <param name="processVarName">流程变量名称</param>
        /// <returns></returns>
        Task<Result<string>> GetSpecifiedProcessVar(string processInstanceId, string processVarName);

        /// <summary>
        /// 获取流程变量s
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <returns></returns>
        Task<Result<Dictionary<string, string>>> GetAllProcessVar(string processInstanceId);

        /// <summary>
        /// 获取流程审批留言s
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <returns></returns>
        Task<Result<List<ActionSoftTaskCommentInfoDto>>> GetProcessComments(string processInstanceId);


    }
}
