using Com.OPPO.Mo.Thirdparty.Hr.PsHr.Request;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Requests;
using Com.OPPO.Mo.Thirdparty.HR.PsHr.Request;
using Com.OPPO.Mo.Thirdparty.HR.PsHr.Requests;
using Com.OPPO.Mo.Thirdparty.HR.Public.Requests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr
{
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [ConfigurableHttpHost(ThirdpartySettingNames.PsWebApiHost)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    public interface IHrPsWebApiService:IHttpApi
    {
        /// <summary>
        /// 根据通道，专业领域，职族查询岗位信息接口
        /// </summary>
        /// <param name="hcQuery"></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/")]
        Task<Stream> QueryPositionInformation([JsonContent]PsBadyRequest<List<PositionInformationQuery>> hcQuery);

        /// <summary>
        ///  查询职级清单接口
        /// </summary>
        /// <param name="hcQuery"></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/")]
        Task<Stream> QueryRankList([JsonContent]PsBadyRequest hcQuery);

        /// <summary>
        ///  查询调动员工相关信息接口（绩效状态，转正状态，职族）
        /// </summary>
        /// <param name="hcQuery"></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/")]
        Task<Stream> QueryTransferEmployeeInformation([JsonContent]PsBadyRequest<List<TransferEmployeeQuery>> hcQuery);


        /// <summary>
        ///  员工职务数据更新接口
        /// </summary>
        /// <param name="hcQuery"></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/")]
        Task<Stream> UpdateEmployeeJobData([JsonContent]PsBadyRequest<List<EmployeeJobDataUpdate>> hcQuery);

        /// <summary>
        ///  查询职务职级列表接口
        /// </summary>
        /// <param name="hcQuery"></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/")]
        Task<Stream> QueryJobRankList([JsonContent]PsBadyRequest<List<JobRankListQuery>> hcQuery);

        /// <summary>
        ///  更新纳税单位或部门接口
        /// </summary>
        /// <param name="hcQuery"></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/")]
        Task<Stream> UpdateTaxUnitOrDepartment([JsonContent]PsBadyRequest<List<TaxUnitOrDepartmentUpdate>> hcQuery);

        /// <summary>
        ///  查询职级清单接口
        /// </summary>
        /// <param name="hcQuery"></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/")]
        Task<Stream> QueryJobFunctionList([JsonContent]PsBadyRequest hcQuery);

        /// <summary>
        ///  查询通道的领域信息接口
        /// </summary>
        /// <param name="hcQuery"></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/")]
        Task<Stream> QuerySubFunctionList([JsonContent]PsBadyRequest<List<SubFunctionQuery>> hcQuery);


        /// <summary>
        /// 编制数据查询接口
        /// </summary>
        /// <param name="hcQuery"></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_GETHCINFO.v1/")]
        Task<Stream> GetPreparation([JsonContent]QueryPreparationRequest hcQuery);

        /// <summary>
        /// 审批编制数据处理接口
        /// </summary>
        /// <param name="hcQuery"></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_HCAPPINFO.v1/")]
        Task<Stream> ApprovalPreparation([JsonContent]ApprovalPreparationRequest hcQuery);

        /// <summary>
        /// 社招员工薪酬数据提报接口
        /// </summary>
        /// <param name="hcQuery"></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_IMP_PAY2.v1/")]
        Task<Stream> SalaryDocking([JsonContent]SalaryDockRequest hcQuery);


        /// <summary>
        /// 国家/地区、工作城市、办公地点查询接口
        /// </summary>
        /// <param name="hcQuery"></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/")]
        Task<Stream> OfficeLocationQuery([JsonContent]PsBadyRequest<List<OfficeLocation>> hcQuery);

        /// <summary>
        /// 请假数据推送接口
        /// </summary>
        /// <param name="hcQuery"></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/")]
        Task<Stream> LeavePush([JsonContent]PsBadyRequest<List<LeaveDataInfo>> hcQuery);

        /// <summary>
        /// 确认请假数据接口
        /// </summary>
        /// <param name="hcQuery"></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/")]
        Task<Stream> LeaveUpdate([JsonContent]PsBadyRequest<List<LeaveUpdate>> hcQuery);

        /// <summary>
        /// 第二次推送请假数据接口
        /// </summary>
        /// <param name="hcQuery"></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/")]
        Task<Stream> LeaveChange([JsonContent]PsBadyRequest<List<LeaveChangeInfo>> hcQuery);


        /// <summary>
        /// 查询入职时间和社会工龄增量列表接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="hcQuery"></param>
        /// <returns></returns>
        [HttpPost("/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/")]
        Task<Stream> QueryEmployeeEntrytimeInfo([JsonContent]PsBadyRequest<List<QueryCondition>> hcQuery);
    }
}
