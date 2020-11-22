using Com.OPPO.Mo.Thirdparty.Fdc.Dto;
using Com.OPPO.Mo.Thirdparty.Fdc.Request;
using Com.OPPO.Mo.Thirdparty.Fdc.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Fdc
{

    /// <summary>
    ///  FDC-财务通用接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.FdcWebApiHost)]
    public interface IFinanceExpenseWebApiService : IHttpApi
    {

        /// <summary>
        /// 费用报销获取基础数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/data/basic/kv/api")]
        Task<FinanceDataResponse> GetFinanceExpenseMsg([JsonContent]FinanceQueryDto request);

    }

}
