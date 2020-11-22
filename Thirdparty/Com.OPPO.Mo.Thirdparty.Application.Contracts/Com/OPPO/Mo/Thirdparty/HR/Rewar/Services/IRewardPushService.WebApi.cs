using Com.OPPO.Mo.Thirdparty.Hr.Rewar.Requests;
using System.IO;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Hr.Rewar
{
    /// <summary>
    /// 奖惩公告 webApi
    /// </summary>
    [ConfigurableHttpHost(ThirdpartySettingNames.PsWebApiHost)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    public interface IRewardPushWebApiService : IHttpApi
    {
        /// <summary>
        /// 奖金推送数据
        /// </summary>
        /// <param name="request"><see cref="RewardRequest"/></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_IMP_MNL_DATA_OPR.v1")]
        Task<Stream> RewardPush([JsonContent]RewardRequest request);

        /// <summary>
        /// 教育经历信息查询接口
        /// </summary>
        /// <param name="request"><see cref="EduInfoRequest"/></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_EXP_EDU_INFO_OPR.v1")]
        Task<Stream> ExpEduInfo([JsonContent]EduInfoRequest request);
    }

}
