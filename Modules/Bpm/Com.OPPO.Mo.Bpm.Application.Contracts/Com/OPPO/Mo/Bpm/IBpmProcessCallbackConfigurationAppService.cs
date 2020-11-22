using Com.OPPO.Mo.Bpm.Dtos;
using Com.OPPO.Mo.Queriable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Bpm流程回调配置应用服务接口
    /// </summary>
    public interface IBpmProcessCallbackConfigurationAppService
    {
        /// <summary>
        /// 新增流程回调配置
        /// </summary>
        /// <param name="processCallbackConfigurationAddInput"><see cref="ProcessCallbackConfigurationAddInput"/></param>
        /// <returns></returns>
        Task<Result<ProcessCallbackConfigurationDto>> AddProcessCallbackConfiguration(ProcessCallbackConfigurationAddInput processCallbackConfigurationAddInput);

        /// <summary>
        /// 批量新增/更新流程回调配置
        /// </summary>
        /// <param name="processCallbackConfigurationBatchUpsertInput"><see cref="ProcessCallbackConfigurationBatchUpsertInput"/></param>
        /// <returns></returns>
        Task<Result<List<ProcessCallbackConfigurationDto>>> BatchUpsertProcessCallbackConfiguration(ProcessCallbackConfigurationBatchUpsertInput processCallbackConfigurationBatchUpsertInput);

        /// <summary>
        /// 失效流程回调配置
        /// </summary>
        /// <param name="configurationId">流程回调配置Id</param>
        /// <returns></returns>
        Task<Result<ProcessCallbackConfigurationDto>> InvalidateProcessCallbackConfiguration(Guid configurationId);

        /// <summary>
        /// 生效流程回调配置
        /// </summary>
        /// <param name="configurationId">流程回调配置Id</param>
        /// <returns></returns>
        Task<Result<ProcessCallbackConfigurationDto>> ValidateProcessCallbackConfiguration(Guid configurationId);

        /// <summary>
        /// 删除流程回调配置
        /// </summary>
        /// <param name="configurationId">流程回调配置Id</param>
        /// <returns></returns>
        Task<Result> DeleteProcessCallbackConfiguration(Guid configurationId);

        /// <summary>
        /// 获流程回调配置
        /// </summary>
        /// <param name="configurationId">流程回调配置Id</param>
        /// <returns></returns>
        Task<Result<ProcessCallbackConfigurationDto>> GetProcessCallbackConfiguration(Guid configurationId);

        /// <summary>
        /// 获取所有流程回调配置
        /// </summary>
        /// <returns></returns>
        Task<Result<List<ProcessCallbackConfigurationDto>>> GetAllProcessCallbackConfigruation();

        /// <summary>
        /// 查询流程回调配置
        /// </summary>
        /// <param name="processCallbackConfigurationQueryInput"><see cref="ProcessCallbackConfigurationQueryInput"/></param>
        /// <returns></returns>
        Task<QueryResult<ProcessCallbackConfigurationDto>> QueryProcessCallbackConfiguration(ProcessCallbackConfigurationQueryInput processCallbackConfigurationQueryInput);

    }
}
