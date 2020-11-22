using Com.OPPO.Mo.Thirdparty.OnePlus.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.OnePlus
{
    /// <summary>
    /// 代发代扣/
    /// </summary>
    public interface IOnePlusAppService : IApplicationService
    {

        /// <summary>
        /// onePlus_PS代发代扣 【第三方接口：/oneplus/ps/oneplus_ps_cOaAprItem_add】
        /// </summary>
        /// <param name="dto">数据集合</param>info_number
        /// <returns></returns>
        Task<Result> AddOnePlusItems(List<OnePlusItemDto> dto);

    }
}
