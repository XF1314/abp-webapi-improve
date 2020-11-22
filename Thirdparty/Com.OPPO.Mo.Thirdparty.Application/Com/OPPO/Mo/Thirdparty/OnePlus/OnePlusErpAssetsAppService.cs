using Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets;
using Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets.Dtos;
using Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.OnePlus
{
    /// <summary>
    /// 一加Erp 资产服务实现类
    /// </summary>
    [Authorize]
    public class OnePlusErpAssetsAppService : ThirdpartyAppServiceBase, IOnePlusErpAssetsAppService
    {
        private readonly IOnePlusErpAssetsEsbService _onePlusErpAssetsEsbService;

        public OnePlusErpAssetsAppService(IOnePlusErpAssetsEsbService onePlusErpAssetsEsbService)
        {
            _onePlusErpAssetsEsbService = onePlusErpAssetsEsbService;
        }

        /// <summary>
        /// 获取Erp 战区数据
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusErpWarZoneDto>>> GetWarZone(string language)
        {

            var response = await _onePlusErpAssetsEsbService.GetWarZone(new OnePlusGetCommonRequest { Language = language });
            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusErpWarZoneDto>>(response.Body.Data);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Data}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusErpWarZoneDto>>(message);
            }
        }

        /// <summary>
        /// 获取Erp 产品大类数据
        /// </summary>
        /// <param name="language"></param>
        /// <param name="profi_seg1"></param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusErpProductCategoryDto>>> GetProductCategory(string language,string profi_seg1)
        {
            if (string.IsNullOrWhiteSpace(profi_seg1))
            {
                return Result.FromError<List<OnePlusErpProductCategoryDto>>($"缺失参数{nameof(profi_seg1)}。");
            }
            var response = await _onePlusErpAssetsEsbService.GetProductCategory(new OnePlusGetProductCategoryRequest { Language = language,Profi_Seg1 = profi_seg1 });
            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusErpProductCategoryDto>>(response.Body.Data);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Data}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusErpProductCategoryDto>>(message);
            }
        }

        /// <summary>
        /// 获取Erp 销售渠道数据
        /// </summary>
        /// <param name="language"></param>
        /// <param name="profi_seg1"></param>
        /// <param name="profi_seg2"></param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusErpDistributionChannelDto>>> GetDistributionChannel(string language,string profi_seg1,string profi_seg2)
        {
            if (string.IsNullOrWhiteSpace(profi_seg1))
            {
                return Result.FromError<List<OnePlusErpDistributionChannelDto>>($"缺失参数{nameof(profi_seg1)}。");
            }

            if (string.IsNullOrWhiteSpace(profi_seg2))
            {
                return Result.FromError<List<OnePlusErpDistributionChannelDto>>($"缺失参数{nameof(profi_seg2)}。");
            }

            var response = await _onePlusErpAssetsEsbService.GetDistributionChannel(new OnePlusGetDistributionChannelRequest { Language = language, Profi_Seg1 = profi_seg1,Profi_Seg2 = profi_seg2 });
            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusErpDistributionChannelDto>>(response.Body.Data);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Data}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusErpDistributionChannelDto>>(message);
            }
        }

        

        /// <summary>
        /// 获取Erp 所属地区数据
        /// </summary>
        /// <param name="language"></param>
        /// <param name="profi_seg1"></param>
        /// <param name="profi_seg2"></param>
        /// <param name="profi_seg3"></param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusErpBelongAreaDto>>> GetBelongArea(string language, string profi_seg1, string profi_seg2,string profi_seg3)
        {
            if (string.IsNullOrWhiteSpace(profi_seg1))
            {
                return Result.FromError<List<OnePlusErpBelongAreaDto>>($"缺失参数{nameof(profi_seg1)}。");
            }

            if (string.IsNullOrWhiteSpace(profi_seg2))
            {
                return Result.FromError<List<OnePlusErpBelongAreaDto>>($"缺失参数{nameof(profi_seg2)}。");
            }

            if (string.IsNullOrWhiteSpace(profi_seg2))
            {
                return Result.FromError<List<OnePlusErpBelongAreaDto>>($"缺失参数{nameof(profi_seg3)}。");
            }

            var response = await _onePlusErpAssetsEsbService.GetBelongArea(new OnePlusGetBelongAreaRequest { Language = language, Profi_Seg1 = profi_seg1, Profi_Seg2 = profi_seg2,Profi_Seg3 = profi_seg3 });
            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusErpBelongAreaDto>>(response.Body.Data);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Data}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusErpBelongAreaDto>>(message);
            }
        }

        /// <summary>
        /// 获取Erp 业务类型大类数据
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusErpBusinessTypeCategoryDto>>> GetBusinessTypeCategory(string language)
        {
            var response = await _onePlusErpAssetsEsbService.GetBusinessTypeCategory(new OnePlusGetCommonRequest { Language = language });
            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusErpBusinessTypeCategoryDto>>(response.Body.Data);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Data}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusErpBusinessTypeCategoryDto>>(message);
            }
        }

        /// <summary>
        /// 获取Erp 业务类型子类
        /// </summary>
        /// <param name="language"></param>
        /// <param name="subac_seg1"></param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusBusinessTypeSubClassDto>>> GetBusinessTypeSubClass(string language,string subac_seg1)
        {
            if (string.IsNullOrWhiteSpace(subac_seg1))
            {
                return Result.FromError<List<OnePlusBusinessTypeSubClassDto>>($"缺失参数{nameof(subac_seg1)}。");
            }

            var response = await _onePlusErpAssetsEsbService.GetBusinessTypeSubClass(new OnePlusBusinessTypeSubClassRequest { Language = language,Subac_Seg1 = subac_seg1 });
            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusBusinessTypeSubClassDto>>(response.Body.Data);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Data}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusBusinessTypeSubClassDto>>(message);
            }
        }

        /// <summary>
        /// 查询Erp 业务类型明细
        /// </summary>
        /// <param name="language"></param>
        /// <param name="subac_seg1"></param>
        /// <param name="subac_seg2"></param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusBusinessTypeDetailsDto>>> GetBusinessTypeDetails(string language, string subac_seg1, string subac_seg2)
        {
            if (string.IsNullOrWhiteSpace(subac_seg1))
            {
                return Result.FromError<List<OnePlusBusinessTypeDetailsDto>>($"缺失参数{nameof(subac_seg1)}。");
            }
            if (string.IsNullOrWhiteSpace(subac_seg2))
            {
                return Result.FromError<List<OnePlusBusinessTypeDetailsDto>>($"缺失参数{nameof(subac_seg2)}。");
            }

            var response = await _onePlusErpAssetsEsbService.GetBusinessTypeDetails(new OnePlusBusinessTypeDetailsRequest { Language = language, Subac_Seg1 = subac_seg1,Subac_Seg2 = subac_seg2 });
            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusBusinessTypeDetailsDto>>(response.Body.Data);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Data}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusBusinessTypeDetailsDto>>(message);
            }
        }

        /// <summary>
        /// 获取Erp 所有SKU
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusErpSkuDto>>> GetErpAllSKU(string language)
        {
            var response = await _onePlusErpAssetsEsbService.GetErpAllSKU(new OnePlusGetCommonRequest { Language = language });
            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusErpSkuDto>>(response.Body.Data);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Data}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusErpSkuDto>>(message);
            }
        }

        /// <summary>
        /// 获取营销预算项目
        /// </summary>
        /// <param name="language"></param>
        /// <param name="proje_seg2"></param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusMarketingBudgetProjectProjectDto>>> GetMarketingBudgetProject(string language, string proje_seg2)
        {
            var response = await _onePlusErpAssetsEsbService.GetMarketingBudgetProject(new OnePlusGetMarketingBudgetProjectRequest { Language = language, Proje_Seg2 = proje_seg2 });
            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusMarketingBudgetProjectProjectDto>>(response.Body.Data);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Data}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusMarketingBudgetProjectProjectDto>>(message);
            }
        }

        /// <summary>
        /// 获取研发预算项目
        /// </summary>
        /// <param name="language"></param>
        /// <param name="proje_seg1"></param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusRDBudgetProjectDto>>> GetRDBudgetProject(string language, string proje_seg1)
        {
            var response = await _onePlusErpAssetsEsbService.GetRDBudgetProject(new OnePlusGetRDBudgetProjectRequest { Language = language, Proje_Seg1 = proje_seg1 });
            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusRDBudgetProjectDto>>(response.Body.Data);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Data}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusRDBudgetProjectDto>>(message);
            }
        }
    }
}
