using Com.OPPO.Mo.Thirdparty.Hio.Dtos;
using Com.OPPO.Mo.Thirdparty.Hio.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Hio
{
    /// <summary>
    /// 学习平台资管
    /// </summary>
    [Area("Hio")]
    [Route("api/mo/thirdparty/Hio/")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class HioController : AbpController, IHioAppService
    {
        private readonly IHioAppService _hioAppService;

        public HioController(IHioAppService hioAppService)
        {
            _hioAppService = hioAppService;
        }

        /// <summary>
        /// /查询新员工入职培训成绩 【第三方接口：/oppo/hio/queryCourseGrade】
        /// </summary>
        /// <param name="respType">返回格式,支持json/xml两种格式，默认为json格式</param>
        /// <param name="usercode">用户工号</param>
        /// <returns></returns>
        [HttpGet("query-course-grade")]
        public async Task<Result<CourseGradeDto>> QueryCourseGrade(string usercode, string respType = "")
        {
            return await _hioAppService.QueryCourseGrade(usercode, respType);
        }

    }
}
