using Com.OPPO.Mo.Thirdparty.Visitors.Request;
using Com.OPPO.Mo.Thirdparty.Visitors.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Visitors
{
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    public interface IVisitorsApiService : IHttpApi
    {
        /// <summary>
        /// 门禁道闸权限下发
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/oppo/visitors/authercate_data_push")]
        Task<EsbResponse> AuthercateDataPush([FormContent]AuthercateDataPush query);

        /// <summary>
        /// 门禁类型视图
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/oppo/visitors/get_mjtype")]
        Task<AccessControlTypeViewResponse> GetAccessControlTypeView([PathQuery]BaseEsbRequest query);

        /// <summary>
        /// 门禁类型视图(新)
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/oppo/visitors/get_mo_MJDetail")]
        Task<NewAccessControlTypeViewResponse> GetAccessControlTypeViewNew([PathQuery]BaseEsbRequest query);
    }
}
