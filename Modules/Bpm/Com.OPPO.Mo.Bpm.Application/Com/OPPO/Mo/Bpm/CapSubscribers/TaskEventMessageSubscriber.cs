using Com.OPPO.Mo.Bpm.Etos;
using Com.OPPO.Mo.Bpm.Repositories;
using DotNetCore.CAP;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.EventBus.Local;

namespace Com.OPPO.Mo.Bpm.CapSubscribers
{
    /// <summary>
    /// 任务事件消息订阅者
    /// </summary>
    public class TaskEventMessageSubscriber : ICapSubscribe, ITransientDependency
    {
        private readonly ICapPublisher _capPublisher;
        private readonly ILocalEventBus _localEventBus;
        private readonly ILogger<TaskEventMessageSubscriber> _logger;
        private readonly ITaskEventMessageRepository _taskEventMessageRepository;
        private readonly IBpmCallbackWebApiService _bpmCallbackWebApiService;
        private readonly ITaskCallbackConfigurationRepository _taskCallbackConfigurationRepository;

        /// <summary>
        /// <see cref="TaskEventMessageSubscriber"/>
        /// </summary>
        public TaskEventMessageSubscriber(
            ICapPublisher capPublisher,
            ILocalEventBus localEventBus,
            ILogger<TaskEventMessageSubscriber> logger,
            ITaskEventMessageRepository taskEventMessageRepository,
            IBpmCallbackWebApiService bpmCallbackWebApiService,
            ITaskCallbackConfigurationRepository taskCallbackConfigurationRepository)
        {
            _logger = logger;
            _capPublisher = capPublisher;
            _localEventBus = localEventBus;
            _taskEventMessageRepository = taskEventMessageRepository;
            _bpmCallbackWebApiService = bpmCallbackWebApiService;
            _taskCallbackConfigurationRepository = taskCallbackConfigurationRepository;
        }

        /// <summary>
        /// 任务回调
        /// </summary>
        /// <param name="taskEventMessageEto"><see cref="TaskEventMessageEto"/></param>
        /// <returns></returns>
        [CapSubscribe(MoBpmConsts.TaskEventMessageTopic, Group = "bpm.service.task.callback")]
        public async Task TaskCallback(TaskEventMessageEto taskEventMessageEto)
        {
            var taskEventMessage = await _taskEventMessageRepository.GetAsync(Guid.Parse(taskEventMessageEto.Id));
            if (taskEventMessage is null)
                _logger.LogError($"无对应任务事件消息【{taskEventMessageEto.Id}】");
            else
            {
                var taskCallbackConfigurations = await _taskCallbackConfigurationRepository.GetQueryable()
                     .Where(x => x.Action == taskEventMessage.Action
                     && x.ProcessDefinitionId == taskEventMessage.ProcessDefinition.ProcessDefinitionId
                     && x.TaskDefinitionId == taskEventMessage.TaskDefinition.TaskDefinitionId
                     && x.TaskEventName == taskEventMessage.TaskEventName
                     && x.IsValid)
                     .ToDynamicListAsync<TaskCallbackConfiguration>();

                if (taskCallbackConfigurations is null || !taskCallbackConfigurations.Any())
                    _logger.LogInformation($"任务实例【{taskEventMessageEto.Id}】：\r\n系统中无流程【{ taskEventMessage.ProcessDefinition.ProcessDefinitionId}】，" +
                    $"节点【{taskEventMessage.TaskDefinition.TaskDefinitionId}】，事件【{taskEventMessage.TaskEventName}】对应的有效回调配置");
                else
                {
                    var taskEtoJsonString = JsonConvert.SerializeObject(taskEventMessage);
                    var formatedTaskEventMessageItems = JsonValueParser.Parse(taskEtoJsonString);
                    var taskCallbackEventPublishTasks = taskCallbackConfigurations.Select(x =>
                   {
                       var @params = new Dictionary<string, string> { { "cipher", x.Cipher } };
                       x.ParamsPaths.ForEach(y =>
                       {
                           if (formatedTaskEventMessageItems.ContainsKey(y))
                               @params.Add(y, formatedTaskEventMessageItems[y]);
                       });
                       return _capPublisher.PublishAsync(MoBpmConsts.TaskCallbackEventTopic, new TaskCallbackEto
                       {
                           TaskEventMessageId = taskEventMessageEto.Id,
                           SuccessAssertions = x.SuccessAssertions,
                           IsNeedPaasToken = x.IsNeedPaasToken,
                           CallbackUrl = x.CallbackUrl,
                           Headers = x.Headers,
                           Params = @params
                       });
                   }).ToList();

                    await Task.WhenAll(taskCallbackEventPublishTasks);
                }
            }
        }

        /// <summary>
        /// 流程实例上报
        /// </summary>
        /// <param name="taskEventMessageEto"><see cref="TaskEventMessageEto"/></param>
        /// <returns></returns>
        [CapSubscribe(MoBpmConsts.ProcessEventMessageTopic, Group = "bpm.service.process.instance.upload")]
        public async Task ProcessInstanceUpload(TaskEventMessageEto taskEventMessageEto)
        {
            _logger.LogWarning("流程上报", taskEventMessageEto);

            await Task.CompletedTask;
        }

    }
}
