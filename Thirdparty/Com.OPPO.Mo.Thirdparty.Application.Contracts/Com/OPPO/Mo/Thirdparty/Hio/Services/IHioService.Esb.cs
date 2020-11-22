using Com.OPPO.Mo.Thirdparty.Hio.Requests;
using Com.OPPO.Mo.Thirdparty.Hio.Response;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Hio.Services
{
    /// <summary>
    /// 查询新员工入职培训成绩 Esb服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IHioWebApiService : IHttpApi
    {
        /// <summary>
        /// 查询新员工入职培训成绩
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("/oppo/hio/queryCourseGrade")]
        Task<HioResponse<CourseGradeInfo>> QueryCourseGrade([PathQuery] CourseQueryRequest request);
    }
}
