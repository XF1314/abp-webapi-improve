using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Com.OPPO.Mo.Bpm.Repositories
{
    /// <summary>
    /// 流程实例归属仓储接口
    /// </summary>
    public interface IProcessInstanceBelongRepository : IMoBasicRepository<ProcessInstanceBelong, Guid>
    {
        /// <summary>
        /// 根据流程实例Id获取流程实例归属
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <returns></returns>
        Task<ProcessInstanceBelong> GetProcessInstanceBelongByInstanceId(string appId, string processInstanceId);

        /// <summary>
        ///  根据流程实例Ids获取流程实例归属s
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="processInstanceIds">流程实例Ids</param>
        /// <returns></returns>
        Task<List<ProcessInstanceBelong>> GetProcessInstanceBelongsByInstanceIds(string appId, List<string> processInstanceIds);

        /// <summary>
        /// 根据流程实例编码获取流程实例归属
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="processInstanceCode">流程实例编码</param>
        /// <returns></returns>
        Task<ProcessInstanceBelong> GetProcessInstanceBelongByInstanceCode(string appId, string processInstanceCode);

        /// <summary>
        /// 根据流程实例编码s获取流程实例归属s
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="processInstanceCodes">流程实例编码s</param>
        /// <returns></returns>
        Task<List<ProcessInstanceBelong>> GetProcessInstanceBelongsByInstanceCodes(string appId, List<string> processInstanceCodes);

    }
}
