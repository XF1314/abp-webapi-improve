using Com.OPPO.Mo.Thirdparty.Hr.LMS.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.LMS.Requests;
using Com.OPPO.Mo.Thirdparty.Hr.LMS.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Hr
{
    /// <summary>
    /// 离职资源
    /// </summary>
    [Area("lms")]
    [Route("api/mo/thirdparty/hr/lms")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class LmsController : AbpController, IPeopleSoftLmsAppService
    {
        private readonly IPeopleSoftLmsAppService _peopleSoftDimissioonAppService;

        public LmsController(IPeopleSoftLmsAppService peopleSoftDimissioonAppService)
        {
            _peopleSoftDimissioonAppService = peopleSoftDimissioonAppService;
        }

        /// <summary>
        /// LMS更新离职信息 【第三方接口 /oppo/it/lms_dimissionnew_update】
        /// </summary>
        /// <param name="input">离职信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("lms-dimissionnew-update")]
        public async Task<Result<LmsDto>> DimissionNewUpdate(LmInput input)
        {
            return await _peopleSoftDimissioonAppService.DimissionNewUpdate(input);
        }

        /// <summary>
        /// 离职信息同步接口 【第三方接口 /opinion/sync/approval/msg】
        /// </summary>
        /// <param name="input">离职信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("sync-approval-msg")]
        public async Task<Result<SyncMsgDto>> SyncApprovalMsg(LmSyncMsgInput input)
        {
            return await _peopleSoftDimissioonAppService.SyncApprovalMsg(input);
        }

        /// <summary>
        /// 同步审批人变更接口【第三方接口 /opinion/modify/approve】
        /// </summary>
        /// <param name="request">变更信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("modify-approve")]
        public async Task<Result<SyncMsgDto>> Approve(LmsModifyApproveRequest request)
        {
            return await _peopleSoftDimissioonAppService.Approve(request);
        }

        /// <summary>
        /// 检测员工是否已提交离职申请 【第三方接口 /apply/check/staff】
        /// </summary>
        /// <param name="accounts">工号</param>
        /// <returns></returns>
        [HttpPost]
        [Route("apply-check")]
        public async Task<Result<SyncMsgDto>> CheckApply(List<string> accounts)
        {
            return await _peopleSoftDimissioonAppService.CheckApply(accounts);
        }
    }
}
