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
    /// Bpm Eai任务实例归属应用服务接口
    /// </summary>
    public interface IBpmEaiTaskInstanceBelongAppService : IApplicationService
    {
        /// <summary>
        /// 授予Eai任务实例归属
        /// </summary>
        /// <param name="eaiTaskInstanceId">Eai任务实例Id</param>
        /// <param name="appId">应用Id</param>
        /// <returns></returns>
        Task<Result<EaiTaskInstanceBelongDto>> GrantEaiTaskInstanceBelong(string eaiTaskInstanceId, string appId);

        /// <summary>
        /// 获取Eai任务实例归属
        /// </summary>
        /// <param name="belongId">Eai任务实例归属Id</param>
        /// <returns></returns>
        Task<Result<EaiTaskInstanceBelongDto>> GetEaiTaskInstanceBelong(Guid belongId);

        /// <summary>
        /// 查询Eai任务实例归属
        /// </summary>
        /// <param name="eaiTaskInstanceBelongQueryInput"><see cref="EaiTaskInstanceBelongQueryInput"/></param>
        /// <returns></returns>
        Task<QueryResult<EaiTaskInstanceBelongDto>> QueryEaiTaskInstanceBelong(EaiTaskInstanceBelongQueryInput eaiTaskInstanceBelongQueryInput);

        /// <summary>
        /// 分页查询Eai任务实例归属
        /// </summary>
        /// <param name="eaiTaskInstanceBelongPageQueryInput"><see cref="EaiTaskInstanceBelongPageQueryInput"/></param>
        /// <returns></returns>
        Task<PageQueryResult<EaiTaskInstanceBelongDto>> PageQueryEaiTaskInstanceBelong(EaiTaskInstanceBelongPageQueryInput eaiTaskInstanceBelongPageQueryInput);

        /// <summary>
        /// 删除Eai任务实例归属
        /// </summary>
        /// <param name="belongId">Eai任务实例归属Id</param>
        /// <returns></returns>
        Task<Result> RevokeEaiTaskInstanceBelong(Guid belongId);

    }
}
