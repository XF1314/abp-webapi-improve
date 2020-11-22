using Com.OPPO.Mo.Thirdparty.Hr.Rewar.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.Rewar.Requests;
using Com.OPPO.Mo.Thirdparty.Hr.Rewar.Response;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Hr.Rewar
{
    /// <summary>
    /// 奖惩公告服务
    /// </summary>
    [Authorize]
    public class RewardPushAppService : ThirdpartyAppServiceBase, IRewardPushAppService
    {
        private readonly IRewardPushWebApiService _rewardPushWebApiService;
        public RewardPushAppService(IRewardPushWebApiService rewardPushWebApiService)
        {
            this._rewardPushWebApiService = rewardPushWebApiService;
        }

        public async Task<Result<List<RewardPushDto>>> RewardPush(List<RewardInput> input)
        {
            if (input.Count <= 0)
            {
                return Result.FromError<List<RewardPushDto>>($"缺失参数。{nameof(input)}");
            }

            var list = ObjectMapper.Map<List<RewardInput>, List<RewardInfo>>(input);

            var request = new RewardRequest
            {
                Data = list
            };

            var resSteam = await _rewardPushWebApiService.RewardPush(request);

            string ret = null;

            using (Stream getStream = new GZipStream(resSteam, CompressionMode.Decompress))
            {
                using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                {
                    ret = streamReader.ReadToEnd();
                }
            }

            if (!string.IsNullOrEmpty(ret))
            {
                var resmodel = JsonConvert.DeserializeObject<RewarResponse<RewardPushDto>>(ret);

                if (resmodel.Status == "1" || resmodel.Descr == "成功")
                {
                    var res = resmodel.Data;

                    return Result.FromData(res);
                }
            }

            return Result.FromData(new List<RewardPushDto>());

        }


        /// <summary>
        ///教育经历信息查询接口
        /// </summary>
        /// <param name="Emplids">员工Id</param>
        /// <returns></returns>
        public async Task<Result<List<EduInfoDto>>> ExpEduInfoOpr(List<string> Emplids)
        {
            if (Emplids.Count <= 0)
            {
                return Result.FromError<List<EduInfoDto>>($"缺失参数。{nameof(Emplids)}");
            }

            var resSteam = await _rewardPushWebApiService.ExpEduInfo(new EduInfoRequest
            {
                Data = Emplids.Select(m => new EduInfo
                {
                    EmplId = m
                }).ToList()
            });

            string ret = null;

            using (Stream getStream = new GZipStream(resSteam, CompressionMode.Decompress))
            {
                using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                {
                    ret = streamReader.ReadToEnd();
                }
            }

            if (!string.IsNullOrEmpty(ret))
            {
                var resmodel = JsonConvert.DeserializeObject<RewarResponse<EduInfoDto>>(ret);

                if (resmodel.Status == "1" || resmodel.Descr == "成功")
                {
                    var res = resmodel.Data;

                    return Result.FromData(res);
                }
            }

            return Result.FromData(new List<EduInfoDto>());
        }
    }
}
