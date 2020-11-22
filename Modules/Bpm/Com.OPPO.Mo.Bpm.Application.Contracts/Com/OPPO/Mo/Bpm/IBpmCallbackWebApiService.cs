using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Bpm回调WebApi服务接口
    /// </summary>
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    public interface IBpmCallbackWebApiService : IHttpApi
    {
        /// <summary>
        /// 回调
        /// </summary>
        /// <param name="callbackUrl">回调Url</param>
        /// <param name="headers">请求头参数s</param>
        /// <param name="params">回调参数s</param>
        /// <returns></returns>
        [HttpPost]
        Task<string> Callback([Uri] string callbackUrl, [Headers] Dictionary<string, string> headers = null, [JsonContent] Dictionary<string, string> @params = null);
    }
}
