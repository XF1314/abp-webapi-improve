using Com.OPPO.Mo.Bpm.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Com.OPPO.Mo.Bpm.Repositories
{
    /// <summary>
    /// 流程发起权限仓储接口
    /// </summary>
    public interface IProcessLaunchPermissionRepository : IMoBasicRepository<ProcessLaunchPermission, Guid>
    {
        /// <summary>
        /// 获取流程发起权限
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="processDefinitionId">流程定义Id</param>
        /// <returns></returns>
        Task<ProcessLaunchPermission> GetProcessLaunchPermission(string appId, string processDefinitionId); 
    }
}
