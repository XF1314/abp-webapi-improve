using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.Erp.Services
{
    /// <summary>
    /// 生产方案量产/营销样机申请（销售）
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IErpEsbService : IHttpApi
    {
        /// <summary>
        /// 通过资产代码获取资产描述
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/erp/assets/assets_info_get")]
        Task<ErpAssetInfoResponse> GetAssetsInfoByAssetsCode([PathQuery]ErpAssetsInfoQueryRequest query );

      
    }
}
