using Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos;
using Com.OPPO.Mo.Thirdparty.OnePlus.PS.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.PS
{
    /// <summary>
    /// OnePlus Ps
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IOnePlusPsEsbService : IHttpApi
    {
        /// <summary>
        /// 法定节假日推送数据接口
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        [HttpPost("/oneplus/ps/oneplus_ps_cEmplOt_add")]
        Task<EsbResponse> AddPublicHoildayOTInfo([FormContent] OnePlusHolidayOTInfoAddRequest formData);
    }
}
