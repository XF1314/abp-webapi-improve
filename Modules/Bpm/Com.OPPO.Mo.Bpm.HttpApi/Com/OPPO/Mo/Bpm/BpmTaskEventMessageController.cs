using Com.OPPO.Mo.Bpm.Dtos;
using Com.OPPO.Mo.Bpm.Etos;
using Com.OPPO.Mo.Queriable;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// 任务事件消息
    /// </summary>
    [Area("bpm")]
    [Route("api/mo/bpm/task-event-message")]
    public class BpmTaskEventMessageController : AbpController
    {
        private readonly IBpmTaskEventMessageAppService _taskEventMessageAppService;

        /// <summary>
        /// <see cref="BpmTaskEventMessageController"/>
        /// </summary>
        public BpmTaskEventMessageController(IBpmTaskEventMessageAppService taskEventMessageAppService)
        {
            _taskEventMessageAppService = taskEventMessageAppService;
        }

        /// <summary>
        /// 新增任务事件消息
        /// </summary>
        /// <param name="processEventMessageAddInput"><see cref="TaskEventMessageAddInput"/></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<Result<TaskEventMessageDto>> AddTaskEventMessage([FromBody] TaskEventMessageAddInput processEventMessageAddInput)
        {
            return await _taskEventMessageAppService.AddTaskEventMessage(processEventMessageAddInput);
        }

        /// <summary>
        /// 批量新增任务事件消息
        /// </summary>
        /// <param name="processEventMessageAddInputs"><see cref="List{TaskEventMessageAddInput}"/></param>
        /// <returns></returns>
        [HttpPost("batch-add")]
        public async Task<Result<List<TaskEventMessageDto>>> BatchAddTaskEventMessage([FromBody] List<TaskEventMessageAddInput> processEventMessageAddInputs)
        {
            return await _taskEventMessageAppService.BatchAddTaskEventMessage(processEventMessageAddInputs);
        }

        /// <summary>
        /// 根据任务事件消息Id获取任务事件消息
        /// </summary>
        /// <param name="messageId">任务事件消息Id</param>
        /// <returns></returns>
        [HttpGet("get-by-id")]
        public async Task<Result<TaskEventMessageDto>> GetTaskEventMessage(Guid messageId)
        {
            return await _taskEventMessageAppService.GetTaskEventMessage(messageId);
        }

        ///// <summary>
        ///// 获取所有任务事件消息
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("all")]
        //public async Task<Result<List<TaskEventMessageDto>>> GetAllTaskEventMessage()
        //{
        //    return await _taskEventMessageAppService.GetAllTaskEventMessage();
        //}

        /// <summary>
        /// 查询任务事件消息
        /// </summary>
        /// <param name="processEventMessageQueryInput"><see cref="TaskEventMessageQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("query")]
        public async Task<QueryResult<TaskEventMessageDto>> QueryTaskEventMessage([FromBody] TaskEventMessageQueryInput processEventMessageQueryInput)
        {
            return await _taskEventMessageAppService.QueryTaskEventMessage(processEventMessageQueryInput);
        }

        /// <summary>
        /// 分页查询任务事件消息
        /// </summary>
        /// <param name="taskEventMessagePageQueryInput"><see cref="TaskEventMessagePageQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("page-query")]
        public async Task<PageQueryResult<TaskEventMessageDto>> PageQueryTaskEventMessage([FromBody] TaskEventMessagePageQueryInput taskEventMessagePageQueryInput)
        {
            return await _taskEventMessageAppService.PageQueryTaskEventMessage(taskEventMessagePageQueryInput);
        }

        /// <summary>
        /// 处理任务事件消息
        /// </summary>
        /// <param name="taskEventMessageEto"><see cref="TaskEventMessageEto"/></param>
        /// <returns></returns>
        [HttpPost("process")]
        public async Task<Result> Process([FromBody]TaskEventMessageEto taskEventMessageEto)
        {
            return await _taskEventMessageAppService.Process(taskEventMessageEto);
        }
    }
}
