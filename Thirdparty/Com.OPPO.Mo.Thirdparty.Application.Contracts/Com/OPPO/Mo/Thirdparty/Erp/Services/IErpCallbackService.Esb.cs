using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Erp.Services
{
    /// <summary>
    /// 流程结束时回调
    /// </summary>
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IErpCallbackEsbService : IHttpApi
    {
        /// <summary>
        /// 付款通知单传ERP
        /// </summary>
        /// <param name="request"><see cref="ErpInvoicesPushRequest"/></param>
        /// <returns></returns>
        [HttpPost("/erp/finance/ap_invoices_push")]
        Task<ErpResultResponseResult<ErpResponseInfo>> ApInvoicesPush([FormContent] ErpInvoicesPushRequest request);
    }
}
