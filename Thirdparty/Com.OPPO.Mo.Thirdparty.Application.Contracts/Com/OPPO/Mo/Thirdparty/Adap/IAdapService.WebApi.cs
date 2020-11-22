using Com.OPPO.Mo.Thirdparty.Adap.Dto;
using Com.OPPO.Mo.Thirdparty.Adap.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Adap
{

    /// <summary>
    /// 出差申请-数字行政服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.AdapWebApiHost)]
    public interface IAdapWebApiService : IHttpApi
    {

        /// <summary>
        /// 推送出差申请数据到数字行政
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/s/api/travelApply/pushTravelInfo")]
        Task<TravelResponse> TravelInfoPush([JsonContent]TravelInfoDto request);


    }

}
