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
    /// 流程回调配置
    /// </summary>
    [Area("bpm")]
    [Route("api/mo/bpm/process-callback-configuration")]
    public class BpmProcessCallbackConfigurationController : AbpController
    {
        private readonly IBpmProcessCallbackConfigurationAppService _processCallbackConfigurationAppService;

        /// <summary>
        /// <see cref="BpmProcessCallbackConfigurationController"/>
        /// </summary>
        public BpmProcessCallbackConfigurationController(IBpmProcessCallbackConfigurationAppService processCallbackConfigurationAppService)
        {
            _processCallbackConfigurationAppService = processCallbackConfigurationAppService;
        }

        /// <summary>
        /// 新增流程回调配置
        /// </summary>
        /// <param name="processCallbackConfigurationAddInput"><see cref="ProcessCallbackConfigurationAddInput"/></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<Result<ProcessCallbackConfigurationDto>> AddProcessCallbackConfiguration([FromBody] ProcessCallbackConfigurationAddInput processCallbackConfigurationAddInput)
        {
            return await _processCallbackConfigurationAppService.AddProcessCallbackConfiguration(processCallbackConfigurationAddInput);
        }

        /// <summary>
        /// 批量新增流程回调配置
        /// </summary>
        /// <param name="processCallbackConfigurationBatchUpsertInput"><see cref="ProcessCallbackConfigurationBatchUpsertInput"/></param>
        /// <returns></returns>
        [HttpPost("batch-upsert")]
        public async Task<Result<List<ProcessCallbackConfigurationDto>>> BatchUpsertProcessCallbackConfiguration([FromBody] ProcessCallbackConfigurationBatchUpsertInput processCallbackConfigurationBatchUpsertInput)
        {
            return await _processCallbackConfigurationAppService.BatchUpsertProcessCallbackConfiguration(processCallbackConfigurationBatchUpsertInput);
        }

        /// <summary>
        /// 失效流程回调配置
        /// </summary>
        /// <param name="configurationId">流程回调配置Id</param>
        /// <returns></returns>
        [HttpPost("invalidate-by-id")]
        public async Task<Result<ProcessCallbackConfigurationDto>> InvalidateProcessCallbackConfiguration(Guid configurationId)
        {
            return await _processCallbackConfigurationAppService.InvalidateProcessCallbackConfiguration(configurationId);
        }

        /// <summary>
        /// 生效流程回调配置
        /// </summary>
        /// <param name="configurationId">流程回调配置Id</param>
        /// <returns></returns>
        [HttpPost("validate-by-id")]
        public async Task<Result<ProcessCallbackConfigurationDto>> ValidateProcessCallbackConfiguration(Guid configurationId)
        {
            return await _processCallbackConfigurationAppService.ValidateProcessCallbackConfiguration(configurationId);
        }

        /// <summary>
        /// 删除流程回调配置
        /// </summary>
        /// <param name="configurationId">流程回调配置Id</param>
        /// <returns></returns>
        [HttpDelete("delete-by-id")]
        public async Task<Result> DeleteProcessCallbackConfiguration(Guid configurationId)
        {
            return await _processCallbackConfigurationAppService.DeleteProcessCallbackConfiguration(configurationId);
        }

        /// <summary>
        /// 获流程回调配置
        /// </summary>
        /// <param name="configurationId">流程回调配置Id</param>
        /// <returns></returns>
        [HttpGet("get-by-id")]
        public async Task<Result<ProcessCallbackConfigurationDto>> GetProcessCallbackConfiguration(Guid configurationId)
        {
            return await _processCallbackConfigurationAppService.GetProcessCallbackConfiguration(configurationId);
        }

        ///// <summary>
        ///// 获取所有流程回调配置
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("all")]
        //public async Task<Result<List<ProcessCallbackConfigurationDto>>> GetAllProcessCallbackConfigruation()
        //{
        //    return await _processCallbackConfigurationAppService.GetAllProcessCallbackConfigruation();
        //}

        /// <summary>
        /// 查询流程回调配置
        /// </summary>
        /// <param name="processCallbackConfigurationQueryInput"><see cref="ProcessCallbackConfigurationQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("query")]
        public async Task<QueryResult<ProcessCallbackConfigurationDto>> QueryProcessCallbackConfiguration([FromBody] ProcessCallbackConfigurationQueryInput processCallbackConfigurationQueryInput)
        {
            return await _processCallbackConfigurationAppService.QueryProcessCallbackConfiguration(processCallbackConfigurationQueryInput);
        }
    }
}
