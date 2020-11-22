using Com.OPPO.Mo.Bpm.Dtos;
using Com.OPPO.Mo.Queriable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Bpm任务回调配置应用服务接口
    /// </summary>
    public interface IBpmTaskCallbackConfigurationAppService : IApplicationService
    {
        /// <summary>
        /// 新增任务回调配置
        /// </summary>
        /// <param name="processCallbackConfigurationAddInput"><see cref="TaskCallbackConfigurationAddInput"/></param>
        /// <returns></returns>
        Task<Result<TaskCallbackConfigurationDto>> AddTaskCallbackConfiguration(TaskCallbackConfigurationAddInput processCallbackConfigurationAddInput);

        /// <summary>
        /// 批量新增/更新任务回调配置
        /// </summary>
        /// <param name="taskCallbackConfigurationBatchUpsertInput"><see cref="TaskCallbackConfigurationBatchUpsertInput"/></param>
        /// <returns></returns>
        Task<Result<List<TaskCallbackConfigurationDto>>> BatchUpsertTaskCallbackConfiguration(TaskCallbackConfigurationBatchUpsertInput taskCallbackConfigurationBatchUpsertInput);

        /// <summary>
        /// 失效任务回调配置
        /// </summary>
        /// <param name="configurationId">任务回调配置Id</param>
        /// <returns></returns>
        Task<Result<TaskCallbackConfigurationDto>> InvalidateTaskCallbackConfiguration(Guid configurationId);

        /// <summary>
        /// 生效任务回调配置
        /// </summary>
        /// <param name="configurationId">任务回调配置Id</param>
        /// <returns></returns>
        Task<Result<TaskCallbackConfigurationDto>> ValidateTaskCallbackConfiguration(Guid configurationId);

        /// <summary>
        /// 删除任务回调配置
        /// </summary>
        /// <param name="configurationId">任务回调配置Id</param>
        /// <returns></returns>
        Task<Result> DeleteTaskCallbackConfiguration(Guid configurationId);

        /// <summary>
        /// 获任务回调配置
        /// </summary>
        /// <param name="configurationId">任务回调配置Id</param>
        /// <returns></returns>
        Task<Result<TaskCallbackConfigurationDto>> GetTaskCallbackConfiguration(Guid configurationId);

        /// <summary>
        /// 获取所有任务回调配置
        /// </summary>
        /// <returns></returns>
        Task<Result<List<TaskCallbackConfigurationDto>>> GetAllTaskCallbackConfigruation();

        /// <summary>
        /// 查询任务回调配置
        /// </summary>
        /// <param name="processCallbackConfigurationQueryInput"><see cref="TaskCallbackConfigurationQueryInput"/></param>
        /// <returns></returns>
        Task<QueryResult<TaskCallbackConfigurationDto>> QueryTaskCallbackConfiguration(TaskCallbackConfigurationQueryInput processCallbackConfigurationQueryInput);

    }
}
