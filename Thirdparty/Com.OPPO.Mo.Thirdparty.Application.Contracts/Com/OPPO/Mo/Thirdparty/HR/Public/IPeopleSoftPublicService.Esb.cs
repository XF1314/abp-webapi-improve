
﻿using Com.OPPO.Mo;
using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Requests;
using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Responses;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Request;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Requests;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Responses;
using Com.OPPO.Mo.Thirdparty.Hr.Rewar.Response;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public
{
    /// <summary>
    /// PeopleSoft请假/加班申请/认证报名/社会招聘审批  Esb服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IPeopleSoftPublicEsbService : IHttpApi
    {
        /// <summary>
        /// 请假数据推送接口
        /// </summary>
        /// <param name="queryRequest"></param>
        /// <returns></returns>
        [HttpPost("/oppo/ps/leave_push")]
        Task<EsbResponse> AddLeaveInfo([FormContent] PeopleSoftLeaveInfoAddRequest queryRequest);

        /// <summary>
        /// 请假数据确认接口,POST方式
        /// </summary>
        /// <param name="queryRequest"></param>
        /// <returns></returns>
        [HttpPost("/oppo/ps/leave_update")]
        Task<EsbResponse> UpdateLeaveInfo([FormContent] PeopleSoftLeaveInfoUpdateRequest queryRequest);

        /// <summary>
        /// 请假数据第二次推送接口,POST方式
        /// </summary>
        /// <param name="queryRequest"></param>
        /// <returns></returns>
        [HttpPost("/oppo/ps/leave_change")]
        Task<EsbResponse> LeaveChange([FormContent] PeopleSoftLeaveInfoAddRequest queryRequest);

        /// <summary>
        /// 根据工号获取月薪信息
        /// </summary>
        /// <param name="emplid">工号</param>
        /// <returns></returns>
        [HttpGet("/oppo/ps/get_comprate_by_emplid")]
        Task<PeopleSoftResponse<List<MonthSalaryInfo>>> GetComprateByEmplid([PathQuery] PsMonthSalaryRequest emplid);


        /// <summary>
        /// 月薪制法定节假日加班补报和A工时补发报推送接口
        /// </summary>
        /// <param name="queryRequest"></param>
        /// <returns></returns>
        [HttpPost("/oppo/ps/po_ps_c_mo_ot_event")]
        Task<EsbResponse> MonthlyOvertimeReportAndAWorkTimeReissue([FormContent]LinesRequest queryRequest);


        /// <summary>
        /// 加班工时添加接口
        /// </summary>
        /// <param name="queryRequest"></param>
        /// <returns></returns>
        [HttpPost("/oppo/ps/workhours_put")]
        Task<EsbResponse> AddOvertimeRequest([FormContent]OvertimePushRequest queryRequest);

        /// <summary>
        /// 认证信息查询 【第三方接口：/oppo/ps/authenticate_list】
        /// </summary>
        /// <param name="queryRequest"></param>
        /// <returns></returns>
        [HttpGet("/oppo/ps/authenticate_list")]
        Task<AuthenticateListResponse> QueryAuthenticateListByEmployid([PathQuery]QueryAuthenticateListRequest queryRequest);

        /// <summary>
        /// 根据身份证查工号【第三方接口：/oppo/ps/get_empno_by_nationalid】
        /// </summary>
        /// <param name="getEmpEsbQuery">GetEmpEsbQuery</param>
        /// <returns></returns>
        [HttpGet("/oppo/ps/get_empno_by_nationalid")]
        Task<EmpInfoResponse> GetEmpnobyNationalId([PathQuery]EmpInfoRequest getEmpEsbQuery);
    }
}
