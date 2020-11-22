using Com.OPPO.Mo.Bpm.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Bpm
{
   /// <summary>
   /// Bpm业务对象表权限应用服务接口
   /// </summary>
    public interface IBpmBusinessObjectTablePermissionAppService : IApplicationService
    {
        /// <summary>
        /// 授予业务对象表权限
        /// </summary>
        /// <param name="businessObjectTablePermissionGrantInput"><see cref="BusinessObjectTablePermissionGrantInput"/></param>
        /// <returns></returns>
        Task<Result<BusinessObjectTablePermissionDto>> GrantBusinessObjectTablePermission(BusinessObjectTablePermissionGrantInput businessObjectTablePermissionGrantInput);

        /// <summary>
        /// 批量授予业务对象表权限
        /// </summary>
        /// <param name="businessObjectTablePermissionBatchGrantInput"><see cref="BusinessObjectTablePermissionBatchGrantInput"/></param>
        /// <returns></returns>
        Task<Result<List<BusinessObjectTablePermissionDto>>> BatchGrantBusinessObjectTablePermission(BusinessObjectTablePermissionBatchGrantInput businessObjectTablePermissionBatchGrantInput);

        /// <summary>
        /// 失效业务对象表权限
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="businessObjectTableName">业务对象表名称</param>
        /// <returns></returns>
        Task<Result<BusinessObjectTablePermissionDto>> InvalidateBusinessObjectTablePermission(string appId, string businessObjectTableName);

        /// <summary>
        /// 失效业务对象表权限
        /// </summary>
        /// <param name="permissionId">业务对象表权限Id</param>
        /// <returns></returns>
        Task<Result<BusinessObjectTablePermissionDto>> InvalidateBusinessObjectTablePermission(Guid permissionId);

        /// <summary>
        /// 生效业务对象表权限
        /// </summary>
        /// <param name="permissionId">业务对象表权限Id</param>
        /// <returns></returns>
        Task<Result<BusinessObjectTablePermissionDto>> ValidateBusinessObjectTablePermission(Guid permissionId);

        /// <summary>
        /// 生效业务对象表权限
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="businessObjectTableName">业务对象表名称</param>
        /// <returns></returns>
        Task<Result<BusinessObjectTablePermissionDto>> ValidateBusinessObjectTablePermission(string appId, string businessObjectTableName);

        /// <summary>
        /// 取消业务对象表权限
        /// </summary>
        /// <param name="permissionId">业务对象表权限Id</param>
        /// <returns></returns>
        Task<Result> RevokeBusinessObjectTablePermission(Guid permissionId);

        /// <summary>
        /// 获取业务对象表权限
        /// </summary>
        /// <param name="permissionId">业务对象表权限Id</param>
        /// <returns></returns>
        Task<Result<BusinessObjectTablePermissionDto>> GetBusinessObjectTablePermission(Guid permissionId);

        /// <summary>
        /// 查询业务对象表权限
        /// </summary>
        /// <param name="businessObjectTablePermissionQueryInput"><see cref="BusinessObjectTablePermissionQueryInput"/></param>
        /// <returns></returns>
        Task<Result<List<BusinessObjectTablePermissionDto>>> QueryBusinessObjectTablePermission(BusinessObjectTablePermissionQueryInput businessObjectTablePermissionQueryInput);

        /// <summary>
        /// 获取所有业务对象表权限
        /// </summary>
        /// <returns></returns>
        Task<Result<List<BusinessObjectTablePermissionDto>>> GetAllBusinessObjectTablePermission();


    }
}
