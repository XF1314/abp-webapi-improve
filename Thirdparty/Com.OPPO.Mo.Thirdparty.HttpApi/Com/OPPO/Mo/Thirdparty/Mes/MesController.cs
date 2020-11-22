using Com.OPPO.Mo.Thirdparty.Mes.Dtos;
using Com.OPPO.Mo.Thirdparty.Mes.Responses;
using Com.OPPO.Mo.Thirdparty.Mes.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Mes
{
    /// <summary>
    /// Mes认证公开文件/生产方案量产/营销样机申请(销售)
    /// </summary>
    [Area("mes")]
    [Route("api/mo/thirdparty/mes")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class MesController : AbpController, IMesAppService
    {
        private readonly IMesAppService _mesAppService;

        public MesController(IMesAppService mesAppService)
        {
            _mesAppService = mesAppService;
        }

        /// <summary>
        /// 查询销售国家数据【第三方接口：/mes/basics/mes_country_list】
        /// </summary>
        /// <param name="ConutryCode">国家代码,可不填</param>
        /// <param name="CountryType">国家类型,可不填</param>
        /// <param name="ResponseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        [HttpGet("basics/query-country-data")]
        public async Task<Result<MesCountryDataBody>> GetCountryList(string ConutryCode, string CountryType, string ResponseType)
        {
            return await _mesAppService.GetCountryList(ConutryCode, CountryType, ResponseType);
        }

        /// <summary>
        /// 通过资产代码获取资产描述【第三方接口：/mes/basics/erp_get_production_model_by_material】
        /// </summary>
        /// <param name="AssetsNumber">资产代码</param>
        /// <returns></returns>
        [HttpGet("basics/query-assetsinfo-by-erp")]
        public async Task<Result<List<MesProductModelResponse>>> GetCoverageChangeModelName(string AssetsNumber)
        {
            return await _mesAppService.GetCoverageChangeModelName(AssetsNumber);
        }

        /// <summary>
        /// 将mo单据数据写入MES系统【第三方接口：/mes/basics/mes_mo_document_insert】
        /// </summary>
        /// <param name="dtos">数据集合</param>
        /// <returns></returns>
        [HttpPost("add-modoc-to-mes")]
        public async Task<Result> AddMoDocToMes(List<MarketingPrototypeInfoDto> dtos)
        {
            return await _mesAppService.AddMoDocToMes(dtos);
        }

    }

}
