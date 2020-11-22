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
    /// Bpm流程实例归属应用服务接口
    /// </summary>
    public interface IBpmProcessInstanceBelongAppService : IApplicationService
    {
        /// <summary>
        /// 授予流程实例归属
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <param name="appId">应用Id</param>
        /// <returns></returns>
        Task<Result<ProcessInstanceBelongDto>> GrantProcessInstanceBelong(string processInstanceId, string appId);

        /// <summary>
        /// 获取流程实例归属
        /// </summary>
        /// <param name="belongId">流程实例归属Id</param>
        /// <returns></returns>
        Task<Result<ProcessInstanceBelongDto>> GetProcessInstanceBelong(Guid belongId);

        /// <summary>
        /// 取消流程实例归属
        /// </summary>
        /// <param name="belongId">流程实例归属Id</param>
        /// <returns></returns>
        Task<Result> RevokeProcessInstanceBelong(Guid belongId);

        /// <summary>
        /// 查询流程实例归属
        /// </summary>
        /// <param name="processInstanceBelongQueryInput"><see cref="ProcessInstanceBelongQueryInput"/></param>
        /// <returns></returns>
        Task<QueryResult<ProcessInstanceBelongDto>> QueryProcessInstanceBelong(ProcessInstanceBelongQueryInput processInstanceBelongQueryInput);

        /// <summary>
        /// 分页查询流程实例归属
        /// </summary>
        /// <param name="processInstanceBelongPageQueryInput"><see cref="ProcessInstanceBelongPageQueryInput"/></param>
        /// <returns></returns>
        Task<PageQueryResult<ProcessInstanceBelongDto>> PageQueryProcessInstanceBelong(ProcessInstanceBelongPageQueryInput processInstanceBelongPageQueryInput);
    }
}
