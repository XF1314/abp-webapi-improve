using Com.OPPO.Mo.Thirdparty.Hr.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Responses;
using Com.OPPO.Mo.Thirdparty.Hr.Requests;
using Com.OPPO.Mo.Thirdparty.Hr.Responses;
using Com.OPPO.Mo.Thirdparty.Hr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.LeaveBatch
{
    [Authorize]
    public class LeaveBatchAppService: ThirdpartyAppServiceBase, ILeaveBatchAppService
    {
        private readonly ILeaveBatchWebApiService _hrLeaveBatchService;
        public LeaveBatchAppService(
            ILeaveBatchWebApiService LeaveBatchService)
        {
            _hrLeaveBatchService = LeaveBatchService;
        }
        public async Task<Result> LeaveBatchPush(BatchLeavePushInfo LeaveBatchPushInput)
        {
            if (string.IsNullOrWhiteSpace(LeaveBatchPushInput.ProcessInstanceCode))
                return Result.FromError($"{LeaveBatchPushInput.ProcessInstanceCode}不能为空。");
            else
            {
                List<LeaveBatchData> leavedatas = new List<LeaveBatchData>();
                int i = 0;
                foreach (var item in LeaveBatchPushInput.LeaveDatas) {                    
                    LeaveBatchData leavedata = new LeaveBatchData();
                    if (string.IsNullOrWhiteSpace(item.EmployeeId)) {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}EmployeeId不能为空。");
                    }
                    leavedata.employee_id = item.EmployeeId.Trim();
                    if (string.IsNullOrWhiteSpace(item.ProcessInstanceCode))
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}FormInstanceCode不能为空。");
                    }
                    leavedata.formInstance_code = item.ProcessInstanceCode;
                    if (string.IsNullOrWhiteSpace(item.BeginDate))
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}BeginDate不能为空。");
                    }
                    leavedata.begin_date = item.BeginDate;
                    if (string.IsNullOrWhiteSpace(item.BeginTime))
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}BeginTime不能为空。");
                    }
                    leavedata.begin_time = item.BeginTime;
                    if (string.IsNullOrWhiteSpace(item.EndDate))
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}EndDate不能为空。");
                    }
                    leavedata.end_date = item.EndDate;
                    if (string.IsNullOrWhiteSpace(item.EndTime))
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}EndTime不能为空。");
                    }
                    leavedata.end_time = item.EndTime;
                    if (string.IsNullOrWhiteSpace(item.IsItConsistentWithLeaveInfo))
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}IsItConsistentWithLeaveInfo不能为空。");
                    }
                    if (item.IsItConsistentWithLeaveInfo!="Y"&& item.IsItConsistentWithLeaveInfo != "N")
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}IsItConsistentWithLeaveInfo格式不正确，取值范围为Y 或 N。");
                    }
                    leavedata.flag = item.IsItConsistentWithLeaveInfo;
                    if (string.IsNullOrWhiteSpace(item.CancelLeave))
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}CancelLeave不能为空。");
                    }
                    if (item.CancelLeave != "Y" && item.CancelLeave != "N")
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}CancelLeave格式不正确，取值范围为Y 或 N。");
                    }
                    leavedata.flag1 = item.CancelLeave;
                    if (string.IsNullOrWhiteSpace(item.LeaveCause))
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}LeaveCause不能为空。");
                    }
                    leavedata.leave_cause = item.LeaveCause;
                    leavedata.c_days = item.TotalDays;
                    leavedata.c_abs_days01 = item.DaysOfPersonalLeave;
                    leavedata.c_abs_days02 = item.DaysOfAnnualLeave;
                    leavedata.c_abs_days03 = item.DaysOfWeekend;
                    leavedata.c_abs_days04 = item.DaysOfNursingLeave;
                    leavedata.c_abs_days05 = item.DaysOfMarriageLeave;
                    leavedata.c_abs_days06 = item.DaysOfAntenatalExaminationLeave;
                    leavedata.c_abs_days07 = item.DaysOfMaternityLeave;
                    leavedata.c_abs_days08 = item.DaysOfSickLeave;
                    leavedata.c_abs_days09 = item.DaysOfSpecialLeave;
                    leavedata.c_abs_days10 = item.DaysOfInjuryLeave;
                    leavedata.c_abs_days11 = item.DaysOfFuneralLeave;
                    leavedata.approval_date = item.ApproveDate;
                    leavedata.approve_date = item.ApproveDate;
                    leavedata.comments = item.Comments;
                    leavedatas.Add(leavedata);
                    i++;
                }
                LeaveBatchRequest pushInfo = new LeaveBatchRequest();
                pushInfo.formInstance_code = LeaveBatchPushInput.ProcessInstanceCode;
                pushInfo.leave_data = JsonConvert.SerializeObject(leavedatas);
                
                //TODO:验证CompileInfo是否合格的Json格式
                var response = await _hrLeaveBatchService.LeaveBatchPust(pushInfo);

                if (response.IsOk)
                    return Result.Ok();
                else
                {
                    var message = $"【{response.Body?.BussinessCode}】{response.Body?.Message}";
                    Logger.LogError(message);
                    return Result.FromError(message);
                }
            }
        }
        public async Task<Result> LeaveBatchVisitorsPush(BatchLeavePushInfo LeaveBatchPushInput)
        {
            if (string.IsNullOrWhiteSpace(LeaveBatchPushInput.ProcessInstanceCode))
                return Result.FromError($"{LeaveBatchPushInput.ProcessInstanceCode}不能为空。");
            else
            {
                List<LeaveBatchData> leavedatas = new List<LeaveBatchData>();
                int i = 0;
                foreach (var item in LeaveBatchPushInput.LeaveDatas)
                {
                    LeaveBatchData leavedata = new LeaveBatchData();
                    if (string.IsNullOrWhiteSpace(item.EmployeeId))
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}EmployeeId不能为空。");
                    }
                    leavedata.employee_id = item.EmployeeId.Trim();
                    if (string.IsNullOrWhiteSpace(item.ProcessInstanceCode))
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}FormInstanceCode不能为空。");
                    }
                    leavedata.formInstance_code = item.ProcessInstanceCode;
                    if (string.IsNullOrWhiteSpace(item.BeginDate))
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}BeginDate不能为空。");
                    }
                    leavedata.begin_date = item.BeginDate;
                    if (string.IsNullOrWhiteSpace(item.BeginTime))
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}BeginTime不能为空。");
                    }
                    leavedata.begin_time = item.BeginTime;
                    if (string.IsNullOrWhiteSpace(item.EndDate))
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}EndDate不能为空。");
                    }
                    leavedata.end_date = item.EndDate;
                    if (string.IsNullOrWhiteSpace(item.EndTime))
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}EndTime不能为空。");
                    }
                    leavedata.end_time = item.EndTime;
                    if (string.IsNullOrWhiteSpace(item.IsItConsistentWithLeaveInfo))
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}IsItConsistentWithLeaveInfo不能为空。");
                    }
                    if (item.IsItConsistentWithLeaveInfo != "Y" && item.IsItConsistentWithLeaveInfo != "N")
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}IsItConsistentWithLeaveInfo格式不正确，取值范围为Y 或 N。");
                    }
                    leavedata.flag = item.IsItConsistentWithLeaveInfo;
                    if (string.IsNullOrWhiteSpace(item.CancelLeave))
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}CancelLeave不能为空。");
                    }
                    if (item.CancelLeave != "Y" && item.CancelLeave != "N")
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}CancelLeave格式不正确，取值范围为Y 或 N。");
                    }
                    leavedata.flag1 = item.CancelLeave;
                    if (string.IsNullOrWhiteSpace(item.LeaveCause))
                    {
                        return Result.FromError($"{LeaveBatchPushInput.LeaveDatas}LeaveCause不能为空。");
                    }
                    leavedata.leave_cause = item.LeaveCause;
                    leavedata.c_days = item.TotalDays;
                    leavedata.c_abs_days01 = item.DaysOfPersonalLeave;
                    leavedata.c_abs_days02 = item.DaysOfAnnualLeave;
                    leavedata.c_abs_days03 = item.DaysOfWeekend;
                    leavedata.c_abs_days04 = item.DaysOfNursingLeave;
                    leavedata.c_abs_days05 = item.DaysOfMarriageLeave;
                    leavedata.c_abs_days06 = item.DaysOfAntenatalExaminationLeave;
                    leavedata.c_abs_days07 = item.DaysOfMaternityLeave;
                    leavedata.c_abs_days08 = item.DaysOfSickLeave;
                    leavedata.c_abs_days09 = item.DaysOfSpecialLeave;
                    leavedata.c_abs_days10 = item.DaysOfInjuryLeave;
                    leavedata.c_abs_days11 = item.DaysOfFuneralLeave;
                    leavedata.approval_date = item.ApproveDate;
                    leavedata.approve_date = item.ApproveDate;
                    leavedata.comments = item.Comments;
                    leavedatas.Add(leavedata);
                    i++;
                }
                LeaveBatchVisitorRequest pushInfo = new LeaveBatchVisitorRequest();
                pushInfo.formInstance_code = LeaveBatchPushInput.ProcessInstanceCode;
                pushInfo.send_data = JsonConvert.SerializeObject(leavedatas);

                //TODO:验证CompileInfo是否合格的Json格式
                var response = await _hrLeaveBatchService.LeaveBatchVisitorsPush(pushInfo);

                if (response.IsOk)
                    return Result.Ok();
                else
                {
                    var message = $"【{response.Body?.BussinessCode}】{response.Body?.Message}";
                    Logger.LogError(message);
                    return Result.FromError(message);
                }
            }
        }
    }
}
