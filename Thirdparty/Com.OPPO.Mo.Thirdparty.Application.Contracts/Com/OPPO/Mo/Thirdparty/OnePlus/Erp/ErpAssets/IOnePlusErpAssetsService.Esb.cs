using Com.OPPO.Mo.Thirdparty.Erp;
using Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Requests;
using Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets
{
    /// <summary>
    /// Erp/OnePlus Assets
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IOnePlusErpAssetsEsbService : IHttpApi
    {
        /// <summary>
        /// 查询Erp 战区数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_gl_profitc_account_v_query_PROFI_SEG1")]
        Task<ErpResultResponseResult<OnePlusInfo>> GetWarZone([PathQuery] OnePlusGetCommonRequest request);
        /// <summary>
        /// 查询Erp 产品大类信息(需要传入战区Code作为参数)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_gl_profitc_account_v_query_PROFI_SEG2")]
        Task<ErpResultResponseResult<OnePlusInfo>> GetProductCategory([PathQuery] OnePlusGetProductCategoryRequest request);
        /// <summary>
        /// 查询Erp 销售渠道(传入战区Code 产品大类Code)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_gl_profitc_account_v_query_PROFI_SEG3")]
        Task<ErpResultResponseResult<OnePlusInfo>> GetDistributionChannel([PathQuery] OnePlusGetDistributionChannelRequest request);
        /// <summary>
        /// 查询Erp 所属地区(传入战区Code 产品大类Code 销售渠道Code)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_gl_profitc_account_v_query_PROFI_SEG4")]
        Task<ErpResultResponseResult<OnePlusInfo>> GetBelongArea([PathQuery] OnePlusGetBelongAreaRequest request);

        /// <summary>
        /// 查询Erp 业务类型大类
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_gl_subdet_account_v_query_SUBAC_SEG1")]
        Task<ErpResultResponseResult<OnePlusInfo>> GetBusinessTypeCategory([PathQuery] OnePlusGetCommonRequest request);

        /// <summary>
        /// 查询Erp 业务类型子类
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_gl_subdet_account_v_query_SUBAC_SEG2")]
        Task<ErpResultResponseResult<OnePlusInfo>> GetBusinessTypeSubClass([PathQuery] OnePlusBusinessTypeSubClassRequest request);

        /// <summary>
        /// 查询Erp 业务类型明细
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_gl_subdet_account_v_query_SUBAC_SEG3")]
        Task<ErpResultResponseResult<OnePlusInfo>> GetBusinessTypeDetails([PathQuery] OnePlusBusinessTypeDetailsRequest request);

        /// <summary>
        /// 获取Erp 所有SKU
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_oa_item_ec_v_query_all")]
        Task<ErpResultResponseResult<OnePlusInfo>> GetErpAllSKU([PathQuery] OnePlusGetCommonRequest request);

        /// <summary>
        /// 查询营销预算项目
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_gl_project_account_v_query_PROJE_SEG1")]
        Task<ErpResultResponseResult<OnePlusInfo>> GetMarketingBudgetProject([PathQuery] OnePlusGetMarketingBudgetProjectRequest request);

        /// <summary>
        /// 查询研发预算项目
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_gl_project_account_v_query_PROJE_SEG2")]
        Task<ErpResultResponseResult<OnePlusInfo>> GetRDBudgetProject([PathQuery] OnePlusGetRDBudgetProjectRequest request);
    }
}
