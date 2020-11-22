using Com.OPPO.Mo.Thirdparty.Mes.Requests;
using Com.OPPO.Mo.Thirdparty.Mes.Responses;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.Mes.Services
{

    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IMesEsbService : IHttpApi
    {
        /// <summary>
        /// 查询销售国家数据
        /// </summary>
        /// <param name="queryRequest"></param>
        /// <returns></returns>
        [HttpGet("/mes/basics/mes_country_list")]
        Task<MesCountryDataResponse> GetCountryList([PathQuery]MesCountryInfoQueryRequest queryRequest);


        /// <summary>
        /// 通过资产代码获取资产描述
        /// </summary>
        /// <param name="queryRequest"></param>
        /// <returns></returns>
        [HttpGet("/mes/basics/erp_get_production_model_by_material")]
        Task<List<MesProductModelResponse>> GetCoverageChangeModelName([PathQuery]MesAssetInfoQueryRequest  queryRequest);

        /// <summary>
        /// 将mo单据数据写入MES系统
        /// </summary>
        /// <param name="queryRequest"></param>
        /// <returns></returns>
        [HttpPost("/mes/basics/mes_mo_document_insert")]
        Task<EsbResponse> AddMoDocToMes([FormContent]MoDocToMesRequest queryRequest);
    }
}
