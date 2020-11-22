using Com.OPPO.Mo.Bpm.Dtos;
using Com.OPPO.Mo.Queriable;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// 流程事件消息
    /// </summary>
    [Area("bpm")]
    [Route("api/mo/bpm/process-event-message")]
    public class BpmProcessEventMessageController : AbpController
    {
        private readonly IBpmProcessEventMessageAppService _processEventMessageAppService;

        /// <summary>
        /// <see cref="BpmProcessEventMessageController"/>
        /// </summary>
        public BpmProcessEventMessageController(IBpmProcessEventMessageAppService processEventMessageAppService)
        {
            _processEventMessageAppService = processEventMessageAppService;
        }

        /// <summary>
        /// 新增流程事件消息
        /// </summary>
        /// <param name="processEventMessageAddInput"><see cref="ProcessEventMessageAddInput"/></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<Result<ProcessEventMessageDto>> AddProcessEventMessage([FromBody] ProcessEventMessageAddInput processEventMessageAddInput)
        {
            return await _processEventMessageAppService.AddProcessEventMessage(processEventMessageAddInput);
        }

        /// <summary>
        /// 批量新增流程事件消息
        /// </summary>
        /// <param name="processEventMessageAddInputs"><see cref="List{ProcessEventMessageAddInput}"/></param>
        /// <returns></returns>
        [HttpPost("batch-add")]
        public async Task<Result<List<ProcessEventMessageDto>>> BatchAddProcessEventMessage([FromBody] List<ProcessEventMessageAddInput> processEventMessageAddInputs)
        {
            return await _processEventMessageAppService.BatchAddProcessEventMessage(processEventMessageAddInputs);
        }

        /// <summary>
        /// 根据Id获取流程事件消息
        /// </summary>
        /// <param name="messageId">流程事件消息Id</param>
        /// <returns></returns>
        [HttpGet("get-by-id")]
        public async Task<Result<ProcessEventMessageDto>> GetProcessEventMessage(Guid messageId)
        {
            return await _processEventMessageAppService.GetProcessEventMessage(messageId);
        }

        ///// <summary>
        ///// 获取所有流程事件消息
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("all")]
        //public async Task<Result<List<ProcessEventMessageDto>>> GetAllProcessEventMessage()
        //{
        //    return await _processEventMessageAppService.GetAllProcessEventMessage();
        //}

        /// <summary>
        /// 查询流程事件消息
        /// </summary>
        /// <param name="processEventMessageQueryInput"><see cref="ProcessEventMessageQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("query")]
        public async Task<QueryResult<ProcessEventMessageDto>> QueryProcessEventMessage([FromBody] ProcessEventMessageQueryInput processEventMessageQueryInput)
        {
            return await _processEventMessageAppService.QueryProcessEventMessage(processEventMessageQueryInput);
        }

        /// <summary>
        /// 分页查询流程事件消息
        /// </summary>
        /// <param name="processEventMessagePageQueryInput"><see cref="ProcessEventMessagePageQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("page-query")]
        public async Task<PageQueryResult<ProcessEventMessageDto>> PageQueryProcessEventMessage([FromBody] ProcessEventMessagePageQueryInput processEventMessagePageQueryInput)
        {
            return await _processEventMessageAppService.PageQueryProcessEventMessage(processEventMessagePageQueryInput);
        }
    }
}