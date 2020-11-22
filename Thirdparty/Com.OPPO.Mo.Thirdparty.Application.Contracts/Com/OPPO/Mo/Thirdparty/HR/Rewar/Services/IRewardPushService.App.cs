using Com.OPPO.Mo.Thirdparty.Hr.Rewar.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Hr.Rewar
{
    /// <summary>
    /// 奖惩公告服务接口
    /// </summary>
    public interface IRewardPushAppService : IApplicationService
    {
        /// <summary>
        /// 奖分推送数据接口
        /// </summary>
        /// <param name="input">奖金推送信息</param>
        /// <returns></returns>
        Task<Result<List<RewardPushDto>>> RewardPush(List<RewardInput> input);

        /// <summary>
        ///教育经历信息查询接口
        /// </summary>
        /// <param name="Emplids">员工Id</param>
        /// <returns></returns>
        Task<Result<List<EduInfoDto>>> ExpEduInfoOpr(List<string> Emplids);
    }
}
