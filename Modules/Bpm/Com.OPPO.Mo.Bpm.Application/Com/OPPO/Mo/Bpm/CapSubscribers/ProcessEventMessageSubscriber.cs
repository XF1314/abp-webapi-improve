using Com.OPPO.Mo.Bpm.Etos;
using Com.OPPO.Mo.Bpm.Repositories;
using DotNetCore.CAP;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Local;
using System.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Com.OPPO.Mo.Bpm.CapSubscribers
{
    /// <summary>
    /// 流程事件消息订阅者
    /// </summary>
    public class ProcessEventMessageSubscriber : ICapSubscribe, ITransientDependency
    {
        private readonly ICapPublisher _capPublisher;
        private readonly ILocalEventBus _localEventBus;
        private readonly ILogger<ProcessEventMessageSubscriber> _logger;
        private readonly IProcessEventMessageRepository _processEventMessageRepository;
        private readonly IBpmCallbackWebApiService _bpmCallbackWebApiService;
        private readonly IProcessCallbackConfigurationRepository _processCallbackConfigurationRepository;

        /// <summary>
        /// <see cref="ProcessEventMessageSubscriber"/>
        /// </summary>
        public ProcessEventMessageSubscriber(
            ICapPublisher capPublisher,
            ILocalEventBus localEventBus,
            ILogger<ProcessEventMessageSubscriber> logger,
            IProcessEventMessageRepository processEventMessageRepository,
            IBpmCallbackWebApiService bpmCallbackWebApiService,
            IProcessCallbackConfigurationRepository processCallbackConfigurationRepository)
        {
            _logger = logger;
            _capPublisher = capPublisher;
            _localEventBus = localEventBus;
            _processEventMessageRepository = processEventMessageRepository;
            _bpmCallbackWebApiService = bpmCallbackWebApiService;
            _processCallbackConfigurationRepository = processCallbackConfigurationRepository;
        }

        /// <summary>
        /// 流程回调
        /// </summary>
        /// <param name="processEventMessageEto"><see cref="ProcessEventMessageEto"/></param>
        /// <returns></returns>
        [CapSubscribe(MoBpmConsts.ProcessEventMessageTopic, Group = "bpm.service.process.callback")]
        public async Task ProcessCallback(ProcessEventMessageEto processEventMessageEto)
        {
            var processEventMessage = await _processEventMessageRepository.GetAsync(Guid.Parse(processEventMessageEto.Id));
            if (processEventMessage is null)
                _logger.LogError($"无对应流程事件消息【{processEventMessageEto.Id}】");
            else
            {
                var processCallbackConfigurations = await _processCallbackConfigurationRepository.GetQueryable()
                    .Where(x => x.ProcessDefinitionId == processEventMessage.ProcessDefinition.ProcessDefinitionId
                    && x.ProcessEventName == processEventMessage.ProcessEventName
                    && x.IsValid)
                    .ToDynamicListAsync<ProcessCallbackConfiguration>();
                if (processCallbackConfigurations is null || !processCallbackConfigurations.Any())
                    _logger.LogInformation($"流程实例【{processEventMessageEto.Id}】：\r\n系统中无流程【{ processEventMessage.ProcessDefinition.ProcessDefinitionId}】，事件【{processEventMessage.ProcessEventName}】对应的有效回调配置");
                else
                {
                    var processEtoJsonString = JsonConvert.SerializeObject(processEventMessage);
                    var formatedProcessEventMessageItems = JsonValueParser.Parse(processEtoJsonString);
                    var processCallbackEventPublishTasks = processCallbackConfigurations.Select(x =>
                    {
                        var @params = new Dictionary<string, string> { { "cipher", x.Cipher } };
                        x.ParamsPaths.ForEach(y =>
                        {
                            if (formatedProcessEventMessageItems.ContainsKey(y))
                                @params.Add(y, formatedProcessEventMessageItems[y]);
                        });
                        return _capPublisher.PublishAsync(MoBpmConsts.ProcessCallbackEventTopic, new ProcessCallbackEto
                        {
                            ProcessEventMessageId = processEventMessageEto.Id,
                            SuccessAssertions = x.SuccessAssertions,
                            IsNeedPaasToken = x.IsNeedPaasToken,
                            CallbackUrl = x.CallbackUrl,
                            Headers = x.Headers,
                            Params = @params
                        });
                    }).ToList();

                    await Task.WhenAll(processCallbackEventPublishTasks);
                }
            }
        }

        /// <summary>
        /// 流程实例上报
        /// </summary>
        /// <param name="processEventMessageEto"><see cref="ProcessEventMessageEto"/></param>
        /// <returns></returns>
        [CapSubscribe(MoBpmConsts.ProcessEventMessageTopic, Group = "bpm.service.process.instance.upload")]
        public async Task ProcessInstanceUpload(ProcessEventMessageEto processEventMessageEto)
        {
            _logger.LogWarning("流程上报", processEventMessageEto);

            await Task.CompletedTask;
        }

    }
}
