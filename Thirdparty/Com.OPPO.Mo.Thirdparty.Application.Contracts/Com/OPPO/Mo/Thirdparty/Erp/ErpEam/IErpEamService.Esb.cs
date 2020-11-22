using Com.OPPO.Mo.Thirdparty.Erp.ErpEam.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.ErpEam.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpEam
{
    /// <summary>
    /// Erp/Eam
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IErpEamEsbService : IHttpApi
    {
        /// <summary>
        /// EAM-资产报废_资产信息查询 【第三方接口：/erp/eam/get_eqpt_retirement_list】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/erp/eam/get_eqpt_retirement_list")]
        Task<AssetRetirementResponse> GetAssetRetirementList([PathQuery]QueryAssetRetirementRequest query);
    }
}
