using Com.OPPO.Mo.Thirdparty.Mes.Dtos;
using Com.OPPO.Mo.Thirdparty.Mes.Requests;
using Com.OPPO.Mo.Thirdparty.Mes.Responses;
using Com.OPPO.Mo.Thirdparty.Mes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Mes
{
    /// <summary>
    /// Mes认证公开文件/生产方案量产/营销样机申请(销售)
    /// </summary>
    [Authorize]
    public class MesAppService : ThirdpartyAppServiceBase, IMesAppService
    {
        private readonly IConfiguration _configuration;
        private readonly IMesEsbService  _mesEsbService;

        /// <summary>
        /// <see cref="MesExportSoftwareInfoAppService"/>
        /// </summary>
        public MesAppService(IConfiguration configuration,
            IMesEsbService mesEsbService)
        {
            _configuration = configuration;
            _mesEsbService = mesEsbService;
        }



        public async Task<Result<MesCountryDataBody>> GetCountryList(string ConutryCode, string CountryType, string ResponseType)
        {
            MesCountryInfoQueryRequest queryRequest = new MesCountryInfoQueryRequest { ConutryCode = ConutryCode, CountryType = CountryType, ResponseType = ResponseType };
            var response = await _mesEsbService.GetCountryList(queryRequest);
            if (response.Response.Code == null)
                return Result.FromData(response.Response);
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogError(message);
                return Result.FromError<MesCountryDataBody>(message);
            }
        }

        public async Task<Result<List<MesProductModelResponse>>> GetCoverageChangeModelName(string AssetsNumber)
        {
            MesAssetInfoQueryRequest queryRequest = new MesAssetInfoQueryRequest { AssetsNumber = AssetsNumber };
            var response = await _mesEsbService.GetCoverageChangeModelName(queryRequest);   

            if (response != null)
                return Result.FromData(response);
            else
            {
                var message = $"【{response}】";
                Logger.LogError(message);
                return Result.FromError<List<MesProductModelResponse>>(message);
            }
        }


        /// <summary>
        /// 将mo单据数据写入MES系统【第三方接口：/mes/basics/mes_mo_document_insert】
        /// </summary>
        /// <param name="dtos">数据集合</param>
        /// <returns></returns>
        public async Task<Result> AddMoDocToMes(List<MarketingPrototypeInfoDto> dtos)
        {
            var res = ObjectMapper.Map<List<MarketingPrototypeInfoDto>, List<MarketingPrototypeInfo>>(dtos);
            MoDocToMesRequest queryRequest = new MoDocToMesRequest { Datas = JsonConvert.SerializeObject(res) };
            var response = await _mesEsbService.AddMoDocToMes(queryRequest);

            if (response.Body.BussinessCode == "0")
                return Result.Ok();
            else
            {
                var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }

    }
}
