using Com.OPPO.Mo.Thirdparty.Hr.PsHr;
using Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.PsHr.Response;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Dtos;
using Com.OPPO.Mo.Thirdparty.HR.PsHr.Dtos;
using Com.OPPO.Mo.Thirdparty.HR.PsHr.Response;
using Com.OPPO.Mo.Thirdparty.HR.PsHr.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.HR
{

    /// <summary>
    /// psft-hr资源 内部调动/认证报名/社会招聘审批
    /// </summary>
    [Area("hr")]
    [Route("api/mo/thirdparty/ps/psft-hr")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class PeopleSoftHrController : AbpController, IPsHrAppService
    {
        private readonly IPsHrAppService  _AppService;

        public PeopleSoftHrController(IPsHrAppService AppService)
        {
            _AppService = AppService;
        }

    
        ///// <summary>
        ///// 查询用户有授权的it系统【第三方接口：/oppo/upm/user/perm/app/list】
        ///// </summary>
        ///// <param name="userId">用户id</param>
        ///// <param name="queryType">1表示只获取有角色的it系统，2表示只获取有权限的it系统，3表示获取全部</param>
        ///// <returns></returns>
        //[HttpGet("upm/query-user-role-app")]
        //public async Task<Result<List<AuthorizationSystem>>> GetUserPermAppList([Required]string userId, [Required]QueryTypeEnum queryType)
        //{
        //    return await _AppService.GetUserPermAppList(userId, queryType);
        //}

        /// <summary>
        /// 根据通道，专业领域，职族查询岗位信息接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        [HttpPost("query-position-information")]
        public async Task<Result<List<PositionInformationResponse>>> QueryPositionInformation([FromBody]PsBadyRequestDto<List<PositionInformationQueryDto>> psBadyRequest)
        {
            return await _AppService.QueryPositionInformation(psBadyRequest);
        }

        /// <summary>
        /// 查询职级清单接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        [HttpPost("query-rank-list")]
        public async Task<Result<List<RankResponse>>> QueryRankList([FromBody]PsBadyRequestDto<List<RankQueryDto>> psBadyRequest)
        {
            return await _AppService.QueryRankList(psBadyRequest);
        }

        /// <summary>
        /// 查询调动员工相关信息接口（绩效状态，转正状态，职族）【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        [HttpPost("query-transfer-employee-information")]
        public async Task<Result<List<TransferEmployeeResponse>>> QueryTransferEmployeeInformation(PsBadyRequestDto<List<TransferEmployeeQueryDto>> psBadyRequest)
        {
            return await _AppService.QueryTransferEmployeeInformation(psBadyRequest);
        }

        /// <summary>
        /// 员工职务数据更新接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        [HttpPut("update-employee-job-data")]
        public async Task<Result<List<EmployeeJobDataUpdateResponse>>> UpdateEmployeeJobData(PsBadyRequestDto<List<EmployeeJobDataUpdateDto>> psBadyRequest)
        {
            return await _AppService.UpdateEmployeeJobData(psBadyRequest);
        }

        /// <summary>
        /// 查询职务职级列表接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        [HttpPost("query-job-rank-list")]
        public async Task<Result<List<JobRankListResponse>>> QueryJobRankList(PsBadyRequestDto<List<JobRankListQueryDto>> psBadyRequest)
        {
            return await _AppService.QueryJobRankList(psBadyRequest);
        }


        /// <summary>
        /// 更新纳税单位或部门接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        [HttpPut("update-taxunit-or-department")]
        public async Task<Result<List<TaxUnitOrDepartmentUpdateResponse>>> UpdateTaxUnitOrDepartment(PsBadyRequestDto<List<TaxUnitOrDepartmentUpdateDto>> psBadyRequest)
        {
            return await _AppService.UpdateTaxUnitOrDepartment(psBadyRequest);
        }

        /// <summary>
        /// 查询通道列表接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        [HttpPost("query-jobfunction-list")]
        public async Task<Result<JobFunctionListResponse<List<JobFuncs>>>> QueryJobFunctionList([FromBody]PsBadyRequestDto psBadyRequest)
        {
            return await _AppService.QueryJobFunctionList(psBadyRequest);
        }

        /// <summary>
        /// 查询通道的领域信息接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        [HttpPost("query-subfunction-list")]
        public async Task<Result<SubJobFuncResponse<List<SubJobFunction>>>> QuerySubFunctionList([FromBody]PsBadyRequestDto<List<SubFunctionQueryDto>> psBadyRequest)
        {
            return await _AppService.QuerySubFunctionList(psBadyRequest);
        }

        /// <summary>
        /// 编制数据查询接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_GETHCINFO.v1/】
        /// </summary>
        /// <param name="orgCode">需要查询的组织编号</param>
        /// <param name="applierNum">申请人数</param>
        /// <returns></returns>
        [HttpPost("query-preparation")]
        public async Task<Result<DepartmentManningQuotas>> GetPreparation([Required]string orgCode, [Required]string applierNum)
        {
            return await _AppService.GetPreparation(orgCode, applierNum);
        }

        /// <summary>
        /// 审批编制数据处理接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_HCAPPINFO.v1/】
        /// </summary>
        /// <param name="approvalPreparationDto">审批编制数据</param>
        /// <returns></returns>
        [HttpPost("approval-preparation")]
        public async Task<Result> ApprovalPreparation([FromBody]ApprovalPreparationDto approvalPreparationDto)
        {
            return await _AppService.ApprovalPreparation(approvalPreparationDto);
        }

        /// <summary>
        /// 社招员工薪酬数据提报接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_IMP_PAY2.v1/】
        /// </summary>
        /// <param name="dto">员工薪酬数据</param>
        /// <returns></returns>
        [HttpPost("salary-docking")]
        public async Task<Result<List<SalaryDockResults>>> SalaryDocking([FromBody]List<SalaryInfoDto> dto)
        {
            return await _AppService.SalaryDocking(dto);
        }

        /// <summary>
        /// 国家/地区、工作城市、办公地点查询接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="dto">办公地点</param>
        /// <returns></returns>
        [HttpPost("query-office-location")]
        public async Task<Result<OfficeLocationResponse>> OfficeLocationQuery([FromBody]PsBadyRequestDto<List<OfficeLocationDto>>  dto)
        {
            return await _AppService.OfficeLocationQuery(dto);
        }

        /// <summary>
        /// 请假数据推送接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="dto">请假信息</param>
        /// <returns></returns>
        [HttpPost("leave/leave-add")]
        public async Task<Result<List<EmployeeJobDataUpdateResponse>>> LeavePush([FromBody]PsBadyRequestDto<List<LeaveDataDto>> dto)
        {
            return await _AppService.LeavePush(dto);
        }

        /// <summary>
        /// 确认请假数据接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="dto">请假信息</param>
        /// <returns></returns>
        [HttpPut("leave/leave-update")]
        public async Task<Result<List<EmployeeJobDataUpdateResponse>>> LeaveUpdate([FromBody]PsBadyRequestDto<List<LeaveUpdateDto>> dto)
        {
            return await _AppService.LeaveUpdate(dto);
        }

        /// <summary>
        /// 第二次推送请假数据接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="dto">请假信息</param>
        /// <returns></returns>
        [HttpPost("leave/leave-change")]
        public async Task<Result<List<EmployeeJobDataUpdateResponse>>> LeaveChange([FromBody]PsBadyRequestDto<List<LeaveChangeDto>> dto)
        {
            return await _AppService.LeaveChange(dto);
        }

        /// <summary>
        /// 查询入职时间和社会工龄增量列表接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="dto">查询组合信息</param>
        /// <returns></returns>
        [HttpPost("query-employee-entrytime-info")]
        public async Task<Result<List<EmployResult>>> QueryEmployeeEntrytimeInfo([FromBody]PsBadyRequestDto<List<QueryConditionDto>> dto)
        {
            return await _AppService.QueryEmployeeEntrytimeInfo(dto);
        }

    }

}
