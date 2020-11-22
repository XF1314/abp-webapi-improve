
using Com.OPPO.Mo.Thirdparty.OTravel.Dto;
using Com.OPPO.Mo.Thirdparty.OTravel.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.OTravel
{
    /// <summary>
    /// 出差申请
    /// </summary>
    [Area("otravel")]
    [Route("api/mo/thirdparty/otravel")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class OTravelController : AbpController, IOTravelAppService
    {
        private readonly IOTravelAppService  _OTravelAppService;

        public OTravelController(IOTravelAppService OTravelAppService)
        {
            _OTravelAppService = OTravelAppService;
        }

        /// <summary>
        /// 查询商旅国家城市【第三方接口：/wsapi/zas/srvrectenant/process】
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        [HttpPost("query-travel-area-data")]
        public async Task<Result<List<TravelArea>>> OTravelAreaQuery(TravelAreaQueryDto queryDto)
        {
            return await _OTravelAppService.OTravelAreaQuery(queryDto);
        }

        /// <summary>
        /// 将出差单详情推送给商旅【第三方接口：/wsapi/errand/srvrectenant/process】
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        [HttpPost("travel-details-push")]
        public async Task<Result> TravelDetailsPush(TravelDetailsDto queryDto)
        {
            return await _OTravelAppService.TravelDetailsPush(queryDto);
        }

        /// <summary>
        /// 出差单状态同步给商旅【第三方接口：/wsapi/errand/srvrectenant/process】
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        [HttpPost("travel-bill-status-sync")]
        public async Task<Result> TravelBillStatusSync(TravelBillStatusDto queryDto)
        {
            return await _OTravelAppService.TravelBillStatusSync(queryDto);
        }

    }
}
