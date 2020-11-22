using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.OnePlus.Dtos;
using Com.OPPO.Mo.Thirdparty.OnePlus.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.OnePlus
{

    /// <summary>
    /// 代发代扣/
    /// </summary>
    [Authorize]
    public class OnePlusAppService : ThirdpartyAppServiceBase, IOnePlusAppService
    {

        /// <summary>
        /// onePlus_PS代发代扣 【第三方接口：/oneplus/ps/oneplus_ps_cOaAprItem_add】
        /// </summary>
        /// <param name="dto">数据集合</param>info_number
        /// <returns></returns>
        public async Task<Result> AddOnePlusItems(List<OnePlusItemDto> dto)
        {
            var service = ServiceProvider.GetRequiredService<IOnePlusEsbService>();
            var datas = ObjectMapper.Map<List<OnePlusItemDto>, List<OnePlusItem>>(dto);
            var response = await service.InsertSubsInfoToERP(new LinesRequest
            {
                Data = JsonConvert.SerializeObject(datas)
            });

            if (response.Body.BussinessCode == "1")
                return Result.Ok(response.Body.Message);
            else
            {
                var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }

    }
}
