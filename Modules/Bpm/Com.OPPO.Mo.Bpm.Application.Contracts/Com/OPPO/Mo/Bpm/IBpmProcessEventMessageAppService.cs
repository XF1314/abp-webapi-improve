using Com.OPPO.Mo.Bpm.Dtos;
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
    /// Bpm流程事件消息应用服务接口
    /// </summary>
    public interface IBpmProcessEventMessageAppService : IApplicationService
    {
        /// <summary>
        /// 新增流程事件消息
        /// </summary>
        /// <param name="processEventMessageAddInput"><see cref="ProcessEventMessageAddInput"/></param>
        /// <returns></returns>
        Task<Result<ProcessEventMessageDto>> AddProcessEventMessage(ProcessEventMessageAddInput processEventMessageAddInput);

        /// <summary>
        /// 批量新增流程事件消息
        /// </summary>
        /// <param name="processEventMessageAddInputs"><see cref="List{ProcessEventMessageAddInput}"/></param>
        /// <returns></returns>
        Task<Result<List<ProcessEventMessageDto>>> BatchAddProcessEventMessage(List<ProcessEventMessageAddInput> processEventMessageAddInputs);

        /// <summary>
        /// 获取流程事件消息
        /// </summary>
        /// <param name="id"><see cref="IEntity{Guid}.Id"/></param>
        /// <returns></returns>
        Task<Result<ProcessEventMessageDto>> GetProcessEventMessage(Guid messageId);

        /// <summary>
        /// 获取所有流程事件消息
        /// </summary>
        /// <returns></returns>
        Task<Result<List<ProcessEventMessageDto>>> GetAllProcessEventMessage();

        /// <summary>
        /// 查询流程事件消息
        /// </summary>
        /// <param name="processEventMessageQueryInput"><see cref="ProcessEventMessageQueryInput"/></param>
        /// <returns></returns>
        Task<QueryResult<ProcessEventMessageDto>> QueryProcessEventMessage(ProcessEventMessageQueryInput processEventMessageQueryInput);

        /// <summary>
        /// 分页查询流程事件消息
        /// </summary>
        /// <param name="processEventMessagePageQueryInput"><see cref="ProcessEventMessagePageQueryInput"/></param>
        /// <returns></returns>
        Task<PageQueryResult<ProcessEventMessageDto>> PageQueryProcessEventMessage(ProcessEventMessagePageQueryInput processEventMessagePageQueryInput);
    }
}
