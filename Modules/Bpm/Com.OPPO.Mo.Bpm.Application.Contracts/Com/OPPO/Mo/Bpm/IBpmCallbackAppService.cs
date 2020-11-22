using Com.OPPO.Mo.Bpm.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Bpm回调应用服务接口
    /// </summary>
    public interface IBpmCallbackAppService : IApplicationService
    {
        /// <summary>
        /// 触发任务回调
        /// </summary>
        /// <param name="taskEventMessageId">任务事件消息Id</param>
        /// <returns></returns>
        Task<Result> TriggerTaskCallback(string taskEventMessageId);

        /// <summary>
        /// 触发流程回调
        /// </summary>
        /// <param name="processEventMessageId">流程事件消息Id</param>
        /// <returns></returns>
        Task<Result> TriggerProcessCallback(string processEventMessageId);

        /// <summary>
        /// 任务回调
        /// </summary>
        /// <param name="taskEventCallbackInput"><see cref="TaskEventCallbackInput"/></param>
        /// <returns></returns>
        Task<Result<string>> TaskCallback(TaskEventCallbackInput taskEventCallbackInput);

        /// <summary>
        /// 流程回调
        /// </summary>
        /// <param name="processEventCallbackInput"><see cref="ProcessEventCallbackInput"/></param>
        /// <returns></returns>
        Task<Result<string>> ProcessCallback(ProcessEventCallbackInput processEventCallbackInput);

    }
}
