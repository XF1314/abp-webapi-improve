using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Com.OPPO.Mo.Bpm.Repositories
{
    /// <summary>
    /// Eai任务实例归属仓储接口
    /// </summary>
    public interface IEaiTaskInstanceBelongRepository : IMoBasicRepository<EaiTaskInstanceBelong, Guid>
    {
        /// <summary>
        /// 根据任务实例Id获取任务实例归属
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="EaiTaskInstanceId">Eai任务实例Id</param>
        /// <returns></returns>
        Task<EaiTaskInstanceBelong> GetTaskInstanceBelongByInstanceId(string appId, string taskInstanceId);

        /// <summary>
        /// 根据任务业务Id获取任务实例归属
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="taskInstanceId">任务业务Id</param>
        /// <returns></returns>
        Task<EaiTaskInstanceBelong> GetTaskInstanceBelongByTaskBizId(string appId, string taskBizId);


    }
}
