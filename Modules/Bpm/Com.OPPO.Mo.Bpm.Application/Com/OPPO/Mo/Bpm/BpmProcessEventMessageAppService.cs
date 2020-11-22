using Com.OPPO.Mo.Bpm.Dtos;
using Com.OPPO.Mo.Bpm.Etos;
using Com.OPPO.Mo.Bpm.Repositories;
using Com.OPPO.Mo.Queriable;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Bpm流程事件消息应用服务
    /// </summary>
    [Authorize]
    public class BpmProcessEventMessageAppService : BpmAppServiceBase, IBpmProcessEventMessageAppService
    {
        private readonly ICapPublisher _capPublisher;
        private readonly IProcessEventMessageRepository _processEventMessageRepository;

        public BpmProcessEventMessageAppService(ICapPublisher capPublisher, IProcessEventMessageRepository processEventMessageRepository)
        {
            _capPublisher = capPublisher;
            _processEventMessageRepository = processEventMessageRepository;
        }

        /// <inheritdoc/>
        public async Task<Result<ProcessEventMessageDto>> AddProcessEventMessage(ProcessEventMessageAddInput processEventMessageAddInput)
        {
            var processEventMessage = ObjectMapper.Map<ProcessEventMessageAddInput, ProcessEventMessage>(processEventMessageAddInput);
            //事件消息落库
            processEventMessage = await _processEventMessageRepository.InsertAsync(processEventMessage);
            var processEventMessageDto = ObjectMapper.Map<ProcessEventMessage, ProcessEventMessageDto>(processEventMessage);
            //同步到消息队列,无事务支持
            var processEventMessageEto = ObjectMapper.Map<ProcessEventMessage, ProcessEventMessageEto>(processEventMessage);
            await _capPublisher.PublishAsync(MoBpmConsts.ProcessEventMessageTopic, processEventMessageEto);

            return Result.FromData(processEventMessageDto);
        }

        /// <inheritdoc/>
        public async Task<Result<List<ProcessEventMessageDto>>> BatchAddProcessEventMessage(List<ProcessEventMessageAddInput> processEventMessageAddInputs)
        {
            var processEventMessages = ObjectMapper.Map<List<ProcessEventMessageAddInput>, List<ProcessEventMessage>>(processEventMessageAddInputs);
            var processEventMessageAddTasks = processEventMessages.Select(x => _processEventMessageRepository.InsertAsync(x)).ToList();
            processEventMessages = (await Task.WhenAll(processEventMessageAddTasks)).ToList();
            var processEventMessageDtos = ObjectMapper.Map<List<ProcessEventMessage>, List<ProcessEventMessageDto>>(processEventMessages);
            //同步到消息队列,无事务支持
            var processEventMessageEtos = ObjectMapper.Map<List<ProcessEventMessage>, List<ProcessEventMessageEto>>(processEventMessages);
            var processEventMessagePublishTasks = processEventMessageEtos.Select(x => _capPublisher.PublishAsync(MoBpmConsts.ProcessEventMessageTopic, x));
            Task.WaitAll(processEventMessagePublishTasks.ToArray());

            return Result.FromData(processEventMessageDtos);
        }

        /// <inheritdoc/>
        public async Task<Result<ProcessEventMessageDto>> GetProcessEventMessage(Guid messageId)
        {
            var processEventMessage = await _processEventMessageRepository.GetAsync(messageId);
            var processEventMessageDto = ObjectMapper.Map<ProcessEventMessage, ProcessEventMessageDto>(processEventMessage);

            return Result.FromData(processEventMessageDto);
        }

        /// <inheritdoc/>
        public async Task<Result<List<ProcessEventMessageDto>>> GetAllProcessEventMessage()
        {
            var processEventMessges = await _processEventMessageRepository.GetListAsync();
            var processEventMessageDtos = ObjectMapper.Map<List<ProcessEventMessage>, List<ProcessEventMessageDto>>(processEventMessges);

            return Result.FromData(processEventMessageDtos);
        }

        /// <inheritdoc/>
        public async Task<QueryResult<ProcessEventMessageDto>> QueryProcessEventMessage(ProcessEventMessageQueryInput processEventMessageQueryInput)
        {
            var filter = new Query<ProcessEventMessage>().GetFilter();
            if (!string.IsNullOrWhiteSpace(processEventMessageQueryInput.ProcessDefinitionId))
                filter = filter.And(x => x.ProcessDefinition.ProcessDefinitionId == processEventMessageQueryInput.ProcessDefinitionId);
            if (!string.IsNullOrWhiteSpace(processEventMessageQueryInput.ProcessInstanceId))
                filter = filter.And(x => x.ProcessInstanceId == processEventMessageQueryInput.ProcessInstanceId);
            if (!string.IsNullOrWhiteSpace(processEventMessageQueryInput.ProcessEventName))
                filter = filter.And(x => x.ProcessEventName.Contains(processEventMessageQueryInput.ProcessEventName));
            if (!string.IsNullOrWhiteSpace(processEventMessageQueryInput.UserCode))
                filter = filter.And(x => x.Operator.UserCode == processEventMessageQueryInput.UserCode);
            if (processEventMessageQueryInput.CreationTimeFrom.HasValue)
                filter = filter.And(x => x.CreationTime >= processEventMessageQueryInput.CreationTimeFrom.Value);
            if (processEventMessageQueryInput.CreationTimeTo.HasValue)
                filter = filter.And(x => x.CreationTime <= processEventMessageQueryInput.CreationTimeTo.Value);

            var processEventMessages = await _processEventMessageRepository.GetQueryable().Where(filter).ToDynamicListAsync<ProcessEventMessage>();
            var processEventMessageDtos = ObjectMapper.Map<List<ProcessEventMessage>, List<ProcessEventMessageDto>>(processEventMessages);

            return QueryResult.FromData(processEventMessageDtos);
        }

        /// <inheritdoc/>
        public async Task<PageQueryResult<ProcessEventMessageDto>> PageQueryProcessEventMessage(ProcessEventMessagePageQueryInput processEventMessagePageQueryInput)
        {
            var filter = new Query<ProcessEventMessage>().GetFilter();
            if (!string.IsNullOrWhiteSpace(processEventMessagePageQueryInput.ProcessDefinitionId))
                filter = filter.And(x => x.ProcessDefinition.ProcessDefinitionId == processEventMessagePageQueryInput.ProcessDefinitionId);
            if (!string.IsNullOrWhiteSpace(processEventMessagePageQueryInput.ProcessInstanceId))
                filter = filter.And(x => x.ProcessInstanceId == processEventMessagePageQueryInput.ProcessInstanceId);
            if (!string.IsNullOrWhiteSpace(processEventMessagePageQueryInput.ProcessEventName))
                filter = filter.And(x => x.ProcessEventName.Contains( processEventMessagePageQueryInput.ProcessEventName));
            if (!string.IsNullOrWhiteSpace(processEventMessagePageQueryInput.UserCode))
                filter = filter.And(x => x.Operator.UserCode == processEventMessagePageQueryInput.UserCode);
            if (processEventMessagePageQueryInput.CreationTimeFrom.HasValue)
                filter = filter.And(x => x.CreationTime >= processEventMessagePageQueryInput.CreationTimeFrom.Value);
            if (processEventMessagePageQueryInput.CreationTimeTo.HasValue)
                filter = filter.And(x => x.CreationTime <= processEventMessagePageQueryInput.CreationTimeTo.Value);

            var totalCount = _processEventMessageRepository.GetQueryable().Where(filter).Count();
            var processEventMessages = await _processEventMessageRepository.GetQueryable().Where(filter)
                .Skip(processEventMessagePageQueryInput.Offset).Take(processEventMessagePageQueryInput.Count).ToDynamicListAsync<ProcessEventMessage>();
            var processEventMessageDtos = ObjectMapper.Map<List<ProcessEventMessage>, List<ProcessEventMessageDto>>(processEventMessages);

            return PageQueryResult.FromData(processEventMessageDtos, totalCount, (IPageInfo)processEventMessagePageQueryInput);
        }

    }
}
