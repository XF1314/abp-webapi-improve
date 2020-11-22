using Com.OPPO.Mo.Thirdparty.Erp.ErpEam;
using Com.OPPO.Mo.Thirdparty.Erp.ErpEam.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpEam.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.ErpEam.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Erp
{

    [Authorize]
    public class ErpEamAppService : ThirdpartyAppServiceBase, IErpEamAppService
    {

        /// <summary>
        /// EAM-资产报废_资产信息查询 【第三方接口：/erp/eam/get_eqpt_retirement_list】
        /// </summary>
        /// <param name="assetCode">设备编码或者资产编码,必填</param>info_number
        /// <param name="language">语言,非必填</param>
        /// <returns></returns>
        public async Task<Result<List<AssetRetirementInfo>>> GetAssetRetirementList(string assetCode, string language)
        {
            var service = ServiceProvider.GetRequiredService<IErpEamEsbService>();
            QueryAssetRetirementRequest query = new QueryAssetRetirementRequest
            {
                InfoNumber = assetCode,
                Language = language
            };
            var response = await service.GetAssetRetirementList(query);

            if (response.Response.Code == null)
            {
                var datas = ObjectMapper.Map<List<AssetRetirementInfoDto>, List<AssetRetirementInfo>>(response.Response.results);
                return Result.FromData(datas);
            }
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogError(message);
                return Result.FromError<List<AssetRetirementInfo>>(message);
            }
        }

    }
}
