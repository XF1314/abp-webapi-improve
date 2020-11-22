using Com.OPPO.Mo.Bpm.ActionSoft.Processes;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft流程
    /// </summary>
    [Area("actionsoft")]
    [Route("openapi/actionsoft/process")]
    public class ActionSoftProcessController : AbpController
    {
        private readonly IActionSoftProcessAppService _actionSoftProcessAppService;

        /// <summary>
        /// <see cref="ActionSoftProcessController"/>
        /// </summary>
        public ActionSoftProcessController(IActionSoftProcessAppService actionSoftProcessInstanceAppService)
        {
            _actionSoftProcessAppService = actionSoftProcessInstanceAppService;
        }

        /// <summary>
        /// 创建流程
        /// </summary>
        /// <param name="processCreateInput"><see cref="ActionSoftProcessCreateInput"/></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<Result<ActionSoftProcessCreateOutput>> CreateProcess([FromBody] ActionSoftProcessCreateInput processCreateInput)
        {
            return await _actionSoftProcessAppService.CreateProcess(processCreateInput);
        }

        /// <summary>
        /// 启动流程
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <returns></returns>
        [HttpPost("start")]
        public async Task<Result<ActionSoftProcessStartOutput>> StartProcess(string processInstanceId)
        {
            return await _actionSoftProcessAppService.StartProcess(processInstanceId);
        }

        /// <summary>
        /// 创建并启动流程
        /// </summary>
        /// <param name="processCreateAndStartInput"><see cref="ActionSoftProcessCreateAndStartInput"/></param>
        /// <returns></returns>
        [HttpPost("create-and-start")]
        public async Task<Result<ActionSoftProcessCreateAndStartOutput>> CreateAndStartProcess([FromBody] ActionSoftProcessCreateAndStartInput processCreateAndStartInput)
        {
            return await _actionSoftProcessAppService.CreateAndStartProcess(processCreateAndStartInput);
        }

        /// <summary>
        /// 提交（送审）流程
        /// </summary>
        /// <param name="processSubmitInput"><see cref="ActionSoftProcessSubmitInput"/></param>
        /// <returns></returns>
        [HttpPost("submit")]
        public async Task<Result<ActionSoftTaskExecuteResultDto>> SubmitProcess([FromBody] ActionSoftProcessSubmitInput processSubmitInput)
        {
            return await _actionSoftProcessAppService.SubmitProcess(processSubmitInput);
        }

        /// <summary>
        /// 检查流程是否可撤回
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <returns></returns>
        [HttpPost("revocability/check")]
        public async Task<Result<bool>> CheckProcessRevocability(string processInstanceId)
        {
            return await _actionSoftProcessAppService.CheckProcessRevocability(processInstanceId);
        }

        /// <summary>
        /// 撤回流程
        /// </summary>
        /// <param name="actionSoftProcessRevokeInput"><see cref="ActionSoftProcessRevokeInput"/></param>
        /// <returns></returns>
        [HttpPost("revoke")]
        public async Task<Result<ActionSoftTaskDto>> RevokeProcess([FromBody] ActionSoftProcessRevokeInput actionSoftProcessRevokeInput)
        {
            return await _actionSoftProcessAppService.RevokeProcess(actionSoftProcessRevokeInput);
        }

        /// <summary>
        /// 回退（驳回）流程
        /// </summary>
        /// <param name="actionSoftProcessRollbackInput"><see cref="ActionSoftProcessRollbackInput"/></param>
        /// <returns></returns>
        [HttpPost("rollback")]
        public async Task<Result<ActionSoftTaskDto>> RollbackProcess([FromBody] ActionSoftProcessRollbackInput actionSoftProcessRollbackInput)
        {
            return await _actionSoftProcessAppService.RollbackProcess(actionSoftProcessRollbackInput);
        }

        /// <summary>
        /// 流程预测
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <param name="isUserTaskOnly">是否只预测人工任务</param>
        /// <returns></returns>
        [HttpGet("predict")]
        public async Task<Result<ActionSoftProcessPredictInfoDto>> GetProcessPredictInfo(string processInstanceId, bool isUserTaskOnly = true)
        {
            return await _actionSoftProcessAppService.GetProcessPredictInfo(processInstanceId, isUserTaskOnly);
        }

        /// <summary>
        /// 自定义流程审批人
        /// </summary>
        /// <param name="processApproverCustomizeInput"><see cref="ActionSoftProcessApproverCustomizeInput"/></param>
        /// <returns></returns>
        [HttpPost("approver/customize")]
        public async Task<Result> CustomizeProcessApprovers([FromBody] ActionSoftProcessApproverCustomizeInput processApproverCustomizeInput)
        {
            return await _actionSoftProcessAppService.CustomizeProcessApprovers(processApproverCustomizeInput);
        }

        /// <summary>
        /// 取消流程
        /// </summary>
        /// <param name="processCancelInput"><see cref="ActionSoftProcessCancelInput"/></param>
        /// <returns></returns>
        [HttpPost("cancel")]
        public async Task<Result> CancelProcess([FromBody] ActionSoftProcessCancelInput processCancelInput)
        {
            return await _actionSoftProcessAppService.CancelProcess(processCancelInput);
        }

        /// <summary>
        /// 终止（作废）流程
        /// </summary>
        /// <param name="processTerminateInput"><see cref="ActionSoftProcessTerminateInput"/></param>
        /// <returns></returns>
        [HttpPost("terminate")]
        public async Task<Result> TerminateProcess([FromBody] ActionSoftProcessTerminateInput processTerminateInput)
        {
            return await _actionSoftProcessAppService.TerminateProcess(processTerminateInput);
        }

        /// <summary>
        /// 删除流程
        /// </summary>
        /// <param name="processDeleteInput"><see cref="ActionSoftProcessDeleteInput"/></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public async Task<Result> DeleteProcess([FromBody] ActionSoftProcessDeleteInput processDeleteInput)
        {
            return await _actionSoftProcessAppService.DeleteProcess(processDeleteInput);
        }

        /// <summary>
        /// 根据流程实例Id获取流程信息
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <returns></returns>
        [HttpGet("get-by-id")]
        public async Task<Result<ActionSoftProcessDto>> GetProcessById(string processInstanceId)
        {
            return await _actionSoftProcessAppService.GetProcessById(processInstanceId);
        }

        /// <summary>
        /// 根据一组流程实例Id获取一组流程信息
        /// </summary>
        /// <param name="processInstanceIds">一组流程实例Id</param>
        /// <returns></returns>
        [HttpGet("get-by-ids")]
        public async Task<Result<List<ActionSoftProcessDto>>> GetProcessByIds(List<string> processInstanceIds)
        {
            return await _actionSoftProcessAppService.GetProcessByIds(processInstanceIds);
        }

        /// <summary>
        /// 根据流程实例编码获取流程信息
        /// </summary>
        /// <param name="processInstanceCode">流程实例编码</param>
        /// <returns></returns>
        [HttpGet("get-by-code")]
        public async Task<Result<ActionSoftProcessDto>> GetProcessByCode(string processInstanceCode)
        {
            return await _actionSoftProcessAppService.GetProcessByCode(processInstanceCode);
        }

        /// <summary>
        /// 根据一组流程实例编码获取一组流程信息
        /// </summary>
        /// <param name="processInstanceCodes">一组流程实例编码</param>
        /// <returns></returns>
        [HttpGet("get-by-codes")]
        public async Task<Result<List<ActionSoftProcessDto>>> GetProcessByCodes(List<string> processInstanceCodes)
        {
            return await _actionSoftProcessAppService.GetProcessByCodes(processInstanceCodes);
        }

        /// <summary>
        /// 获取流程数量
        /// </summary>
        /// <param name="processCountGetInput"><see cref="ActionSoftProcessCountGetInput"/></param>
        /// <returns></returns>
        [HttpPost("count")]
        public async Task<Result<int>> GetProcessCount([FromBody] ActionSoftProcessCountGetInput processCountGetInput)
        {
            return await _actionSoftProcessAppService.GetProcessCount(processCountGetInput);
        }

        /// <summary>
        /// 【无归属权限控制】查询流程信息
        /// </summary>
        /// <param name="processQueryInput"><see cref="ActionSoftProcessQueryInput"/></param>Sub
        /// <returns></returns>
        [HttpPost("query")]
        public async Task<Result<List<ActionSoftSimplifiedProcessDto>>> QueryProcess([FromBody] ActionSoftProcessQueryInput processQueryInput)
        {
            return await _actionSoftProcessAppService.QueryProcess(processQueryInput);
        }

        /// <summary>
        /// 【无归属权限控制】分页查询流程信息
        /// </summary>
        /// <param name="processPageQueryInput"><see cref="ActionSoftProcessPageQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("page-query")]
        public async Task<Result<List<ActionSoftSimplifiedProcessDto>>> PageQueryProcess([FromBody] ActionSoftProcessPageQueryInput processPageQueryInput)
        {
            return await _actionSoftProcessAppService.PageQueryProcess(processPageQueryInput);
        }

        /// <summary>
        /// 设置流程变量
        /// </summary>
        /// <param name="specifiedProcessVarSetInput"><see cref="ActionSoftSpecifiedProcessVarSetInput"/></param>
        /// <returns></returns>
        [HttpPost("var/set")]
        public async Task<Result> SetSpecifiedProcessVar([FromBody] ActionSoftSpecifiedProcessVarSetInput specifiedProcessVarSetInput)
        {
            return await _actionSoftProcessAppService.SetSpecifiedProcessVar(specifiedProcessVarSetInput);
        }

        /// <summary>
        /// 批量设置流程变量
        /// </summary>
        /// <param name="processVarBatchSetInput"><see cref="ActionSoftProcessVarBatchSetInput"/></param>
        /// <returns></returns>
        [HttpPost("var/batch-set")]
        public async Task<Result> BatchSetProcessVar([FromBody] ActionSoftProcessVarBatchSetInput processVarBatchSetInput)
        {
            return await _actionSoftProcessAppService.BatchSetProcessVar(processVarBatchSetInput);
        }

        /// <summary>
        /// 获取流程变量
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <param name="processVarName">流程变量名称</param>
        /// <returns></returns>
        [HttpGet("var/get-by-name")]
        public async Task<Result<string>> GetSpecifiedProcessVar(string processInstanceId, string processVarName)
        {
            return await _actionSoftProcessAppService.GetSpecifiedProcessVar(processInstanceId, processVarName);
        }

        /// <summary>
        /// 获取所有的流程变量
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <returns></returns>
        [HttpGet("var/all")]
        public async Task<Result<Dictionary<string, string>>> GetAllProcessVar(string processInstanceId)
        {
            return await _actionSoftProcessAppService.GetAllProcessVar(processInstanceId);
        }

        /// <summary>
        /// 获取流程审批留言
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <returns></returns>
        [HttpGet("comments")]
        public async Task<Result<List<ActionSoftTaskCommentInfoDto>>> GetProcessComments(string processInstanceId)
        {
            return await _actionSoftProcessAppService.GetProcessComments(processInstanceId);
        }
    }
}
