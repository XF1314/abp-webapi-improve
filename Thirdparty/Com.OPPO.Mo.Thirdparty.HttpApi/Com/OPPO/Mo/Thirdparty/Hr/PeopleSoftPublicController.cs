using Com.OPPO.Mo.Thirdparty.Hr.Public;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Dto;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Responses;
using Com.OPPO.Mo.Thirdparty.HR.Public.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Hr.Leave
{

    /// <summary>
    /// 请假申请/认证报名/加班申请/社会招聘审批
    /// </summary>
    [Area("leave")]
    [Route("api/mo/thirdparty/ps")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class PeopleSoftPublicController : AbpController, IPeopleSoftPublicAppService
    {
        private readonly IPeopleSoftPublicAppService _AppService;

        public PeopleSoftPublicController(IPeopleSoftPublicAppService AppService)
        {
            _AppService = AppService;
        }

        /// <summary>
        /// 请假数据确认接口,POST方式【第三方接口：/oppo/ps/leave_push】
        /// </summary>
        /// <param name="leaveData">请假信息</param>
        /// <returns></returns>
        [HttpPost("leave/leave-add")]
        public async Task<Result> LeavePush([FromBody] LeaveDataDto leaveData)
        {
            return await _AppService.LeavePush(leaveData);
        }

        /// <summary>
        /// 请假数据确认接口,POST方式【第三方接口：/oppo/ps/leave_update】
        /// </summary>
        /// <param name="approvalDate">销假时间</param>
        /// <param name="employeeId">员工工号</param>
        /// <param name="isLeaveTrue">与请假是否相符Y/N</param>
        /// <param name="isFile">是否有销假资料Y/N</param>
        /// <param name="formInstanceCode">文件编号</param>
        /// <returns></returns>
        [HttpPut("leave/leave-update")]
        public async Task<Result> LeaveUpdate([Required]string formInstanceCode,[Required]DateTime approvalDate, [Required]string employeeId, [Required]bool isLeaveTrue, [Required]bool isFile )
        {
            return await _AppService.LeaveUpdate(formInstanceCode, approvalDate, employeeId, isLeaveTrue, isFile);
        }

        /// <summary>
        /// 请假数据推送接口,POST方式【第三方接口：/oppo/ps/leave_change】
        /// </summary>
        /// <param name="leaveData">请假信息</param>
        /// <returns></returns>
        [HttpPost("leave/leave-change")]
        public async Task<Result> LeaveChange([FromBody] LeaveDataDto leaveData)
        {
            return await _AppService.LeaveChange(leaveData);
        }

        /// <summary>
        /// 月薪制法定节假日加班补报和A工时补发报推送接口【第三方接口：/oppo/ps/po_ps_c_mo_ot_event】
        /// </summary>
        /// <param name="overtime">加班信息</param>
        /// <returns></returns>
        [HttpPost("overtimerequest/holidays-overtime-report")]
        public async Task<Result> MonthlyOvertimeReportAndAWorkTimeReissue([FromBody]List<OvertimeDto> overtime)
        {
            return await _AppService.MonthlyOvertimeReportAndAWorkTimeReissue(overtime);
        }

        /// <summary>
        /// 加班工时添加【第三方接口：/oppo/ps/workhours_put】
        /// </summary>
        /// <param name="overtime">加班信息</param>
        /// <returns></returns>
        [HttpPost("overtimerequest/overtime-add")]
        public async Task<Result> AddOvertimeRequest([FromBody]List<OvertimePushDto> overtime)
        {
            return await _AppService.AddOvertimeRequest(overtime);
        }


        ///// <summary>
        ///// 认证信息查询 【第三方接口：/oppo/ps/authenticate_list】
        ///// </summary>
        ///// <param name="employId">工号,必填</param>
        ///// <param name="responseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        ///// <returns></returns>
        //[HttpGet("query-authenticate-list-by-employid")]
        //public async Task<Result<AuthenticateListBody>> QueryAuthenticateListByEmployid([Required]string employId, string responseType)
        //{
        //    return await _AppService.QueryAuthenticateListByEmployid(employId, responseType);
        //}

        /// <summary>
        /// 根据身份证查工号【第三方接口：/oppo/ps/get_empno_by_nationalid】
        /// </summary>
        /// <param name="nationalId">身份证号</param>
        /// <returns></returns>
        [HttpGet("get-empno-by-nationalid")]
        public async Task<Result<EmpInfo>> GetEmpnobyNationalId([Required]string nationalId)
        {
            return await _AppService.GetEmpnobyNationalId(nationalId);
        }

    }

}
