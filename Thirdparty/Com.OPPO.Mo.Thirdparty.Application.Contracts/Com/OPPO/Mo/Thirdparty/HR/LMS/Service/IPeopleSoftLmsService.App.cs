using Com.OPPO.Mo.Thirdparty.Hr.LMS.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.LMS.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Hr.LMS.Service
{
    /// <summary>
    /// 人员离职接口
    /// </summary>
    public interface IPeopleSoftLmsAppService : IApplicationService
    {
        /// <summary>
        /// LMS更新离职信息
        /// </summary>
        /// <param name="input">离职信息</param>
        /// <returns></returns>
        Task<Result<LmsDto>> DimissionNewUpdate(LmInput input);

        /// <summary>
        /// 离职信息同步接口
        /// </summary>
        /// <param name="input">离职信息</param>
        /// <returns></returns>
        Task<Result<SyncMsgDto>> SyncApprovalMsg(LmSyncMsgInput input);

        /// <summary>
        /// 同步审批人变更接口
        /// </summary>
        /// <param name="request">变更信息</param>
        /// <returns></returns>
        Task<Result<SyncMsgDto>> Approve(LmsModifyApproveRequest request);

        /// <summary>
        /// 检测员工是否已提交离职申请
        /// </summary>
        /// <param name="accounts">工号</param>
        /// <returns></returns>
        Task<Result<SyncMsgDto>> CheckApply(List<string> accounts);
    }
}
