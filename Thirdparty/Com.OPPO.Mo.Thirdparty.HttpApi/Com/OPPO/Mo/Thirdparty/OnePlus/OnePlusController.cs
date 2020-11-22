using Com.OPPO.Mo.Thirdparty.OnePlus.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.OnePlus
{
    /// <summary>
    /// OnePlus 资源
    /// </summary>
    [Area("oneplus")]
    [Route("api/mo/thirdparty/oneplus/ps")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class OnePlusController : AbpController, IOnePlusAppService
    {
        private readonly IOnePlusAppService _AppService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="erpAppService"></param>
        public OnePlusController(IOnePlusAppService erpAppService)
        {
            _AppService = erpAppService;
        }

        /// <summary>
        /// onePlus_PS代发代扣 【第三方接口：/oneplus/ps/oneplus_ps_cOaAprItem_add】
        /// </summary>
        /// <param name="dto">数据集合</param>info_number
        /// <returns></returns>
        [HttpPost("add-oneplus-list")]
        public async Task<Result> AddOnePlusItems(List<OnePlusItemDto> dto)
        {
            return await _AppService.AddOnePlusItems(dto);
        }

    }
}
