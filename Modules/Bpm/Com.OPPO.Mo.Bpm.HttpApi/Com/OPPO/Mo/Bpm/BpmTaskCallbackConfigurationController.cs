using Com.OPPO.Mo.Bpm.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Com.OPPO.Mo.Queriable;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// 任务回调配置
    /// </summary>
    [Area("bpm")]
    [Route("api/mo/bpm/task-callback-configuration")]
    public class BpmTaskCallbackConfigurationController : AbpController
    {
        private readonly IBpmTaskCallbackConfigurationAppService _taskCallbackConfigurationAppService;

        /// <summary>
        /// <see cref="BpmTaskCallbackConfigurationController"/>
        /// </summary>
        public BpmTaskCallbackConfigurationController(IBpmTaskCallbackConfigurationAppService taskCallbackConfigurationAppService)
        {
            _taskCallbackConfigurationAppService = taskCallbackConfigurationAppService;
        }

        /// <summary>
        /// 新增任务回调配置
        /// </summary>
        /// <param name="taskCallbackConfigurationAddInput"><see cref="TaskCallbackConfigurationAddInput"/></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<Result<TaskCallbackConfigurationDto>> AddTaskCallbackConfiguration([FromBody] TaskCallbackConfigurationAddInput taskCallbackConfigurationAddInput)
        {
            return await _taskCallbackConfigurationAppService.AddTaskCallbackConfiguration(taskCallbackConfigurationAddInput);
        }

        /// <summary>
        /// 批量新增/更新任务回调配置
        /// </summary>
        /// <param name="taskCallbackConfigurationBatchUpsertInput"><see cref="TaskCallbackConfigurationBatchUpsertInput"/></param>
        /// <returns></returns>
        [HttpPost("batch-upsert")]
        public async Task<Result<List<TaskCallbackConfigurationDto>>> BatchUpsertTaskCallbackConfiguration([FromBody]TaskCallbackConfigurationBatchUpsertInput taskCallbackConfigurationBatchUpsertInput)
        {
            return await _taskCallbackConfigurationAppService.BatchUpsertTaskCallbackConfiguration(taskCallbackConfigurationBatchUpsertInput);
        }

        /// <summary>
        /// 失效任务回调配置
        /// </summary>
        /// <param name="configurationId">任务回调配置Id</param>
        /// <returns></returns>
        [HttpPost("invalidate-by-id")]
        public async Task<Result<TaskCallbackConfigurationDto>> InvalidateTaskCallbackConfiguration(Guid configurationId)
        {
            return await _taskCallbackConfigurationAppService.InvalidateTaskCallbackConfiguration(configurationId);
        }

        /// <summary>
        /// 生效任务回调配置
        /// </summary>
        /// <param name="configurationId">任务回调配置Id</param>
        /// <returns></returns>
        [HttpPost("validate-by-id")]
        public async Task<Result<TaskCallbackConfigurationDto>> ValidateTaskCallbackConfiguration(Guid configurationId)
        {
            return await _taskCallbackConfigurationAppService.ValidateTaskCallbackConfiguration(configurationId);
        }

        /// <summary>
        /// 删除任务回调配置
        /// </summary>
        /// <param name="configurationId">任务回调配置Id</param>
        /// <returns></returns>
        [HttpDelete("delete-by-id")]
        public async Task<Result> DeleteTaskCallbackConfiguration(Guid configurationId)
        {
            return await _taskCallbackConfigurationAppService.DeleteTaskCallbackConfiguration(configurationId);
        }

        /// <summary>
        /// 获任务回调配置
        /// </summary>
        /// <param name="configurationId">任务回调配置Id</param>
        /// <returns></returns>
        [HttpGet("get-by-id")]
        public async Task<Result<TaskCallbackConfigurationDto>> GetTaskCallbackConfiguration(Guid configurationId)
        {
            return await _taskCallbackConfigurationAppService.GetTaskCallbackConfiguration(configurationId);
        }

        ///// <summary>
        ///// 获取所有任务回调配置
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("all")]
        //public async Task<Result<List<TaskCallbackConfigurationDto>>> GetAllTaskCallbackConfigruation()
        //{
        //    return await _taskCallbackConfigurationAppService.GetAllTaskCallbackConfigruation();
        //}

        /// <summary>
        /// 查询流程回调配置
        /// </summary>
        /// <param name="taskCallbackConfigurationQueryInput"><see cref="TaskCallbackConfigurationQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("query")]
        public async Task<QueryResult<TaskCallbackConfigurationDto>> QueryTaskCallbackConfiguration([FromBody] TaskCallbackConfigurationQueryInput taskCallbackConfigurationQueryInput)
        {
            return await _taskCallbackConfigurationAppService.QueryTaskCallbackConfiguration(taskCallbackConfigurationQueryInput);
        }
    }
}
