using Com.OPPO.Mo.Thirdparty.Adap.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Adap
{

    /// <summary>
    /// 出差申请-数字行政接口
    /// </summary>
    [Area("adap")]
    [Route("api/mo/thirdparty/adap")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class AdapController : AbpController, IAdapAppService
    {
        private readonly IAdapAppService _AdapAppService;

        public AdapController(IAdapAppService AdapAppService)
        {
            _AdapAppService = AdapAppService;
        }

        /// <summary>
        /// 推送出差申请数据到数字行政【第三方接口：/s/api/travelApply/pushTravelInfo】
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        [HttpPost("travel-data-push")]
        public async Task<Result> TravelInfoPush(TravelInfoDto queryDto)
        {
            return await _AdapAppService.TravelInfoPush(queryDto);
        }


    }

}
