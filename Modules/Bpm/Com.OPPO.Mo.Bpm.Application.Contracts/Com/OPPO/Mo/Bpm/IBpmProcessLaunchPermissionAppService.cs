using Com.OPPO.Mo.Bpm.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Bpm流程发起权限应用服务接口
    /// </summary>
    public interface IBpmProcessLaunchPermissionAppService : IApplicationService
    {
        /// <summary>
        /// 授予流程发起权限
        /// </summary>
        /// <param name="processLaunchPermissionGrantInput"><see cref="ProcessLaunchPermissionGrantInput"/></param>
        /// <returns></returns>
        Task<Result<ProcessLaunchPermissionDto>> GrantProcessLaunchPermission(ProcessLaunchPermissionGrantInput processLaunchPermissionGrantInput);

        /// <summary>
        /// 批量授予流程发起权限
        /// </summary>
        /// <param name="processLaunchPermissionBatchGrantInput"><see cref="ProcessLaunchPermissionBatchGrantInput"/></param>
        /// <returns></returns>
        Task<Result<List<ProcessLaunchPermissionDto>>> BatchGrantProcessLaunchPermission(ProcessLaunchPermissionBatchGrantInput processLaunchPermissionBatchGrantInput);

        /// <summary>
        /// 失效流程发起权限
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="processDefinitionId">流程定义Id</param>
        /// <returns></returns>
        Task<Result<ProcessLaunchPermissionDto>> InvalidateProcessLaunchPermission(string appId, string processDefinitionId);

        /// <summary>
        /// 失效流程发起权限
        /// </summary>
        /// <param name="permissionId">流程发起权限Id</param>
        /// <returns></returns>
        Task<Result<ProcessLaunchPermissionDto>> InvalidateProcessLaunchPermission(Guid permissionId);

        /// <summary>
        /// 生效流程发起权限
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="processDefinitionId">流程定义Id</param>
        /// <returns></returns>
        Task<Result<ProcessLaunchPermissionDto>> ValidateProcessLaunchPermission(string appId, string processDefinitionId);

        /// <summary>
        /// 生效流程发起权限
        /// </summary>
        /// <param name="permissionId">流程发起权限Id</param>
        /// <returns></returns>
        Task<Result<ProcessLaunchPermissionDto>> ValidateProcessLaunchPermission(Guid permissionId);

        /// <summary>
        /// 取消流程发起权限
        /// </summary>
        /// <param name="permissionId">流程发起权限Id</param>
        /// <returns></returns>
        Task<Result> RevokeProcessLaunchPermission(Guid permissionId);

        /// <summary>
        /// 获取流程发起权限
        /// </summary>
        /// <param name="permissionId">流程发起权限Id</param>
        /// <returns></returns>
        Task<Result<ProcessLaunchPermissionDto>> GetProcessLaunchPermission(Guid permissionId);

        /// <summary>
        /// 查询流程发起权限
        /// </summary>
        /// <param name="processLaunchPermissionQueryInput"><see cref="ProcessLaunchPermissionQueryInput"/></param>
        /// <returns></returns>
        Task<Result<List<ProcessLaunchPermissionDto>>> QueryProcessLaunchPermission(ProcessLaunchPermissionQueryInput processLaunchPermissionQueryInput);

        /// <summary>
        /// 获取所有流程发起权限
        /// </summary>
        /// <returns></returns>
        Task<Result<List<ProcessLaunchPermissionDto>>> GetAllProcessLaunchPermission();


    }
}
