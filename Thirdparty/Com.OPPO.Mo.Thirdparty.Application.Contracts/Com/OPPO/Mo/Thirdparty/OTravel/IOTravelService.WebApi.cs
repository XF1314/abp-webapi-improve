using Com.OPPO.Mo.Thirdparty.OTravel.Request;
using Com.OPPO.Mo.Thirdparty.OTravel.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.OTravel
{

    /// <summary>
    /// 出差申请-OTravel服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.OTravelWebApiHost)]
    public interface IOTravelWebApiService : IHttpApi
    {


        /// <summary>
        /// 更新商旅国家城市
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/wsapi/zas/srvrectenant/process")]
        Task<TravelAreaResponse<List<TravelArea>>> OTravelAreaQuery([FormContent]TravelAreaRequest request);

        /// <summary>
        /// 将出差单详情推送给商旅
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/wsapi/errand/srvrectenant/process")]
        Task<TravelAreaResponse> TravelDetailsPush([FormContent]TravelDetailsRequest request);


        /// <summary>
        /// 出差单状态同步
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/wsapi/errand/srvrectenant/process")]
        Task<TravelAreaResponse> TravelBillStatusSync([FormContent]TravelBillStatusRequest request);

    }

}
