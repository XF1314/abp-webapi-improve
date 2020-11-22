using Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform;
using Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform.Response;
using Com.OPPO.Mo.Thirdparty.HR.PreEmploymentPlatform.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Hr
{
    /// <summary>
    /// 招聘平台——社会招聘审批
    /// </summary>
    [Area("recruit")]
    [Route("api/mo/thirdparty/ps/recruit")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class RecruitPlatformController : AbpController, ISocialRecruitApprovalAppService
    {
        private readonly ISocialRecruitApprovalAppService  _socialRecruitApprovalAppService;

        public RecruitPlatformController(ISocialRecruitApprovalAppService  socialRecruitApprovalAppService)
        {
            _socialRecruitApprovalAppService = socialRecruitApprovalAppService;
        }


        /// <summary>
        /// 预入职平台/员工数据同步接口【第三方接口：/hostip/staff/info】
        /// </summary>
        /// <param name="employment">员工数据</param>
        /// <returns></returns>
        [HttpPost("pre/employee-data-sync")]
        public async Task<Result> EmployeeDataSync(EmploymentDto employment)
        {
            return await _socialRecruitApprovalAppService.EmployeeDataSync(employment);
        }

        /// <summary>
        /// 预入职平台/办公用具领用状态同步【第三方接口：/hostip/entry/office】
        /// </summary>
        /// <param name="status">办公用具领用状态，必填,1表示办公用具领用;2表示电脑权限开通</param>
        /// <param name="employId">操作者ID，必填</param>
        /// <param name="number">文件编号，必填</param>
        /// <returns></returns>
        [HttpPost("pre/receive-state-sync")]
        public async Task<Result> ReceiveStateSync([Required]string status, [Required]string employId, [Required]string number)
        {
            return await _socialRecruitApprovalAppService.ReceiveStateSync(status, employId, number);
        }


        /// <summary>
        /// 预入职平台/招聘平台获取员工信息【第三方接口：/recruit/queryRecruit】
        /// </summary>
        /// <param name="name">员工名</param>
        /// <returns></returns>
        [HttpPost("pre/get-employee-data")]
        public async Task<Result<List<ResumeInfo>>> GetEmployeeData(string name = "")
        {
            return await _socialRecruitApprovalAppService.GetEmployeeData(name);
        }

    }


}
