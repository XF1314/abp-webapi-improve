using Com.OPPO.Mo.Thirdparty.Hr.Public.Dto;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Responses;
using Com.OPPO.Mo.Thirdparty.HR.Public.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public
{
    /// <summary>
    /// PeopleSoft请假/认证报名 应用服务接口
    /// </summary>
    public interface IPeopleSoftPublicAppService : IApplicationService
    {
        /// <summary>
        /// 请假数据确认接口,POST方式【第三方接口：/oppo/ps/leave_push】
        /// </summary>
        /// <param name="leaveData">请假信息</param>
        /// <returns></returns>
        Task<Result> LeavePush(LeaveDataDto leaveData);

        /// <summary>
        /// 请假数据确认接口,POST方式【第三方接口：/oppo/ps/leave_update】
        /// </summary>
        /// <param name="approvalDate">销假时间</param>
        /// <param name="employeeId">员工工号</param>
        /// <param name="isLeaveTrue">与请假是否相符Y/N</param>
        /// <param name="isFile">是否有销假资料Y/N</param>
        /// <param name="formInstanceCode">文件编号</param>
        /// <returns></returns>
        Task<Result> LeaveUpdate(string formInstanceCode, DateTime approvalDate, string employeeId, bool isLeaveTrue, bool isFile);

        /// <summary>
        /// 请假数据推送接口,POST方式【第三方接口：/oppo/ps/leave_change】
        /// </summary>
        /// <param name="leaveData">请假信息</param>
        /// <returns></returns>
        Task<Result> LeaveChange(LeaveDataDto leaveData);

        /// <summary>
        /// 月薪制法定节假日加班补报和A工时补发
        /// </summary>
        /// <param name="overtime"></param>
        /// <returns></returns>
        Task<Result> MonthlyOvertimeReportAndAWorkTimeReissue(List<OvertimeDto> overtime);

        /// <summary>
        /// 加班工时添加接口
        /// </summary>
        /// <param name="overtime"></param>
        /// <returns></returns>
        Task<Result> AddOvertimeRequest(List<OvertimePushDto> overtime);

        ///// <summary>
        ///// 认证信息查询 【第三方接口：/oppo/ps/authenticate_list】
        ///// </summary>
        ///// <param name="employId">工号,必填</param>
        ///// <param name="responseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        ///// <returns></returns>
        //Task<Result<AuthenticateListBody>> QueryAuthenticateListByEmployid(string employId, string responseType);

        /// <summary>
        /// 根据身份证查工号
        /// </summary>
        /// <param name="nationalId">身份证</param>
        /// <returns></returns>
        Task<Result<EmpInfo>> GetEmpnobyNationalId(string nationalId);

    }
}
