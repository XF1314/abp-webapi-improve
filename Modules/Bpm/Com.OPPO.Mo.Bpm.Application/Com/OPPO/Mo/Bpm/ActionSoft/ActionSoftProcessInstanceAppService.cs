using Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects;
using Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.ProcesseInstances;
using Com.OPPO.Mo.Bpm.ActionSoft.ProcesseInstances.Dtos;
using Com.OPPO.Mo.Bpm.ActionSoft.ProcesseInstances.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.ProcesseInstances.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using IActionSoftProcessInstanceAppService = Com.OPPO.Mo.Bpm.ActionSoft.ProcesseInstances.IActionSoftProcessInstanceAppService;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft流程实例应用服务
    /// </summary>
    [Authorize]
    public class ActionSoftProcessInstanceAppService : BpmAppServiceBase, IActionSoftProcessInstanceAppService
    {
        private readonly IActionSoftBusinessObjectWebApiService _actionSoftBusinessObjectWebApiService;
        private readonly IActionSoftProcessInstanceWebApiService _actionSoftProcessInstanceWebApiService;

        /// <summary>
        /// <see cref="ActionSoftProcessInstanceAppService"/>
        /// </summary>
        public ActionSoftProcessInstanceAppService(
            IActionSoftBusinessObjectWebApiService actionSoftBusinessObjectWebApiService,
            IActionSoftProcessInstanceWebApiService actionSoftProcessInstanceWebApiService)
        {
            _actionSoftBusinessObjectWebApiService = actionSoftBusinessObjectWebApiService;
            _actionSoftProcessInstanceWebApiService = actionSoftProcessInstanceWebApiService;
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftProcessInstanceCreateOutput>> CreateProcessInstance(ActionSoftProcessInstanceCreateInput actionsoftProcessInstanceCreateInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processLaunchGrant = await ProcessLaunchPermissionGrantRepository.GetProcessLaunchPermissionGrant(appId: clientId, actionsoftProcessInstanceCreateInput.ProcessDefinitionId);
            if (processLaunchGrant is null || !processLaunchGrant.IsValid)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权创建流程【{actionsoftProcessInstanceCreateInput.ProcessDefinitionId}】");
                return Result.FromCode<ActionSoftProcessInstanceCreateOutput>(ResultCode.Forbidden, $"应用【{clientId}】无流程【{actionsoftProcessInstanceCreateInput.ProcessDefinitionId}】创建权限");
            }
            else
            {
                var actionSoftProcessInstanceCreateRequest = ObjectMapper
                     .Map<ActionSoftProcessInstanceCreateInput, ActionSoftProcessInstanceCreateRequest>(actionsoftProcessInstanceCreateInput);
                var response = await _actionSoftProcessInstanceWebApiService.CreateProcessInstance(actionSoftProcessInstanceCreateRequest);
                if (!response.IsOk)
                {
                    var errorMessage = $"【{response.ErrorCode}】{response.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<ActionSoftProcessInstanceCreateOutput>(errorMessage);
                }
                else
                {
                    await ProcessInstanceBelongRepository.InsertAsync(new ProcessInstanceBelong
                    {
                        AppId = clientId,
                        ProcessInstanceId = response.Data.ProcessInstanceId,
                        ProcessInstanceCode = response.Data.ProcessInstanceCode,
                        ProcessInstanceTitle = response.Data.ProcessInstanceTitle
                    });

                    return Result.FromData(new ActionSoftProcessInstanceCreateOutput
                    {
                        ProcessInstanceId = response.Data.ProcessInstanceId,
                        ProcessInstanceCode = response.Data.ProcessInstanceCode,
                        ProcessInstanceTitle = response.Data.ProcessInstanceTitle
                    });
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> StartProcessInstance(string processInstanceId)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, processInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权启动流程实例【{processInstanceId}】");
                return Result.FromCode(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{processInstanceId}】权限");
            }
            else
            {
                var processInstanceStartResponse = await _actionSoftProcessInstanceWebApiService.StartProcessInstance(new ActionSoftProcessInstanceStartRequest { ProcessInstanceId = processInstanceId });
                if (processInstanceStartResponse.IsOk)
                    return Result.Ok();
                else
                {
                    var errorMessage = $"【{processInstanceStartResponse.ErrorCode}】{processInstanceStartResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftProcessInstanceCreateAndStartOutput>> CreateAndStartProcessInstance(ActionSoftProcessInstanceCreateAndStartInput actionSoftProcessInstanceCreateAndStartInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processLaunchGrant = await ProcessLaunchPermissionGrantRepository.GetProcessLaunchPermissionGrant(appId: clientId, actionSoftProcessInstanceCreateAndStartInput.ProcessDefinitionId);
            if (processLaunchGrant is null || !processLaunchGrant.IsValid)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权发起流程【{actionSoftProcessInstanceCreateAndStartInput.ProcessDefinitionId}】");
                return Result.FromCode<ActionSoftProcessInstanceCreateAndStartOutput>
                    (ResultCode.Forbidden, $"应用【{clientId}】无流程【{actionSoftProcessInstanceCreateAndStartInput.ProcessDefinitionId}】发起权限");
            }
            else
            {
                var actionSoftProcessInstanceCreateRequest = ObjectMapper
                    .Map<ActionSoftProcessInstanceCreateAndStartInput, ActionSoftProcessInstanceCreateRequest>(actionSoftProcessInstanceCreateAndStartInput);
                var processInstanceCreateResponse = await _actionSoftProcessInstanceWebApiService.CreateProcessInstance(actionSoftProcessInstanceCreateRequest);
                if (!processInstanceCreateResponse.IsOk)
                {
                    var errorMessage = $"【{processInstanceCreateResponse.ErrorCode}】{processInstanceCreateResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<ActionSoftProcessInstanceCreateAndStartOutput>(errorMessage);
                }
                else
                {
                    var boBatchCreateResponses = new Dictionary<string, ActionSoftWebApiResponse<List<string>>>();
                    if (actionSoftProcessInstanceCreateAndStartInput.BusinessObjects != null)
                    {
                        foreach (var businessObject in actionSoftProcessInstanceCreateAndStartInput.BusinessObjects)
                        {
                            if (!string.IsNullOrWhiteSpace(businessObject.Key) && businessObject.Value.Any())
                            {
                                var boBatchCreateResponse = await _actionSoftBusinessObjectWebApiService.BatchCreateBusinessObject(new ActionSoftBusinessObjectBatchCreateRequest
                                {
                                    BusinessObjectSetName = businessObject.Key,
                                    BusinessObjectFields = businessObject.Value,
                                    ProcessInstanceId = processInstanceCreateResponse.Data.ProcessInstanceId,
                                    CreatorUserCode = actionSoftProcessInstanceCreateAndStartInput.CreatorUserCode
                                });
                                boBatchCreateResponses.Add(businessObject.Key, boBatchCreateResponse);
                                if (!boBatchCreateResponse.IsOk) break;//任一Bo记录创建失败，停止后续创建
                            }
                        }

                        //创建Bo记录失败，则删除已创建成功的流程实例对象和Bo记录，并响应失败
                        if (boBatchCreateResponses.Values.Any(x => !x.IsOk))
                        {
                            await _actionSoftProcessInstanceWebApiService.DeleteProcessInstance(new ActionSoftProcessInstanceDeleteRequest
                            {
                                ProcessInstanceId = processInstanceCreateResponse.Data.ProcessInstanceId,
                                OperatorUserCode = actionSoftProcessInstanceCreateAndStartInput.CreatorUserCode
                            });
                            var boDeleteTasks = actionSoftProcessInstanceCreateAndStartInput.BusinessObjects
                                .Where(x => !string.IsNullOrWhiteSpace(x.Key) && x.Value.Any())
                                .Select(x => Task.Run(() => _actionSoftBusinessObjectWebApiService.DeleteBusinessObjectByProcessInstance(new ActionSoftBusinessObjectDeleteByProcessInstanceRequest
                                {
                                    ProcessInstanceId = processInstanceCreateResponse.Data.ProcessInstanceId,
                                    BusinessObjectSetName = x.Key
                                })));
                            Task.WaitAll(boDeleteTasks.ToArray());
                            var errorMessages = string.Join(Environment.NewLine, boBatchCreateResponses.Values.Where(y => !y.IsOk).Select(z => $"【{z.ErrorCode}】{z.Message}"));
                            Logger.LogError(errorMessages);
                            return Result.FromError<ActionSoftProcessInstanceCreateAndStartOutput>(errorMessages);
                        }
                    }

                    var processInstanceStartResponse = await _actionSoftProcessInstanceWebApiService
                        .StartProcessInstance(new ActionSoftProcessInstanceStartRequest { ProcessInstanceId = processInstanceCreateResponse.Data.ProcessInstanceId });
                    if (processInstanceStartResponse.IsOk)
                    {
                        //写入流程实例归属记录
                        await ProcessInstanceBelongRepository.InsertAsync(new ProcessInstanceBelong
                        {
                            AppId = clientId,
                            ProcessInstanceId = processInstanceCreateResponse.Data.ProcessInstanceId,
                            ProcessInstanceCode = processInstanceCreateResponse.Data.ProcessInstanceCode,
                            ProcessInstanceTitle = processInstanceCreateResponse.Data.ProcessInstanceTitle
                        });

                        //写入增业务对象归属记录
                        var boBlongsAddTasks = new List<Task<BusinessObjectBelong>>();
                        boBatchCreateResponses.ToList().ForEach(x =>
                        {
                            boBlongsAddTasks.AddRange(x.Value.Data.Select(y => BusinessObjectBelongRepository.InsertAsync(new BusinessObjectBelong
                            {
                                AppId = clientId,
                                BusinessObjectSetName = x.Key,
                                BusinessObjectId = y
                            })));
                        });
                        await boBlongsAddTasks.WhenAll();

                        return Result.FromData(new ActionSoftProcessInstanceCreateAndStartOutput
                        {
                            ProcessInstanceId = processInstanceCreateResponse.Data.ProcessInstanceId,
                            ProcessInstanceCode = processInstanceCreateResponse.Data.ProcessInstanceCode,
                            BusinessObjectIds = boBatchCreateResponses.ToDictionary(x => x.Key, y => y.Value.Data)
                        });
                    }
                    else//启动流程实例失败，则删除已创建成功的流程实例对象和Bo记录，并响应失败
                    {
                        await _actionSoftProcessInstanceWebApiService.DeleteProcessInstance(new ActionSoftProcessInstanceDeleteRequest
                        {
                            ProcessInstanceId = processInstanceCreateResponse.Data.ProcessInstanceId,
                            OperatorUserCode = actionSoftProcessInstanceCreateAndStartInput.CreatorUserCode
                        });
                        var actionSoftBoDeleteTasks = actionSoftProcessInstanceCreateAndStartInput.BusinessObjects
                            .Where(x => !string.IsNullOrWhiteSpace(x.Key) && x.Value.Any())
                            .Select(x => Task.Run(() => _actionSoftBusinessObjectWebApiService.DeleteBusinessObjectByProcessInstance(new ActionSoftBusinessObjectDeleteByProcessInstanceRequest
                            {
                                ProcessInstanceId = processInstanceCreateResponse.Data.ProcessInstanceId,
                                BusinessObjectSetName = x.Key
                            })));
                        Task.WaitAll(actionSoftBoDeleteTasks.ToArray());

                        var errorMessage = $"【{processInstanceCreateResponse.ErrorCode}】{processInstanceStartResponse.Message}";
                        Logger.LogError(errorMessage);
                        return Result.FromError<ActionSoftProcessInstanceCreateAndStartOutput>(errorMessage);
                    }
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> CancelProcessInstance(ActionSoftProcessInstanceCancelInput actionSoftProcessInstanceCancelInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, actionSoftProcessInstanceCancelInput.ProcessInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权撤回流程实例【{actionSoftProcessInstanceCancelInput.ProcessInstanceId}】");
                return Result.FromCode(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{actionSoftProcessInstanceCancelInput.ProcessInstanceId}】权限");
            }
            else
            {
                var processInstanceCancelResponse = await _actionSoftProcessInstanceWebApiService.CancelProcessInstance(new ActionSoftProcessInstanceCancelRequest
                {
                    ProcessInstanceId = actionSoftProcessInstanceCancelInput.ProcessInstanceId,
                    OperatorUserCode = actionSoftProcessInstanceCancelInput.OperatorUserCode
                });
                if (processInstanceCancelResponse.IsOk)
                    return Result.Ok();
                else
                {
                    var errorMessage = $"【{processInstanceCancelResponse.ErrorCode}】{processInstanceCancelResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> DeleteProcessInstance(ActionSoftProcessInstanceDeleteInput actionSoftProcessInstanceDeleteInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, actionSoftProcessInstanceDeleteInput.ProcessInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权删除流程实例【{actionSoftProcessInstanceDeleteInput.ProcessInstanceId}】");
                return Result.FromCode(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{actionSoftProcessInstanceDeleteInput.ProcessInstanceId}】权限");
            }
            else
            {
                var processInstanceDeleteResponse = await _actionSoftProcessInstanceWebApiService.DeleteProcessInstance(new ActionSoftProcessInstanceDeleteRequest
                {
                    ProcessInstanceId = actionSoftProcessInstanceDeleteInput.ProcessInstanceId,
                    OperatorUserCode = actionSoftProcessInstanceDeleteInput.OperatorUserCode
                });
                if (processInstanceDeleteResponse.IsOk)
                    return Result.Ok();
                else
                {
                    var errorMessage = $"【{processInstanceDeleteResponse.ErrorCode}】{processInstanceDeleteResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<string>> GetSpecifiedProcessInstanceVar(string processInstanceId, string processInstanceVarName)
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
                var specifiedProcessInstanceVarGetResponse = await _actionSoftProcessInstanceWebApiService.GetSpecifiedProcessInstanceVar(new ActionSoftSpecifiedProcessIntanceVarGetRequest
                {
                    ProcessInstanceId = processInstanceId,
                    ProcessVarName = processInstanceVarName
                });
                if (specifiedProcessInstanceVarGetResponse.IsOk)
                    return Result.FromData(specifiedProcessInstanceVarGetResponse.Data);
                else
                {
                    var errorMessage = $"【{specifiedProcessInstanceVarGetResponse.ErrorCode}】{specifiedProcessInstanceVarGetResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<string>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<Dictionary<string, string>>> GetAllProcessInstanceVar(string processInstanceId)
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
                var allProcessInstanceVarGetResponse = await _actionSoftProcessInstanceWebApiService.GetAllProcessInstanceVar(new ActionSoftProcessInstanceVarsGetRequest
                {
                    ProcessInstanceId = processInstanceId
                });
                if (allProcessInstanceVarGetResponse.IsOk)
                    return Result.FromData(allProcessInstanceVarGetResponse.Data);
                else
                {
                    var errorMessage = $"【{allProcessInstanceVarGetResponse.ErrorCode}】{allProcessInstanceVarGetResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<Dictionary<string, string>>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> SetSpecifiedProcessInstanceVar(ActionSoftSpecifiedProcessInstanceVarSetInput actionSoftSpecifiedProcessInstanceVarSetInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, actionSoftSpecifiedProcessInstanceVarSetInput.ProcessInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权设置流程实例【{actionSoftSpecifiedProcessInstanceVarSetInput.ProcessInstanceId}】变量信息");
                return Result.FromCode<int>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{actionSoftSpecifiedProcessInstanceVarSetInput.ProcessInstanceId}】权限");
            }
            else
            {
                var specifiedProcessInstanceVarSetRequest = ObjectMapper
                    .Map<ActionSoftSpecifiedProcessInstanceVarSetInput, ActionSoftSpecifiedProcessInstanceVarSetRequest>(actionSoftSpecifiedProcessInstanceVarSetInput);
                var specifiedProcessInstanceVarSetResponse = await _actionSoftProcessInstanceWebApiService.SetSpecifiedProcessInstanceVar(specifiedProcessInstanceVarSetRequest);
                if (specifiedProcessInstanceVarSetResponse.IsOk)
                    return Result.Ok();
                else
                {
                    var errorMessage = $"【{specifiedProcessInstanceVarSetResponse.ErrorCode}】{specifiedProcessInstanceVarSetResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> BatchSetProcessInstanceVar(ActionSoftProcessInstanceVarBatchSetInput actionSoftProcessInstanceVarBatchSetInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceId(appId: clientId, actionSoftProcessInstanceVarBatchSetInput.ProcessInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"【{clientId}】应用尝试越权设置【{actionSoftProcessInstanceVarBatchSetInput.ProcessInstanceId}】流程实例变量信息");
                return Result.FromCode(ResultCode.Forbidden, $"【{clientId}】应用无【{actionSoftProcessInstanceVarBatchSetInput.ProcessInstanceId}】流程实例权限");
            }
            else
            {
                var processInstanceVarBatchSetRequest = ObjectMapper
                    .Map<ActionSoftProcessInstanceVarBatchSetInput, ActionSoftProcessInstanceVarBatchSetRequest>(actionSoftProcessInstanceVarBatchSetInput);
                var processInstanceVarBatchSetResponse = await _actionSoftProcessInstanceWebApiService.BatchSetProcessInstanceVar(processInstanceVarBatchSetRequest);
                if (processInstanceVarBatchSetResponse.IsOk)
                    return Result.Ok();
                else
                {
                    var errorMessage = $"【{processInstanceVarBatchSetResponse.ErrorCode}】{processInstanceVarBatchSetResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftProcessInstanceDto>> GetProcessInstanceByCode(string processInstanceCode)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceCode(appId: clientId, processInstanceCode);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取流程实例【{processInstanceCode}】详细信息");
                return Result.FromCode<ActionSoftProcessInstanceDto>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{processInstanceCode}】权限");
            }
            else
            {
                var processInstanceQueryReponse = await _actionSoftProcessInstanceWebApiService
                    .QueryProcessInstance(new ActionSoftProcessInstanceQueryRequest { ProcessInstanceCodes = { processInstanceCode } });
                if (processInstanceQueryReponse.IsOk)
                {
                    var processInstance = processInstanceQueryReponse.Data.FirstOrDefault();
                    var processInstanceDto = processInstance is null ? null : ObjectMapper.Map<ActionSoftProcessInstanceInfo, ActionSoftProcessInstanceDto>(processInstance);
                    return Result.FromData(processInstanceDto);
                }
                else
                {
                    var errorMessage = $"【{processInstanceQueryReponse.ErrorCode}】{processInstanceQueryReponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<ActionSoftProcessInstanceDto>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<ActionSoftProcessInstanceDto>>> GetProcessInstanceByCodes(List<string> processInstanceCodes)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelongs = await ProcessInstanceBelongRepository
                .GetProcessInstanceBelongsByInstanceCodes(appId: clientId, processInstanceCodes) ?? new List<ProcessInstanceBelong>();
            var processInstanceCodesWithNoAuthority = processInstanceCodes.Except(processInstanceBelongs.Select(x => x.ProcessInstanceCode));
            if (processInstanceCodesWithNoAuthority.Any())
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取流程实例【{string.Join(",", processInstanceCodesWithNoAuthority)}】详细信息");
                return Result.FromCode<List<ActionSoftProcessInstanceDto>>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{string.Join(",", processInstanceCodesWithNoAuthority)}】权限");
            }
            else
            {
                var processInstanceQueryReponse = await _actionSoftProcessInstanceWebApiService
                .QueryProcessInstance(new ActionSoftProcessInstanceQueryRequest { ProcessInstanceCodes = processInstanceCodes });
                if (processInstanceQueryReponse.IsOk)
                {
                    var processInstanceDto = ObjectMapper.Map<List<ActionSoftProcessInstanceInfo>, List<ActionSoftProcessInstanceDto>>(processInstanceQueryReponse.Data);
                    return Result.FromData(processInstanceDto);
                }
                else
                {
                    var errorMessage = $"【{processInstanceQueryReponse.ErrorCode}】{processInstanceQueryReponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<List<ActionSoftProcessInstanceDto>>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftProcessInstanceDto>> GetProcessInstanceById(string processInstanceId)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetProcessInstanceBelongByInstanceCode(appId: clientId, processInstanceId);
            if (processInstanceBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取流程实例【{processInstanceId}】详细信息");
                return Result.FromCode<ActionSoftProcessInstanceDto>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{processInstanceId}】权限");
            }
            else
            {
                var processInstanceGetReponse = await _actionSoftProcessInstanceWebApiService
                    .GetProcessInstance(new ActionSoftProcessInstanceGetRequest { ProcessInstanceId = processInstanceId });
                if (processInstanceGetReponse.IsOk)
                {
                    var processInstanceDto = ObjectMapper.Map<ActionSoftProcessInstanceInfo, ActionSoftProcessInstanceDto>(processInstanceGetReponse.Data);
                    return Result.FromData(processInstanceDto);
                }
                else
                {
                    var errorMessage = $"【{processInstanceGetReponse.ErrorCode}】{processInstanceGetReponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<ActionSoftProcessInstanceDto>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<ActionSoftProcessInstanceDto>>> GetProcessInstanceByIds(List<string> processInstanceIds)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var processInstanceBelongs = await ProcessInstanceBelongRepository
                .GetProcessInstanceBelongsByInstanceIds(appId: clientId, processInstanceIds) ?? new List<ProcessInstanceBelong>();
            var processInstanceIdsWithNoAuthority = processInstanceIds.Except(processInstanceBelongs.Select(x => x.ProcessInstanceCode));
            if (processInstanceIdsWithNoAuthority.Any())
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取流程实例【{string.Join(",", processInstanceIdsWithNoAuthority)}】详细信息");
                return Result.FromCode<List<ActionSoftProcessInstanceDto>>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{string.Join(",", processInstanceIdsWithNoAuthority)}】权限");
            }
            else
            {
                var processInstanceQueryReponse = await _actionSoftProcessInstanceWebApiService
                    .QueryProcessInstance(new ActionSoftProcessInstanceQueryRequest { ProcessInstanceIds = processInstanceIds });
                if (processInstanceQueryReponse.IsOk)
                {
                    var processInstanceDto = ObjectMapper.Map<List<ActionSoftProcessInstanceInfo>, List<ActionSoftProcessInstanceDto>>(processInstanceQueryReponse.Data);
                    return Result.FromData(processInstanceDto);
                }
                else
                {
                    var errorMessage = $"【{processInstanceQueryReponse.ErrorCode}】{processInstanceQueryReponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<List<ActionSoftProcessInstanceDto>>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<ActionSoftSimplifiedProcessInstanceDto>>> QueryProcessInstance(ActionSoftProcessInstanceQueryInput actionSoftProcessInstanceQueryInput)
        {
            var processInstanceQueryRequest = ObjectMapper.Map<ActionSoftProcessInstanceQueryInput, ActionSoftProcessInstanceQueryRequest>(actionSoftProcessInstanceQueryInput);
            var processInstanceQueryReapone = await _actionSoftProcessInstanceWebApiService.QueryProcessInstance(processInstanceQueryRequest);
            if (processInstanceQueryReapone.IsOk)
            {
                var processInstanceDto = ObjectMapper.Map<List<ActionSoftProcessInstanceInfo>, List<ActionSoftSimplifiedProcessInstanceDto>>(processInstanceQueryReapone.Data);
                return Result.FromData(processInstanceDto);
            }
            else
            {
                var errorMessage = $"【{processInstanceQueryReapone.ErrorCode}】{processInstanceQueryReapone.Message}";
                Logger.LogError(errorMessage);
                return Result.FromError<List<ActionSoftSimplifiedProcessInstanceDto>>(errorMessage);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<ActionSoftSimplifiedProcessInstanceDto>>> PageQueryProcessInstance(ActionSoftProcessInstancePageQueryInput actionSoftProcessInstancePageQueryInput)
        {
            var processInstancePageQueryRequest = new ActionSoftProcessInstancePageQueryRequest
            {
                Offset = actionSoftProcessInstancePageQueryInput.Offset,
                Count = actionSoftProcessInstancePageQueryInput.Count
            };
            processInstancePageQueryRequest.ProcessInstanceInfoQueryModel = ObjectMapper
                .Map<ActionSoftProcessInstancePageQueryInput, ActionSoftProcessInstanceQueryModel>(actionSoftProcessInstancePageQueryInput);
            var processInstancePageQueryReapone = await _actionSoftProcessInstanceWebApiService.PageQueryProcessInstance(processInstancePageQueryRequest);
            if (processInstancePageQueryReapone.IsOk)
            {
                var processInstanceDto = ObjectMapper.Map<List<ActionSoftProcessInstanceInfo>, List<ActionSoftSimplifiedProcessInstanceDto>>(processInstancePageQueryReapone.Data);
                return Result.FromData(processInstanceDto);
            }
            else
            {
                var errorMessage = $"【{processInstancePageQueryReapone.ErrorCode}】{processInstancePageQueryReapone.Message}";
                Logger.LogError(errorMessage);
                return Result.FromError<List<ActionSoftSimplifiedProcessInstanceDto>>(errorMessage);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<int>> GetProcessInstanceCount(ActionSoftProcessInstanceCountGetInput actionSoftProcessInstanceCountGetInput)
        {
            var processInstanceCountGetRequest = ObjectMapper.Map<ActionSoftProcessInstanceCountGetInput, ActionSoftProcessInstanceCountGetRequest>(actionSoftProcessInstanceCountGetInput);
            var processInstanceCountGetReapone = await _actionSoftProcessInstanceWebApiService.GetProcessInstanceCount(processInstanceCountGetRequest);
            if (processInstanceCountGetReapone.IsOk)
                return Result.FromData(processInstanceCountGetReapone.Data);
            else
            {
                var errorMessage = $"【{processInstanceCountGetReapone.ErrorCode}】{processInstanceCountGetReapone.Message}";
                Logger.LogError(errorMessage);
                return Result.FromError<int>(errorMessage);
            }
        }
    }
}
