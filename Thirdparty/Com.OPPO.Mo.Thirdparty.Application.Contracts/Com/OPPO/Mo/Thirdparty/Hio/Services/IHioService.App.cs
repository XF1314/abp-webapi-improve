using Com.OPPO.Mo.Thirdparty.Hio.Dtos;
using Com.OPPO.Mo.Thirdparty.Hio.Requests;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Hio.Services
{
    /// <summary>
    /// 学习平台接口
    /// </summary>
    public interface IHioAppService : IApplicationService
    {
        /// <summary>
        /// 查询新员工入职培训成绩
        /// </summary>
        /// <param name="usercode">用户工号</param>
        /// <param name="respType">返回格式,支持json/xml两种格式，默认为json格式</param>
        /// <returns></returns>
        Task<Result<CourseGradeDto>> QueryCourseGrade(string usercode, string respType = "");
    }
}
