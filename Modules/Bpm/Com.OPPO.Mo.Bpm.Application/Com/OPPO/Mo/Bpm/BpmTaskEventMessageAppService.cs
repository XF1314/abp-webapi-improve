using Com.OPPO.Mo.Bpm.Dtos;
using Com.OPPO.Mo.Bpm.Repositories;
using Com.OPPO.Mo.Queriable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using DotNetCore.CAP;
using Volo.Abp.Uow;
using Com.OPPO.Mo.Bpm.Etos;
using Volo.Abp.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Bpm流程事件消息应用服务
    /// </summary>
    [Authorize]
    public class BpmTaskEventMessageAppService : BpmAppServiceBase, IBpmTaskEventMessageAppService
    {
        private readonly ICapPublisher _capPublisher;
        private readonly ITaskEventMessageRepository _taskEventMessageRepository;

        /// <summary>
        /// <see cref="BpmTaskEventMessageAppService"/>
        /// </summary>
        public BpmTaskEventMessageAppService(ICapPublisher capPublisher,
            ITaskEventMessageRepository taskEventMessageRepository)
        {
            _capPublisher = capPublisher;
            _taskEventMessageRepository = taskEventMessageRepository;
        }

        /// <inheritdoc/>
        public async Task<Result<TaskEventMessageDto>> AddTaskEventMessage(TaskEventMessageAddInput taskEventMessageAddInput)
        {
            var taskEventMessage = ObjectMapper.Map<TaskEventMessageAddInput, TaskEventMessage>(taskEventMessageAddInput);
            //事件消息落库
            taskEventMessage = await _taskEventMessageRepository.InsertAsync(taskEventMessage);
            var taskEventMessageDto = ObjectMapper.Map<TaskEventMessage, TaskEventMessageDto>(taskEventMessage);
            //同步到消息队列,无事务支持
            var taskEventMessageEto = ObjectMapper.Map<TaskEventMessage, TaskEventMessageEto>(taskEventMessage);
            await _capPublisher.PublishAsync(MoBpmConsts.TaskEventMessageTopic, taskEventMessageEto);

            return Result.FromData(taskEventMessageDto);
        }

        /// <inheritdoc/>
        public async Task<Result<List<TaskEventMessageDto>>> BatchAddTaskEventMessage(List<TaskEventMessageAddInput> taskEventMessageAddInputs)
        {
            var taskEventMessages = ObjectMapper.Map<List<TaskEventMessageAddInput>, List<TaskEventMessage>>(taskEventMessageAddInputs);
            var taskEventMessageAddTasks = taskEventMessages.Select(x => _taskEventMessageRepository.InsertAsync(x)).ToList();
            taskEventMessages = (await Task.WhenAll(taskEventMessageAddTasks)).ToList();
            var taskEventMessageDtos = ObjectMapper.Map<List<TaskEventMessage>, List<TaskEventMessageDto>>(taskEventMessages);
            //同步到消息队列,无事务支持
            var taskEventMessageEtos = ObjectMapper.Map<List<TaskEventMessage>, List<TaskEventMessageEto>>(taskEventMessages);
            var taskEventMessagePublishTasks = taskEventMessageEtos.Select(x => _capPublisher.PublishAsync(MoBpmConsts.TaskEventMessageTopic, x));
            Task.WaitAll(taskEventMessagePublishTasks.ToArray());

            return Result.FromData(taskEventMessageDtos);
        }

        /// <summary>
        /// 获取任务事件消息
        /// </summary>
        /// <param name="messageId"><see cref="IEntity{Guid}.Id"/></param>
        /// <returns></returns>
        public async Task<Result<TaskEventMessageDto>> GetTaskEventMessage(Guid messageId)
        {
            var taskEventMessage = await _taskEventMessageRepository.GetAsync(messageId);
            var taskEventMessageDto = ObjectMapper.Map<TaskEventMessage, TaskEventMessageDto>(taskEventMessage);

            return Result.FromData(taskEventMessageDto);
        }

        /// <inheritdoc/>
        public async Task<Result<List<TaskEventMessageDto>>> GetAllTaskEventMessage()
        {
            var taskEventMessges = await _taskEventMessageRepository.GetListAsync();
            var taskEventMessageDtos = ObjectMapper.Map<List<TaskEventMessage>, List<TaskEventMessageDto>>(taskEventMessges);

            return Result.FromData(taskEventMessageDtos);
        }

        /// <ineritdoc/>
        public async Task<QueryResult<TaskEventMessageDto>> QueryTaskEventMessage(TaskEventMessageQueryInput taskEventMessageQueryInput)
        {
            var filter = new Query<TaskEventMessage>().GetFilter();
            if (!string.IsNullOrWhiteSpace(taskEventMessageQueryInput.ProcessDefinitionId))
                filter = filter.And(x => x.ProcessDefinition.ProcessDefinitionId == taskEventMessageQueryInput.ProcessDefinitionId);
            if (!string.IsNullOrWhiteSpace(taskEventMessageQueryInput.ProcessInstanceId))
                filter = filter.And(x => x.ProcessInstance.ProcessInstanceId == taskEventMessageQueryInput.ProcessInstanceId);
            if (!string.IsNullOrWhiteSpace(taskEventMessageQueryInput.TaskInstanceId))
                filter = filter.And(x => x.TaskInstanceId == taskEventMessageQueryInput.TaskInstanceId);
            if (!string.IsNullOrWhiteSpace(taskEventMessageQueryInput.TaskEventName))
                filter = filter.And(x => x.TaskEventName == taskEventMessageQueryInput.TaskEventName);
            if (!string.IsNullOrWhiteSpace(taskEventMessageQueryInput.OperatorUserCode))
                filter = filter.And(x => x.Operator.UserCode == taskEventMessageQueryInput.OperatorUserCode);
            if (!string.IsNullOrWhiteSpace(taskEventMessageQueryInput.TargetUserCode))
                filter = filter.And(x => x.TargetUser != null && x.TargetUser.UserCode == taskEventMessageQueryInput.TargetUserCode);
            if (taskEventMessageQueryInput.CreationTimeFrom.HasValue)
                filter = filter.And(x => x.CreationTime >= taskEventMessageQueryInput.CreationTimeFrom.Value);
            if (taskEventMessageQueryInput.CreationTimeTo.HasValue)
                filter = filter.And(x => x.CreationTime <= taskEventMessageQueryInput.CreationTimeTo.Value);

            var taskEventMessages = await _taskEventMessageRepository.GetQueryable().Where(filter).ToDynamicListAsync<TaskEventMessage>();
            var taskEventMessageDtos = ObjectMapper.Map<List<TaskEventMessage>, List<TaskEventMessageDto>>(taskEventMessages);

            return QueryResult.FromData(taskEventMessageDtos);
        }

        /// <summary>
        /// 分页查询任务事件消息
        /// </summary>
        /// <param name="taskEventMessagePageQueryInput"><see cref="TaskEventMessagePageQueryInput"/></param>
        /// <returns></returns>
        public async Task<PageQueryResult<TaskEventMessageDto>> PageQueryTaskEventMessage(TaskEventMessagePageQueryInput taskEventMessagePageQueryInput)
        {
            var filter = new Query<TaskEventMessage>().GetFilter();
            if (!string.IsNullOrWhiteSpace(taskEventMessagePageQueryInput.ProcessDefinitionId))
                filter = filter.And(x => x.ProcessDefinition.ProcessDefinitionId == taskEventMessagePageQueryInput.ProcessDefinitionId);
            if (!string.IsNullOrWhiteSpace(taskEventMessagePageQueryInput.ProcessInstanceId))
                filter = filter.And(x => x.ProcessInstance.ProcessInstanceId == taskEventMessagePageQueryInput.ProcessInstanceId);
            if (!string.IsNullOrWhiteSpace(taskEventMessagePageQueryInput.TaskDefinitionId))
                filter = filter.And(x => x.TaskDefinition.TaskDefinitionId == taskEventMessagePageQueryInput.TaskDefinitionId);
            if (!string.IsNullOrWhiteSpace(taskEventMessagePageQueryInput.TaskInstanceId))
                filter = filter.And(x => x.TaskInstanceId == taskEventMessagePageQueryInput.TaskInstanceId);
            if (!string.IsNullOrWhiteSpace(taskEventMessagePageQueryInput.TaskEventName))
                filter = filter.And(x => x.TaskEventName.Contains(taskEventMessagePageQueryInput.TaskEventName));
            if (!string.IsNullOrWhiteSpace(taskEventMessagePageQueryInput.OperatorUserCode))
                filter = filter.And(x => x.Operator.UserCode == taskEventMessagePageQueryInput.OperatorUserCode);
            if (!string.IsNullOrWhiteSpace(taskEventMessagePageQueryInput.TargetUserCode))
                filter = filter.And(x => x.TargetUser != null && x.TargetUser.UserCode == taskEventMessagePageQueryInput.TargetUserCode);
            if (taskEventMessagePageQueryInput.CreationTimeFrom.HasValue)
                filter = filter.And(x => x.CreationTime >= taskEventMessagePageQueryInput.CreationTimeFrom.Value);
            if (taskEventMessagePageQueryInput.CreationTimeTo.HasValue)
                filter = filter.And(x => x.CreationTime <= taskEventMessagePageQueryInput.CreationTimeTo.Value);

            var totalCount = _taskEventMessageRepository.GetQueryable().Where(filter).Count();
            var taskEventMessages = await _taskEventMessageRepository.GetQueryable().Where(filter)
                .Skip(taskEventMessagePageQueryInput.Offset).Take(taskEventMessagePageQueryInput.Count).ToDynamicListAsync<TaskEventMessage>();
            var taskEventMessageDtos = ObjectMapper.Map<List<TaskEventMessage>, List<TaskEventMessageDto>>(taskEventMessages);

            return PageQueryResult.FromData(taskEventMessageDtos, totalCount, (IPageInfo)taskEventMessagePageQueryInput);
        }

        public async Task<Result> Process(TaskEventMessageEto taskEventMessageEto)
        {
            var taskEventMessage = await _taskEventMessageRepository.GetAsync(Guid.Parse(taskEventMessageEto.Id));
            if (taskEventMessage is null)
            {
                Logger.LogError($"无对应任务事件消息【{taskEventMessageEto.Id}】");
                return Result.FromError($"无对应任务事件消息【{taskEventMessageEto.Id}】");
            }
            else
            {
                var taskCallbackConfigurations = await ServiceProvider.GetRequiredService<ITaskCallbackConfigurationRepository>().GetQueryable()
                     .Where(x => x.Action == taskEventMessage.Action
                     && x.ProcessDefinitionId == taskEventMessage.ProcessDefinition.ProcessDefinitionId
                     && x.TaskDefinitionId == taskEventMessage.TaskDefinition.TaskDefinitionId
                     && x.TaskEventName == taskEventMessage.TaskEventName
                     && x.IsValid)
                     .ToDynamicListAsync<TaskCallbackConfiguration>();

                if (taskCallbackConfigurations is null || !taskCallbackConfigurations.Any())
                {
                    Logger.LogInformation($"任务实例【{taskEventMessageEto.Id}】：\r\n系统中无流程【{ taskEventMessage.ProcessDefinition.ProcessDefinitionId}】，" +
                        $"节点【{taskEventMessage.TaskDefinition.TaskDefinitionId}】，事件【{taskEventMessage.TaskEventName}】对应的有效回调配置");
                    return Result.Ok();
                }
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
                            CallbackUrl = x.CallbackUrl,
                            Headers = x.Headers,
                            Params = @params
                        });
                    }).ToList();

                    await Task.WhenAll(taskCallbackEventPublishTasks);
                    return Result.Ok();
                }
            }

        }
    }
}
