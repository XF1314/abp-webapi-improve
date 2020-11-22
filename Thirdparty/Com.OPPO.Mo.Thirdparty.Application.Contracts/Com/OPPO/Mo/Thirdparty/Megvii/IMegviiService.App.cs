using Com.OPPO.Mo.Thirdparty.HR.PsHr.Response;
using Com.OPPO.Mo.Thirdparty.Megvii.Dto;
using Com.OPPO.Mo.Thirdparty.Megvii.Request;
using Com.OPPO.Mo.Thirdparty.Megvii.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using WebApiClient.Parameterables;

namespace Com.OPPO.Mo.Thirdparty.Megvii
{

    /// <summary>
    /// 旷视接口服务
    /// </summary>
    public interface IMegviiAppService : IApplicationService
    {
        /// <summary>
        /// 获取人员分组列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Result<BaseMegviiResponse<List<PersonnelGroup>>>> GetPersonnelGroupList(QueryTermsDto dto);


        /// <summary>
        /// 图片质量检查
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        Task<Result> PhotoQualityChecking(AddPhotoRequestDto photo);

        /// <summary>
        /// 上传人员底库【旷视接口： /subject/photo】
        /// </summary>
        /// <param name="dto">传输数据模型</param>
        /// <returns></returns>
        Task<Result<AddPhotoResponse>> AddPhoto(AddPhotoRequestDto dto);


        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="megviiUserInfo"></param>
        /// <returns></returns>
        Task<Result<BaseMegviiResponse<CreateUserResponse>>> CreateUser(MegviiUserInfoDto megviiUserInfo);

        /// <summary>
        /// 根据工号查人员id
        /// </summary>
        /// <param name="jobnumber"></param>
        /// <returns></returns>
        Task<Result<BaseMegviiResponse<EmployeeInfoResponse>>> QueryIdByJobNumber(string jobnumber);

        /// <summary>
        /// 删除subject底库
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        Task<Result> DeleteSubjectBySubjectId(string subjectId);
    }
}
