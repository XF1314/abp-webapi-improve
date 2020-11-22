using Com.OPPO.Mo.Bpm.ActionSoft.Extensions.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Extensions
{
    /// <summary>
    /// ActionSoft扩展WebApi服务接口
    /// </summary>
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(BpmSettingNames.ActiontSoftWebApiHost)]
    public interface IActionSoftExtensionWebApiService : IHttpApi
    {
        /// <summary>
        /// 获取访问Token
        /// </summary>
        /// <param name="actionSoftSessionIdGetRequest"><see cref="ActionSoftSessionIdGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<string>> GetAccessToken([FormContent] ActionSoftSessionIdGetRequest actionSoftSessionIdGetRequest);

        /// <summary>
        /// 调用Aslp服务
        /// </summary>
        /// <param name="actionSoftAslpCallRequest"><see cref="ActionSoftAslpCallRequest{ActionSoftProcessPredicatParams}"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<string> CallAslp([FormContent] ActionSoftAslpCallRequest<ActionSoftProcessPredictParams> actionSoftAslpCallRequest);

    }
}
