using Com.OPPO.Mo.Thirdparty.HR.PsHr.Response;
using Com.OPPO.Mo.Thirdparty.Megvii.Dto;
using Com.OPPO.Mo.Thirdparty.Megvii.Request;
using Com.OPPO.Mo.Thirdparty.Megvii.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using WebApiClient.Parameterables;

namespace Com.OPPO.Mo.Thirdparty.Megvii
{

    /// <summary>
    /// 旷视接口服务
    /// </summary>
    [Area("megvii")]
    [Route("api/mo/thirdparty/megvii")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class MegviiController : AbpController, IMegviiAppService
    {
        private readonly IMegviiAppService _megviiAppService;

        public MegviiController(IMegviiAppService megviiAppService)
        {
            _megviiAppService = megviiAppService;
        }


        /// <summary>
        /// 获取人员分组列表【旷视接口：/subjects/group/list】“外来人员进入车间申请”获取厂区地址
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("query-personne-group-list")]
        public async Task<Result<BaseMegviiResponse<List<PersonnelGroup>>>> GetPersonnelGroupList(QueryTermsDto dto)
        {
            return await _megviiAppService.GetPersonnelGroupList(dto);
        }


        /// <summary>
        /// 图片质量检查【旷视接口： /subject/photo/check】
        /// </summary>
        /// <param name="dto">图片文件</param>
        /// <returns></returns>
        [HttpPost("photo-quality-check")]
        public async Task<Result> PhotoQualityChecking(AddPhotoRequestDto dto)
        {
            return await _megviiAppService.PhotoQualityChecking(dto);
        }


        /// <summary>
        /// 根据工号查人员信息【旷视接口：/subject_jobnumber】
        /// </summary>
        /// <param name="jobNumber">人员编号，创建时的编号</param>
        /// <returns></returns>
        [HttpGet("query-id-by-jobnumber")]
        public async Task<Result<BaseMegviiResponse<EmployeeInfoResponse>>> QueryIdByJobNumber([Required] string jobNumber)
        {
            return await _megviiAppService.QueryIdByJobNumber(jobNumber);
        }

        /// <summary>
        /// 删除subject底库【旷视接口： /subject/photo】
        /// </summary>
        /// <param name="subjectId">id</param>
        /// <returns></returns>
        [HttpDelete("delete-subject-by-id")]
        public async Task<Result> DeleteSubjectBySubjectId([Required] string subjectId)
        {
            return await _megviiAppService.DeleteSubjectBySubjectId(subjectId);
        }

        /// <summary>
        /// 上传人员底库【旷视接口： /subject/photo】
        /// </summary>
        /// <param name="dto">传输数据模型</param>
        /// <returns></returns>
        [HttpPost("add-photo")]
        public async Task<Result<AddPhotoResponse>> AddPhoto(AddPhotoRequestDto dto)
        {
            return await _megviiAppService.AddPhoto(dto);
        }

        /// <summary>
        /// 创建用户【旷视接口： /subject/photo】
        /// </summary>
        /// <param name="megviiUserInfo">请求数据</param>
        /// <returns></returns>
        [HttpPost("add-user")]
        public async Task<Result<BaseMegviiResponse<CreateUserResponse>>> CreateUser(MegviiUserInfoDto megviiUserInfo)
        {
            return await _megviiAppService.CreateUser(megviiUserInfo);
        }


    }
}
