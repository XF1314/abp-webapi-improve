using Com.OPPO.Mo.Bpm.Dtos;
using Com.OPPO.Mo.Bpm.Etos;
using Com.OPPO.Mo.Queriable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Bpm任务事件消息应用服务接口
    /// </summary>
    public interface IBpmTaskEventMessageAppService : IApplicationService
    {
        /// <summary>
        /// 新增任务事件消息
        /// </summary>
        /// <param name="taskEventMessageAddInput"><see cref="TaskEventMessageAddInput"/></param>
        /// <returns></returns>
        Task<Result<TaskEventMessageDto>> AddTaskEventMessage(TaskEventMessageAddInput taskEventMessageAddInput);

        /// <summary>
        /// 批量新增任务事件消息
        /// </summary>
        /// <param name="taskEventMessageAddInputs"><see cref="List{taskEventMessageAddInput}"/></param>
        /// <returns></returns>
        Task<Result<List<TaskEventMessageDto>>> BatchAddTaskEventMessage(List<TaskEventMessageAddInput> taskEventMessageAddInputs);

        /// <summary>
        /// 获取任务事件消息
        /// </summary>
        /// <param name="messageId"><see cref="IEntity{Guid}.Id"/></param>
        /// <returns></returns>
        Task<Result<TaskEventMessageDto>> GetTaskEventMessage(Guid messageId);

        /// <summary>
        /// 获取所有任务事件消息
        /// </summary>
        /// <returns></returns>
        Task<Result<List<TaskEventMessageDto>>> GetAllTaskEventMessage();

        /// <summary>
        /// 查询任务事件消息
        /// </summary>
        /// <param name="taskEventMessageQueryInput"><see cref="TaskEventMessageQueryInput"/></param>
        /// <returns></returns>
        Task<QueryResult<TaskEventMessageDto>> QueryTaskEventMessage(TaskEventMessageQueryInput taskEventMessageQueryInput);

        /// <summary>
        /// 分页查询任务事件消息
        /// </summary>
        /// <param name="taskEventMessagePageQueryInput"><see cref="TaskEventMessagePageQueryInput"/></param>
        /// <returns></returns>
        Task<PageQueryResult<TaskEventMessageDto>> PageQueryTaskEventMessage(TaskEventMessagePageQueryInput taskEventMessagePageQueryInput);

        /// <summary>
        /// 处理任务事件消息
        /// </summary>
        /// <param name="taskEventMessageEto"><see cref="TaskEventMessageEto"/></param>
        /// <returns></returns>
        Task<Result> Process(TaskEventMessageEto taskEventMessageEto);
    }
}
