using Com.OPPO.Mo.Bpm;
using Com.OPPO.Mo.Bpm.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.BPM
{
    /// <summary>
    /// 业务对象表权限
    /// </summary>
    [Area("bpm")]
    [Route("api/mo/bpm/business-object-table-permission")]
    public class BpmBusinessObjectTablePermissionController : AbpController
    {
        private IBpmBusinessObjectTablePermissionAppService _businessObjectSetPermissionAppService;

        /// <summary>
        /// <see cref="BpmBusinessObjectTablePermissionController"/>
        /// </summary>
        public BpmBusinessObjectTablePermissionController(IBpmBusinessObjectTablePermissionAppService businessObjectSetPermissionGrantAppService)
        {
            _businessObjectSetPermissionAppService = businessObjectSetPermissionGrantAppService;
        }

        /// <summary>
        /// 授予业务对象表权限
        /// </summary>
        /// <param name="businessObjectSetPermissionAddInput"><see cref="BusinessObjectTablePermissionGrantInput"/></param>
        /// <returns></returns>
        [HttpPost("grant")]
        public async Task<Result<BusinessObjectTablePermissionDto>> GrantBusinessObjectTablePermission([FromBody]BusinessObjectTablePermissionGrantInput businessObjectSetPermissionAddInput)
        {
            return await _businessObjectSetPermissionAppService.GrantBusinessObjectTablePermission(businessObjectSetPermissionAddInput);
        }

        /// <summary>
        /// 批量授予业务对象表权限
        /// </summary>
        /// <param name="businessObjectTablePermissionBatchGrantInput"><see cref="BusinessObjectTablePermissionBatchGrantInput"/></param>
        /// <returns></returns>
        [HttpPost("batch-grant")]
        public async Task<Result<List<BusinessObjectTablePermissionDto>>> BatchGrantBusinessObjectTablePermission([FromBody]BusinessObjectTablePermissionBatchGrantInput businessObjectTablePermissionBatchGrantInput)
        {
            return await _businessObjectSetPermissionAppService.BatchGrantBusinessObjectTablePermission(businessObjectTablePermissionBatchGrantInput);
        }

        /// <summary>
        /// 失效业务对象表权限
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="businessObjectTableName">业务对象表名称</param>
        /// <returns></returns>
        [HttpPost("invalidate")]
        public async Task<Result<BusinessObjectTablePermissionDto>> InvalidateBusinessObjectTablePermission(string appId, string businessObjectTableName)
        {
            return await _businessObjectSetPermissionAppService.InvalidateBusinessObjectTablePermission(appId, businessObjectTableName);
        }

        /// <summary>
        /// 失效业务对象表权限
        /// </summary>
        /// <param name="permissionId">业务对象表权限Id</param>
        /// <returns></returns>
        [HttpPost("invalidate-by-id")]
        public async Task<Result<BusinessObjectTablePermissionDto>> InvalidateBusinessObjectTablePermission(Guid permissionId)
        {
            return await _businessObjectSetPermissionAppService.InvalidateBusinessObjectTablePermission(permissionId);
        }

        /// <summary>
        /// 生效业务对象表权限
        /// </summary>
        /// <param name="permissionId">业务对象表权限Id</param>
        /// <returns></returns>
        [HttpPost("validate-by-id")]
        public async Task<Result<BusinessObjectTablePermissionDto>> ValidateBusinessObjectTablePermission(Guid permissionId)
        {
            return await _businessObjectSetPermissionAppService.ValidateBusinessObjectTablePermission(permissionId);
        }

        /// <summary>
        /// 生效业务对象表权限
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="businessObjectTableName">业务对象表名称</param>
        /// <returns></returns>
        [HttpPost("validate")]
        public async Task<Result<BusinessObjectTablePermissionDto>> ValidateBusinessObjectTablePermission(string appId, string businessObjectTableName)
        {
            return await _businessObjectSetPermissionAppService.ValidateBusinessObjectTablePermission(appId, businessObjectTableName);
        }

        /// <summary>
        /// 取消业务对象表权限
        /// </summary>
        /// <param name="permissionId">业务对象表权限Id</param>
        /// <returns></returns>
        [HttpDelete("revoke-by-id")]
        public async Task<Result> RevokeBusinessObjectTablePermission(Guid permissionId)
        {
            return await _businessObjectSetPermissionAppService.RevokeBusinessObjectTablePermission(permissionId);
        }

        /// <summary>
        /// 获取业务对象表权限
        /// </summary>
        /// <param name="permissionId">业务对象表权限Id</param>
        /// <returns></returns>
        [HttpGet("get-by-id")]
        public async Task<Result<BusinessObjectTablePermissionDto>> GetBusinessObjectTablePermission(Guid permissionId)
        {
            return await _businessObjectSetPermissionAppService.GetBusinessObjectTablePermission(permissionId);
        }

        /// <summary>
        /// 查询业务对象表权限
        /// </summary>
        /// <param name="businessObjectTablePermissionQueryInput"><see cref="BusinessObjectTablePermissionQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("query")]
        public async Task<Result<List<BusinessObjectTablePermissionDto>>> QueryBusinessObjectTablePermission([FromBody] BusinessObjectTablePermissionQueryInput businessObjectTablePermissionQueryInput)
        {
            return await _businessObjectSetPermissionAppService.QueryBusinessObjectTablePermission(businessObjectTablePermissionQueryInput);
        }

        ///// <summary>
        ///// 获取所有业务对象表权限
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("all")]
        //public async Task<Result<List<BusinessObjectTablePermissionDto>>> GetAllBusinessObjectTablePermission()
        //{
        //    return await _businessObjectSetPermissionAppService.GetAllBusinessObjectTablePermission();
        //}
    }
}
