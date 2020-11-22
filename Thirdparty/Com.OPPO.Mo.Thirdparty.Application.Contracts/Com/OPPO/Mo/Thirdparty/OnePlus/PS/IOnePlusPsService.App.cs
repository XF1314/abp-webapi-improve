using Com.OPPO.Mo.Thirdparty.OnePlus.PS.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.PS
{
    /// <summary>
    /// OnePlus Ps Service
    /// </summary>
    public interface IOnePlusPsAppService : IApplicationService
    {
        /// <summary>
        /// 法定节假日加班数据推送接口【第三方接口: /oneplus/ps/oneplus_ps_cEmplOt_add】
        /// </summary>
        /// <returns></returns>
        Task<Result> AddPublicHoildayOTInfo(OnePlusHolidayOTDto holidayOTDto);
    }
}
