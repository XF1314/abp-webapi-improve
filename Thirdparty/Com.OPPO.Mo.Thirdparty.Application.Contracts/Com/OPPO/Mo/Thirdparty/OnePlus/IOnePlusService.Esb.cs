using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.OnePlus
{

    /// <summary>
    /// OnePlus/PS
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IOnePlusEsbService : IHttpApi
    {

        /// <summary>
        /// onePlus_PS代发代扣 【第三方接口：/oneplus/ps/oneplus_ps_cOaAprItem_add】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/oneplus/ps/oneplus_ps_cOaAprItem_add")]
        Task<EsbResponse> InsertSubsInfoToERP([FormContent]LinesRequest query);

    }
}
