using Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets
{
    /// <summary>
    /// OnePlus Erp Assets
    /// </summary>
    public interface IOnePlusErpAssetsAppService : IApplicationService
    {
        /// <summary>
        /// 获取Erp 战区数据
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        Task<Result<List<OnePlusErpWarZoneDto>>> GetWarZone(string language);
        
        /// <summary>
        /// 获取Erp 产品大类数据
        /// </summary>
        /// <param name="language"></param>
        /// <param name="profi_seg1"></param>
        /// <returns></returns>
        Task<Result<List<OnePlusErpProductCategoryDto>>> GetProductCategory(string language,string profi_seg1);
        /// <summary>
        /// 获取Erp 销售渠道数据
        /// </summary>
        /// <param name="language"></param>
        /// <param name="profi_seg1"></param>
        /// <param name="profi_seg2"></param>
        /// <returns></returns>
        Task<Result<List<OnePlusErpDistributionChannelDto>>> GetDistributionChannel(string language, string profi_seg1, string profi_seg2);

        /// <summary>
        /// 获取Erp 所属地区数据
        /// </summary>
        /// <param name="language"></param>
        /// <param name="profi_seg1"></param>
        /// <param name="profi_seg2"></param>
        /// <param name="profi_seg3"></param>
        /// <returns></returns>
        Task<Result<List<OnePlusErpBelongAreaDto>>> GetBelongArea(string language, string profi_seg1, string profi_seg2, string profi_seg3);

        /// <summary>
        /// 获取Erp 业务类型大类
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        Task<Result<List<OnePlusErpBusinessTypeCategoryDto>>> GetBusinessTypeCategory(string language);

        /// <summary>
        /// 查询Erp 业务类型子类
        /// </summary>
        /// <param name="language"></param>
        /// <param name="subac_seg1"></param>
        /// <returns></returns>
        Task<Result<List<OnePlusBusinessTypeSubClassDto>>> GetBusinessTypeSubClass(string language, string subac_seg1);

        /// <summary>
        /// 查询Erp 业务类型明细
        /// </summary>
        /// <param name="language"></param>
        /// <param name="subac_seg1"></param>
        /// <param name="subac_seg2"></param>
        /// <returns></returns>
        Task<Result<List<OnePlusBusinessTypeDetailsDto>>> GetBusinessTypeDetails(string language, string subac_seg1,string subac_seg2);

        /// <summary>
        /// 获取Erp 所有SKU
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        Task<Result<List<OnePlusErpSkuDto>>> GetErpAllSKU(string language);

        /// <summary>
        /// 获取营销预算项目
        /// </summary>
        /// <param name="language"></param>
        /// <param name="proje_seg2"></param>
        /// <returns></returns>
        Task<Result<List<OnePlusMarketingBudgetProjectProjectDto>>> GetMarketingBudgetProject(string language, string proje_seg2);

        /// <summary>
        /// 获取研发预算项目
        /// </summary>
        /// <param name="language"></param>
        /// <param name="proje_seg1"></param>
        /// <returns></returns>
        Task<Result<List<OnePlusRDBudgetProjectDto>>> GetRDBudgetProject(string language, string proje_seg1);
    }
}
