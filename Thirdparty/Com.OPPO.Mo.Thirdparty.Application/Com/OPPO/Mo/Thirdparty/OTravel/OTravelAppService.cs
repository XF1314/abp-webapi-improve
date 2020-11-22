using Com.OPPO.Mo.Thirdparty.OTravel.Dto;
using Com.OPPO.Mo.Thirdparty.OTravel.Request;
using Com.OPPO.Mo.Thirdparty.OTravel.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.OTravel
{

    [Authorize]
    public class OTravelAppService : ThirdpartyAppServiceBase, IOTravelAppService
    {
        private readonly IConfiguration _configuration;
        private readonly IOTravelWebApiService _EsbService;

        public OTravelAppService(
            IConfiguration configuration,
            IOTravelWebApiService peopleSoftLeaveEsbService)
        {
            _configuration = configuration;
            _EsbService = peopleSoftLeaveEsbService;
        }

        /// <summary>
        /// 查询商旅国家城市【第三方接口：/wsapi/zas/srvrectenant/process】
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        public async Task<Result<List<TravelArea>>> OTravelAreaQuery(TravelAreaQueryDto queryDto)
        {

            var request = new TravelAreaRequest()
            {
                Data = JsonConvert.SerializeObject(queryDto)
            };

            var response = await _EsbService.OTravelAreaQuery(request);

            if (response.IsSuccess)
                return Result.Ok(response.Data);
            else
            {
                var message = $"【{response.Code}】{response.Message}";
                Logger.LogWarning(message);
                return Result.FromError<List<TravelArea>>(message);
            }
        }

        /// <summary>
        /// 将出差单详情推送给商旅【第三方接口：/wsapi/errand/srvrectenant/process】
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        public async Task<Result> TravelDetailsPush(TravelDetailsDto queryDto)
        {

            var request = new TravelDetailsRequest()
            {
                Data = JsonConvert.SerializeObject(queryDto)
            };

            var response = await _EsbService.TravelDetailsPush(request);

            if (response.IsSuccess)
                return Result.Ok(response.Message);
            else
            {
                var message = $"【{response.Code}】{response.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }

        /// <summary>
        /// 出差单状态同步给商旅【第三方接口：/wsapi/errand/srvrectenant/process】
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        public async Task<Result> TravelBillStatusSync(TravelBillStatusDto queryDto)
        {

            var request = new TravelBillStatusRequest()
            {
                Data = JsonConvert.SerializeObject(queryDto)
            };

            var response = await _EsbService.TravelBillStatusSync(request);

            if (response.IsSuccess)
                return Result.Ok(response.Message);
            else
            {
                var message = $"【{response.Code}】{response.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }


    }


}
