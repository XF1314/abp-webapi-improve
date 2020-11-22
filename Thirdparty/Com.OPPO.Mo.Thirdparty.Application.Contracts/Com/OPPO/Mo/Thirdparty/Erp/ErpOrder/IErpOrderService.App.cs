using Com.OPPO.Mo.Thirdparty.Erp.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpOrder.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpOrder.Responses;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpOrder
{

    /// <summary>
    /// Erp/order应用服务接口
    /// </summary>
    public interface IErpOrderAppService : IApplicationService
    {
        /// <summary>
        /// 营销样机流程创建so 【第三方接口：/erp/orders/order_line_push】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Result> OrderLinePush(List<ErpOrderLineDto> dto);

        /// <summary>
        /// 获取订单号和交货编号 【第三方接口：/erp/orders/get_order_deliver_info】
        /// </summary>
        /// <param name="DocId">文件编号,必填</param>
        /// <param name="ResponseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        Task<Result<List<DetailsItem>>> GetOrderDeliverInfo(string DocId, string ResponseType);
    }
}
