using Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects;
using Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.Extensions;
using Com.OPPO.Mo.Bpm.ActionSoft.Extensions.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.Organiztion;
using Com.OPPO.Mo.Bpm.ActionSoft.Organiztion.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes.Responses;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Volo.Abp.Threading;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft流程实例应用服务
    /// </summary>
    [Authorize]
    public class ActionSoftProcessAppService : BpmAppServiceBase, IActionSoftProcessAppService
    {
        private readonly IActionSoftBusinessObjectWebApiService _actionSoftBusinessObjectWebApiService;
        private readonly IActionSoftProcessWebApiService _actionSoftProcessWebApiService;
        private readonly IActionSoftTaskWebApiService _actionSoftTaskWebApiService;

        /// <summary>
        /// <see cref="ActionSoftProcessAppService"/>
        /// </summary>
        public ActionSoftProcessAppService(
            IActionSoftBusinessObjectWebApiService actionSoftBusinessObjectWebApiService,
            IActionSoftProcessWebApiService actionSoftProcessWebApiService,
            IActionSoftTaskWebApiService actionSoftTaskWebApiService)
        {
            _actionSoftTaskWebApiService = actionSoftTaskWebApiService;
            _actionSoftProcessWebApiService = actionSoftProcessWebApiService;
            _actionSoftBusinessObjectWebApiService = actionSoftBusinessObjectWebApiService;
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftProcessCreateOutput>> CreateProcess(ActionSoftProcessCreateInput actionsoftProcessCreateInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processLaunch = await ProcessLaunchPermissionRepository.GetProcessLaunchPermission(appId: clientId, actionsoftProcessCreateInput.ProcessDefinitionId);
            if (processLaunch is null || !processLaunch.IsValid)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权创建流程【{actionsoftProcessCreateInput.ProcessDefinitionId}】");
                return Result.FromCode<ActionSoftProcessCreateOutput>(ResultCode.Forbidden, $"应用【{clientId}】无流程【{actionsoftProcessCreateInput.ProcessDefinitionId}】创建权限");
            }

            var processCreateRequest = ObjectMapper
                 .Map<ActionSoftProcessCreateInput, ActionSoftProcessCreateRequest>(actionsoftProcessCreateInput);
            actionsoftProcessCreateInput.ActivityApprovers.RemoveAll(x => string.IsNullOrWhiteSpace(x.TaskDefinitionId));
            if (actionsoftProcessCreateInput.ActivityApprovers.Any())
            {
                var formatedActivityApprovers = actionsoftProcessCreateInput.ActivityApprovers.ToDictionary(x => x.TaskDefinitionId, y => string.Join(" ", y.ApproverUserCodes));
                if (processCreateRequest.ProcessVars.ContainsKey(MoBpmConsts.ActionSoftCustomApprovers))
                    processCreateRequest.ProcessVars.Remove(MoBpmConsts.ActionSoftCustomApprovers);
                processCreateRequest.ProcessVars.Add(MoBpmConsts.ActionSoftCustomApprovers, JsonConvert.SerializeObject(formatedActivityApprovers));
            }

            var processCreateResponse = await _actionSoftProcessWebApiService.CreateProcess(processCreateRequest);
            if (!processCreateResponse.IsOk)
            {
                var errorMessage = $"【{processCreateResponse.ErrorCode}】{processCreateResponse.Message}";
                Logger.LogError(errorMessage);
                return Result.FromError<ActionSoftProcessCreateOutput>(errorMessage);
            }

            await ProcessInstanceBelongRepository.InsertAsync(new ProcessInstanceBelong
            {
                AppId = clientId,
                ProcessInstanceId = processCreateResponse.Data.ProcessInstanceId,
                ProcessInstanceCode = processCreateResponse.Data.ProcessInstanceCode,
                ProcessTitle = processCreateResponse.Data.ProcessTitle
            });

            return Result.FromData(new ActionSoftProcessCreateOutput
            {
                ProcessInstanceId = processCreateResponse.Data.ProcessInstanceId,
                ProcessInstanceCode = processCreateResponse.Data.ProcessInstanceCode,
                ProcessTitle = processCreateResponse.Data.ProcessTitle
            });
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftProcessStartOutput>> StartProcess(string processInstanceId)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, processInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权启动流程实例【{processInstanceId}】");
                return Result.FromCode<ActionSoftProcessStartOutput>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{processInstanceId}】权限");
            }

            var processStartResponse = await _actionSoftProcessWebApiService.StartProcess(new ActionSoftProcessStartRequest { ProcessInstanceId = processInstanceId });
            if (!processStartResponse.IsOk)
            {
                var errorMessage = $"【{processStartResponse.ErrorCode}】{processStartResponse.Message}";
                Logger.LogError(errorMessage);
                return Result.FromError<ActionSoftProcessStartOutput>(errorMessage);
            }

            var processGetResponse = await _actionSoftProcessWebApiService.GetProcess(new ActionSoftProcessGetRequest { ProcessInstanceId = processInstanceId });
            if (!processGetResponse.IsOk)
            {
                var errorMessage = $"流程启动成功，但获取流程信息失败，【{processStartResponse.ErrorCode}】{processStartResponse.Message}";
                Logger.LogError(errorMessage);
                return Result.FromError<ActionSoftProcessStartOutput>(errorMessage);
            }

            var processStartOutput = new ActionSoftProcessStartOutput
            {
                ProcessInstanceId = processGetResponse.Data.ProcessInstanceId,
                ProcessInstanceCode = processGetResponse.Data.ProcessInstanceCode,
                ProcessTitle = processGetResponse.Data.ProcessTitle,
                StartTaskDefinitionId = processGetResponse.Data.StartTaskDefinitionId,
                StartTaskInstanceId = processGetResponse.Data.StartTaskInstanceId
            };

            return Result.FromData(processStartOutput);
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftProcessCreateAndStartOutput>> CreateAndStartProcess(ActionSoftProcessCreateAndStartInput actionSoftProcessCreateAndStartInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processLaunchPermission = await ProcessLaunchPermissionRepository.GetProcessLaunchPermission(appId: clientId, actionSoftProcessCreateAndStartInput.ProcessDefinitionId);
            if (processLaunchPermission is null || !processLaunchPermission.IsValid)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权发起流程【{actionSoftProcessCreateAndStartInput.ProcessDefinitionId}】");
                return Result.FromCode<ActionSoftProcessCreateAndStartOutput>
                    (ResultCode.Forbidden, $"应用【{clientId}】无流程【{actionSoftProcessCreateAndStartInput.ProcessDefinitionId}】发起权限");
            }

            var processCreateRequest = ObjectMapper
                .Map<ActionSoftProcessCreateAndStartInput, ActionSoftProcessCreateRequest>(actionSoftProcessCreateAndStartInput);
            actionSoftProcessCreateAndStartInput.ActivityApprovers.RemoveAll(x => string.IsNullOrWhiteSpace(x.TaskDefinitionId));
            if (actionSoftProcessCreateAndStartInput.ActivityApprovers.Any())
            {
                var formatedActivityApprovers = actionSoftProcessCreateAndStartInput.ActivityApprovers.ToDictionary(x => x.TaskDefinitionId, y => string.Join(" ", y.ApproverUserCodes));
                if (processCreateRequest.ProcessVars.ContainsKey(MoBpmConsts.ActionSoftCustomApprovers))
                    processCreateRequest.ProcessVars.Remove(MoBpmConsts.ActionSoftCustomApprovers);
                processCreateRequest.ProcessVars.Add(MoBpmConsts.ActionSoftCustomApprovers, JsonConvert.SerializeObject(formatedActivityApprovers));
            }

            var processCreateResponse = await _actionSoftProcessWebApiService.CreateProcess(processCreateRequest);
            if (!processCreateResponse.IsOk)
            {
                var errorMessage = $"【{processCreateResponse.ErrorCode}】{processCreateResponse.Message}";
                Logger.LogError(errorMessage);
                return Result.FromError<ActionSoftProcessCreateAndStartOutput>(errorMessage);
            }

            var boBatchCreateResponses = new Dictionary<string, ActionSoftWebApiResponse<List<string>>>();
            if (actionSoftProcessCreateAndStartInput.BusinessObjects != null)
            {
                foreach (var businessObject in actionSoftProcessCreateAndStartInput.BusinessObjects)
                {
                    if (!string.IsNullOrWhiteSpace(businessObject.Key) && businessObject.Value.Any())
                    {
                        var boBatchCreateResponse = await _actionSoftBusinessObjectWebApiService.BatchCreateBusinessObject(new ActionSoftBusinessObjectBatchCreateRequest
                        {
                            BusinessObjectTableName = businessObject.Key,
                            BusinessObjectFields = businessObject.Value,
                            ProcessInstanceId = processCreateResponse.Data.ProcessInstanceId,
                            CreatorUserCode = actionSoftProcessCreateAndStartInput.CreatorUserCode
                        });
                        boBatchCreateResponses.Add(businessObject.Key, boBatchCreateResponse);
                        if (!boBatchCreateResponse.IsOk) break;//任一Bo记录创建失败，停止后续创建
                    }
                }

                //创建Bo记录失败，则删除已创建成功的流程实例对象和Bo记录，并响应失败
                if (boBatchCreateResponses.Values.Any(x => !x.IsOk))
                {
                    await _actionSoftProcessWebApiService.DeleteProcess(new ActionSoftProcessDeleteRequest
                    {
                        ProcessInstanceId = processCreateResponse.Data.ProcessInstanceId,
                        OperatorUserCode = actionSoftProcessCreateAndStartInput.CreatorUserCode
                    });
                    var boDeleteTasks = actionSoftProcessCreateAndStartInput.BusinessObjects
                        .Where(x => !string.IsNullOrWhiteSpace(x.Key) && x.Value.Any())
                        .Select(x => Task.Run(() => _actionSoftBusinessObjectWebApiService.BatchDeleteBusinessObjectByProcess(new ActionSoftBusinessObjectDeleteByProcessRequest
                        {
                            ProcessInstanceId = processCreateResponse.Data.ProcessInstanceId,
                            BusinessObjectTableName = x.Key
                        })));
                    Task.WaitAll(boDeleteTasks.ToArray());
                    var errorMessages = string.Join(Environment.NewLine, boBatchCreateResponses.Values.Where(y => !y.IsOk).Select(z => $"【{z.ErrorCode}】{z.Message}"));
                    Logger.LogError(errorMessages);
                    return Result.FromError<ActionSoftProcessCreateAndStartOutput>(errorMessages);
                }
            }

            var processStartResponse = await _actionSoftProcessWebApiService
                .StartProcess(new ActionSoftProcessStartRequest { ProcessInstanceId = processCreateResponse.Data.ProcessInstanceId });
            if (processStartResponse.IsOk)
            {
                //写入流程实例归属记录，TODO:考虑异步处理
                await ProcessInstanceBelongRepository.InsertAsync(new ProcessInstanceBelong
                {
                    AppId = clientId,
                    ProcessInstanceId = processCreateResponse.Data.ProcessInstanceId,
                    ProcessInstanceCode = processCreateResponse.Data.ProcessInstanceCode,
                    ProcessTitle = processCreateResponse.Data.ProcessTitle
                });

                //写入增业务对象归属记录，TODO:考虑异步处理
                var businessObjectBelongTasks = new List<Task<BusinessObjectBelong>>();
                boBatchCreateResponses.ToList().ForEach(x =>
                {
                    businessObjectBelongTasks.AddRange(x.Value.Data.Select(y => BusinessObjectBelongRepository.InsertAsync(new BusinessObjectBelong
                    {
                        AppId = clientId,
                        BusinessObjectTableName = x.Key,
                        ProcessInstanceId = processCreateResponse.Data.ProcessInstanceId,
                        BusinessObjectId = y
                    })));
                });
                await businessObjectBelongTasks.WhenAll();

                var processGetResponse = await _actionSoftProcessWebApiService.GetProcess(new ActionSoftProcessGetRequest { ProcessInstanceId = processCreateResponse.Data.ProcessInstanceId });
                if (!processGetResponse.IsOk)
                {
                    var errorMessage = $"流程创建并启动成功，但获取流程信息失败，【{processStartResponse.ErrorCode}】{processStartResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<ActionSoftProcessCreateAndStartOutput>(errorMessage);
                }
                else
                {
                    var processCreateAndStartOutput = new ActionSoftProcessCreateAndStartOutput
                    {
                        ProcessInstanceId = processCreateResponse.Data.ProcessInstanceId,
                        ProcessInstanceCode = processCreateResponse.Data.ProcessInstanceCode,
                        ProcessTitle = processCreateResponse.Data.ProcessTitle,
                        StartTaskInstanceId = processGetResponse.Data.StartTaskInstanceId,
                        StartTaskDefinitionId = processGetResponse.Data.StartTaskDefinitionId,
                        BusinessObjectIds = boBatchCreateResponses.ToDictionary(x => x.Key, y => y.Value.Data)
                    };

                    return Result.FromData(processCreateAndStartOutput);
                }
            }
            else//启动流程实例失败，则删除已创建成功的流程实例对象和业务对象记录，并响应失败
            {
                await _actionSoftProcessWebApiService.DeleteProcess(new ActionSoftProcessDeleteRequest
                {
                    ProcessInstanceId = processCreateResponse.Data.ProcessInstanceId,
                    OperatorUserCode = actionSoftProcessCreateAndStartInput.CreatorUserCode
                });
                var actionSoftBoDeleteTasks = actionSoftProcessCreateAndStartInput.BusinessObjects
                    .Where(x => !string.IsNullOrWhiteSpace(x.Key) && x.Value.Any())
                    .Select(x => Task.Run(() => _actionSoftBusinessObjectWebApiService.BatchDeleteBusinessObjectByProcess(new ActionSoftBusinessObjectDeleteByProcessRequest
                    {
                        ProcessInstanceId = processCreateResponse.Data.ProcessInstanceId,
                        BusinessObjectTableName = x.Key
                    })));
                Task.WaitAll(actionSoftBoDeleteTasks.ToArray());

                var errorMessage = $"【{processCreateResponse.ErrorCode}】{processStartResponse.Message}";
                Logger.LogError(errorMessage);
                return Result.FromError<ActionSoftProcessCreateAndStartOutput>(errorMessage);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftTaskExecuteResultDto>> SubmitProcess(ActionSoftProcessSubmitInput actionSoftProcessSubmitInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, actionSoftProcessSubmitInput.ProcessInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权提交(送审)流程实例【{actionSoftProcessSubmitInput.ProcessInstanceId}】");
                return Result.FromCode<ActionSoftTaskExecuteResultDto>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{actionSoftProcessSubmitInput.ProcessInstanceId}】权限");
            }

            var processInstanceGetResponse = await _actionSoftProcessWebApiService.GetProcess(new ActionSoftProcessGetRequest { ProcessInstanceId = actionSoftProcessSubmitInput.ProcessInstanceId });
            var taskQueryResponse = await _actionSoftTaskWebApiService
                .QueryTask(new ActionSoftTaskQueryRequest { TaskQueryModel = new ActionSoftTaskQueryModel { ProcessInstanceId = actionSoftProcessSubmitInput.ProcessInstanceId } });
            if (!processInstanceGetResponse.IsOk || !taskQueryResponse.IsOk)
            {
                var errorMessage = !processInstanceGetResponse.IsOk
                    ? $"【{processInstanceGetResponse.ErrorCode}】{processInstanceGetResponse.Message}"
                    : $"【{taskQueryResponse.ErrorCode}】{taskQueryResponse.Message}";
                Logger.LogError(errorMessage);
                return Result.FromError<ActionSoftTaskExecuteResultDto>(errorMessage);
            }

            if (!taskQueryResponse.Data.Any(x => x.TaskDefinitionId == processInstanceGetResponse.Data.StartTaskDefinitionId))
                return Result.FromError<ActionSoftTaskExecuteResultDto>($"流程实例【{actionSoftProcessSubmitInput.ProcessInstanceId}】处理非拟制状态，无需再次送审");
            else
            {
                var startTaskInstance = taskQueryResponse.Data.First(x => x.TaskDefinitionId == processInstanceGetResponse.Data.StartTaskDefinitionId);
                var taskRecordCommitRequest = new ActionSoftTaskRecordCommitRequest
                {
                    TaskInstanceId = processInstanceGetResponse.Data.StartTaskInstanceId,
                    OperatorUserCode = actionSoftProcessSubmitInput.OperatorUserCode,
                    Action = ActionSoftApprovalAction.送审.ToString(),
                    Commment = "-",
                    IsIgnoreDefaultSetting = false
                };
                var taskRecordCommitResponse = await _actionSoftTaskWebApiService.CommitTaskApprovalRecord(taskRecordCommitRequest);
                if (!taskRecordCommitResponse.IsOk)
                {
                    var errrorMessage = $"任务【{taskRecordCommitRequest.TaskInstanceId}】审批记录提交失败，原因：【{taskRecordCommitResponse.ErrorCode}】{taskRecordCommitResponse.Message}";
                    Logger.LogError(errrorMessage);
                    return Result.FromError<ActionSoftTaskExecuteResultDto>(errrorMessage);
                }
                else
                {
                    var taskCompleteRequest = new ActionSoftTaskCompleteRequest
                    {
                        TaskInstanceId = startTaskInstance.TaskInstanceId,
                        OperatorUserCode = actionSoftProcessSubmitInput.OperatorUserCode,
                        ProcessVars = actionSoftProcessSubmitInput.ProcessVars
                    };
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
        public async Task<Result<bool>> CheckProcessRevocability(string processInstanceId)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, processInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权检查流程实例【{processInstanceId}】可撤回性");
                return Result.FromCode<bool>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{processInstanceId}】权限");
            }
            else
            {
                var processRevocabilityCheckRequest = new ActionSoftProcessRevocabilityCheckRequest { ProcessInstanceId = processInstanceId };
                var processRevocabilityCheckResponse = await _actionSoftProcessWebApiService.CheckProcessRevocability(processRevocabilityCheckRequest);
                if (processRevocabilityCheckResponse.IsOk)
                    return Result.FromData(processRevocabilityCheckResponse.Data);
                else
                {
                    var errorMessage = $"【{processRevocabilityCheckResponse.ErrorCode}】{processRevocabilityCheckResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<bool>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftTaskDto>> RevokeProcess(ActionSoftProcessRevokeInput actionSoftProcessRevokeInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, actionSoftProcessRevokeInput.ProcessInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权撤回流程实例【{actionSoftProcessRevokeInput.ProcessInstanceId}】");
                return Result.FromCode<ActionSoftTaskDto>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{actionSoftProcessRevokeInput.ProcessInstanceId}】权限");
            }
            else
            {
                var processRevokeRequest = new ActionSoftProcessRevokeRequest
                {
                    ProcessInstanceId = actionSoftProcessRevokeInput.ProcessInstanceId,
                    RevokeReason = actionSoftProcessRevokeInput.RevokeReason
                };
                var processRevokeResponse = await _actionSoftProcessWebApiService.RevokeProcess(processRevokeRequest);
                if (processRevokeResponse.IsOk)
                {
                    var taskDto = ObjectMapper.Map<ActionSoftTaskInfo, ActionSoftTaskDto>(processRevokeResponse.Data);
                    return Result.FromData(taskDto);
                }
                else
                {
                    var errorMessage = $"【{processRevokeResponse.ErrorCode}】{processRevokeResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<ActionSoftTaskDto>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftTaskDto>> RollbackProcess(ActionSoftProcessRollbackInput actionSoftProcessRollbackInput)
        {
            var taskGetResponse = await _actionSoftTaskWebApiService.GetTask(new ActionSoftTaskGetRequest { TaskInstanceId = actionSoftProcessRollbackInput.TaskInstanceId });
            if (!taskGetResponse.IsOk)
            {
                var errrorMessage = $"【{taskGetResponse.ErrorCode}】{taskGetResponse.Message}";
                Logger.LogError(errrorMessage);
                return Result.FromError<ActionSoftTaskDto>(errrorMessage);
            }
            if (taskGetResponse.Data is null)
                return Result.FromCode<ActionSoftTaskDto>(ResultCode.NoData, $"无任务实例【{actionSoftProcessRollbackInput.TaskInstanceId}】");
            else if (taskGetResponse.Data.IsEaiTask)
                return Result.FromCode<ActionSoftTaskDto>(ResultCode.Fail, $"任务实例【{actionSoftProcessRollbackInput.TaskInstanceId}】是EAI任务，请到EAI任务相关接口操作");
            else
            {
                var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
                var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(clientId, taskGetResponse.Data.ProcessDefinitionId);
                if (processInstanceBelong is null)
                {
                    Logger.LogWarning($"应用【{clientId}】尝试越权回退流程任务实例【{taskGetResponse.Data.TaskInstanceId}】");
                    return Result.FromCode<ActionSoftTaskDto>(ResultCode.Forbidden, $"应用【{clientId}】无流程任务实例【{taskGetResponse.Data.TaskInstanceId}】权限");
                }

                var taskRollbackRequest = new ActionSoftTaskRollbackRequest
                {
                    TaskInstanceId = actionSoftProcessRollbackInput.TaskInstanceId,
                    TargetActivityId = actionSoftProcessRollbackInput.TargetActivityId,
                    OperatorUserCode = actionSoftProcessRollbackInput.OperatorUserCode,
                    RollbackReason = actionSoftProcessRollbackInput.RollbackReason,
                    IsCompensation = actionSoftProcessRollbackInput.IsCompensation
                };
                var taskRollbackResponse = await _actionSoftTaskWebApiService.RollbackTask(taskRollbackRequest);
                if (taskRollbackResponse.IsOk)
                {
                    var taskDto = ObjectMapper.Map<ActionSoftTaskInfo, ActionSoftTaskDto>(taskRollbackResponse.Data);
                    return Result.FromData(taskDto);
                }
                else
                {
                    var errrorMessage = $"【{taskRollbackResponse.ErrorCode}】{taskRollbackResponse.Message}";
                    Logger.LogError(errrorMessage);
                    return Result.FromError<ActionSoftTaskDto>(errrorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> CancelProcess(ActionSoftProcessCancelInput actionSoftProcessCancelInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, actionSoftProcessCancelInput.ProcessInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权撤回流程实例【{actionSoftProcessCancelInput.ProcessInstanceId}】");
                return Result.FromCode(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{actionSoftProcessCancelInput.ProcessInstanceId}】权限");
            }
            else
            {
                var processCancelResponse = await _actionSoftProcessWebApiService.CancelProcess(new ActionSoftProcessCancelRequest
                {
                    ProcessInstanceId = actionSoftProcessCancelInput.ProcessInstanceId,
                    OperatorUserCode = actionSoftProcessCancelInput.OperatorUserCode
                });
                if (processCancelResponse.IsOk)
                    return Result.Ok();
                else
                {
                    var errorMessage = $"【{processCancelResponse.ErrorCode}】{processCancelResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> TerminateProcess(ActionSoftProcessTerminateInput actionSoftProcessTerminateInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, actionSoftProcessTerminateInput.ProcessInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权终止/作废流程实例【{actionSoftProcessTerminateInput.ProcessInstanceId}】");
                return Result.FromCode(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{actionSoftProcessTerminateInput.ProcessInstanceId}】权限");
            }
            else
            {
                var processTerminateResponse = await _actionSoftProcessWebApiService.TerminateProcess(new ActionSoftProcessTerminateRequest
                {
                    ProcessInstanceId = actionSoftProcessTerminateInput.ProcessInstanceId,
                    OperatorUserCode = actionSoftProcessTerminateInput.OperatorUserCode
                });
                if (processTerminateResponse.IsOk)
                    return Result.Ok();
                else
                {
                    var errorMessage = $"【{processTerminateResponse.ErrorCode}】{processTerminateResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> DeleteProcess(ActionSoftProcessDeleteInput actionSoftProcessDeleteInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, actionSoftProcessDeleteInput.ProcessInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权删除流程实例【{actionSoftProcessDeleteInput.ProcessInstanceId}】");
                return Result.FromCode(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{actionSoftProcessDeleteInput.ProcessInstanceId}】权限");
            }
            else
            {
                var processDeleteResponse = await _actionSoftProcessWebApiService.DeleteProcess(new ActionSoftProcessDeleteRequest
                {
                    ProcessInstanceId = actionSoftProcessDeleteInput.ProcessInstanceId,
                    OperatorUserCode = actionSoftProcessDeleteInput.OperatorUserCode
                });
                if (processDeleteResponse.IsOk)
                    return Result.Ok();
                else
                {
                    var errorMessage = $"【{processDeleteResponse.ErrorCode}】{processDeleteResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftProcessPredictInfoDto>> GetProcessPredictInfo(string processInstanceId, bool isUserTaskOnly = false)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, processInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取流程实例【{processInstanceId}】预测信息");
                return Result.FromCode<ActionSoftProcessPredictInfoDto>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{processInstanceId}】权限");
            }

            var actionSoftExtensionWebApiService = ServiceProvider.GetRequiredService<IActionSoftExtensionWebApiService>();
            var sessionIdGetRequest = new ActionSoftSessionIdGetRequest
            {
                UserCode = MoBpmConsts.ActionSoftAdminUserCode,
                Ip = "127.0.0.1"
            };
            var sessionIdGetResponse = await actionSoftExtensionWebApiService.GetAccessToken(sessionIdGetRequest);
            if (!sessionIdGetResponse.IsOk)
            {
                var message = $"用户【{MoBpmConsts.ActionSoftAdminUserCode}】SessionId获取失败，【{sessionIdGetResponse.ErrorCode}】{sessionIdGetResponse.Message}";
                Logger.LogWarning(message);
                return Result.FromCode<ActionSoftProcessPredictInfoDto>(ResultCode.Fail, message);
            }

            var accessToken = sessionIdGetResponse.Data;
            var aslpCallRequest = new ActionSoftAslpCallRequest<ActionSoftProcessPredictParams>(ActionSoftAslpServiceAddresses.ProcessPredication)
            {
                Params = new ActionSoftProcessPredictParams
                {
                    ProcessInstanceId = processInstanceId,
                    SessionId = accessToken
                }
            };
            var aslpCallResponse = await actionSoftExtensionWebApiService.CallAslp(aslpCallRequest);
            aslpCallResponse = Regex.Unescape(aslpCallResponse).TrimStart('"').TrimEnd('"');
            var processPredictResponse = JsonConvert.DeserializeObject<ActionSoftWebApiResponse<ActionSoftProcessPredictInfo>>(aslpCallResponse);
            if (!processPredictResponse.IsOk)
            {
                var message = $"获取流程【{processInstanceId}】预测信息失败，【{processPredictResponse.ErrorCode}】{processPredictResponse.Message}";
                Logger.LogWarning(message);
                return Result.FromCode<ActionSoftProcessPredictInfoDto>(ResultCode.Fail, message);
            }

            var taskQueryResponse = await _actionSoftTaskWebApiService.QueryTask(new ActionSoftTaskQueryRequest
            {
                TaskQueryModel = new ActionSoftTaskQueryModel
                {
                    ProcessInstanceId = processInstanceId
                }
            });
            var processPredictInfoDto = new ActionSoftProcessPredictInfoDto
            {
                IsBapActive = processPredictResponse.Data.IsBapActive,
                PredictCompleteTime = processPredictResponse.Data.PredictCompleteTime,
                PredictCompleteProcess = processPredictResponse.Data.PredictCompleteProcess,
                PredictTasks = ObjectMapper.Map<List<ActionSoftTaskPredictInfo>, List<ActionSoftTaskPredictInfoDto>>(processPredictResponse.Data.PredictTasks)
            };
            var processInstanceVarGetRequest = new ActionSoftSpecifiedProcessIntanceVarGetRequest
            {
                ProcessInstanceId = processInstanceId,
                ProcessVarName = MoBpmConsts.ActionSoftCustomApprovers
            };
            var processInstanceVarGetResponse = await _actionSoftProcessWebApiService.GetSpecifiedProcessVar(processInstanceVarGetRequest);
            if (isUserTaskOnly)
                processPredictInfoDto.PredictTasks.RemoveAll(x => x.ActivityType != ActionSoftActivityType.UserTask);
            if (taskQueryResponse.IsOk && taskQueryResponse.Data.Any())
                processPredictInfoDto.CurrentActivityId = taskQueryResponse.Data.First().TaskDefinitionId;
            if (processInstanceVarGetResponse.IsOk && !string.IsNullOrWhiteSpace(processInstanceVarGetResponse.Data))
            {
                var customApprovers = JsonConvert.DeserializeObject<Dictionary<string, string>>(processInstanceVarGetResponse.Data);
                customApprovers.RemoveAll(x => string.IsNullOrWhiteSpace(x.Key) || string.IsNullOrWhiteSpace(x.Value)).ToList().ForEach(x =>
                 {
                     //只处理未审批且非当前节点预测
                     var activityApprovers = x.Value.Split(" ").ToList();
                     var currentTask = processPredictInfoDto.PredictTasks.Where(y => y.TaskDefinitionId == x.Key
                    && y.TaskDefinitionId != processPredictInfoDto.CurrentActivityId && !y.TaskCompleteTime.HasValue).FirstOrDefault();
                     if (currentTask != null && activityApprovers.Any())
                     {
                         var userNamesGetResponse = AsyncHelper.RunSync(() => ServiceProvider
                         .GetRequiredService<IActionSoftOrganizationWebApiService>().GetUserNames(new ActionSoftUserNamesGetByUserCodesRequest
                         {
                             UserCodes = activityApprovers,
                             Split = "/"
                         }));
                         if (userNamesGetResponse.IsOk)
                         {
                             currentTask.ClaimUserCode = string.Join("/", activityApprovers);
                             currentTask.ClaimUserName = userNamesGetResponse.Data;
                         }
                     }
                 });
            }

            return Result.FromData(processPredictInfoDto);
        }

        /// <inheritdoc/>
        public async Task<Result> CustomizeProcessApprovers(ActionSoftProcessApproverCustomizeInput processApproverCustomizeInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, processApproverCustomizeInput.ProcessInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权自定义流程实例【{processApproverCustomizeInput.ProcessInstanceId}】审批人");
                return Result.FromCode<string>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{processApproverCustomizeInput.ProcessInstanceId}】权限");
            }
            else
            {
                var formatedActivityApprovers = processApproverCustomizeInput.ActivityApprovers.ToDictionary(x => x.TaskDefinitionId, y => string.Join(" ", y.ApproverUserCodes));
                var specifiedProcessVarSetRequest = new ActionSoftSpecifiedProcessVarSetRequest
                {
                    ProcessVarName = MoBpmConsts.ActionSoftCustomApprovers,
                    ProcessInstanceId = processApproverCustomizeInput.ProcessInstanceId,
                    ProcessVarValue = JsonConvert.SerializeObject(formatedActivityApprovers)
                };
                var specifiedProcessVarSetResponse = await _actionSoftProcessWebApiService.SetSpecifiedProcessVar(specifiedProcessVarSetRequest);
                if (specifiedProcessVarSetResponse.IsOk)
                    return Result.Ok();
                else
                {
                    var errorMessage = $"【{specifiedProcessVarSetResponse.ErrorCode}】{specifiedProcessVarSetResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<string>> GetSpecifiedProcessVar(string processInstanceId, string processInstanceVarName)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, processInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取流程实例【{processInstanceId}】变量信息");
                return Result.FromCode<string>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{processInstanceId}】权限");
            }
            else
            {
                var specifiedProcessVarGetResponse = await _actionSoftProcessWebApiService.GetSpecifiedProcessVar(new ActionSoftSpecifiedProcessIntanceVarGetRequest
                {
                    ProcessInstanceId = processInstanceId,
                    ProcessVarName = processInstanceVarName
                });
                if (specifiedProcessVarGetResponse.IsOk)
                    return Result.FromData(specifiedProcessVarGetResponse.Data);
                else
                {
                    var errorMessage = $"【{specifiedProcessVarGetResponse.ErrorCode}】{specifiedProcessVarGetResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<string>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<Dictionary<string, string>>> GetAllProcessVar(string processInstanceId)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, processInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取流程实例【{processInstanceId}】变量信息");
                return Result.FromCode<Dictionary<string, string>>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{processInstanceId}】权限");
            }
            else
            {
                var allProcessVarGetResponse = await _actionSoftProcessWebApiService.GetAllProcessVar(new ActionSoftProcessVarsGetRequest
                {
                    ProcessInstanceId = processInstanceId
                });
                if (allProcessVarGetResponse.IsOk)
                    return Result.FromData(allProcessVarGetResponse.Data);
                else
                {
                    var errorMessage = $"【{allProcessVarGetResponse.ErrorCode}】{allProcessVarGetResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<Dictionary<string, string>>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> SetSpecifiedProcessVar(ActionSoftSpecifiedProcessVarSetInput actionSoftSpecifiedProcessVarSetInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, actionSoftSpecifiedProcessVarSetInput.ProcessInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权设置流程实例【{actionSoftSpecifiedProcessVarSetInput.ProcessInstanceId}】变量信息");
                return Result.FromCode<int>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{actionSoftSpecifiedProcessVarSetInput.ProcessInstanceId}】权限");
            }
            else
            {
                var specifiedProcessVarSetRequest = ObjectMapper
                    .Map<ActionSoftSpecifiedProcessVarSetInput, ActionSoftSpecifiedProcessVarSetRequest>(actionSoftSpecifiedProcessVarSetInput);
                var specifiedProcessVarSetResponse = await _actionSoftProcessWebApiService.SetSpecifiedProcessVar(specifiedProcessVarSetRequest);
                if (specifiedProcessVarSetResponse.IsOk)
                    return Result.Ok();
                else
                {
                    var errorMessage = $"【{specifiedProcessVarSetResponse.ErrorCode}】{specifiedProcessVarSetResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> BatchSetProcessVar(ActionSoftProcessVarBatchSetInput actionSoftProcessVarBatchSetInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, actionSoftProcessVarBatchSetInput.ProcessInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"【{clientId}】应用尝试越权设置【{actionSoftProcessVarBatchSetInput.ProcessInstanceId}】流程实例变量信息");
                return Result.FromCode(ResultCode.Forbidden, $"【{clientId}】应用无【{actionSoftProcessVarBatchSetInput.ProcessInstanceId}】流程实例权限");
            }
            else
            {
                var processVarBatchSetRequest = ObjectMapper
                    .Map<ActionSoftProcessVarBatchSetInput, ActionSoftProcessVarBatchSetRequest>(actionSoftProcessVarBatchSetInput);
                var processVarBatchSetResponse = await _actionSoftProcessWebApiService.BatchSetProcessVar(processVarBatchSetRequest);
                if (processVarBatchSetResponse.IsOk)
                    return Result.Ok();
                else
                {
                    var errorMessage = $"【{processVarBatchSetResponse.ErrorCode}】{processVarBatchSetResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftProcessDto>> GetProcessByCode(string processInstanceCode)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceCode(appId: clientId, processInstanceCode);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取流程实例【{processInstanceCode}】详细信息");
                return Result.FromCode<ActionSoftProcessDto>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{processInstanceCode}】权限");
            }
            else
            {
                var processQueryReponse = await _actionSoftProcessWebApiService
                    .QueryProcess(new ActionSoftProcessQueryRequest { ProcessQueryModel = new ActionSoftProcessQueryModel { ProcessInstanceCodes = { processInstanceCode } } });
                if (processQueryReponse.IsOk)
                {
                    var processInstance = processQueryReponse.Data.FirstOrDefault();
                    var processInstanceDto = processInstance is null ? null : ObjectMapper.Map<ActionSoftProcessInfo, ActionSoftProcessDto>(processInstance);
                    return Result.FromData(processInstanceDto);
                }
                else
                {
                    var errorMessage = $"【{processQueryReponse.ErrorCode}】{processQueryReponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<ActionSoftProcessDto>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<ActionSoftProcessDto>>> GetProcessByCodes(List<string> processInstanceCodes)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelongs = await ProcessInstanceBelongRepository
                .GetProcessInstanceBelongsByInstanceCodes(appId: clientId, processInstanceCodes) ?? new List<ProcessInstanceBelong>();
            var processInstanceCodesWithNoAuthority = processInstanceCodes.Except(processInstanceBelongs.Select(x => x.ProcessInstanceCode));
            if (processInstanceCodesWithNoAuthority.Any())
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取流程实例【{string.Join(",", processInstanceCodesWithNoAuthority)}】详细信息");
                return Result.FromCode<List<ActionSoftProcessDto>>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{string.Join(",", processInstanceCodesWithNoAuthority)}】权限");
            }
            else
            {
                var processQueryReponse = await _actionSoftProcessWebApiService
                .QueryProcess(new ActionSoftProcessQueryRequest { ProcessQueryModel = new ActionSoftProcessQueryModel { ProcessInstanceCodes = processInstanceCodes } });
                if (processQueryReponse.IsOk)
                {
                    var processInstanceDto = ObjectMapper.Map<List<ActionSoftProcessInfo>, List<ActionSoftProcessDto>>(processQueryReponse.Data);
                    return Result.FromData(processInstanceDto);
                }
                else
                {
                    var errorMessage = $"【{processQueryReponse.ErrorCode}】{processQueryReponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<List<ActionSoftProcessDto>>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftProcessDto>> GetProcessById(string processInstanceId)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, processInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取流程实例【{processInstanceId}】详细信息");
                return Result.FromCode<ActionSoftProcessDto>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{processInstanceId}】权限");
            }
            else
            {
                var processGetReponse = await _actionSoftProcessWebApiService
                    .GetProcess(new ActionSoftProcessGetRequest { ProcessInstanceId = processInstanceId });
                if (processGetReponse.IsOk)
                {
                    var processDto = ObjectMapper.Map<ActionSoftProcessInfo, ActionSoftProcessDto>(processGetReponse.Data);
                    return Result.FromData(processDto);
                }
                else
                {
                    var errorMessage = $"【{processGetReponse.ErrorCode}】{processGetReponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<ActionSoftProcessDto>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<ActionSoftProcessDto>>> GetProcessByIds(List<string> processInstanceIds)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelongs = await ProcessInstanceBelongRepository
                .GetProcessInstanceBelongsByInstanceIds(appId: clientId, processInstanceIds) ?? new List<ProcessInstanceBelong>();
            var processInstanceIdsWithNoAuthority = processInstanceIds.Except(processInstanceBelongs.Select(x => x.ProcessInstanceId));
            if (processInstanceIdsWithNoAuthority.Any())
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取流程实例【{string.Join(",", processInstanceIdsWithNoAuthority)}】详细信息");
                return Result.FromCode<List<ActionSoftProcessDto>>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{string.Join(",", processInstanceIdsWithNoAuthority)}】权限");
            }
            else
            {
                var processQueryReponse = await _actionSoftProcessWebApiService
                    .QueryProcess(new ActionSoftProcessQueryRequest { ProcessQueryModel = new ActionSoftProcessQueryModel { ProcessInstanceIds = processInstanceIds } });
                if (processQueryReponse.IsOk)
                {
                    var processInstanceDto = ObjectMapper.Map<List<ActionSoftProcessInfo>, List<ActionSoftProcessDto>>(processQueryReponse.Data);
                    return Result.FromData(processInstanceDto);
                }
                else
                {
                    var errorMessage = $"【{processQueryReponse.ErrorCode}】{processQueryReponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<List<ActionSoftProcessDto>>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<ActionSoftSimplifiedProcessDto>>> QueryProcess(ActionSoftProcessQueryInput actionSoftProcessQueryInput)
        {
            var processQueryModel = ObjectMapper.Map<ActionSoftProcessQueryInput, ActionSoftProcessQueryModel>(actionSoftProcessQueryInput);
            var processQueryRequest = new ActionSoftProcessQueryRequest { ProcessQueryModel = processQueryModel };
            var processQueryResponse = await _actionSoftProcessWebApiService.QueryProcess(processQueryRequest);
            if (processQueryResponse.IsOk)
            {
                var processInstanceDto = ObjectMapper.Map<List<ActionSoftProcessInfo>, List<ActionSoftSimplifiedProcessDto>>(processQueryResponse.Data);
                return Result.FromData(processInstanceDto);
            }
            else
            {
                var errorMessage = $"【{processQueryResponse.ErrorCode}】{processQueryResponse.Message}";
                Logger.LogError(errorMessage);
                return Result.FromError<List<ActionSoftSimplifiedProcessDto>>(errorMessage);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<ActionSoftSimplifiedProcessDto>>> PageQueryProcess(ActionSoftProcessPageQueryInput actionSoftProcessPageQueryInput)
        {
            var processPageQueryRequest = new ActionSoftProcessPageQueryRequest
            {
                Offset = actionSoftProcessPageQueryInput.Offset,
                Count = actionSoftProcessPageQueryInput.Count
            };
            processPageQueryRequest.ProcessQueryModel = ObjectMapper
                .Map<ActionSoftProcessPageQueryInput, ActionSoftProcessQueryModel>(actionSoftProcessPageQueryInput);
            var processPageQueryReapone = await _actionSoftProcessWebApiService.PageQueryProcess(processPageQueryRequest);
            if (processPageQueryReapone.IsOk)
            {
                var processInstanceDto = ObjectMapper.Map<List<ActionSoftProcessInfo>, List<ActionSoftSimplifiedProcessDto>>(processPageQueryReapone.Data);
                return Result.FromData(processInstanceDto);
            }
            else
            {
                var errorMessage = $"【{processPageQueryReapone.ErrorCode}】{processPageQueryReapone.Message}";
                Logger.LogError(errorMessage);
                return Result.FromError<List<ActionSoftSimplifiedProcessDto>>(errorMessage);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<int>> GetProcessCount(ActionSoftProcessCountGetInput actionSoftProcessCountGetInput)
        {
            var processQueryModel = ObjectMapper.Map<ActionSoftProcessCountGetInput, ActionSoftProcessQueryModel>(actionSoftProcessCountGetInput);
            var processCountGetRequest = new ActionSoftProcessCountGetRequest { ProcessQueryModel = processQueryModel };
            var processCountGetResponse = await _actionSoftProcessWebApiService.GetProcessCount(processCountGetRequest);
            if (processCountGetResponse.IsOk)
                return Result.FromData(processCountGetResponse.Data);
            else
            {
                var errorMessage = $"【{processCountGetResponse.ErrorCode}】{processCountGetResponse.Message}";
                Logger.LogError(errorMessage);
                return Result.FromError<int>(errorMessage);
            }
        }

        /// <summary>
        /// 获取流程审批留言s
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// 
        /// <returns></returns>
        public async Task<Result<List<ActionSoftTaskCommentInfoDto>>> GetProcessComments(string processInstanceId)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, processInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取流程实例【{processInstanceId}】审批留言信息");
                return Result.FromCode<List<ActionSoftTaskCommentInfoDto>>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{processInstanceId}】权限");
            }
            else
            {
                var processCommentsGetRequest = new ActionSoftProcessCommentsGetRequest { ProcessInstanceId = processInstanceId };
                var processCommnetsGetResponse = await _actionSoftProcessWebApiService.GetProcessComments(processCommentsGetRequest);
                if (processCommnetsGetResponse.IsOk)
                {
                    var taskComments = ObjectMapper.Map<List<ActionSoftTaskCommentInfo>, List<ActionSoftTaskCommentInfoDto>>(processCommnetsGetResponse.Data);
                    return Result.FromData(taskComments);
                }
                else
                {
                    var errorMessage = $"【{processCommnetsGetResponse.ErrorCode}】{processCommnetsGetResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<List<ActionSoftTaskCommentInfoDto>>(errorMessage);
                }
            }
        }
    }
}
