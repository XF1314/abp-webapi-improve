using Com.OPPO.Mo.Thirdparty.Sms.Requests;
using Com.OPPO.Mo.Thirdparty.Sms.Responses;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Sms.Services
{
    /// <summary>
    /// Sms  WebApi Service
    /// </summary>
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.SmsWebApiHost)]
    public interface ISmsWebApiService : IHttpApi
    {
        /// <summary>
        /// 短息发送
        /// <param name="request"><see cref="SmsRequest"/></param>
        /// </summary>
        /// <returns></returns>
        [HttpPost("/gate/api/single_sms")]
        Task<SmsResponse> SingleSms([JsonContent] SmsRequest request);
    }
}
