
using Com.OPPO.Mo.Thirdparty.HR.PsHr.Dtos;
using Com.OPPO.Mo.Thirdparty.HR.PsHr.Response;
using Com.OPPO.Mo.Thirdparty.Megvii.Common;
using Com.OPPO.Mo.Thirdparty.Megvii.Dto;
using Com.OPPO.Mo.Thirdparty.Megvii.Request;
using Com.OPPO.Mo.Thirdparty.Megvii.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Parameterables;

namespace Com.OPPO.Mo.Thirdparty.Megvii
{

    [Authorize]
    public class MegviiAppService : ThirdpartyAppServiceBase, IMegviiAppService
    {
        private readonly IMegviiWebApiService  _apiService;

        public MegviiAppService(IMegviiWebApiService apiService)
        {
            _apiService = apiService;
        }


        /// <summary>
        /// 图片质量检查
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        public async Task<Result> PhotoQualityChecking(AddPhotoRequestDto photo)
        {
            var request = ObjectMapper.Map<AddPhotoRequestDto, AddPhotoRequest>(photo);
            var responseModel = await _apiService.PhotoQualityChecking(request);

            var faceRecordJO = Newtonsoft.Json.Linq.JObject.Parse(responseModel);
            var response = faceRecordJO.ToObject<BaseMegviiResponse<EmptyData>>();
            if (response.Code == 0)
                return Result.Ok("验证成功");
            else
            {
                var message = $"【{response.Code}】{response.Desc}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }

        }


        /// <summary>
        /// 上传人员底库【旷视接口： /subject/photo】
        /// </summary>
        /// <param name="dto">传输数据模型</param>
        /// <returns></returns>
        public async Task<Result<AddPhotoResponse>> AddPhoto(AddPhotoRequestDto dto)
        {
            var request = ObjectMapper.Map<AddPhotoRequestDto, AddPhotoRequest>(dto);
            var responseModel = await _apiService.AddPhoto(request);

            var faceRecordJO = Newtonsoft.Json.Linq.JObject.Parse(responseModel);
            var response = faceRecordJO.ToObject<BaseMegviiResponse<AddPhotoDto>>();
            if (response.Code == 0)
            {
                var data = ObjectMapper.Map<AddPhotoDto, AddPhotoResponse>(response.Data);
                return Result.FromData<AddPhotoResponse>(data);
            }
            else
            {
                var message = $"【{response.Code}】{response.Desc}";
                Logger.LogWarning(message);
                return Result.FromError<AddPhotoResponse>(message);
            }

        }


        /// <summary>
        /// 获取人员分组列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Result<BaseMegviiResponse<List<PersonnelGroup>>>> GetPersonnelGroupList(QueryTermsDto dto)
        {
            var query = ObjectMapper.Map<QueryTermsDto, QueryTerms>(dto);
            var responseModel = await _apiService.GetPersonnelGroupList(query);

            var faceRecordJO = Newtonsoft.Json.Linq.JObject.Parse(responseModel);
            var response = faceRecordJO.ToObject<BaseMegviiResponse<List<PersonnelGroupDto>>>();
            if (response.Code == 0)
            {
                var datas = ObjectMapper.Map<List<PersonnelGroupDto>, List<PersonnelGroup>>(response.Data);
                BaseMegviiResponse<List<PersonnelGroup>> baseMegvii = new BaseMegviiResponse<List<PersonnelGroup>>();
                baseMegvii.Code = response.Code;
                baseMegvii.Data = datas;
                baseMegvii.Page = response.Page;
                return Result.FromData(baseMegvii);
            }
            else
            {
                var message = $"【{response.Code}】{response.Desc}";
                Logger.LogWarning(message);
                return Result.FromError<BaseMegviiResponse<List<PersonnelGroup>>>(message);
            }

        }


        /// <summary>
        /// 根据工号查人员id
        /// </summary>
        /// <param name="jobNumber"></param>
        /// <returns></returns>
        public async Task<Result<BaseMegviiResponse<EmployeeInfoResponse>>> QueryIdByJobNumber(string jobNumber)
        {
            string responseModel = await _apiService.QueryIdByJobNumber(jobNumber);

            var faceRecordJO = Newtonsoft.Json.Linq.JObject.Parse(responseModel);
            var response = faceRecordJO.ToObject<BaseMegviiResponse<EmployeeInfoResponse>>();
            if (response.Code == 0)
                return Result.FromData(response);
            else
            {
                var message = $"【{response.Code}】{response.Desc}";
                Logger.LogWarning(message);
                return Result.FromError<BaseMegviiResponse<EmployeeInfoResponse>>(message);
            }
        }


        /// <summary>
        /// 删除subject底库
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public async Task<Result> DeleteSubjectBySubjectId(string subjectId)
        {
            string responseModel = await _apiService.DeleteSubjectBySubjectId(subjectId);
            var faceRecordJO = Newtonsoft.Json.Linq.JObject.Parse(responseModel);
            var response = faceRecordJO.ToObject<BaseMegviiResponse<EmptyData>>();
            if (response.Code == 0)
                return Result.Ok();
            else
            {
                var message = $"【{response.Code}】{response.Desc}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }


        /// <summary>
        /// 创建用户【旷视接口： /subject/photo】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<Result<BaseMegviiResponse<CreateUserResponse>>> CreateUser(MegviiUserInfoDto query)
        {
            var reqmodel = ObjectMapper.Map<MegviiUserInfoDto, MegviiUserInfo>(query);
            string responseModel = await _apiService.CreateUser(reqmodel);

            var faceRecordJO = Newtonsoft.Json.Linq.JObject.Parse(responseModel);
            var response = faceRecordJO.ToObject<BaseMegviiResponse<CreateUserResponseDto>>();
            if (response.Code == 0)
            {
                var data = ObjectMapper.Map<CreateUserResponseDto, CreateUserResponse>(response.Data);
                BaseMegviiResponse<CreateUserResponse> baseMegvii = new BaseMegviiResponse<CreateUserResponse>();
                baseMegvii.Code = response.Code;
                baseMegvii.Data = data;
                baseMegvii.Page = response.Page;
                return Result.FromData(baseMegvii);
            }
            else
            {
                var message = $"【{response.Code}】{response}";
                Logger.LogWarning(message);
                return Result.FromError<BaseMegviiResponse<CreateUserResponse>>(message);
            }
        }
     
    }

}
