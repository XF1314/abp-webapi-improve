using Com.OPPO.Mo.Thirdparty.Hr.PsHr.Request;
using Com.OPPO.Mo.Thirdparty.Hr.PsHr.Response;
using Com.OPPO.Mo.Thirdparty.Upm.Requests;
using Com.OPPO.Mo.Thirdparty.Upm.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Upm
{
    /// <summary>
    /// PeopleSoft内部调动Esb服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IUpmEsbService : IHttpApi
    {
        /// <summary>
        /// 查询用户有授权的it系统[]
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        //[HttpGet("/oppo/upm/user/perm/app/list")]
        //Task<UpmBaseResponse<List<AuthorizationSystem>>> GetUserPermAppList([PathQuery]AuthorizationSystemQuery query);

        /// <summary>
        /// UPM权限变更通知【第三方接口：/oppo/upm/delivery/mq】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/oppo/upm/delivery/mq")]
        Task<UpmBaseResponse> AuthorityChangeToUPM([FormContent]AuthorityChangeRequest query);

    }
}
