using Com.OPPO.Mo.Thirdparty.Hr.LMS.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.LMS.Requests;
using Com.OPPO.Mo.Thirdparty.Hr.LMS.Responses;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Hr.LMS.Service
{
    /// <summary>
    /// PeopleSoft 离职 Esb服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IPeopleSofLmsService : IHttpApi
    {
        /// <summary>
        /// 更新离职信息
        /// </summary>
        /// <param name="request"><see cref="LmsRequest"/></param>
        /// <returns></returns>
        [HttpPost("/oppo/it/lms_dimissionnew_update")]
        Task<LmsResponse<LmsInfo>> DimissionnewUpdate([FormContent] LmsRequest request);

    }
}
