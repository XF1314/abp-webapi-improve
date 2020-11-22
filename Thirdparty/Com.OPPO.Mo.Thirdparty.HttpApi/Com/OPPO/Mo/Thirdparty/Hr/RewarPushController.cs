using Com.OPPO.Mo.Thirdparty.Hr.Rewar;
using Com.OPPO.Mo.Thirdparty.Hr.Rewar.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Hr
{
    /// <summary>
    /// 奖惩公告资源
    /// </summary>
    [Area("rewar")]
    [Route("api/mo/thirdparty/hr/rewar")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class RewarPushController : AbpController, IRewardPushAppService
    {
        private readonly IRewardPushAppService _rewardPushAppService;
        public RewarPushController(IRewardPushAppService rewardPushAppService)
        {
            _rewardPushAppService = rewardPushAppService;
        }

        /// <summary>
        /// 奖金推送 【第三方接口 /PSIGW/RESTListeningConnector/PSFT_HR/C_IMP_MNL_DATA_OPR.v1】
        /// </summary>
        /// <param name="input">奖金推送实体信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("c-imp-mnl-data-opr")]
        public async Task<Result<List<RewardPushDto>>> RewardPush(List<RewardInput> input)
        {
            return await _rewardPushAppService.RewardPush(input);
        }

        /// <summary>
        ///教育经历信息查询接口 【第三方接口 /PSIGW/RESTListeningConnector/PSFT_HR/C_EXP_EDU_INFO_OPR.v1】
        /// </summary>
        /// <param name="Emplids">员工Id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("c-exp-edu-info-opr")]
        public async Task<Result<List<EduInfoDto>>> ExpEduInfoOpr(List<string> Emplids)
        {
            return await _rewardPushAppService.ExpEduInfoOpr(Emplids);
        }

    }
}
