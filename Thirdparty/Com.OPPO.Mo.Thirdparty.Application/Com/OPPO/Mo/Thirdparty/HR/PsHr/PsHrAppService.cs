
using Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.PsHr.Request;
using Com.OPPO.Mo.Thirdparty.Hr.PsHr.Response;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.Public.Requests;
using Com.OPPO.Mo.Thirdparty.HR.PsHr.Dtos;
using Com.OPPO.Mo.Thirdparty.HR.PsHr.Request;
using Com.OPPO.Mo.Thirdparty.HR.PsHr.Requests;
using Com.OPPO.Mo.Thirdparty.HR.PsHr.Response;
using Com.OPPO.Mo.Thirdparty.HR.PsHr.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr
{
    /// <summary>
    /// 内部调动/认证报名/社会招聘审批
    /// </summary>
    [Authorize]
    public class PsHrAppService : ThirdpartyAppServiceBase, IPsHrAppService
    {
        private readonly IConfiguration _configuration;
        private readonly IHrPsWebApiService  _PsWebApiService;

        public PsHrAppService(IConfiguration configuration, IHrPsWebApiService PsWebApiService)
        {
            _configuration = configuration;
            _PsWebApiService = PsWebApiService;
        }

        ///// <summary>
        ///// 查询用户有授权的it系统
        ///// </summary>
        ///// <param name="userId"></param>
        ///// <param name="queryType"></param>
        ///// <returns></returns>
        //public async Task<Result<List<AuthorizationSystem>>> GetUserPermAppList(string userId, QueryTypeEnum queryType)
        //{
        //    AuthorizationSystemQuery query = new AuthorizationSystemQuery { UserId = userId, QueryType = queryType };
        //    var response = await  _WebApiService.GetUserPermAppList(query);
        //    if (response.success == "true")
        //        return Result.Ok(response.body);
        //    else
        //    {
        //        var message = $"【{response.resultCode}】{response.cause}";
        //        Logger.LogWarning(message);
        //        return Result.FromError<List<AuthorizationSystem>>(message);
        //    }
        //}

      

        /// <summary>
        /// 根据通道，专业领域，职族查询岗位信息接口
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        public async Task<Result<List<PositionInformationResponse>>> QueryPositionInformation(PsBadyRequestDto<List<PositionInformationQueryDto>> psBadyRequest)
        {
           
                string ret = null;
                var list = ObjectMapper.Map<List<PositionInformationQueryDto>, List<PositionInformationQuery>>(psBadyRequest.datas);

                PsBadyRequest<List<PositionInformationQuery>> psBady = new PsBadyRequest<List<PositionInformationQuery>>
                {
                    datas = list,
                    InterfaceCode = psBadyRequest.InterfaceCode,
                    SystemCode = psBadyRequest.SystemCode,
                    Language = psBadyRequest.Language
                };
                var resSteam = await _PsWebApiService.QueryPositionInformation(psBady);
                using (Stream getStream = new System.IO.Compression.GZipStream(resSteam, System.IO.Compression.CompressionMode.Decompress))
                {
                    using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                    {
                        ret = streamReader.ReadToEnd();
                    }
                }
                if (!string.IsNullOrEmpty(ret))
                {
                    var resmodel = JsonConvert.DeserializeObject<PsHrBaseResponse<List<PositionInformationResponseDto>>>(ret);
                    if (resmodel.code == "200")
                    {
                        var datas = ObjectMapper.Map<List<PositionInformationResponseDto>, List<PositionInformationResponse>>(resmodel.datas);
                        return Result.FromData(datas);
                    }
                    else
                    {
                        var message = $"【{resmodel.code}】{resmodel.message}";
                        Logger.LogWarning(message);
                        return Result.FromError<List<PositionInformationResponse>>(message);
                    }
                }
          
            return Result.FromError<List<PositionInformationResponse>>("请求错误");
        }


        /// <summary>
        ///查询职级清单接口
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        public async Task<Result<List<RankResponse>>> QueryRankList(PsBadyRequestDto<List<RankQueryDto>> psBadyRequest)
        {
            string ret = null;
            var list = ObjectMapper.Map<List<RankQueryDto>, List<RankQuery>>(psBadyRequest.datas);

            PsBadyRequest<List<RankQuery>> psBady = new PsBadyRequest<List<RankQuery>>
            {
                datas = list,
                InterfaceCode = psBadyRequest.InterfaceCode,
                SystemCode = psBadyRequest.SystemCode,
                Language = psBadyRequest.Language
            };
            var resSteam = await _PsWebApiService.QueryRankList(psBady);
            using (Stream getStream = new System.IO.Compression.GZipStream(resSteam, System.IO.Compression.CompressionMode.Decompress))
            {
                using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                {
                    ret = streamReader.ReadToEnd();
                }
            }
            if (!string.IsNullOrEmpty(ret))
            {
                var resmodel = JsonConvert.DeserializeObject<PsHrBaseResponse<List<RankResponseDto>>>(ret);
                if (resmodel.code == "200")
                {
                    var datas = ObjectMapper.Map<List<RankResponseDto>, List<RankResponse>>(resmodel.datas);
                    return Result.FromData(datas);
                }
                else
                {
                    var message = $"【{resmodel.code}】{resmodel.message}";
                    Logger.LogWarning(message);
                    return Result.FromError<List<RankResponse>>(message);
                }
            }
            return Result.FromError<List<RankResponse>>("请求错误");
        }

        /// <summary>
        /// 查询调动员工相关信息接口（绩效状态，转正状态，职族）
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        public async Task<Result<List<TransferEmployeeResponse>>> QueryTransferEmployeeInformation(PsBadyRequestDto<List<TransferEmployeeQueryDto>> psBadyRequest)
        {
            string ret = null;
            var list = ObjectMapper.Map<List<TransferEmployeeQueryDto>, List<TransferEmployeeQuery>>(psBadyRequest.datas);

            PsBadyRequest<List<TransferEmployeeQuery>> psBady = new PsBadyRequest<List<TransferEmployeeQuery>>
            {
                datas = list,
                InterfaceCode = psBadyRequest.InterfaceCode,
                SystemCode = psBadyRequest.SystemCode,
                Language = psBadyRequest.Language
            };
            var resSteam = await _PsWebApiService.QueryTransferEmployeeInformation(psBady);
            using (Stream getStream = new System.IO.Compression.GZipStream(resSteam, System.IO.Compression.CompressionMode.Decompress))
            {
                using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                {
                    ret = streamReader.ReadToEnd();
                }
            }
            if (!string.IsNullOrEmpty(ret))
            {
                var resmodel = JsonConvert.DeserializeObject<PsHrBaseResponse<List<TransferEmployeeResponseDto>>>(ret);
                if (resmodel.code == "200")
                {
                    var datas = ObjectMapper.Map<List<TransferEmployeeResponseDto>, List<TransferEmployeeResponse>>(resmodel.datas);
                    return Result.FromData(datas);
                }
                else
                {
                    var message = $"【{resmodel.code}】{resmodel.message}";
                    Logger.LogWarning(message);
                    return Result.FromError<List<TransferEmployeeResponse>>(message);
                }
            }
            return Result.FromError<List<TransferEmployeeResponse>>("请求错误");
        }


        /// <summary>
        /// 员工职务数据更新接口
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        public async Task<Result<List<EmployeeJobDataUpdateResponse>>> UpdateEmployeeJobData(PsBadyRequestDto<List<EmployeeJobDataUpdateDto>> psBadyRequest)
        {
            string ret = null;

            var list = ObjectMapper.Map<List<EmployeeJobDataUpdateDto>, List<EmployeeJobDataUpdate>>(psBadyRequest.datas);

            PsBadyRequest<List<EmployeeJobDataUpdate>> psBady = new PsBadyRequest<List<EmployeeJobDataUpdate>>
            {
                datas = list,
                InterfaceCode = psBadyRequest.InterfaceCode,
                SystemCode = psBadyRequest.SystemCode,
                Language = psBadyRequest.Language
            };
            var resSteam = await _PsWebApiService.UpdateEmployeeJobData(psBady);
            using (Stream getStream = new System.IO.Compression.GZipStream(resSteam, System.IO.Compression.CompressionMode.Decompress))
            {
                using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                {
                    ret = streamReader.ReadToEnd();
                }
            }
            if (!string.IsNullOrEmpty(ret))
            {
                try
                {
                    var resmodel = JsonConvert.DeserializeObject<PsHrBaseResponse<List<EmployeeJobDataUpdateResponseDto>>>(ret);
                    if (resmodel.code == "200")
                    {
                        var datas = ObjectMapper.Map<List<EmployeeJobDataUpdateResponseDto>, List<EmployeeJobDataUpdateResponse>>(resmodel.datas);
                        return Result.FromData(datas);
                    }
                    else
                    {
                        var message = $"【{resmodel.code}】{resmodel.message}";
                        Logger.LogWarning(message);
                        return Result.FromError<List<EmployeeJobDataUpdateResponse>>(message);
                    }
                }
                catch (Exception)
                {
                    return Result.FromError<List<EmployeeJobDataUpdateResponse>>(ret);
                }
            }
            return Result.FromError<List<EmployeeJobDataUpdateResponse>>("请求错误");
        }

        /// <summary>
        /// 查询职务职级列表接口
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        public async Task<Result<List<JobRankListResponse>>> QueryJobRankList(PsBadyRequestDto<List<JobRankListQueryDto>> psBadyRequest)
        {
            string ret = null;

            var list = ObjectMapper.Map<List<JobRankListQueryDto>, List<JobRankListQuery>>(psBadyRequest.datas);

            PsBadyRequest<List<JobRankListQuery>> psBady = new PsBadyRequest<List<JobRankListQuery>>
            {
                datas = list,
                InterfaceCode = psBadyRequest.InterfaceCode,
                SystemCode = psBadyRequest.SystemCode,
                Language = psBadyRequest.Language
            };
            var resSteam = await _PsWebApiService.QueryJobRankList(psBady);
            using (Stream getStream = new System.IO.Compression.GZipStream(resSteam, System.IO.Compression.CompressionMode.Decompress))
            {
                using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                {
                    ret = streamReader.ReadToEnd();
                }
            }
            if (!string.IsNullOrEmpty(ret))
            {
                try
                {
                    var resmodel = JsonConvert.DeserializeObject<PsHrBaseResponse<List<JobRankListResponseDto>>>(ret);
                    if (resmodel.code == "200")
                    {
                        var datas = ObjectMapper.Map<List<JobRankListResponseDto>, List<JobRankListResponse>>(resmodel.datas);
                        //JobRankListResponse model = new JobRankListResponse { TotalRows = resmodel.datas.totalRows, Datas = datas };
                        return Result.FromData(datas);
                    }
                    else
                    {
                        var message = $"【{resmodel.code}】{resmodel.message}";
                        Logger.LogWarning(message);
                        return Result.FromError<List<JobRankListResponse>>(message);
                    }
                }
                catch (Exception ex)
                {
                    return Result.FromError<List<JobRankListResponse>>(ret);
                }
            }
            return Result.FromError<List<JobRankListResponse>>("请求错误");
        }


        /// <summary>
        /// 更新纳税单位或部门接口
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        public async Task<Result<List<TaxUnitOrDepartmentUpdateResponse>>> UpdateTaxUnitOrDepartment(PsBadyRequestDto<List<TaxUnitOrDepartmentUpdateDto>> psBadyRequest)
        {
            string ret = null;

            var list = ObjectMapper.Map<List<TaxUnitOrDepartmentUpdateDto>, List<TaxUnitOrDepartmentUpdate>>(psBadyRequest.datas);

            PsBadyRequest<List<TaxUnitOrDepartmentUpdate>> psBady = new PsBadyRequest<List<TaxUnitOrDepartmentUpdate>>
            {
                datas = list,
                InterfaceCode = psBadyRequest.InterfaceCode,
                SystemCode = psBadyRequest.SystemCode,
                Language = psBadyRequest.Language
            };

            var resSteam = await _PsWebApiService.UpdateTaxUnitOrDepartment(psBady);
            using (Stream getStream = new System.IO.Compression.GZipStream(resSteam, System.IO.Compression.CompressionMode.Decompress))
            {
                using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                {
                    ret = streamReader.ReadToEnd();
                }
            }
            if (!string.IsNullOrEmpty(ret))
            {
                try
                {
                    var resmodel = JsonConvert.DeserializeObject<PsHrBaseResponse<List<TaxUnitOrDepartmentUpdateResponseDto>>>(ret);
                    if (resmodel.code == "200")
                    {
                        var datas = ObjectMapper.Map<List<TaxUnitOrDepartmentUpdateResponseDto>, List<TaxUnitOrDepartmentUpdateResponse>>(resmodel.datas);
                        return Result.FromData(datas);
                    }
                    else
                    {
                        var message = $"【{resmodel.code}】{resmodel.message}";
                        Logger.LogWarning(message);
                        return Result.FromError<List<TaxUnitOrDepartmentUpdateResponse>>(message);
                    }
                }
                catch (Exception)
                {
                    return Result.FromError<List<TaxUnitOrDepartmentUpdateResponse>>(ret);
                }
            }
            return Result.FromError<List<TaxUnitOrDepartmentUpdateResponse>>("请求错误");
        }


        /// <summary>
        ///查询通道列表接口
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        public async Task<Result<JobFunctionListResponse<List<JobFuncs>>>> QueryJobFunctionList(PsBadyRequestDto psBadyRequest)
        {
            try
            {
                string ret = null;
                var psBady = ObjectMapper.Map<PsBadyRequestDto, PsBadyRequest>(psBadyRequest);
                var resSteam = await _PsWebApiService.QueryJobFunctionList(psBady);
                using (Stream getStream = new System.IO.Compression.GZipStream(resSteam, System.IO.Compression.CompressionMode.Decompress))
                {
                    using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                    {
                        ret = streamReader.ReadToEnd();
                    }
                }
                if (!string.IsNullOrEmpty(ret))
                {
                    var resmodel = JsonConvert.DeserializeObject<PsHrBaseResponse<List<JobFunctionListResponse<List<JobFuncsDto>>>>>(ret);
                    if (resmodel.code == "200")
                    {
                        var jobFuncs = ObjectMapper.Map<List<JobFuncsDto>, List<JobFuncs>>(resmodel.datas[0].jobFuncs);
                        var datas = new JobFunctionListResponse<List<JobFuncs>> { totalRows = resmodel.datas[0].totalRows, jobFuncs = jobFuncs };
                        return Result.FromData(datas);
                    }
                    else
                    {
                        var message = $"【{resmodel.code}】{resmodel.message}";
                        Logger.LogWarning(message);
                        return Result.FromError<JobFunctionListResponse<List<JobFuncs>>>(message);
                    }
                }
            }
            catch (Exception ex)
            {

                return Result.FromError<JobFunctionListResponse<List<JobFuncs>>>(ex.Message);
            }
            return Result.FromError<JobFunctionListResponse<List<JobFuncs>>>("请求错误");
        }

        /// <summary>
        /// 查询通道的领域信息接口
        /// </summary>
        /// <param name="psBadyRequest"></param>
        /// <returns></returns>
        public async Task<Result<SubJobFuncResponse<List<SubJobFunction>>>> QuerySubFunctionList(PsBadyRequestDto<List<SubFunctionQueryDto>> psBadyRequest)
        {
            string ret = null;
            var list = ObjectMapper.Map<List<SubFunctionQueryDto>, List<SubFunctionQuery>>(psBadyRequest.datas);

            PsBadyRequest<List<SubFunctionQuery>> psBady = new PsBadyRequest<List<SubFunctionQuery>>
            {
                datas = list,
                InterfaceCode = psBadyRequest.InterfaceCode,
                SystemCode = psBadyRequest.SystemCode,
                Language = psBadyRequest.Language
            };

            var resSteam = await _PsWebApiService.QuerySubFunctionList(psBady);
            using (Stream getStream = new System.IO.Compression.GZipStream(resSteam, System.IO.Compression.CompressionMode.Decompress))
            {
                using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                {
                    ret = streamReader.ReadToEnd();
                }
            }
            if (!string.IsNullOrEmpty(ret))
            {
                try
                {
                    var resmodel = JsonConvert.DeserializeObject<PsHrBaseResponse<List<SubJobFuncResponse<List<SubJobFunctionDto>>>>>(ret);
                    if (resmodel.code == "200")
                    {
                        var subJobFuncs = ObjectMapper.Map<List<SubJobFunctionDto>, List<SubJobFunction>>(resmodel.datas[0].subJobFuncs);
                        var datas = new SubJobFuncResponse<List<SubJobFunction>> { totalRows = resmodel.datas[0].totalRows, subJobFuncs = subJobFuncs };
                        return Result.FromData(datas);
                    }
                    else
                    {
                        var message = $"【{resmodel.code}】{resmodel.message}";
                        Logger.LogWarning(message);
                        return Result.FromError<SubJobFuncResponse<List<SubJobFunction>>>(message);
                    }
                }
                catch (Exception ex)
                {
                    return Result.FromError<SubJobFuncResponse<List<SubJobFunction>>>(ret);
                }
            }
            return Result.FromError<SubJobFuncResponse<List<SubJobFunction>>>("请求错误");
        }

        /// <summary>
        /// 编制数据查询接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_GETHCINFO.v1/】
        /// </summary>
        /// <param name="orgCode">需要查询的组织编号</param>
        /// <param name="applierNum">申请人数</param>
        /// <returns></returns>
        /// <returns></returns>
        public async Task<Result<DepartmentManningQuotas>> GetPreparation(string orgCode, string applierNum)
        {
            string ret = null;
            QueryPreparationRequest hcQuery = new QueryPreparationRequest { OrgCode = orgCode, ApplierNum = applierNum };

            var resSteam = await _PsWebApiService.GetPreparation(hcQuery);
            using (Stream getStream = new System.IO.Compression.GZipStream(resSteam, System.IO.Compression.CompressionMode.Decompress))
            {
                using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                {
                    ret = streamReader.ReadToEnd();
                }
            }
            if (!string.IsNullOrEmpty(ret))
            {
                var resmodel = JsonConvert.DeserializeObject<DepartmentManningQuotasDto>(ret);
                
                if (resmodel.Code == "0000")
                {
                    var datas = ObjectMapper.Map<List<OrganizationCompilationDto>, List<OrganizationCompilation>>(resmodel.Datas);
                    DepartmentManningQuotas departmentManningQuotas = new DepartmentManningQuotas {
                        Datas = datas,
                        OrgDepartmentId = resmodel.OrgDepartmentId,
                        TotalCompilation = resmodel.TotalCompilation,
                        InTotal = resmodel.InTotal,
                        IsLaunch = resmodel.IsLaunch
                    };
                    return Result.FromData(departmentManningQuotas);
                }
                else
                {
                    var message = $"【{resmodel.Code}】{resmodel.Message}";
                    Logger.LogWarning(message);
                    return Result.FromError<DepartmentManningQuotas>(message);
                }
            }
            return Result.FromError<DepartmentManningQuotas>("请求错误");
        }

        /// <summary>
        /// 审批编制数据处理接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_HCAPPINFO.v1/】
        /// </summary>
        /// <param name="hcQuery">审批编制数据</param>
        /// <returns></returns>
        public async Task<Result> ApprovalPreparation(ApprovalPreparationDto hcQuery)
        {
            string ret = null;

            var datas = ObjectMapper.Map<List<DepartmentEmployDto>, List<DepartmentEmploy>>(hcQuery.Datas);
            ApprovalPreparationRequest request = new ApprovalPreparationRequest { 
                Action = hcQuery.Action,
                FileId= hcQuery.FileId,
                RecruitmentType = hcQuery.RecruitmentType,
                Datas = datas
            };
            var resSteam = await _PsWebApiService.ApprovalPreparation(request);

            using (Stream getStream = new System.IO.Compression.GZipStream(resSteam, System.IO.Compression.CompressionMode.Decompress))
            {
                using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                {
                    ret = streamReader.ReadToEnd();
                }
            }

            if (!string.IsNullOrEmpty(ret))
            {
                var resmodel = JsonConvert.DeserializeObject<EsbResponseBody>(ret);
                if (resmodel.BussinessCode == "0000")
                {
                    return Result.Ok(resmodel.Message);
                }
                else
                {
                    var message = $"【{resmodel.BussinessCode}】{resmodel.Message}";
                    Logger.LogWarning(message);
                    return Result.FromError(message);
                }

            }
            return Result.FromError("请求错误");
        }

        /// <summary>
        /// 社招员工薪酬数据提报接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_IMP_PAY2.v1/】
        /// </summary>
        /// <param name="dto">员工薪酬数据</param>
        /// <returns></returns>
        public async Task<Result<List<SalaryDockResults>>> SalaryDocking(List<SalaryInfoDto> dto)
        {
            string ret = null;
            var datas = ObjectMapper.Map<List<SalaryInfoDto>, List<SalaryInfo>>(dto);
            var resSteam = await _PsWebApiService.SalaryDocking(new SalaryDockRequest { data = datas });
            using (Stream getStream = new System.IO.Compression.GZipStream(resSteam, System.IO.Compression.CompressionMode.Decompress))
            {
                using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                {
                    ret = streamReader.ReadToEnd();
                }
            }

            if (!string.IsNullOrEmpty(ret))
            {
                var resmodel = JsonConvert.DeserializeObject<SalaryDockResponse>(ret);
                if (resmodel.BussinessCode == "1")
                {
                    var list = ObjectMapper.Map<List<SalaryDockResultsDto>, List<SalaryDockResults>>(resmodel.data);
                    return Result.FromData(list);
                }
                else
                {
                    var message = $"【{resmodel.BussinessCode}】{resmodel.Message}+{resmodel.data}";
                    Logger.LogWarning(message);
                    return Result.FromError<List<SalaryDockResults>>(message);
                }

            }
            return Result.FromError<List<SalaryDockResults>>("请求错误");
        }


        /// <summary>
        /// 国家/地区、工作城市、办公地点查询接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="dto">办公地点</param>
        /// <returns></returns>
        public async Task<Result<OfficeLocationResponse>> OfficeLocationQuery(PsBadyRequestDto<List<OfficeLocationDto>> psBadyRequest)
        {
            string ret = null;
            var list = ObjectMapper.Map<List<OfficeLocationDto>, List<OfficeLocation>>(psBadyRequest.datas);

            PsBadyRequest<List<OfficeLocation>> psBady = new PsBadyRequest<List<OfficeLocation>>
            {
                datas = list,
                InterfaceCode = psBadyRequest.InterfaceCode,
                SystemCode = psBadyRequest.SystemCode,
                Language = psBadyRequest.Language
            };
            var resSteam = await _PsWebApiService.OfficeLocationQuery(psBady);
            using (Stream getStream = new System.IO.Compression.GZipStream(resSteam, System.IO.Compression.CompressionMode.Decompress))
            {
                using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                {
                    ret = streamReader.ReadToEnd();
                }
            }
            if (!string.IsNullOrEmpty(ret))
            {
                var resmodel = JsonConvert.DeserializeObject<OfficeLocationResponse>(ret);
                if (resmodel.Code == "200")
                    return Result.FromData(resmodel);
                else
                {
                    var message = $"【{resmodel.Code}】{resmodel.Message}";
                    Logger.LogWarning(message);
                    return Result.FromError<OfficeLocationResponse>(message);
                }
            }
            return Result.FromError<OfficeLocationResponse>("请求错误");
        }

        /// <summary>
        /// 请假数据推送接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="dto">请假信息</param>
        /// <returns></returns>
        public async Task<Result<List<EmployeeJobDataUpdateResponse>>> LeavePush(PsBadyRequestDto<List<LeaveDataDto>> psBadyRequest)
        {
            string ret = null;
            var list = ObjectMapper.Map<List<LeaveDataDto>, List<LeaveDataInfo>>(psBadyRequest.datas);

            PsBadyRequest<List<LeaveDataInfo>> psBady = new PsBadyRequest<List<LeaveDataInfo>>
            {
                datas = list,
                InterfaceCode = psBadyRequest.InterfaceCode,
                SystemCode = psBadyRequest.SystemCode,
                Language = psBadyRequest.Language
            };
            var resSteam = await _PsWebApiService.LeavePush(psBady);
            using (Stream getStream = new System.IO.Compression.GZipStream(resSteam, System.IO.Compression.CompressionMode.Decompress))
            {
                using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                {
                    ret = streamReader.ReadToEnd();
                }
            }
            if (!string.IsNullOrEmpty(ret))
            {
                try
                {
                    var resmodel = JsonConvert.DeserializeObject<PsHrBaseResponse<List<EmployeeJobDataUpdateResponseDto>>>(ret);
                    if (resmodel.code == "200")
                    {
                        var datas = ObjectMapper.Map<List<EmployeeJobDataUpdateResponseDto>, List<EmployeeJobDataUpdateResponse>>(resmodel.datas);
                        return Result.FromData(datas);
                    }
                    else
                    {
                        var message = $"【{resmodel.code}】{resmodel.message}";
                        Logger.LogWarning(message);
                        return Result.FromError<List<EmployeeJobDataUpdateResponse>>(message);
                    }
                }
                catch (Exception)
                {
                    return Result.FromError<List<EmployeeJobDataUpdateResponse>>(ret);
                }
            }
            return Result.FromError<List<EmployeeJobDataUpdateResponse>>("请求错误");
        }


        /// <summary>
        /// 确认请假数据接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="psBadyRequest">请假信息</param>
        /// <returns></returns>
        public async Task<Result<List<EmployeeJobDataUpdateResponse>>> LeaveUpdate(PsBadyRequestDto<List<LeaveUpdateDto>> psBadyRequest)
        {
            string ret = null;

            var list = new List<LeaveUpdate>();
            foreach (var item in psBadyRequest.datas)
            {
                list.Add(new LeaveUpdate {
                    FormInstanceCode = item.FormInstanceCode,
                    ApprovalDate = item.ApprovalDate,
                    EmployeeId = item.EmployeeId,
                    IsLeaveTrue = item.IsLeaveTrue ? "Y" : "N",
                    IsFile = item.IsFile ? "Y" : "N"
            });
            }

            PsBadyRequest<List<LeaveUpdate>> psBady = new PsBadyRequest<List<LeaveUpdate>>
            {
                datas = list,
                InterfaceCode = psBadyRequest.InterfaceCode,
                SystemCode = psBadyRequest.SystemCode,
                Language = psBadyRequest.Language
            };
            var resSteam = await _PsWebApiService.LeaveUpdate(psBady);
            using (Stream getStream = new System.IO.Compression.GZipStream(resSteam, System.IO.Compression.CompressionMode.Decompress))
            {
                using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                {
                    ret = streamReader.ReadToEnd();
                }
            }
            if (!string.IsNullOrEmpty(ret))
            {
                try
                {
                    var resmodel = JsonConvert.DeserializeObject<PsHrBaseResponse<List<EmployeeJobDataUpdateResponseDto>>>(ret);
                    if (resmodel.code == "200")
                    {
                        var datas = ObjectMapper.Map<List<EmployeeJobDataUpdateResponseDto>, List<EmployeeJobDataUpdateResponse>>(resmodel.datas);
                        return Result.FromData(datas);
                    }
                    else
                    {
                        var message = $"【{resmodel.code}】{resmodel.message}";
                        Logger.LogWarning(message);
                        return Result.FromError<List<EmployeeJobDataUpdateResponse>>(message);
                    }
                }
                catch (Exception)
                {
                    return Result.FromError<List<EmployeeJobDataUpdateResponse>>(ret);
                }
            }
            return Result.FromError<List<EmployeeJobDataUpdateResponse>>("请求错误");
        }


        /// <summary>
        /// 请假数据推送接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="dto">请假信息</param>
        /// <returns></returns>
        public async Task<Result<List<EmployeeJobDataUpdateResponse>>> LeaveChange(PsBadyRequestDto<List<LeaveChangeDto>> psBadyRequest)
        {
            string ret = null;
            var list = ObjectMapper.Map<List<LeaveChangeDto>, List<LeaveChangeInfo>>(psBadyRequest.datas);

            PsBadyRequest<List<LeaveChangeInfo>> psBady = new PsBadyRequest<List<LeaveChangeInfo>>
            {
                datas = list,
                InterfaceCode = psBadyRequest.InterfaceCode,
                SystemCode = psBadyRequest.SystemCode,
                Language = psBadyRequest.Language
            };
            var resSteam = await _PsWebApiService.LeaveChange(psBady);
            using (Stream getStream = new System.IO.Compression.GZipStream(resSteam, System.IO.Compression.CompressionMode.Decompress))
            {
                using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                {
                    ret = streamReader.ReadToEnd();
                }
            }
            if (!string.IsNullOrEmpty(ret))
            {
                try
                {
                    var resmodel = JsonConvert.DeserializeObject<PsHrBaseResponse<List<EmployeeJobDataUpdateResponseDto>>>(ret);
                    if (resmodel.code == "200")
                    {
                        var datas = ObjectMapper.Map<List<EmployeeJobDataUpdateResponseDto>, List<EmployeeJobDataUpdateResponse>>(resmodel.datas);
                        return Result.FromData(datas);
                    }
                    else
                    {
                        var message = $"【{resmodel.code}】{resmodel.message}";
                        Logger.LogWarning(message);
                        return Result.FromError<List<EmployeeJobDataUpdateResponse>>(message);
                    }
                }
                catch (Exception)
                {
                    return Result.FromError<List<EmployeeJobDataUpdateResponse>>(ret);
                }
            }
            return Result.FromError< List<EmployeeJobDataUpdateResponse>> ("请求错误");
        }


        /// <summary>
        /// 查询入职时间和社会工龄增量列表接口【第三方接口：/PSIGW/RESTListeningConnector/PSFT_HR/C_OPERATE.v1/】
        /// </summary>
        /// <param name="dto">查询组合信息</param>
        /// <returns></returns>
        public async Task<Result<List<EmployResult>>> QueryEmployeeEntrytimeInfo(PsBadyRequestDto<List<QueryConditionDto>> psBadyRequest)
        {
            string ret = null;
            var list = ObjectMapper.Map<List<QueryConditionDto>, List<QueryCondition>>(psBadyRequest.datas);

            PsBadyRequest<List<QueryCondition>> psBady = new PsBadyRequest<List<QueryCondition>>
            {
                datas = list,
                InterfaceCode = psBadyRequest.InterfaceCode,
                SystemCode = psBadyRequest.SystemCode,
                Language = psBadyRequest.Language
            };
            var resSteam = await _PsWebApiService.QueryEmployeeEntrytimeInfo(psBady);
            using (Stream getStream = new System.IO.Compression.GZipStream(resSteam, System.IO.Compression.CompressionMode.Decompress))
            {
                using (StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8))
                {
                    ret = streamReader.ReadToEnd();
                }
            }
            if (!string.IsNullOrEmpty(ret))
            {
                try
                {
                    var resmodel = JsonConvert.DeserializeObject<PsHrBaseResponse<List<EmployResultDto>>>(ret);
                    if (resmodel.code == "200")
                    {
                        List<EmployResult> results = new List<EmployResult>();
                        foreach (var item in resmodel.datas)
                        {
                            EmployResult employ = new EmployResult();
                            employ.TotalRows = item.totalRows;
                            employ.Datas = ObjectMapper.Map<List<ContentItemDto>, List<ContentItem>>(item.entrys);
                            results.Add(employ);
                        }
                        
                        return Result.FromData(results);
                    }
                    else
                    {
                        var message = $"【{resmodel.code}】{resmodel.message}";
                        Logger.LogWarning(message);
                        return Result.FromError<List<EmployResult>>(message);
                    }
                }
                catch (Exception)
                {
                    return Result.FromError<List<EmployResult>>(ret);
                }
            }
            return Result.FromError<List<EmployResult>>("请求错误");
        }

    }
}
