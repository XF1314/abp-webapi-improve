using Com.OPPO.Mo.Bpm.ActionSoft.Tasks;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft任务应用服务
    /// </summary>
    [Authorize]
    public class ActionSoftTaskAppService : BpmAppServiceBase, IActionSoftTaskAppService
    {
        private IActionSoftTaskWebApiService _actionSoftTaskWebApiService;

        /// <summary>
        /// <see cref="ActionSoftTaskAppService"/>
        /// </summary>
        public ActionSoftTaskAppService(IActionSoftTaskWebApiService actionSoftTaskWebApiService)
        {
            _actionSoftTaskWebApiService = actionSoftTaskWebApiService;
        }

        /// <inheritdoc/>
        public async Task<Result<string>> CreateEaiTask(ActionSoftEaiTaskCreateInput actionSoftEaiTaskCreateInput)
        {
            if (actionSoftEaiTaskCreateInput.ExtensionInfo.IsMobileSupport && string.IsNullOrWhiteSpace(actionSoftEaiTaskCreateInput.ExtensionInfo.ActionParams.MobileFormUrl))
                return Result.FromError<string>("参数：移动端表单Url不能为空");

            actionSoftEaiTaskCreateInput.ExtensionInfo.Keywords += $"|{actionSoftEaiTaskCreateInput.ExtensionInfo.ProcessInstanceCode}|{actionSoftEaiTaskCreateInput.EaiTaskBizId}|{actionSoftEaiTaskCreateInput.EaiTaskTitle}";
            var eaiTaskCreateRequest = ObjectMapper.Map<ActionSoftEaiTaskCreateInput, ActionSoftEaiTaskCreateRequest>(actionSoftEaiTaskCreateInput);
            var eaiTaskCreateResponse = await _actionSoftTaskWebApiService.CreateEaiTask(eaiTaskCreateRequest);
            if (eaiTaskCreateResponse.IsOk)
            {
                var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
                var EaiTaskInstanceBelong = new EaiTaskInstanceBelong
                {
                    EaiTaskInstanceId = eaiTaskCreateResponse.Data.EaiTaskInstanceId,
                    EaiTaskBizId = eaiTaskCreateResponse.Data.EaiTaskBizId,
                    EaiTaskTitle = eaiTaskCreateResponse.Data.EaiTaskTitle,
                    AppId = clientId
                };
                await EaiTaskBelongRepository.InsertAsync(EaiTaskInstanceBelong);

                return Result.FromData(eaiTaskCreateResponse.Data.EaiTaskInstanceId);
            }
            else
            {
                var errrorMessage = $"【{eaiTaskCreateResponse.ErrorCode}】{eaiTaskCreateResponse.Message}";
                Logger.LogError(errrorMessage);

                return Result.FromError<string>(errrorMessage);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<bool>> DeleteEaiTask(string eaiTaskInstanceId)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var eaiTaskInstanceBelong = await EaiTaskBelongRepository.GetTaskInstanceBelongByInstanceId(clientId, eaiTaskInstanceId);
            if (eaiTaskInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权删除EAI任务实例【{eaiTaskInstanceId}】");
                return Result.FromCode<bool>(ResultCode.Forbidden, $"应用【{clientId}】无EAI任务实例【{eaiTaskInstanceId}】权限");
            }
            else
            {
                var eaiTaskDeleteRequest = new ActionSoftEaiTaskDeleteRequest { EaiTaskInstanceId = eaiTaskInstanceId, OperatorUserCode = MoBpmConsts.ActionSoftAdminUserCode };
                var eaiTaskDeleteResponse = await _actionSoftTaskWebApiService.DeleteEaiTask(eaiTaskDeleteRequest);
                if (eaiTaskDeleteResponse.IsOk)
                    return Result.FromData(eaiTaskDeleteResponse.Data);
                else
                {
                    var errrorMessage = $"【{eaiTaskDeleteResponse.ErrorCode}】{eaiTaskDeleteResponse.Message}";
                    Logger.LogError(errrorMessage);

                    return Result.FromError<bool>(errrorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<bool>> DeleteEaiTaskByBizId(string appName, string eaiTaskBizId)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var eaiTaskInstanceBelong = await EaiTaskBelongRepository.GetTaskInstanceBelongByTaskBizId(clientId, eaiTaskBizId);
            if (eaiTaskInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权删除EAI任务实例【{eaiTaskBizId}】");
                return Result.FromCode<bool>(ResultCode.Forbidden, $"应用【{clientId}】无EAI任务实例【{eaiTaskBizId}】权限");
            }
            else
            {
                var eaiTaskDeleteByBizIdRequest = new ActionSoftEaiTaskDeleteByBizIdRequest { AppName = appName, EaiTaskBizId = eaiTaskBizId };
                var eaiTaskDeleteResponse = await _actionSoftTaskWebApiService.DeleteEaiTaskByBizId(eaiTaskDeleteByBizIdRequest);
                if (eaiTaskDeleteResponse.IsOk)
                    return Result.FromData(eaiTaskDeleteResponse.Data);
                else
                {
                    var errrorMessage = $"【{eaiTaskDeleteResponse.ErrorCode}】{eaiTaskDeleteResponse.Message}";
                    Logger.LogError(errrorMessage);

                    return Result.FromError<bool>(errrorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> CompleteEaiTask(string eaiTaskInstanceId)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var eaiTaskInstanceBelong = await EaiTaskBelongRepository.GetTaskInstanceBelongByInstanceId(clientId, eaiTaskInstanceId);
            if (eaiTaskInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权完成EAI任务实例【{eaiTaskInstanceId}】");
                return Result.FromCode<bool>(ResultCode.Forbidden, $"应用【{clientId}】无EAI任务实例【{eaiTaskInstanceId}】权限");
            }
            else
            {
                var eaiTaskCompleteRequest = new ActionSoftEaiTaskCompleteRequest { EaiTaskInstanceId = eaiTaskInstanceId };
                var eaiTaskCompleteResponse = await _actionSoftTaskWebApiService.CompleteEaiTask(eaiTaskCompleteRequest);
                if (eaiTaskCompleteResponse.IsOk)
                    return Result.Ok();
                else
                {
                    var errrorMessage = $"【{eaiTaskCompleteResponse.ErrorCode}】{eaiTaskCompleteResponse.Message}";
                    Logger.LogError(errrorMessage);

                    return Result.FromError(errrorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> CompleteEaiTaskByBizId(string appName, string eaiTaskBizId)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var EaiTaskInstanceBelong = await EaiTaskBelongRepository.GetTaskInstanceBelongByTaskBizId(clientId, eaiTaskBizId);
            if (EaiTaskInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权完成EAI任务实例【{eaiTaskBizId}】");
                return Result.FromCode<bool>(ResultCode.Forbidden, $"应用【{clientId}】无EAI任务实例【{eaiTaskBizId}】权限");
            }
            else
            {
                var eaiTaskCompleteByBizIdRequest = new ActionSoftEaiTaskCompleteByBizIdRequest
                {
                    AppName = appName,
                    EaiTaskBizId = eaiTaskBizId
                };
                var eaiTaskCompleteByBizIdResponse = await _actionSoftTaskWebApiService.CompleteEaiTaskByBizId(eaiTaskCompleteByBizIdRequest);
                if (eaiTaskCompleteByBizIdResponse.IsOk)
                    return Result.Ok();
                else
                {
                    var errrorMessage = $"【{eaiTaskCompleteByBizIdResponse.ErrorCode}】{eaiTaskCompleteByBizIdResponse.Message}";
                    Logger.LogError(errrorMessage);

                    return Result.FromError(errrorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftEaiTaskDto>> GetEaiTaskByBizId(string appName, string eaiTaskBizId)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var eaiTaskInstanceBelong = await EaiTaskBelongRepository.GetTaskInstanceBelongByTaskBizId(clientId, eaiTaskBizId);
            if (eaiTaskInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取EAI任务实例【{eaiTaskBizId}】");
                return Result.FromCode<ActionSoftEaiTaskDto>(ResultCode.Forbidden, $"应用【{clientId}】无EAI任务实例【{eaiTaskBizId}】权限");
            }
            else
            {
                var eaiTaskGetByBizIdRequest = new ActionSoftEaiTaskGetByBizIdRequest
                {
                    AppName = appName,
                    EaiTaskBizId = eaiTaskBizId
                };
                var eaiTaskGetByBizIdResponse = await _actionSoftTaskWebApiService.GetEaiTaskByBizId(eaiTaskGetByBizIdRequest);
                if (eaiTaskGetByBizIdResponse.IsOk)
                {
                    var eaiTaskDto = ObjectMapper.Map<ActionSoftEaiTaskInfo, ActionSoftEaiTaskDto>(eaiTaskGetByBizIdResponse.Data);
                    return Result.FromData(eaiTaskDto);
                }
                else
                {
                    var errrorMessage = $"【{eaiTaskGetByBizIdResponse.ErrorCode}】{eaiTaskGetByBizIdResponse.Message}";
                    Logger.LogError(errrorMessage);
                    return Result.FromError<ActionSoftEaiTaskDto>(errrorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<ActionSoftTaskSimulationInfoDto>>> SimulateTask(ActionSoftTaskSimulateInput actionSoftTaskSimulateInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(clientId, actionSoftTaskSimulateInput.ProcessInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取流程实例【{actionSoftTaskSimulateInput.ProcessInstanceId}】任务的模拟执行信息");
                return Result.FromCode<List<ActionSoftTaskSimulationInfoDto>>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{actionSoftTaskSimulateInput.ProcessInstanceId}】中任务模拟执行权限");
            }
            else
            {
                var taskSimulateRequest = ObjectMapper.Map<ActionSoftTaskSimulateInput, ActionSoftTaskSimulateRequest>(actionSoftTaskSimulateInput);
                var taskSimulateResponse = await _actionSoftTaskWebApiService.SimulateTask(taskSimulateRequest);
                if (taskSimulateResponse.IsOk)
                    return Result.FromData(ObjectMapper.Map<List<ActionSoftTaskSimulationInfo>, List<ActionSoftTaskSimulationInfoDto>>(taskSimulateResponse.Data));
                else
                {
                    var errrorMessage = $"【{taskSimulateResponse.ErrorCode}】{taskSimulateResponse.Message}";
                    Logger.LogError(errrorMessage);
                    return Result.FromError<List<ActionSoftTaskSimulationInfoDto>>(errrorMessage);
                }
            }
        }
        /// <inheritdoc/>
        public async Task<Result<bool>> TaskCloseCheck(string taskInstanceId)
        {
            var taskCloseCheckRequest = new ActionSoftTaskCloseCheckRequest { TaskInstanceId = taskInstanceId };
            var taskCloseCheckResponse = await _actionSoftTaskWebApiService.TaskCloseCheck(taskCloseCheckRequest);
            if (taskCloseCheckResponse.IsOk)
                return Result.FromData(taskCloseCheckResponse.Data);
            else
            {
                var errrorMessage = $"【{taskCloseCheckResponse.ErrorCode}】{taskCloseCheckResponse.Message}";
                Logger.LogError(errrorMessage);
                return Result.FromError<bool>(errrorMessage);
            }
        }


        /// <inheritdoc/>
        public async Task<Result<bool>> CommitTaskRecord(ActionSoftTaskRecordCommitInput actionSoftTaskRecordCommitInput)
        {
            var taskGetResponse = await _actionSoftTaskWebApiService.GetTask(new ActionSoftTaskGetRequest { TaskInstanceId = actionSoftTaskRecordCommitInput.TaskInstanceId });
            if (!taskGetResponse.IsOk)
            {
                var errrorMessage = $"【{taskGetResponse.ErrorCode}】{taskGetResponse.Message}";
                Logger.LogError(errrorMessage);
                return Result.FromError<bool>(errrorMessage);
            }
            if (taskGetResponse.Data is null)
                return Result.FromCode<bool>(ResultCode.NoData, $"无任务实例【{actionSoftTaskRecordCommitInput.TaskInstanceId}】");
            else if (taskGetResponse.Data.IsEaiTask)
                return Result.FromCode<bool>(ResultCode.Fail, $"任务实例【{actionSoftTaskRecordCommitInput.TaskInstanceId}】是EAI任务，请到EAI任务相关接口操作");
            else
            {
                var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
                var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(clientId, taskGetResponse.Data.ProcessInstanceId);
                if (processInstanceBelong is null)
                {
                    Logger.LogWarning($"应用【{clientId}】尝试越权完成流程任务实例【{taskGetResponse.Data.TaskInstanceId}】");
                    return Result.FromCode<bool>(ResultCode.Forbidden, $"应用【{clientId}】无流程任务实例【{taskGetResponse.Data.TaskInstanceId}】权限");
                }
                else
                {
                    var taskRecordCommitRequest = ObjectMapper
                    .Map<ActionSoftTaskRecordCommitInput, ActionSoftTaskRecordCommitRequest>(actionSoftTaskRecordCommitInput);
                    var taskRecordCommitResponse = await _actionSoftTaskWebApiService.CommitTaskApprovalRecord(taskRecordCommitRequest);
                    if (taskRecordCommitResponse.IsOk)
                        return Result.FromData(taskRecordCommitResponse.Data);
                    else
                    {
                        var errrorMessage = $"【{taskRecordCommitResponse.ErrorCode}】{taskRecordCommitResponse.Message}";
                        Logger.LogError(errrorMessage);
                        return Result.FromError<bool>(errrorMessage);
                    }
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftTaskExecuteResultDto>> CompleteTask(ActionSoftTaskCompleteInput actionSoftTaskCompleteInput)
        {
            var taskGetResponse = await _actionSoftTaskWebApiService.GetTask(new ActionSoftTaskGetRequest { TaskInstanceId = actionSoftTaskCompleteInput.TaskInstanceId });
            if (!taskGetResponse.IsOk)
            {
                var errrorMessage = $"【{taskGetResponse.ErrorCode}】{taskGetResponse.Message}";
                Logger.LogError(errrorMessage);
                return Result.FromError<ActionSoftTaskExecuteResultDto>(errrorMessage);
            }
            if (taskGetResponse.Data is null)
                return Result.FromCode<ActionSoftTaskExecuteResultDto>(ResultCode.NoData, $"无任务实例【{actionSoftTaskCompleteInput.TaskInstanceId}】");
            else if (taskGetResponse.Data.IsEaiTask)
                return Result.FromCode<ActionSoftTaskExecuteResultDto>(ResultCode.Fail, $"任务实例【{actionSoftTaskCompleteInput.TaskInstanceId}】是EAI任务，请到EAI任务相关接口操作");
            else
            {
                var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
                var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(clientId, taskGetResponse.Data.ProcessInstanceId);
                if (processInstanceBelong is null)
                {
                    Logger.LogWarning($"应用【{clientId}】尝试越权完成流程任务实例【{taskGetResponse.Data.TaskInstanceId}】");
                    return Result.FromCode<ActionSoftTaskExecuteResultDto>(ResultCode.Forbidden, $"应用【{clientId}】无流程任务实例【{taskGetResponse.Data.TaskInstanceId}】权限");
                }
                else
                {
                    var taskCompleteRequest = ObjectMapper.Map<ActionSoftTaskCompleteInput, ActionSoftTaskCompleteRequest>(actionSoftTaskCompleteInput);
                    var taskCompleteResponse = await _actionSoftTaskWebApiService.CompleteTask(taskCompleteRequest);
                    if (taskCompleteResponse.IsOk)
                    {
                        var taskExecutionResultDto = ObjectMapper.Map<ActionSoftTaskExecutionResultInfo, ActionSoftTaskExecuteResultDto>(taskCompleteResponse.Data);
                        return Result.FromData(taskExecutionResultDto);
                    }
                    else
                    {
                        var errrorMessage = $"【{taskCompleteResponse.ErrorCode}】{taskCompleteResponse.Message}";
                        Logger.LogError(errrorMessage);

                        return Result.FromError<ActionSoftTaskExecuteResultDto>(errrorMessage);
                    }
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftTaskExecuteResultDto>> CompleteTaskWithRecord(ActionSoftTaskCompleteWithRecordInput actionSoftTaskCompleteWithRecordInput)
        {
            var taskGetResponse = await _actionSoftTaskWebApiService.GetTask(new ActionSoftTaskGetRequest { TaskInstanceId = actionSoftTaskCompleteWithRecordInput.TaskInstanceId });
            if (!taskGetResponse.IsOk)
            {
                var errrorMessage = $"【{taskGetResponse.ErrorCode}】{taskGetResponse.Message}";
                Logger.LogError(errrorMessage);
                return Result.FromError<ActionSoftTaskExecuteResultDto>(errrorMessage);
            }
            if (taskGetResponse.Data is null)
                return Result.FromCode<ActionSoftTaskExecuteResultDto>(ResultCode.NoData, $"无任务实例【{actionSoftTaskCompleteWithRecordInput.TaskInstanceId}】");
            else if (taskGetResponse.Data.IsEaiTask)
                return Result.FromCode<ActionSoftTaskExecuteResultDto>(ResultCode.Fail, $"任务实例【{actionSoftTaskCompleteWithRecordInput.TaskInstanceId}】是EAI任务，请到EAI任务相关接口操作");
            else
            {
                var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
                var processLauchPemission = await ProcessLaunchPermissionRepository.GetProcessLaunchPermission(clientId, taskGetResponse.Data.ProcessDefinitionId);
                if (processLauchPemission is null)
                {
                    Logger.LogWarning($"应用【{clientId}】尝试越权完成流程任务实例【{taskGetResponse.Data.TaskInstanceId}】");
                    return Result.FromCode<ActionSoftTaskExecuteResultDto>(ResultCode.Forbidden, $"应用【{clientId}】无流程任务实例【{taskGetResponse.Data.TaskInstanceId}】权限");
                }
                else
                {
                    var taskCompleteRequest = new ActionSoftTaskCompleteRequest
                    {
                        TaskInstanceId = actionSoftTaskCompleteWithRecordInput.TaskInstanceId,
                        OperatorUserCode = actionSoftTaskCompleteWithRecordInput.OperatorUserCode,
                        ProcessVars = actionSoftTaskCompleteWithRecordInput.ProcessVars,
                        IsContinue = actionSoftTaskCompleteWithRecordInput.IsContinue,
                        IsPauseOnUserTask = actionSoftTaskCompleteWithRecordInput.IsPauseOnUserTask,
                    };
                    var taskCompleteResponse = await _actionSoftTaskWebApiService.CompleteTask(taskCompleteRequest);
                    if (taskCompleteResponse.IsOk)
                    {
                        var taskRecordCommitRequest = new ActionSoftTaskRecordCommitRequest
                        {
                            TaskInstanceId = actionSoftTaskCompleteWithRecordInput.TaskInstanceId,
                            OperatorUserCode = actionSoftTaskCompleteWithRecordInput.OperatorUserCode,
                            Action = actionSoftTaskCompleteWithRecordInput.Action,
                            Commment = actionSoftTaskCompleteWithRecordInput.Commment,
                            IsIgnoreDefaultSetting = actionSoftTaskCompleteWithRecordInput.IsIgnoreDefaultSetting
                        };
                        var taskRecordCommitResponse = await _actionSoftTaskWebApiService.CommitTaskApprovalRecord(taskRecordCommitRequest);
                        if (taskRecordCommitResponse.IsOk && taskRecordCommitResponse.Data)
                        {
                            var taskExecutionResultDto = ObjectMapper.Map<ActionSoftTaskExecutionResultInfo, ActionSoftTaskExecuteResultDto>(taskCompleteResponse.Data);
                            return Result.FromData(taskExecutionResultDto);
                        }
                        else
                        {
                            var errrorMessage = $"流程任务【{taskRecordCommitRequest.TaskInstanceId}】已标识为完成，" +
                                $"但审批记录提交失败，原因：【{taskRecordCommitResponse.ErrorCode}】{taskRecordCommitResponse.Message}";
                            Logger.LogError(errrorMessage);
                            return Result.FromError<ActionSoftTaskExecuteResultDto>(errrorMessage);
                        }
                    }
                    else
                    {
                        var errrorMessage = $"【{taskCompleteResponse.ErrorCode}】{taskCompleteResponse.Message}";
                        Logger.LogError(errrorMessage);

                        return Result.FromError<ActionSoftTaskExecuteResultDto>(errrorMessage);
                    }
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<long>> GetTaskCount(ActionSoftTaskCountGetInput actionSoftTaskCountGetInput)
        {
            var taskQueryModel = ObjectMapper.Map<ActionSoftTaskCountGetInput, ActionSoftTaskQueryModel>(actionSoftTaskCountGetInput);
            var taskCountGetRequest = new ActionSoftTaskCountGetRequest { TaskQueryModel = taskQueryModel };
            var taskCountGetResponse = await _actionSoftTaskWebApiService.GetTaskCount(taskCountGetRequest);
            if (taskCountGetResponse.IsOk)
                return Result.FromData(taskCountGetResponse.Data);
            else
            {
                var errrorMessage = $"【{taskCountGetResponse.ErrorCode}】{taskCountGetResponse.Message}";
                Logger.LogError(errrorMessage);

                return Result.FromError<long>(errrorMessage);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<ActionSoftSimplifiedTaskDto>>> QueryTask(ActionSoftTaskQueryInput actionSoftTaskQueryInput)
        {
            var taskQueryModel = ObjectMapper.Map<ActionSoftTaskQueryInput, ActionSoftTaskQueryModel>(actionSoftTaskQueryInput);
            var taskQueryRequest = new ActionSoftTaskQueryRequest { TaskQueryModel = taskQueryModel };
            var taskQueryResponse = await _actionSoftTaskWebApiService.QueryTask(taskQueryRequest);
            if (taskQueryResponse.IsOk)
            {
                var simplifiedTaskDtos = ObjectMapper.Map<List<ActionSoftTaskInfo>, List<ActionSoftSimplifiedTaskDto>>(taskQueryResponse.Data);
                return Result.FromData(simplifiedTaskDtos);
            }
            else
            {
                var errrorMessage = $"【{taskQueryResponse.ErrorCode}】{taskQueryResponse.Message}";
                Logger.LogError(errrorMessage);

                return Result.FromError<List<ActionSoftSimplifiedTaskDto>>(errrorMessage);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<ActionSoftSimplifiedTaskDto>>> PageQueryTask(ActionSoftTaskPageQueryInput actionSoftTaskPageQueryInput)
        {
            var taskQueryModel = ObjectMapper.Map<ActionSoftTaskPageQueryInput, ActionSoftTaskQueryModel>(actionSoftTaskPageQueryInput);
            var taskPageQueryRequest = new ActionSoftTaskPageQueryRequest { TaskQueryModel = taskQueryModel };
            var taskPageQueryResponse = await _actionSoftTaskWebApiService.PageQueryTask(taskPageQueryRequest);
            if (taskPageQueryResponse.IsOk)
            {
                var simplifiedTaskDtos = ObjectMapper.Map<List<ActionSoftTaskInfo>, List<ActionSoftSimplifiedTaskDto>>(taskPageQueryResponse.Data);
                return Result.FromData(simplifiedTaskDtos);
            }
            else
            {
                var errrorMessage = $"【{taskPageQueryResponse.ErrorCode}】{taskPageQueryResponse.Message}";
                Logger.LogError(errrorMessage);
                return Result.FromError<List<ActionSoftSimplifiedTaskDto>>(errrorMessage);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftTaskDto>> GetTask(string taskInstanceId)
        {
            var taskGetRequest = new ActionSoftTaskGetRequest { TaskInstanceId = taskInstanceId };
            var taskGetResponse = await _actionSoftTaskWebApiService.GetTask(taskGetRequest);
            if (!taskGetResponse.IsOk)
            {
                var errrorMessage = $"【{taskGetResponse.ErrorCode}】{taskGetResponse.Message}";
                Logger.LogError(errrorMessage);
                return Result.FromError<ActionSoftTaskDto>(errrorMessage);
            }
            else
            {
                var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
                if (taskGetResponse.Data is null)
                    return Result.FromCode<ActionSoftTaskDto>(ResultCode.NoData, $"无任务实例【{taskInstanceId}】");
                else if (taskGetResponse.Data.IsEaiTask)
                {
                    var eaiTaskInstanceBelong = await EaiTaskBelongRepository.GetTaskInstanceBelongByInstanceId(clientId, taskGetResponse.Data.TaskInstanceId);
                    if (eaiTaskInstanceBelong is null)
                    {
                        Logger.LogWarning($"应用【{clientId}】尝试越权获取EAI任务实例【{taskGetResponse.Data.TaskInstanceId}】");
                        return Result.FromCode<ActionSoftTaskDto>(ResultCode.Forbidden, $"应用【{clientId}】无EAI任务实例【{taskGetResponse.Data.TaskInstanceId}】权限");
                    }
                }
                else if (!string.IsNullOrWhiteSpace(taskGetResponse.Data.ProcessDefinitionId))
                {
                    var processLauchPemission = await ProcessLaunchPermissionRepository.GetProcessLaunchPermission(clientId, taskGetResponse.Data.ProcessDefinitionId);
                    if (processLauchPemission is null)
                    {
                        Logger.LogWarning($"应用【{clientId}】尝试越权获取流程任务实例【{taskGetResponse.Data.TaskInstanceId}】");
                        return Result.FromCode<ActionSoftTaskDto>(ResultCode.Forbidden, $"应用【{clientId}】无流程任务实例【{taskGetResponse.Data.TaskInstanceId}】权限");
                    }
                }

                var taskDto = ObjectMapper.Map<ActionSoftTaskInfo, ActionSoftTaskDto>(taskGetResponse.Data);
                return Result.FromData(taskDto);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<long>> GetHistoryTaskCount(ActionSoftHistoryTaskCountGetInput actionSoftHistoryTaskCountGetInput)
        {
            var taskQueryModel = ObjectMapper.Map<ActionSoftHistoryTaskCountGetInput, ActionSoftTaskQueryModel>(actionSoftHistoryTaskCountGetInput);
            var historyTaskCountGetRequest = new ActionSoftHistoryTaskCountGetRequest { TaskQueryModel = taskQueryModel };
            var historyTaskCountGetResponse = await _actionSoftTaskWebApiService.GetHistoryTaskCount(historyTaskCountGetRequest);
            if (historyTaskCountGetResponse.IsOk)
                return Result.FromData(historyTaskCountGetResponse.Data);
            else
            {
                var errrorMessage = $"【{historyTaskCountGetResponse.ErrorCode}】{historyTaskCountGetResponse.Message}";
                Logger.LogError(errrorMessage);

                return Result.FromError<long>(errrorMessage);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<ActionSoftSimplifiedTaskDto>>> QueryHistoryTask(ActionSoftHistoryTaskQueryInput actionSoftHistoryTaskQueryInput)
        {
            var taskQueryModel = ObjectMapper.Map<ActionSoftHistoryTaskQueryInput, ActionSoftTaskQueryModel>(actionSoftHistoryTaskQueryInput);
            var historyTaskQueryRequest = new ActionSoftHistoryTaskQueryRequest { TaskQueryModel = taskQueryModel };
            var historyTaskQueryResponse = await _actionSoftTaskWebApiService.QueryHistoryTask(historyTaskQueryRequest);
            if (historyTaskQueryResponse.IsOk)
            {
                var simplifiedTaskDtos = ObjectMapper.Map<List<ActionSoftTaskInfo>, List<ActionSoftSimplifiedTaskDto>>(historyTaskQueryResponse.Data);
                return Result.FromData(simplifiedTaskDtos);
            }
            else
            {
                var errrorMessage = $"【{historyTaskQueryResponse.ErrorCode}】{historyTaskQueryResponse.Message}";
                Logger.LogError(errrorMessage);

                return Result.FromError<List<ActionSoftSimplifiedTaskDto>>(errrorMessage);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<ActionSoftSimplifiedTaskDto>>> PageQueryHistoryTask(ActionSoftHistoryTaskPageQueryInput actionSoftHistoryTaskPageQueryInput)
        {
            var taskQueryModel = ObjectMapper.Map<ActionSoftHistoryTaskPageQueryInput, ActionSoftTaskQueryModel>(actionSoftHistoryTaskPageQueryInput);
            var historyTaskPageQueryRequest = new ActionSoftHistoryTaskPageQueryRequest { TaskQueryModel = taskQueryModel };
            var historyTaskPageQueryResponse = await _actionSoftTaskWebApiService.PageQueryHistoryTask(historyTaskPageQueryRequest);
            if (historyTaskPageQueryResponse.IsOk)
            {
                var simplifiedTaskDtos = ObjectMapper.Map<List<ActionSoftTaskInfo>, List<ActionSoftSimplifiedTaskDto>>(historyTaskPageQueryResponse.Data);
                return Result.FromData(simplifiedTaskDtos);
            }
            else
            {
                var errrorMessage = $"【{historyTaskPageQueryResponse.ErrorCode}】{historyTaskPageQueryResponse.Message}";
                Logger.LogError(errrorMessage);
                return Result.FromError<List<ActionSoftSimplifiedTaskDto>>(errrorMessage);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftTaskDto>> GetHistoryTask(string taskInstanceId)
        {
            var historyTaskGetRequest = new ActionSoftHistoryTaskGetRequest { TaskInstanceId = taskInstanceId };
            var historyTaskGetResponse = await _actionSoftTaskWebApiService.GetHistoryTask(historyTaskGetRequest);
            if (!historyTaskGetResponse.IsOk)
            {
                var errrorMessage = $"【{historyTaskGetResponse.ErrorCode}】{historyTaskGetResponse.Message}";
                Logger.LogError(errrorMessage);
                return Result.FromError<ActionSoftTaskDto>(errrorMessage);
            }
            else
            {
                var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
                if (historyTaskGetResponse.Data is null)
                    return Result.FromCode<ActionSoftTaskDto>(ResultCode.NoData, $"无任务实例【{taskInstanceId}】");
                else if (historyTaskGetResponse.Data.IsEaiTask)
                {
                    var eaiTaskInstanceBelong = await EaiTaskBelongRepository.GetTaskInstanceBelongByInstanceId(clientId, historyTaskGetResponse.Data.TaskInstanceId);
                    if (eaiTaskInstanceBelong is null)
                    {
                        Logger.LogWarning($"应用【{clientId}】尝试越权获取EAI任务实例【{historyTaskGetResponse.Data.TaskInstanceId}】");
                        return Result.FromCode<ActionSoftTaskDto>(ResultCode.Forbidden, $"应用【{clientId}】无EAI任务实例【{historyTaskGetResponse.Data.TaskInstanceId}】权限");
                    }
                }
                else if (string.IsNullOrWhiteSpace(historyTaskGetResponse.Data.ProcessDefinitionId))
                {
                    var processLauchPemission = await ProcessLaunchPermissionRepository.GetProcessLaunchPermission(clientId, historyTaskGetResponse.Data.ProcessDefinitionId);
                    if (processLauchPemission is null)
                    {
                        Logger.LogWarning($"应用【{clientId}】尝试越权获取流程任务实例【{historyTaskGetResponse.Data.TaskInstanceId}】");
                        return Result.FromCode<ActionSoftTaskDto>(ResultCode.Forbidden, $"应用【{clientId}】无流程任务实例【{historyTaskGetResponse.Data.TaskInstanceId}】权限");
                    }
                }

                var taskDto = ObjectMapper.Map<ActionSoftTaskInfo, ActionSoftTaskDto>(historyTaskGetResponse.Data);
                return Result.FromData(taskDto);
            }
        }

        /// <summary>
        /// 创建传阅任务
        /// </summary>
        /// <param name="actionSoftCirculationTaskCreateInput"><see cref="ActionSoftCirculationTaskCreateInput"/></param>
        /// <returns></returns>
        public async Task<Result<List<ActionSoftTaskDto>>> CreateCirculationTask(ActionSoftCirculationTaskCreateInput actionSoftCirculationTaskCreateInput)
        {
            if (!actionSoftCirculationTaskCreateInput.ClaimUserCodes.Any())
                return Result.FromError<List<ActionSoftTaskDto>>("参数ClaimUserCodes不能为空");

            actionSoftCirculationTaskCreateInput.ClaimUserCodes.RemoveAll(x => string.IsNullOrWhiteSpace(x));
            actionSoftCirculationTaskCreateInput.ClaimUserCodes =  actionSoftCirculationTaskCreateInput.ClaimUserCodes.Distinct().ToList();
            var maxCirculationCount = int.Parse(Configuration["oppo-mo-bpm-service-max-circulation-count"]);
            if (actionSoftCirculationTaskCreateInput.ClaimUserCodes.Count > maxCirculationCount)
                return Result.FromError<List<ActionSoftTaskDto>>($"单次最大传阅人次不能超过{maxCirculationCount}");

            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, actionSoftCirculationTaskCreateInput.ProcessInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权创建流程实例【{actionSoftCirculationTaskCreateInput.ProcessInstanceId}】传阅任务");
                return Result.FromCode<List<ActionSoftTaskDto>>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{actionSoftCirculationTaskCreateInput.ProcessInstanceId}】权限");
            }
            else
            {
                var circulationTaskCreateRequest = ObjectMapper.Map<ActionSoftCirculationTaskCreateInput, ActionSoftCirculationTaskCreateRequest>(actionSoftCirculationTaskCreateInput);
                var circulationTaskCreateResponse = await _actionSoftTaskWebApiService.CreateCirculationTask(circulationTaskCreateRequest);
                if (circulationTaskCreateResponse.IsOk)
                {
                    var taskDto = ObjectMapper.Map<List<ActionSoftTaskInfo>, List<ActionSoftTaskDto>>(circulationTaskCreateResponse.Data);
                    return Result.FromData(taskDto);
                }
                else
                {
                    var errrorMessage = $"【{circulationTaskCreateResponse.ErrorCode}】{circulationTaskCreateResponse.Message}";
                    Logger.LogError(errrorMessage);
                    return Result.FromError<List<ActionSoftTaskDto>>(errrorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<string>> GetTaskParticipants(ActionSoftTaskParticipantsGetInput actionSoftTaskParticipantsGetInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(clientId, actionSoftTaskParticipantsGetInput.ProcessInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取流程实例【{actionSoftTaskParticipantsGetInput.ProcessInstanceId}】任务的参与者信息");
                return Result.FromCode<string>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{actionSoftTaskParticipantsGetInput.ProcessInstanceId}】中任务参与者信息获取权限");
            }
            else
            {
                var taskParticipantsGetReqeust = ObjectMapper.Map<ActionSoftTaskParticipantsGetInput, ActionSoftTaskParticipantsGetRequest>(actionSoftTaskParticipantsGetInput);
                var taskParticipantsGetResponse = await _actionSoftTaskWebApiService.GetTaskParticipants(taskParticipantsGetReqeust);
                if (taskParticipantsGetResponse.IsOk)
                    return Result.FromData(taskParticipantsGetResponse.Data);
                else
                {
                    var errrorMessage = $"【{taskParticipantsGetResponse.ErrorCode}】{taskParticipantsGetResponse.Message}";
                    Logger.LogError(errrorMessage);
                    return Result.FromError<string>(errrorMessage);
                }
            }

        }
    }
}
