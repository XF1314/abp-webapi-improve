using Com.OPPO.Mo.Thirdparty.OnePlus.PS;
using Com.OPPO.Mo.Thirdparty.OnePlus.PS.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Ps
{
    /// <summary>
    /// OnePlus Ps 接口资源
    /// </summary>
    [Area("oneplusps")]
    [Route("api/mo/thirdparty/oneplus/ps")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class OnePlusPsController : AbpController, IOnePlusPsAppService
    {
        private readonly IOnePlusPsAppService _onePlusPsAppService;
        public OnePlusPsController(IOnePlusPsAppService onePlusPsAppService)
        {
            _onePlusPsAppService = onePlusPsAppService;
        }

        /// <summary>
        /// 法定节假日加班数据推送【第三方接口: /oneplus/ps/oneplus_ps_cEmplOt_add】
        /// </summary>
        /// <param name="holidayOTData"></param>
        /// <returns></returns>
       [HttpPost("oneplus_ps_cEmplOt_add")]
        public async Task<Result> AddPublicHoildayOTInfo([FromBody]OnePlusHolidayOTDto holidayOTData)
        {
            return await _onePlusPsAppService.AddPublicHoildayOTInfo(holidayOTData);
        }
    }
}
