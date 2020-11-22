using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Com.OPPO.Mo.Bpm.Repositories
{
    /// <summary>
    /// 业务对象表权限仓储接口
    /// </summary>
    public interface IBusinessObjectTablePermissionRepository : IMoBasicRepository<BusinessObjectTablePermission, Guid>
    {
        /// <summary>
        /// 获取业务对象表权限
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="businessObjectTableName">业务对象表名称</param>
        /// <returns></returns>
        Task<BusinessObjectTablePermission> GetBusinessObjectTablePermission(string appId, string businessObjectTableName);

    }
}
