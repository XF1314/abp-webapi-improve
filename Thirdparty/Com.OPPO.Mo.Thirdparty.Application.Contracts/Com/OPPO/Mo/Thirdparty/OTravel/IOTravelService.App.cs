using Com.OPPO.Mo.Thirdparty.OTravel.Dto;
using Com.OPPO.Mo.Thirdparty.OTravel.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.OTravel
{

    /// <summary>
    /// OTravel-出差申请应用服务接口
    /// </summary>
    public interface IOTravelAppService : IApplicationService
    {

        /// <summary>
        /// 查询商旅国家城市
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        Task<Result<List<TravelArea>>> OTravelAreaQuery(TravelAreaQueryDto queryDto);


        /// <summary>
        /// 将出差单详情推送给商旅
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        Task<Result> TravelDetailsPush(TravelDetailsDto queryDto);


        /// <summary>
        /// 出差单状态同步
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<Result> TravelBillStatusSync(TravelBillStatusDto status);
    }
}
