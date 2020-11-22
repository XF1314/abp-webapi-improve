using Com.OPPO.Mo.Thirdparty.Megvii.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.DataAnnotations;
using WebApiClient.Parameterables;

namespace Com.OPPO.Mo.Thirdparty.Megvii
{

    /// <summary>
    /// 旷视api
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [ConfigurableHttpHost(ThirdpartySettingNames.MegeviiWebApiHost)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    public interface IMegviiWebApiService : IHttpApi
    {
        /// <summary>
        /// 获取人员分组列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/subjects/group/list")]
        Task<string> GetPersonnelGroupList([PathQuery] QueryTerms query);



        /// <summary>
        /// 图片质量检查
        /// </summary>
        /// <param name="request">请求数据</param>
        /// <returns></returns>
        [HttpPost("/subject/photo/check")]
        Task<string> PhotoQualityChecking([JsonMulitpartText]AddPhotoRequest request);


        /// <summary>
        /// 上传人员底库【旷视接口： /subject/photo】
        /// </summary>
        /// <param name="request">请求数据</param>
        /// <returns></returns>
        [HttpPost("/subject/photo")]
        Task<string> AddPhoto([JsonMulitpartText]AddPhotoRequest request);


        /// <summary>
        /// 根据工号查人员id
        /// </summary>
        /// <param name="jobNumber"></param>
        /// <returns></returns>
        [HttpGet("/subject_jobnumber")]
        Task<string> QueryIdByJobNumber([PathQuery] string jobNumber);


        /// <summary>
        /// 删除subject底库
        /// </summary>
        /// <param name="subjectId">id</param>
        /// <returns></returns>
        [HttpDelete("/subject/photo")]
        Task<string> DeleteSubjectBySubjectId([FormContent][AliasAs("subject_id")] string subjectId);


        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="megviiUserInfo"></param>
        /// <returns></returns>
        [HttpPost("/subject")]
        Task<string> CreateUser([JsonContent] MegviiUserInfo megviiUserInfo);


    }

}
