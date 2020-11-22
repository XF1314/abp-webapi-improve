using Com.OPPO.Mo.Thirdparty.Hio.Dtos;
using Com.OPPO.Mo.Thirdparty.Hio.Requests;
using Com.OPPO.Mo.Thirdparty.Hio.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Hio
{
    /// <summary>
    /// Hio 服务
    /// </summary>
    [Authorize]
    public class HioAppService : ThirdpartyAppServiceBase, IHioAppService
    {
        private readonly IHioWebApiService _hioService;

        public HioAppService(IHioWebApiService hioService)
        {
            _hioService = hioService;
        }

        /// <summary>
        /// 查询新员工入职培训成绩
        /// </summary>
        /// <param name="usercode">用户工号</param>
        /// <param name="respType">返回格式,支持json/xml两种格式，默认为json格式</param>
        /// <returns></returns>
        public async Task<Result<CourseGradeDto>> QueryCourseGrade(string usercode, string respType = "")
        {
            if (string.IsNullOrWhiteSpace(usercode))
                return Result.FromError<CourseGradeDto>($"缺失参数{nameof(usercode)}。");

            var response = await _hioService.QueryCourseGrade(new CourseQueryRequest
            {
                RespType = respType,
                Usercode = usercode
            });

            var res = ObjectMapper.Map<CourseGradeInfo, CourseGradeDto>(response.Data);

            return Result.FromData(res);
        }
    }
}
