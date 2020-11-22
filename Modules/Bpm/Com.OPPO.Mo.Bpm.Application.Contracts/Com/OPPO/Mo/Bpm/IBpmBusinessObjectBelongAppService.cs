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
    /// Bpm业务对象归属应用服务接口
    /// </summary>
    public interface IBpmBusinessObjectBelongAppService : IApplicationService
    {
        /// <summary>
        /// 授予业务对象归属
        /// </summary>
        /// <param name="businessObjectId">业务对象Id</param>
        /// <param name="appId">应用Id</param>
        /// <returns></returns>
        Task<Result<BusinessObjectBelongDto>> GrantBusinessObjectBelong(string businessObjectId, string appId);

        /// <summary>
        /// 获取业务对象归属
        /// </summary>
        /// <param name="belongId">业务对象归属Id</param>
        /// <returns></returns>
        Task<Result<BusinessObjectBelongDto>> GetBusinessObjectBelong(Guid belongId);

        /// <summary>
        /// 删除业务对象归属
        /// </summary>
        /// <param name="belongId">业务对象归属Id</param>
        /// <returns></returns>
        Task<Result> DeleteBusinessObjectBelong(Guid belongId);

        /// <summary>
        /// 查询业务对象归属
        /// </summary>
        /// <param name="businessObjectBelongQueryInput"><see cref="BusinessObjectBelongQueryInput"/></param>
        /// <returns></returns>
        Task<Result<List<BusinessObjectBelongDto>>> QueryBusinessObjectBelong(BusinessObjectBelongQueryInput businessObjectBelongQueryInput);

        /// <summary>
        /// 分页查询业务对象归属
        /// </summary>
        /// <param name="businessObjectBelongPageQueryInput"><see cref="BusinessObjectBelongPageQueryInput"/></param>
        /// <returns></returns>
        Task<PageQueryResult<BusinessObjectBelongDto>> PageQueryBusinessObjectBelong(BusinessObjectBelongPageQueryInput businessObjectBelongPageQueryInput);
    }
}
