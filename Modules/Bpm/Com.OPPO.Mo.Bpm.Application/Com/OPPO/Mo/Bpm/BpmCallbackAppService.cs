using Com.OPPO.Mo.Bpm.Dtos;
using Com.OPPO.Mo.Bpm.Etos;
using Com.OPPO.Mo.Bpm.Repositories;
using Com.OPPO.Mo.Thirdparty.Paas;
using Com.OPPO.Mo.Thirdparty.Paas.Requests;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Bpm回调应用服务
    /// </summary>
    [Authorize]
    public class BpmCallbackAppService : BpmAppServiceBase, IBpmCallbackAppService
    {
        private readonly ICapPublisher _capPublisher;
        private readonly IConfiguration _configuration;
        private readonly IBpmCallbackWebApiService _bpmCallbackWebApiService;
        private readonly ITaskEventMessageRepository _taskEventMessageRepository;
        private readonly IProcessEventMessageRepository _processEventMessageRepository;
        private readonly IPaasAuthenticationWebApiService _paasAuthenticationWebApiService;
        private readonly ITaskCallbackConfigurationRepository _taskCallbackConfigurationRepository;
        private readonly IProcessCallbackConfigurationRepository _processCallbackConfigurationRepository;

        public BpmCallbackAppService(
            ICapPublisher capPublisher,
            IConfiguration configuration,
            IBpmCallbackWebApiService bpmCallbackWebApiService,
            ITaskEventMessageRepository taskEventMessageRepository,
            IProcessEventMessageRepository processEventMessageRepository,
            IPaasAuthenticationWebApiService paasAuthenticationWebApiService,
            ITaskCallbackConfigurationRepository taskCallbackConfigurationRepository,
            IProcessCallbackConfigurationRepository processCallbackConfigurationRepository)
        {
            _capPublisher = capPublisher;
            _configuration = configuration;
            _bpmCallbackWebApiService = bpmCallbackWebApiService;
            _taskEventMessageRepository = taskEventMessageRepository;
            _processEventMessageRepository = processEventMessageRepository;
            _paasAuthenticationWebApiService = paasAuthenticationWebApiService;
            _taskCallbackConfigurationRepository = taskCallbackConfigurationRepository;
            _processCallbackConfigurationRepository = processCallbackConfigurationRepository;
        }

        /// <inheritdoc/>
        public async Task<Result> TriggerTaskCallback(string taskEventMessageId)
        {
            var taskEventMessage = await _taskEventMessageRepository.GetAsync(Guid.Parse(taskEventMessageId));
            if (taskEventMessage is null)
                return Result.FromError($"无对应任务事件消息【{taskEventMessageId}】");
            else
            {
                var taskEventMessageJsonString = JsonConvert.SerializeObject(taskEventMessage);
                var formatedProcessEventMessageItems = JsonValueParser.Parse(taskEventMessageJsonString);
                var taskCallbackConfigurations = await _taskCallbackConfigurationRepository.GetQueryable()
                    .Where(x => x.ProcessDefinitionId == taskEventMessage.ProcessDefinition.ProcessDefinitionId
                    && x.TaskDefinitionId == taskEventMessage.TaskDefinition.TaskDefinitionId
                    && x.TaskEventName == taskEventMessage.TaskEventName
                    && x.Action == taskEventMessage.Action
                    && x.IsValid)
                    .ToDynamicListAsync<TaskCallbackConfiguration>();
                if (taskCallbackConfigurations is null || !taskCallbackConfigurations.Any())
                    return Result.FromError($"系统中无流程【{ taskEventMessage.ProcessDefinition.ProcessDefinitionId}】，" +
                    $"节点【{taskEventMessage.TaskDefinition.TaskDefinitionId}】，事件【{taskEventMessage.TaskEventName}】,审批动作【{taskEventMessage.Action}】对应的有效回调配置");
                else
                {
                    var crateProcessCallbackTasks = taskCallbackConfigurations.Select(x =>
                    {
                        var @params = new Dictionary<string, string> { { "cipher", x.Cipher } };
                        x.ParamsPaths.ForEach(y =>
                        {
                            if (formatedProcessEventMessageItems.ContainsKey(y))
                                @params.Add(y, formatedProcessEventMessageItems[y]);
                        });

                        return _capPublisher.PublishAsync(MoBpmConsts.TaskCallbackEventTopic, new TaskCallbackEto
                        {
                            TaskEventMessageId = taskEventMessageId,
                            SuccessAssertions = x.SuccessAssertions,
                            IsNeedPaasToken = x.IsNeedPaasToken,
                            CallbackUrl = x.CallbackUrl,
                            Headers = x.Headers,
                            Params = @params
                        });

                    }).ToList();

                    await Task.WhenAll(crateProcessCallbackTasks);

                    return Result.Ok();
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> TriggerProcessCallback(string processEventMessageId)
        {
            var processEventMessage = await _processEventMessageRepository.GetAsync(Guid.Parse(processEventMessageId));
            if (processEventMessage is null)
                return Result.FromError($"无对应流程事件消息【{processEventMessageId}】");
            else
            {
                var processEventMessageJsonString = JsonConvert.SerializeObject(processEventMessage);
                var formatedProcessEventMessageItems = JsonValueParser.Parse(processEventMessageJsonString);
                var processCallbackConfigurations = await _processCallbackConfigurationRepository.GetQueryable()
                    .Where(x => x.ProcessDefinitionId == processEventMessage.ProcessDefinition.ProcessDefinitionId
                    && x.ProcessEventName == processEventMessage.ProcessEventName
                    && x.IsValid)
                    .ToDynamicListAsync<ProcessCallbackConfiguration>();
                if (processCallbackConfigurations is null || !processCallbackConfigurations.Any())
                    return Result.FromError($"系统中无流程【{ processEventMessage.ProcessDefinition.ProcessDefinitionId}】，事件【{processEventMessage.ProcessEventName}】对应的有效回调配置");
                else
                {
                    var createProcessCallbackTasks = processCallbackConfigurations.Select(x =>
                    {
                        var @params = new Dictionary<string, string> { { "cipher", x.Cipher } };
                        x.ParamsPaths.ForEach(y =>
                        {
                            if (formatedProcessEventMessageItems.ContainsKey(y))
                                @params.Add(y, formatedProcessEventMessageItems[y]);
                        });

                        return _capPublisher.PublishAsync(MoBpmConsts.ProcessCallbackEventTopic, new ProcessCallbackEto
                        {
                            ProcessEventMessageId = processEventMessageId,
                            SuccessAssertions = x.SuccessAssertions,
                            CallbackUrl = x.CallbackUrl,
                            IsNeedPaasToken = x.IsNeedPaasToken,
                            Headers = x.Headers,
                            Params = @params
                        });
                    }).ToList();

                    await Task.WhenAll(createProcessCallbackTasks);

                    return Result.Ok();
                }
            }
        }


        /// <inheritdoc/>
        public async Task<Result<string>> TaskCallback(TaskEventCallbackInput taskEventCallbackInput)
        {
            if (taskEventCallbackInput.IsNeedPaasToken)
            {
                var paasAccessTokenGetResult = await GetPaasAccessToken();
                if (!paasAccessTokenGetResult.IsSuccess)
                    Logger.LogError(paasAccessTokenGetResult.Msg);
                else
                {
                    taskEventCallbackInput.Headers.Add(PaasSettingNames.PaasAuthAppHeaderName, _configuration[PaasSettingNames.PaasAppId]);
                    taskEventCallbackInput.Headers.Add(PaasSettingNames.PaasAuthTokenHeaderName, paasAccessTokenGetResult.Data);
                }
            }

            var callbackResponse = await _bpmCallbackWebApiService.Callback(taskEventCallbackInput.CallbackUrl, taskEventCallbackInput.Headers, taskEventCallbackInput.Params);
            if (taskEventCallbackInput.SuccessAssertions != null && taskEventCallbackInput.SuccessAssertions.Any())
            {
                var matchString = callbackResponse.Replace(" ", "");
                var mathcResults = taskEventCallbackInput.SuccessAssertions.Select(x => Regex.Match(matchString, x, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture));
                if (mathcResults.Any(y => !y.Success))
                    throw new Exception($"{taskEventCallbackInput.TaskEventMessageId}\r\n{callbackResponse}");
            }

            Trace.WriteLine($"已完成对任务事件消息【{taskEventCallbackInput.TaskEventMessageId}】=>【{taskEventCallbackInput.CallbackUrl}】的回调");
            Logger.LogInformation($"已完成对任务事件消息【{taskEventCallbackInput.TaskEventMessageId}】=>【{taskEventCallbackInput.CallbackUrl}】的回调");

            return Result.FromData(callbackResponse);
        }

        /// <inheritdoc/>
        public async Task<Result<string>> ProcessCallback(ProcessEventCallbackInput processEventCallbackInput)
        {
            if (processEventCallbackInput.IsNeedPaasToken)
            {
                var paasAccessTokenGetResult = await GetPaasAccessToken();
                if (!paasAccessTokenGetResult.IsSuccess)
                    Logger.LogError(paasAccessTokenGetResult.Msg);
                else
                {
                    processEventCallbackInput.Headers.Add(PaasSettingNames.PaasAuthAppHeaderName, _configuration[PaasSettingNames.PaasAppId]);
                    processEventCallbackInput.Headers.Add(PaasSettingNames.PaasAuthTokenHeaderName, paasAccessTokenGetResult.Data);
                }
            }

            var callbackResponse = await _bpmCallbackWebApiService.Callback(processEventCallbackInput.CallbackUrl, processEventCallbackInput.Headers, processEventCallbackInput.Params);
            if (processEventCallbackInput.SuccessAssertions != null && processEventCallbackInput.SuccessAssertions.Any())
            {
                var matchString = callbackResponse.Replace(" ", "");
                var mathcResults = processEventCallbackInput.SuccessAssertions.Select(x => Regex.Match(matchString, x, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture));
                if (mathcResults.Any(y => !y.Success))
                    throw new Exception($"{processEventCallbackInput.ProcessEventMessageId}\r\n{callbackResponse}");
            }

            Trace.WriteLine($"已完成对流程事件消息【{processEventCallbackInput.ProcessEventMessageId}】=>【{processEventCallbackInput.CallbackUrl}】的回调");
            Logger.LogInformation($"已完成对流程事件消息【{processEventCallbackInput.ProcessEventMessageId}】=>【{processEventCallbackInput.CallbackUrl}】的回调");

            return Result.FromData(callbackResponse);
        }

        private async Task<Result<string>> GetPaasAccessToken()
        {
            var paasAppLoginRequest = new PaasAppLoginRequest
            {
                AppTag = _configuration[PaasSettingNames.PaasAppTag],
                AppEncrptedSecret = _configuration[PaasSettingNames.PaasAppSecret]
            };
            var loginResponse = await _paasAuthenticationWebApiService.AppLogin(paasAppLoginRequest, _configuration[PaasSettingNames.PaasTenantId]);
            if (loginResponse.IsOk)
                return Result.FromData(loginResponse.Payload.AccessToken);
            else
            {
                return Result.FromError<string>(loginResponse.Message);
            }
        }
    }
}
