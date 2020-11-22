using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Com.OPPO.Mo.Bpm.Repositories
{
    /// <summary>
    /// 业务对象归属仓储接口
    /// </summary>
    public interface IBusinessObjectBelongRepository : IMoBasicRepository<BusinessObjectBelong, Guid>
    {
        /// <summary>
        /// 根据业务对象Id获取业务对象归属
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="businessObjectId">业务对象Id</param>
        /// <returns></returns>
        Task<BusinessObjectBelong> GetBusinessObjectBelongByBusinessObjectId(string appId,string businessObjectId);

        /// <summary>
        /// 根据流程实例Id获取业务对象归属
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="BusinessObjectTableName">业务对象表名称</param>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <returns></returns>
        Task<BusinessObjectBelong> GetBusinessObjectBelongByProcessInstanceId(string appId, string BusinessObjectTableName, string processInstanceId);

    }
}
