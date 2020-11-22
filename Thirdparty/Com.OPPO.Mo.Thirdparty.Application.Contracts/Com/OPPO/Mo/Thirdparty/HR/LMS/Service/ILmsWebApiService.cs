using Com.OPPO.Mo.Thirdparty.Hr.LMS.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.LMS.Requests;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Hr.LMS.Service
{
    /// <summary>
    /// PeopleSoft 离职 LMS服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.LmsWebApiHost)]
    public interface ILmsWebApiService : IHttpApi
    {
        /// <summary>
        /// 更新离职信息
        /// </summary>
        /// <param name="request"><see cref="LmSyncMsgRequest"/></param>
        /// <returns></returns>
        [HttpPost("/opinion/sync/approval/msg")]
        Task<SyncMsgInfo> SyncApprovalMsg([JsonContent] LmSyncMsgRequest request);

        /// <summary>
        /// 同步审批人变更接口
        /// </summary>
        /// <param name="request"><see cref="LmsModifyApproveRequest"/></param>
        /// <returns></returns>
        [HttpPost("/opinion/modify/approve")]
        Task<SyncMsgInfo> ModifyApprove([JsonContent] LmsModifyApproveRequest request);

        /// <summary>
        /// 检测员工是否已提交离职申请
        /// </summary>
        /// <param name="request"><see cref="LmsApplyCheckRequest"/></param>
        /// <returns></returns>
        [HttpPost("/apply/check/staff")]
        Task<SyncMsgInfo> ApplyCheck([JsonContent] LmsApplyCheckRequest request);

    }
}
