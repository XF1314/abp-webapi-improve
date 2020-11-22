using Com.OPPO.Mo.Bpm.ActionSoft.Organiztion.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Organiztion
{
    /// <summary>
    /// ActionSoft组织架构WebApi服务接口
    /// </summary>
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(BpmSettingNames.ActiontSoftWebApiHost)]
    public interface IActionSoftOrganizationWebApiService : IHttpApi
    {
        /// <summary>
        /// 获取员工姓名
        /// </summary>
        /// <param name="uerNamesGetByUserCodesRequest"><see cref="ActionSoftUserNamesGetByUserCodesRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<string>> GetUserNames([FormContent] ActionSoftUserNamesGetByUserCodesRequest uerNamesGetByUserCodesRequest);
    }
}
