using Com.OPPO.Mo.Thirdparty.Hr.LMS.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.LMS.Requests;
using Com.OPPO.Mo.Thirdparty.Hr.LMS.Service;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Hr.LMS
{
    /// <summary>
    /// 人员离职服务
    /// </summary>
    [Authorize]
    public class PeopleSoftLmsAppService : ThirdpartyAppServiceBase, IPeopleSoftLmsAppService
    {
        private readonly IPeopleSofLmsService _peopleSofDimissionService;
        private readonly ILmsWebApiService _lmsWebApiService;

        public PeopleSoftLmsAppService(IPeopleSofLmsService peopleSofDimissionService, ILmsWebApiService lmsWebApiService)
        {
            _peopleSofDimissionService = peopleSofDimissionService;
            _lmsWebApiService = lmsWebApiService;
        }

        /// <summary>
        /// LMS更新离职信息
        /// </summary>
        /// <param name="input">离职信息</param>
        /// <returns></returns>
        public async Task<Result<LmsDto>> DimissionNewUpdate(LmInput input)
        {
            if (string.IsNullOrWhiteSpace(input.DataJson))
                return Result.FromError<LmsDto>($"{input.DataJson}不能为空。");
            else
            {
                //TODO:验证DataJson是否合格的Json格式

                var response = await _peopleSofDimissionService.DimissionnewUpdate(new LmsRequest
                {
                    DataJson = input.DataJson,
                    FormInstanceCode = input.FormInstanceCode,
                    UserAccount = input.UserAccount
                });

                var info = ObjectMapper.Map<LmsInfo, LmsDto>(response.Data);

                return Result.FromData(info);
            }
        }

        /// <summary>
        /// 离职信息同步接口
        /// </summary>
        /// <param name="input">离职信息</param>
        /// <returns></returns>
        public async Task<Result<SyncMsgDto>> SyncApprovalMsg(LmSyncMsgInput input)
        {
            var request = ObjectMapper.Map<LmSyncMsgInput, LmSyncMsgRequest>(input);

            var response = await _lmsWebApiService.SyncApprovalMsg(request);

            var info = ObjectMapper.Map<SyncMsgInfo, SyncMsgDto>(response);

            return Result.FromData(info);
        }


        /// <summary>
        /// 同步审批人变更接口
        /// </summary>
        /// <param name="request">变更信息</param>
        /// <returns></returns>
        public async Task<Result<SyncMsgDto>> Approve(LmsModifyApproveRequest request)
        {
            if (request.ChangeList.Count <= 0)
                return Result.FromError<SyncMsgDto>($"{request.ChangeList}不能为空。");

            var response = await _lmsWebApiService.ModifyApprove(request);

            var info = ObjectMapper.Map<SyncMsgInfo, SyncMsgDto>(response);

            return Result.FromData(info);
        }

        /// <summary>
        /// 检测员工是否已提交离职申请
        /// </summary>
        /// <param name="accounts">工号</param>
        /// <returns></returns>
        public async Task<Result<SyncMsgDto>> CheckApply(List<string> accounts)
        {
            if (accounts.Count <= 0)
                return Result.FromError<SyncMsgDto>($"{accounts}不能为空。");

            var response = await _lmsWebApiService.ApplyCheck(new LmsApplyCheckRequest
            {
                ApplyIdList = accounts.Select(m => m).ToList()
            });

            var info = ObjectMapper.Map<SyncMsgInfo, SyncMsgDto>(response);

            return Result.FromData(info);
        }
    }
}
