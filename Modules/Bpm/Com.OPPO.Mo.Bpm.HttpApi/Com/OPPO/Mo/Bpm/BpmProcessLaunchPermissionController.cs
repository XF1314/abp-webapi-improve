using Com.OPPO.Mo.Bpm;
using Com.OPPO.Mo.Bpm.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.BPM
{
    /// <summary>
    /// 流程发起权限
    /// </summary>
    [Area("bpm")]
    [Route("api/mo/bpm/process-launch-permission")]
    public class BpmProcessLaunchPermissionController : AbpController
    {
        private readonly IBpmProcessLaunchPermissionAppService _processLaunchPermissionAppService;

        /// <summary>
        /// <see cref="BpmProcessLaunchPermissionController"/>
        /// </summary>
        public BpmProcessLaunchPermissionController(IBpmProcessLaunchPermissionAppService processLaunchPermissionAppService)
        {
            _processLaunchPermissionAppService = processLaunchPermissionAppService;
        }

        /// <summary>
        /// 授予流程发起权限
        /// </summary>
        /// <param name="processLaunchPermissionGrantInput"><see cref="ProcessLaunchPermissionGrantInput"/></param>
        /// <returns></returns>
        [HttpPost("grant")]
        public async Task<Result<ProcessLaunchPermissionDto>> GrantProcessLaunchPermission([FromBody] ProcessLaunchPermissionGrantInput processLaunchPermissionGrantInput)
        {
            return await _processLaunchPermissionAppService.GrantProcessLaunchPermission(processLaunchPermissionGrantInput);
        }

        /// <summary>
        /// 批量授予流程发起权限
        /// </summary>
        /// <param name="processLaunchPermissionBatchGrantInput"><see cref="ProcessLaunchPermissionBatchGrantInput"/></param>
        /// <returns></returns>
        [HttpPost("batch-grant")]
        public async Task<Result<List<ProcessLaunchPermissionDto>>> BatchGrantProcessLaunchPermission([FromBody] ProcessLaunchPermissionBatchGrantInput processLaunchPermissionBatchGrantInput)
        {
            return await _processLaunchPermissionAppService.BatchGrantProcessLaunchPermission(processLaunchPermissionBatchGrantInput);
        }

        /// <summary>
        /// 失效流程发起权限
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="processDefinitionId">流程定义Id</param>
        /// <returns></returns>
        [HttpPost("invalidate")]
        public async Task<Result<ProcessLaunchPermissionDto>> InvalidateProcessLaunchPermission(string appId, string processDefinitionId)
        {
            return await _processLaunchPermissionAppService.InvalidateProcessLaunchPermission(appId, processDefinitionId);
        }

        /// <summary>
        /// 失效流程发起权限
        /// </summary>
        /// <param name="permissionId">流程发起权限Id</param>
        /// <returns></returns>
        [HttpPost("invalidate-by-id")]
        public async Task<Result<ProcessLaunchPermissionDto>> InvalidateProcessLaunchPermission(Guid permissionId)
        {
            return await _processLaunchPermissionAppService.InvalidateProcessLaunchPermission(permissionId);
        }

        /// <summary>
        /// 生效流程发起权限
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="processDefinitionId">流程发起权限Id</param>
        /// <returns></returns>
        [HttpPost("validate")]
        public async Task<Result<ProcessLaunchPermissionDto>> ValidateProcessLaunchPermission(string appId, string processDefinitionId)
        {
            return await _processLaunchPermissionAppService.ValidateProcessLaunchPermission(appId, processDefinitionId);
        }

        /// <summary>
        /// 生效流程发起权限
        /// </summary>
        /// <param name="permissionId">流程发起权限Id</param>
        /// <returns></returns>
        [HttpPost("validate-by-id")]
        public async Task<Result<ProcessLaunchPermissionDto>> ValidateProcessLaunchPermission(Guid permissionId)
        {
            return await _processLaunchPermissionAppService.ValidateProcessLaunchPermission(permissionId);
        }

        /// <summary>
        /// 取消流程发起权限
        /// </summary>
        /// <param name="permissionId">流程发起权限Id</param>
        /// <returns></returns>
        [HttpDelete("revoke-by-id")]
        public async Task<Result> RevokeProcessLaunchPermission(Guid permissionId)
        {
            return await _processLaunchPermissionAppService.RevokeProcessLaunchPermission(permissionId);
        }

        /// <summary>
        /// 获取流程发起权限
        /// </summary>
        /// <param name="permissionId">流程发起权限Id</param>
        /// <returns></returns>
        [HttpGet("get-by-id")]
        public async Task<Result<ProcessLaunchPermissionDto>> GetProcessLaunchPermission(Guid permissionId)
        {
            return await _processLaunchPermissionAppService.GetProcessLaunchPermission(permissionId);
        }

        /// <summary>
        /// 查询流程发起权限
        /// </summary>
        /// <param name="processLaunchPermissionQueryInput"><see cref="ProcessLaunchPermissionQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("query")]
        public async Task<Result<List<ProcessLaunchPermissionDto>>> QueryProcessLaunchPermission([FromBody] ProcessLaunchPermissionQueryInput processLaunchPermissionQueryInput)
        {
            return await _processLaunchPermissionAppService.QueryProcessLaunchPermission(processLaunchPermissionQueryInput);
        }

        ///// <summary>
        ///// 获取所有流程发起权限
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("all")]
        //public async Task<Result<List<ProcessLaunchPermissionDto>>> GetAllProcessLaunchPermission()
        //{
        //    return await _processLaunchPermissionAppService.GetAllProcessLaunchPermission();
        //}
    }
}
