using Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets;
using Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Erp
{
    /// <summary>
    /// OnePlus ERP Assets 资源
    /// </summary>
    [Area("onepluserp")]
    [Route("api/mo/thirdparty/oneplus/erp/assets")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class OnePlusErpAssetsController : AbpController, IOnePlusErpAssetsAppService
    {
        private readonly IOnePlusErpAssetsAppService _onePlusErpAssetsAppService;

        public OnePlusErpAssetsController(IOnePlusErpAssetsAppService onePlusErpAssetsAppSerive)
        {
            _onePlusErpAssetsAppService = onePlusErpAssetsAppSerive;
        }

        /// <summary>
        /// 获取Erp 战区数据 【第三方接口: /oneplus/erp/oneplus_erp_cux_gl_profitc_account_v_query_PROFI_SEG1】
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        [HttpGet("oneplus_erp_cux_gl_profitc_account_v_query_PROFI_SEG1")]
        public async Task<Result<List<OnePlusErpWarZoneDto>>> GetWarZone(string language)
        {
            return await _onePlusErpAssetsAppService.GetWarZone(language);
        }

        /// <summary>
        /// 获取Erp 产品大类数据 【第三方接口: /oneplus/erp/oneplus_erp_cux_gl_profitc_account_v_query_PROFI_SEG2】
        /// </summary>
        /// <param name="language"></param>
        /// <param name="profi_seg1"></param>
        /// <returns></returns>
        [HttpGet("oneplus_erp_cux_gl_profitc_account_v_query_PROFI_SEG2")]
        public async Task<Result<List<OnePlusErpProductCategoryDto>>> GetProductCategory(string language,string profi_seg1)
        {
            return await _onePlusErpAssetsAppService.GetProductCategory(language,profi_seg1);
        }
        /// <summary>
        /// 获取Erp 销售渠道数据 【第三方接口: /oneplus/erp/oneplus_erp_cux_gl_profitc_account_v_query_PROFI_SEG3】
        /// </summary>
        /// <param name="language"></param>
        /// <param name="profi_seg1"></param>
        /// <param name="profi_seg2"></param>
        /// <returns></returns>
        [HttpGet("oneplus_erp_cux_gl_profitc_account_v_query_PROFI_SEG3")]
        public async Task<Result<List<OnePlusErpDistributionChannelDto>>> GetDistributionChannel(string language,string profi_seg1,string profi_seg2)
        {
            return await _onePlusErpAssetsAppService.GetDistributionChannel(language, profi_seg1, profi_seg2);
        }

        /// <summary>
        /// 获取Erp 所属地区数据  【第三方接口: /oneplus/erp/oneplus_erp_cux_gl_profitc_account_v_query_PROFI_SEG4】
        /// </summary>
        /// <param name="language"></param>
        /// <param name="profi_seg1"></param>
        /// <param name="profi_seg2"></param>
        /// <param name="profi_seg3"></param>
        /// <returns></returns>
        [HttpGet("oneplus_erp_cux_gl_profitc_account_v_query_PROFI_SEG4")]
        public async Task<Result<List<OnePlusErpBelongAreaDto>>> GetBelongArea(string language, string profi_seg1, string profi_seg2,string profi_seg3)
        {
            return await _onePlusErpAssetsAppService.GetBelongArea(language, profi_seg1, profi_seg2, profi_seg3);
        }

        /// <summary>
        /// 获取Erp 业务类型大类数据 【第三方接口: /oneplus/erp/oneplus_erp_cux_gl_subdet_account_v_query_SUBAC_SEG1】
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        [HttpGet("oneplus_erp_cux_gl_subdet_account_v_query_SUBAC_SEG1")]
        public async Task<Result<List<OnePlusErpBusinessTypeCategoryDto>>> GetBusinessTypeCategory(string language)
        {
            return await _onePlusErpAssetsAppService.GetBusinessTypeCategory(language);
        }

        /// <summary>
        /// 获取Erp 业务类型子类 【第三方接口: /oneplus/erp/oneplus_erp_cux_gl_subdet_account_v_query_SUBAC_SEG2】
        /// </summary>
        /// <param name="language"></param>
        /// <param name="subac_seg1"></param>
        /// <returns></returns>
        [HttpGet("oneplus_erp_cux_gl_subdet_account_v_query_SUBAC_SEG2")]
        public async Task<Result<List<OnePlusBusinessTypeSubClassDto>>> GetBusinessTypeSubClass(string language,string subac_seg1)
        {
            return await _onePlusErpAssetsAppService.GetBusinessTypeSubClass(language, subac_seg1);
        }

        /// <summary>
        ///  获取Erp 业务类型明细 【第三方接口: /oneplus/erp/oneplus_erp_cux_gl_subdet_account_v_query_SUBAC_SEG3】
        /// </summary>
        /// <param name="language"></param>
        /// <param name="subac_seg1"></param>
        /// <param name="subac_seg2"></param>
        /// <returns></returns>
        [HttpGet("oneplus_erp_cux_gl_subdet_account_v_query_SUBAC_SEG3")]
        public async Task<Result<List<OnePlusBusinessTypeDetailsDto>>> GetBusinessTypeDetails(string language, string subac_seg1,string subac_seg2)
        {
            return await _onePlusErpAssetsAppService.GetBusinessTypeDetails(language, subac_seg1, subac_seg2);
        }

        /// <summary>
        /// 获取Erp 所有SKU 【第三方接口: /oneplus/erp/oneplus_erp_cux_oa_item_ec_v_query_all】
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        [HttpGet("oneplus_erp_cux_oa_item_ec_v_query_all")]
        public async Task<Result<List<OnePlusErpSkuDto>>> GetErpAllSKU(string language)
        {
            return await _onePlusErpAssetsAppService.GetErpAllSKU(language);
        }

        /// <summary>
        /// 获取营销预算项目  【第三方接口: /oneplus/erp/oneplus_erp_cux_gl_project_account_v_query_PROJE_SEG1】
        /// </summary>
        /// <param name="language"></param>
        /// <param name="proje_seg2"></param>
        /// <returns></returns>
        [HttpGet("oneplus_erp_cux_gl_project_account_v_query_PROJE_SEG1")]
        public async Task<Result<List<OnePlusMarketingBudgetProjectProjectDto>>> GetMarketingBudgetProject(string language, string proje_seg2)
        {
            return await _onePlusErpAssetsAppService.GetMarketingBudgetProject(language, proje_seg2);
        }

        /// <summary>
        /// 获取研发预算项目  【第三方接口: /oneplus/erp/oneplus_erp_cux_gl_project_account_v_query_PROJE_SEG2】
        /// </summary>
        /// <param name="language"></param>
        /// <param name="proje_seg1"></param>
        /// <returns></returns>
        [HttpGet("oneplus_erp_cux_gl_project_account_v_query_PROJE_SEG2")]
        public async Task<Result<List<OnePlusRDBudgetProjectDto>>> GetRDBudgetProject(string language, string proje_seg1)
        {
            return await _onePlusErpAssetsAppService.GetRDBudgetProject(language, proje_seg1);
        }
    }
}
