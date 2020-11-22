using Com.OPPO.Mo.Thirdparty.Erp.ErpOrder.Responses;
using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpOrder
{

    /// <summary>
    /// Erp/order
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IErpOrderEsbService : IHttpApi
    {
        /// <summary>
        /// 营销样机流程创建so
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/erp/orders/order_line_push")]
        Task<EsbResponse> OrderLinePush([FormContent]SoLinesRequest query);

        /// <summary>
        /// 获取订单号和交货编号
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/erp/orders/get_order_deliver_info")]
        Task<ErpOrderDeliverInfoResponse> GetOrderDeliverInfo([PathQuery]ErpOrderDeliverInfoQueryRequest query);
    }

}
