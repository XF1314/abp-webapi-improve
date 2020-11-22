using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Erp.Services
{
    /// <summary>
    /// 费用委托收/付款通知单（新）
    /// </summary>
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IErpAssestEsbService : IHttpApi
    {
        /// <summary>
        /// 获取收款公司清单
        /// <param name="request"><see cref="ErpVendorInfoGetRequest"/></param>
        /// </summary>
        /// <returns>返回收款公司清单列表</returns>
        [HttpGet("/erp/assets/vender_code_ou")]
        Task<ErpAssetsResponse<List<ErpVendorInfo>>> GetConversion([PathQuery] ErpVendorInfoGetRequest request);

        /// <summary>
        /// 获取付款公司清单
        /// <param name="request"><see cref="ErpPaymentRequest"/></param>
        /// </summary>
        /// <returns>返回付款公司清单列表</returns>
        [HttpGet("/erp/cbm/cbm_all_org_get")]
        Task<ErpAssetsResponse<List<ErpPaymentInfo>>> GetConversionTwo([PathQuery] ErpPaymentRequest request);

        /// <summary>
        /// 更新科目信息【第三方接口：/erp/assets/pubget_push】
        /// <param name="request"><see cref="PoLinesRequest"/></param>
        /// </summary>
        [HttpPost("/erp/assets/pubget_push")]
        Task<EsbResponse> ToolingFixtureApplicationPush([FormContent]PoLinesRequest request);

    }
}
