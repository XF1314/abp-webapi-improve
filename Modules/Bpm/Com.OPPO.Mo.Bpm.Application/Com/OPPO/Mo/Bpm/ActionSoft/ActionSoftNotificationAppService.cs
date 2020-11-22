using Com.OPPO.Mo.Bpm.ActionSoft;
using Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects;
using Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.Notifications;
using Com.OPPO.Mo.Bpm.ActionSoft.Notifications.Dtos;
using Com.OPPO.Mo.Bpm.ActionSoft.Notifications.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests;
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
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// ActionSoft消息通知应用服务
    /// </summary>
    [Authorize]
    public class ActionSoftNotificationAppService : BpmAppServiceBase, IActionSoftNotificationAppService
    {
        private readonly IActionSoftBusinessObjectWebApiService _actionSoftBusinessObjectWebApiService;
        private readonly IActionSoftNotificationWebApiService _actionSoftNotificationWebApiService;
        private readonly IActionSoftProcessWebApiService _actionSoftProcessWebApiService;
        private readonly IActionSoftTaskWebApiService _actionSoftTaskWebApiService;

        /// <summary>
        /// <see cref="ActionSoftNotificationAppService"/>
        /// </summary>
        public ActionSoftNotificationAppService(IActionSoftNotificationWebApiService actionSoftNotificationWebApiService,
            IActionSoftBusinessObjectWebApiService actionSoftBusinessObjectWebApiService,
            IActionSoftProcessWebApiService actionSoftProcessWebApiService,
            IActionSoftTaskWebApiService actionSoftTaskWebApiService)
        {
            _actionSoftTaskWebApiService = actionSoftTaskWebApiService;
            _actionSoftProcessWebApiService = actionSoftProcessWebApiService;
            _actionSoftNotificationWebApiService = actionSoftNotificationWebApiService;
            _actionSoftBusinessObjectWebApiService = actionSoftBusinessObjectWebApiService;
        }

        /// <inheritdoc/>
        public async Task<Result> SystemMessageEnableCheck()
        {
            var request = new BaseActionSoftWebApiRequest(ActionSoftNotificationCommands.CheckSystemMessageEnabled);
            var response = await _actionSoftNotificationWebApiService.SystemMessageEnableCheck(request);
            if (response.IsOk)
                return Result.FromData(true);
            else
            {
                return Result.FromError(response.Message);
            }
        }

        /// <inheritdoc/>
        public async Task<Result> SendSystemMessage(ActionSoftSystemMessageSendInput systemMessageSendInput)
        {
            if (systemMessageSendInput.To == null || !systemMessageSendInput.To.Any())
                return Result.FromError("消息接收人帐号不能为空。");
            else if (string.IsNullOrWhiteSpace(systemMessageSendInput.Content))
                return Result.FromError("消息内容不能为空。");
            else
            {
                var request = new ActionSoftSystemMessageSendWebApiRequest
                {
                    To = systemMessageSendInput.To,
                    Content = systemMessageSendInput.Content,
                    IsToMobile = systemMessageSendInput.IsToMobile,
                    MessageLevel = systemMessageSendInput.MessageLevel
                };
                var response = await _actionSoftNotificationWebApiService.SendSystemMessage(request);
                if (response.IsOk)
                    return Result.FromData(true);
                else
                {
                    return Result.FromError(response.Message);
                }
            }

        }

        /// <inheritdoc/>
        public async Task<Result<List<ActionSoftTaskDto>>> CreateCirculation(ActionSoftCirculationCreateInput circulationCreateInput)
        {
            if (!circulationCreateInput.ClaimUserCodes.Any())
                return Result.FromError<List<ActionSoftTaskDto>>("参数claimUserCodes不能为空");

            circulationCreateInput.ClaimUserCodes.RemoveAll(x => string.IsNullOrWhiteSpace(x));
            circulationCreateInput.ClaimUserCodes = circulationCreateInput.ClaimUserCodes.Distinct().ToList();
            var maxCirculationCount = int.Parse(Configuration["oppo-mo-bpm-service-max-circulation-count"]);
            if (circulationCreateInput.ClaimUserCodes.Count > maxCirculationCount)
                return Result.FromError<List<ActionSoftTaskDto>>($"单次最大传阅人次不能超过{maxCirculationCount}");

            var processCreateAndStartInput = new ActionSoftProcessCreateAndStartInput
            {
                ProcessDefinitionId = MoBpmConsts.CirculationProcessDefinitionId,
                ProcessTitle = circulationCreateInput.Title,
                CreatorUserCode = MoBpmConsts.ActionSoftAdminUserCode,
                BusinessObjects = new Dictionary<string, List<Dictionary<string, string>>>
                {
                    { MoBpmConsts.CirculationBusinessObjectTableName,new List<Dictionary<string, string>>{
                        new Dictionary<string, string>{
                            {MoBpmConsts.CirculationBusinessObjectPcLinkFieldName,circulationCreateInput.PcLink },
                            {MoBpmConsts.CirculationBusinessObjectMobileLinkFieldName,circulationCreateInput.MobileLink }
                        }
                    } }
                },
            };
            var processCreateAndStartResult = await CreateAndStartProcessInternal(processCreateAndStartInput);
            if (!processCreateAndStartResult.IsSuccess)
                return Result.FromError<List<ActionSoftTaskDto>>(processCreateAndStartResult.Msg);

            var processSubmitResult = await SubmitProcessInternal(processCreateAndStartResult.Data.StartTaskInstanceId, MoBpmConsts.ActionSoftAdminUserCode);
            if (!processSubmitResult.IsSuccess)
                return Result.FromError<List<ActionSoftTaskDto>>(processSubmitResult.Msg);

            var circulationTaskCreateInput = new ActionSoftCirculationTaskCreateInput
            {
                ProcessInstanceId = processCreateAndStartResult.Data.ProcessInstanceId,
                ParentTaskInstanceId = processCreateAndStartResult.Data.StartTaskInstanceId,
                TaskTitle = circulationCreateInput.Title,
                ClaimUserCodes = circulationCreateInput.ClaimUserCodes,
                OperatorUserCode = circulationCreateInput.OperatorUserCode
            };
            var circulationTaskCreateResult = await CreateCirculationTaskInternal(circulationTaskCreateInput);

            return circulationTaskCreateResult;
        }

        private async Task<Result<ActionSoftProcessCreateAndStartOutput>> CreateAndStartProcessInternal(ActionSoftProcessCreateAndStartInput actionSoftProcessCreateAndStartInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
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

        public async Task<Result<ActionSoftTaskExecuteResultDto>> SubmitProcessInternal(string taskInstanceId, string operatorUserCode)
        {
            var taskRecordCommitRequest = new ActionSoftTaskRecordCommitRequest
            {
                TaskInstanceId = taskInstanceId,
                OperatorUserCode = operatorUserCode,
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

            var taskCompleteRequest = new ActionSoftTaskCompleteRequest
            {
                TaskInstanceId = taskInstanceId,
                OperatorUserCode = operatorUserCode
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

        /// <inheritdoc/>
        private async Task<Result<List<ActionSoftTaskDto>>> CreateCirculationTaskInternal(ActionSoftCirculationTaskCreateInput actionSoftCirculationTaskCreateInput)
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
}
