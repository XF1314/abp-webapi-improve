using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Erp.Services
{
    /// <summary>
    /// Erp基础数据Esb服务接口
    /// </summary>
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IErpBasicDataEsbService : IHttpApi
    {
        /// <summary>
        /// 获取汇率换算信息
        /// <param name="request"><see cref="ErpConversionRequest"/></param>
        /// </summary>
        /// <returns></returns>
        [HttpGet("/erp/basics/get_conversion")]
        Task<ErpResponse<List<ErpConversionInfo>>> GetConversion([PathQuery] ErpConversionRequest request);

        /// <summary>
        /// 查询物料信息
        /// <param name="request">查询条件</param>
        /// </summary>
        /// <returns>返回物料清单列表</returns>
        [HttpGet("/erp/basics/mtl_code_search")]
        Task<MaterialInfoResponse> SearchMaterielInfoList([PathQuery] SearchMaterielInfoRequest request);

        /// <summary>
        /// 获取供应商信息
        /// <param name="request"><see cref="ErpVendorInfoGetRequest"/></param>
        /// </summary>
        /// <returns>返回收款公司清单列表</returns>
        [HttpGet("/erp/assets/vender_code_ou")]
        Task<ErpAssetsResponse<List<ErpVendorInfo>>> GetConversion([PathQuery] ErpVendorInfoGetRequest request);
    }
}
