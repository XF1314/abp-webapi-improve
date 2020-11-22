using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Dto;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Request;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Requests;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Responses;
using Com.OPPO.Mo.Thirdparty.HR.Public.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public
{

    [Authorize]
    public class PeopleSoftPublicAppService : ThirdpartyAppServiceBase, IPeopleSoftPublicAppService
    {
        private readonly IConfiguration _configuration;
        private readonly IPeopleSoftPublicEsbService _EsbService;

        public PeopleSoftPublicAppService(
            IConfiguration configuration,
            IPeopleSoftPublicEsbService EsbService)
        {
            _configuration = configuration;
            _EsbService = EsbService;
        }


        public async Task<Result> LeaveChange(LeaveDataDto item)
        {
            var leavedata = ObjectMapper.Map<LeaveDataDto, LeaveDataInfo>(item);
            #region 注释
            //LeaveBatchData leavedata = new LeaveBatchData();
            //if (string.IsNullOrWhiteSpace(item.EmployeeId))
            //{
            //    return Result.FromError($"EmployeeId不能为空。");
            //}
            //leavedata.employee_id = item.EmployeeId.Trim();
            //if (string.IsNullOrWhiteSpace(item.FormInstanceCode))
            //{
            //    return Result.FromError($"FormInstanceCode不能为空。");
            //}
            //leavedata.formInstance_code = item.FormInstanceCode;
            //if (string.IsNullOrWhiteSpace(item.BeginDate))
            //{
            //    return Result.FromError($"BeginDate不能为空。");
            //}
            //leavedata.begin_date = item.BeginDate;
            //if (string.IsNullOrWhiteSpace(item.BeginTime))
            //{
            //    return Result.FromError($"BeginTime不能为空。");
            //}
            //leavedata.begin_time = item.BeginTime;
            //if (string.IsNullOrWhiteSpace(item.EndDate))
            //{
            //    return Result.FromError($"EndDate不能为空。");
            //}
            //leavedata.end_date = item.EndDate;
            //if (string.IsNullOrWhiteSpace(item.EndTime))
            //{
            //    return Result.FromError($"EndTime不能为空。");
            //}
            //leavedata.end_time = item.EndTime;
            //if (string.IsNullOrWhiteSpace(item.IsItConsistentWithLeaveInfo))
            //{
            //    return Result.FromError($"IsItConsistentWithLeaveInfo不能为空。");
            //}
            //if (item.IsItConsistentWithLeaveInfo != "Y" && item.IsItConsistentWithLeaveInfo != "N")
            //{
            //    return Result.FromError($"IsItConsistentWithLeaveInfo格式不正确，取值范围为Y 或 N。");
            //}
            //leavedata.flag = item.IsItConsistentWithLeaveInfo;
            //if (string.IsNullOrWhiteSpace(item.CancelLeave))
            //{
            //    return Result.FromError($"CancelLeave不能为空。");
            //}
            //if (item.CancelLeave != "Y" && item.CancelLeave != "N")
            //{
            //    return Result.FromError($"CancelLeave格式不正确，取值范围为Y 或 N。");
            //}
            //leavedata.flag1 = item.CancelLeave;
            //if (string.IsNullOrWhiteSpace(item.LeaveCause))
            //{
            //    return Result.FromError($"LeaveCause不能为空。");
            //}
            //leavedata.leave_cause = item.LeaveCause;
            //leavedata.c_days = item.TotalDays;
            //leavedata.c_abs_days01 = item.DaysOfPersonalLeave;
            //leavedata.c_abs_days02 = item.DaysOfAnnualLeave;
            //leavedata.c_abs_days03 = item.DaysOfWeekend;
            //leavedata.c_abs_days04 = item.DaysOfNursingLeave;
            //leavedata.c_abs_days05 = item.DaysOfMarriageLeave;
            //leavedata.c_abs_days06 = item.DaysOfAntenatalExaminationLeave;
            //leavedata.c_abs_days07 = item.DaysOfMaternityLeave;
            //leavedata.c_abs_days08 = item.DaysOfSickLeave;
            //leavedata.c_abs_days09 = item.DaysOfSpecialLeave;
            //leavedata.c_abs_days10 = item.DaysOfInjuryLeave;
            //leavedata.c_abs_days11 = item.DaysOfFuneralLeave;
            //leavedata.approval_date = item.ApproveDate;
            //leavedata.approve_date = item.ApproveDate;
            //leavedata.comments = item.Comments;

           
            #endregion
            var leaveForEsbQueryRequest = new PeopleSoftLeaveInfoAddRequest()
            {
                LeaveData = JsonConvert.SerializeObject(leavedata)
            };

            var response = await _EsbService.LeaveChange(leaveForEsbQueryRequest);

            if (response.Body.BussinessCode == "0")
                return Result.Ok(response.Body.Message);
            else
            {
                var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }

     
        public async Task<Result> LeavePush(LeaveDataDto item)
        {
       
            #region 注释
            //LeaveBatchData leavedata = new LeaveBatchData();
            //if (string.IsNullOrWhiteSpace(item.EmployeeId))
            //{
            //    return Result.FromError($"EmployeeId不能为空。");
            //}
            //leavedata.employee_id = item.EmployeeId.Trim();
            //if (string.IsNullOrWhiteSpace(item.FormInstanceCode))
            //{
            //    return Result.FromError($"FormInstanceCode不能为空。");
            //}
            //leavedata.formInstance_code = item.FormInstanceCode;
            //if (string.IsNullOrWhiteSpace(item.BeginDate))
            //{
            //    return Result.FromError($"BeginDate不能为空。");
            //}
            //leavedata.begin_date = item.BeginDate;
            //if (string.IsNullOrWhiteSpace(item.BeginTime))
            //{
            //    return Result.FromError($"BeginTime不能为空。");
            //}
            //leavedata.begin_time = item.BeginTime;
            //if (string.IsNullOrWhiteSpace(item.EndDate))
            //{
            //    return Result.FromError($"EndDate不能为空。");
            //}
            //leavedata.end_date = item.EndDate;
            //if (string.IsNullOrWhiteSpace(item.EndTime))
            //{
            //    return Result.FromError($"EndTime不能为空。");
            //}
            //leavedata.end_time = item.EndTime;
            //if (string.IsNullOrWhiteSpace(item.IsItConsistentWithLeaveInfo))
            //{
            //    return Result.FromError($"IsItConsistentWithLeaveInfo不能为空。");
            //}
            //if (item.IsItConsistentWithLeaveInfo != "Y" && item.IsItConsistentWithLeaveInfo != "N")
            //{
            //    return Result.FromError($"IsItConsistentWithLeaveInfo格式不正确，取值范围为Y 或 N。");
            //}
            //leavedata.flag = item.IsItConsistentWithLeaveInfo;
            //if (string.IsNullOrWhiteSpace(item.CancelLeave))
            //{
            //    return Result.FromError($"CancelLeave不能为空。");
            //}
            //if (item.CancelLeave != "Y" && item.CancelLeave != "N")
            //{
            //    return Result.FromError($"CancelLeave格式不正确，取值范围为Y 或 N。");
            //}
            //leavedata.flag1 = item.CancelLeave;
            //if (string.IsNullOrWhiteSpace(item.LeaveCause))
            //{
            //    return Result.FromError($"LeaveCause不能为空。");
            //}
            //leavedata.leave_cause = item.LeaveCause;
            //leavedata.c_days = item.TotalDays;
            //leavedata.c_abs_days01 = item.DaysOfPersonalLeave;
            //leavedata.c_abs_days02 = item.DaysOfAnnualLeave;
            //leavedata.c_abs_days03 = item.DaysOfWeekend;
            //leavedata.c_abs_days04 = item.DaysOfNursingLeave;
            //leavedata.c_abs_days05 = item.DaysOfMarriageLeave;
            //leavedata.c_abs_days06 = item.DaysOfAntenatalExaminationLeave;
            //leavedata.c_abs_days07 = item.DaysOfMaternityLeave;
            //leavedata.c_abs_days08 = item.DaysOfSickLeave;
            //leavedata.c_abs_days09 = item.DaysOfSpecialLeave;
            //leavedata.c_abs_days10 = item.DaysOfInjuryLeave;
            //leavedata.c_abs_days11 = item.DaysOfFuneralLeave;
            //leavedata.approval_date = item.ApproveDate;
            //leavedata.approve_date = item.ApproveDate;
            //leavedata.comments = item.Comments; 
            #endregion

            var leavedata = ObjectMapper.Map<LeaveDataDto, LeaveDataInfo>(item);
            var leaveForEsbQueryRequest = new PeopleSoftLeaveInfoAddRequest()
            {
                LeaveData = JsonConvert.SerializeObject(leavedata)
            };

            var response = await _EsbService.AddLeaveInfo(leaveForEsbQueryRequest);
            if (response.Body.BussinessCode == "0")
                return Result.Ok(response.Body.Message);
            else
            {
                var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }

        public async Task<Result> LeaveUpdate(string formInstance_code, DateTime approval_date, string employee_id, bool flag, bool flag1)
        {
            var LeaveUpdateEsbQueryRequest = new PeopleSoftLeaveInfoUpdateRequest()
            {
                ApprovalFinishTime = approval_date,
                LeaverUserCode = employee_id,
                IsConsistent = flag,
                HasReportBackMaterial = flag1,
                FormInstanceCode = formInstance_code
            };

            var response = await _EsbService.UpdateLeaveInfo(LeaveUpdateEsbQueryRequest);
            if (response.Body.BussinessCode == "0")
                return Result.Ok(response.Body.Message);
            else
            {
                var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }

        }


        public async Task<Result> MonthlyOvertimeReportAndAWorkTimeReissue(List<OvertimeDto> list)
        {
            var item = ObjectMapper.Map<List<OvertimeDto>, List<Overtime>>(list);

            var leaveForEsbQueryRequest = new LinesRequest()
            {
                Data = JsonConvert.SerializeObject(item)
            };

            var response = await _EsbService.MonthlyOvertimeReportAndAWorkTimeReissue(leaveForEsbQueryRequest);
            if (response.Body.BussinessCode == "0")
                return Result.Ok(response.Body.Message);
            else
            {
                var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
            //if (response.IsOk)
            //    return Result.Ok(response.Body.Message);
            //else
            //{
            //    var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
            //    Logger.LogWarning(message);
            //    return Result.FromError(message);
            //}
        }

        public async Task<Result> AddOvertimeRequest(List<OvertimePushDto> list)
        {
            var item = ObjectMapper.Map<List<OvertimePushDto>, List<OvertimePush>>(list);

            var leaveForEsbQueryRequest = new OvertimePushRequest()
            {
                Data = JsonConvert.SerializeObject(item)
            };

            var response = await _EsbService.AddOvertimeRequest(leaveForEsbQueryRequest);
            if (response.Body.BussinessCode == "0")
                return Result.Ok(response.Body.Message);
            else
            {
                var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
            //if (response.IsOk)
            //    return Result.Ok(response.Body.Message);
            //else
            //{
            //    var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
            //    Logger.LogWarning(message);
            //    return Result.FromError(message);
            //}
        }

        ///// <summary>
        ///// 认证信息查询 【第三方接口：/oppo/ps/authenticate_list】
        ///// </summary>
        ///// <param name="employId">工号,必填</param>
        ///// <param name="responseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        ///// <returns></returns>
        //public async Task<Result<AuthenticateListBody>> QueryAuthenticateListByEmployid(string employId, string responseType)
        //{

        //    var response = await _EsbService.QueryAuthenticateListByEmployid(new QueryAuthenticateListRequest
        //    {
        //        EmployId = employId,
        //        ResponseType = responseType
        //    });

        //    if (response.Response.Datas != null)
        //    {
        //        var datas = ObjectMapper.Map<List<AuthenticateDto>, List<Authenticate>>(response.Response.Datas);
        //        AuthenticateListBody body = new AuthenticateListBody { RowCount = response.Response.RowCount, Datas = datas };
        //        return Result.FromData(body);
        //    }
        //    else
        //    {
        //        var message = $"【{response.Response.Code}】{response.Response.Message}";
        //        Logger.LogWarning(message);
        //        return Result.FromError<AuthenticateListBody>(message);
        //    }
        //}

        /// <summary>
        /// 根据身份证查工号【第三方接口：/oppo/ps/get_empno_by_nationalid】
        /// </summary>
        /// <param name="nationalId">身份证号</param>
        /// <returns></returns>
        public async Task<Result<EmpInfo>> GetEmpnobyNationalId(string nationalId)
        {
            var response = await _EsbService.GetEmpnobyNationalId(new EmpInfoRequest() { NationalId = nationalId });

            if (response.Response.Code == "0")
            {
                var data = ObjectMapper.Map<EmpInfoDto, EmpInfo>(response.Response.Empinfo);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogWarning(message);
                return Result.FromError<EmpInfo>(message);
            }

        }

    }
}
