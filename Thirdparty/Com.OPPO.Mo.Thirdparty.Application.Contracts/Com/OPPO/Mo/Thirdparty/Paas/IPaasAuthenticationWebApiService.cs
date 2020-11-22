using Com.OPPO.Mo.Thirdparty.Paas.Requests;
using Com.OPPO.Mo.Thirdparty.Paas.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Paas
{
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(PaasSettingNames.PaasAppHost)]
    public interface IPaasAuthenticationWebApiService :IHttpApi
    {
        /// <summary>
        /// 应用登录
        /// </summary>
        /// <param name="paasAppLoginRequest"><see cref="PaasAppLoginRequest"/></param>
        /// <param name="ternatId">租户</param>
        /// <returns></returns>
        [HttpPost("/xpaas-console-api/api/v1/acApps/thirdAppLogin")]
        Task<PaasPayloadResponse<PaasTokenInfo>> AppLogin( [JsonContent] PaasAppLoginRequest paasAppLoginRequest, [PathQuery] string ternatId = "oppo");

    }
}
