using Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform;
using Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform.Request;
using Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform.Response;
using Com.OPPO.Mo.Thirdparty.HR.PreEmploymentPlatform.Dtos;
using Com.OPPO.Mo.Thirdparty.HR.PreEmploymentPlatform.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Hr.RecruitPlatform
{
    /// <summary>
    /// 社会招聘审批
    /// </summary>
    [Authorize]
    public class SocialRecruitApprovalAppService : ThirdpartyAppServiceBase, ISocialRecruitApprovalAppService
    {
        private readonly IPreEmploymentWebApiService  _webApiService;

        public SocialRecruitApprovalAppService(IPreEmploymentWebApiService webApiService)
        {
            _webApiService = webApiService;
        }

        /// <summary>
        /// 预入职平台/员工数据同步接口【第三方接口：/hostip/staff/info】
        /// </summary>
        /// <param name="employment">员工数据</param>
        /// <returns></returns>
        public async Task<Result> EmployeeDataSync(EmploymentDto employment)
        {    
            var workList = ObjectMapper.Map<List<WorkInfoDto>, List<WorkInfo>>(employment.WorkList);
            var eduList = ObjectMapper.Map<List<EducationInfoDto>, List<EducationInfo>>(employment.EduList);
            var query = ObjectMapper.Map<EmploymentDto, EmploymentRequest>(employment);
            query.WorkList = JsonConvert.SerializeObject(workList);
            query.EduList = JsonConvert.SerializeObject(eduList);
            var response = await _webApiService.EmployeeDataSync(query);
         
            if (response.status == "OK")
                return Result.Ok(response.data);
            else
            {
                var message = $"【{response.code}】{response.message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }

        /// <summary>
        /// 预入职平台/办公用具领用状态同步【第三方接口：/hostip/entry/office】
        /// </summary>
        /// <param name="status">办公用具领用状态，必填,1表示办公用具领用;2表示电脑权限开通</param>
        /// <param name="employId">操作者ID，必填</param>
        /// <param name="number">文件编号，必填</param>
        /// <returns></returns>
        public async Task<Result> ReceiveStateSync(string status, string employId, string number)
        {

            var receiveState = new ReceiveStateRequest { Status = status, EmployId = employId,Number = number };
            var response = await _webApiService.ReceiveStateSync(receiveState);
            if (response.BussinessCode == "0")
                return Result.Ok(response.Message);
            else
            {
                var message = $"【{response.BussinessCode}】{response.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }

        /// <summary>
        /// 预入职平台/招聘平台获取员工信息【第三方接口：/recruit/queryRecruit】
        /// </summary>
        /// <param name="name">员工名</param>
        /// <returns></returns>
        public async Task<Result<List<ResumeInfo>>> GetEmployeeData(string name)
        {
            var query = new GetEmployRequest { Name = name };
            var response = await _webApiService.GetEmployeeData(query);
            if (response.Status == "OK")
                return Result.FromData(response.Data);
            else
            {
                var message = $"【{response.Code}】{response.Message}";
                Logger.LogWarning(message);
                return Result.FromError<List<ResumeInfo>>(message);
            }
        }


    }
}
