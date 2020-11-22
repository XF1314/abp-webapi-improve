using Com.OPPO.Mo.Thirdparty.Hr.Requests;
using Com.OPPO.Mo.Thirdparty.Hr.Responses;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Hr.Services
{
    /// <summary>
    /// PS系统员工批量请假申请接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface ILeaveBatchWebApiService : IHttpApi
    {
        [HttpPost("/oppo/ps/leave_batch_push")]
        Task<LeaveBatchResponses> LeaveBatchPust([FormContent]LeaveBatchRequest LeaveBatchRequest);
        [HttpPost("/oppo/visitors/leave_push")]
        Task<LeaveBatchResponses> LeaveBatchVisitorsPush([FormContent] LeaveBatchVisitorRequest LeaveBatchRequest);
    }
}
