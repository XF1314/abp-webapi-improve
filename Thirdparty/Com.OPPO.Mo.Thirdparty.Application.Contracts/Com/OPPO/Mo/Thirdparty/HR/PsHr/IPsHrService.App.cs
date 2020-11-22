using Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.PsHr.Response;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Dtos;
using Com.OPPO.Mo.Thirdparty.HR.PsHr.Dtos;
using Com.OPPO.Mo.Thirdparty.HR.PsHr.Response;
using Com.OPPO.Mo.Thirdparty.HR.PsHr.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr
{

    /// <summary>
    /// PeopleSoft—— 内部调动/认证报名/社会招聘审批 ——应用服务接口
    /// </summary>
    public interface IPsHrAppService : IApplicationService
    {

        ///// <summary>
        ///// 查询用户有授权的it系统
        ///// </summary>
        ///// <param name="userId">用户id</param>
        ///// <param name="queryType">1表示只获取有角色的it系统，2表示只获取有权限的it系统，3表示获取全部</param>
        ///// <returns></returns>
        //Task<Result<List<AuthorizationSystem>>> GetUserPermAppList(string userId, QueryTypeEnum queryType);

        ///// <summary>
        ///// 用户权限及角色查询接口，按用户ID、应用ID查询，支持分页及权限/角色模糊查询
        ///// </summary>
        ///// <param name="permissionsAndRolesDto"></param>
        ///// <returns></returns>
        //Task<Result<List<AuthorizationSystem>>> GetUserApplicationSystemPermissionsAndRoles(PermissionsAndRolesDto permissionsAndRolesDto);


        /// <summary>
        /// 根据通道，专业领域，职族查询岗位信息接口
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        Task<Result<List<PositionInformationResponse>>> QueryPositionInformation(PsBadyRequestDto<List<PositionInformationQueryDto>> psBadyRequest);

        /// <summary>
        /// 查询职级清单接口
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        Task<Result<List<RankResponse>>> QueryRankList(PsBadyRequestDto<List<RankQueryDto>> psBadyRequest);


        /// <summary>
        /// 查询调动员工相关信息接口（绩效状态，转正状态，职族）
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        Task<Result<List<TransferEmployeeResponse>>> QueryTransferEmployeeInformation(PsBadyRequestDto<List<TransferEmployeeQueryDto>> psBadyRequest);

        /// <summary>
        /// 员工职务数据更新接口
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        Task<Result<List<EmployeeJobDataUpdateResponse>>> UpdateEmployeeJobData(PsBadyRequestDto<List<EmployeeJobDataUpdateDto>> psBadyRequest);

        /// <summary>
        /// 查询职务职级列表接口
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        Task<Result<List<JobRankListResponse>>> QueryJobRankList(PsBadyRequestDto<List<JobRankListQueryDto>> psBadyRequest);

        /// <summary>
        /// 更新纳税单位或部门接口
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        Task<Result<List<TaxUnitOrDepartmentUpdateResponse>>> UpdateTaxUnitOrDepartment(PsBadyRequestDto<List<TaxUnitOrDepartmentUpdateDto>> psBadyRequest);


        /// <summary>
        /// 查询通道列表接口
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        Task<Result<JobFunctionListResponse<List<JobFuncs>>>> QueryJobFunctionList(PsBadyRequestDto psBadyRequest);

        /// <summary>
        /// 查询通道的领域信息接口
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        Task<Result<SubJobFuncResponse<List<SubJobFunction>>>> QuerySubFunctionList(PsBadyRequestDto<List<SubFunctionQueryDto>> psBadyRequest);


        /// <summary>
        /// 编制数据查询接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_GETHCINFO.v1/】
        /// </summary>
        /// <param name="orgCode">需要查询的组织编号</param>
        /// <param name="applierNum">申请人数</param>
        /// <returns></returns>
        Task<Result<DepartmentManningQuotas>> GetPreparation(string orgCode, string applierNum);

        /// <summary>
        /// 审批编制数据处理接口
        /// </summary>
        /// <param name="hcQuery"></param>
        /// <returns></returns>
        Task<Result> ApprovalPreparation(ApprovalPreparationDto hcQuery);

        /// <summary>
        /// 社招员工薪酬数据提报接口
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Result<List<SalaryDockResults>>> SalaryDocking(List<SalaryInfoDto> dto);


        /// <summary>
        /// 国家/地区、工作城市、办公地点查询接口
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Result<OfficeLocationResponse>> OfficeLocationQuery(PsBadyRequestDto<List<OfficeLocationDto>>  dto);

        /// <summary>
        /// 请假数据推送接口
        /// </summary>
        /// <param name="dto">请假信息</param>
        /// <returns></returns>
        Task<Result<List<EmployeeJobDataUpdateResponse>>> LeavePush(PsBadyRequestDto<List<LeaveDataDto>> dto);

        /// <summary>
        /// 确认请假数据接口
        /// </summary>
        /// <param name="dto">请假信息</param>
        /// <returns></returns>
        Task<Result<List<EmployeeJobDataUpdateResponse>>> LeaveUpdate(PsBadyRequestDto<List<LeaveUpdateDto>> dto);


        /// <summary>
        /// 第二次推送请假数据接口
        /// </summary>
        /// <param name="dto">请假信息</param>
        /// <returns></returns>
        Task<Result<List<EmployeeJobDataUpdateResponse>>> LeaveChange(PsBadyRequestDto<List<LeaveChangeDto>> dto);

        /// <summary>
        /// 查询入职时间和社会工龄增量列表接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="dto">查询组合信息</param>
        /// <returns></returns>
       Task<Result<List<EmployResult>>> QueryEmployeeEntrytimeInfo(PsBadyRequestDto<List<QueryConditionDto>> dto);
    }
}
