using Com.OPPO.Mo.Thirdparty.Erp.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpOrder;
using Com.OPPO.Mo.Thirdparty.Erp.ErpOrder.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpOrder.Responses;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using Com.OPPO.Mo.Thirdparty.Erp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.ERP
{
    /// <summary>
    /// ERP/order 资源
    /// </summary>
    [Area("erp")]
    [Route("api/mo/thirdparty/erp/order")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class ErpOrderController : AbpController, IErpOrderAppService
    {
        private readonly IErpOrderAppService _erpAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="erpAppService"></param>
        public ErpOrderController(IErpOrderAppService erpAppService)
        {
            _erpAppService = erpAppService;
        }

        /// <summary>
        /// 营销样机流程创建so 【第三方接口：/erp/orders/order_line_push】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("order-line-add")]
        public async Task<Result> OrderLinePush(List<ErpOrderLineDto> dto)
        {
            return await _erpAppService.OrderLinePush(dto);
        }


        /// <summary>
        /// 获取订单号和交货编号 【第三方接口：/erp/orders/get_order_deliver_info】
        /// </summary>
        /// <param name="docId">文件编号,必填</param>
        /// <param name="responseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        [HttpGet("query-order-deliver-info")]
        public async Task<Result<List<DetailsItem>>> GetOrderDeliverInfo([Required]string docId, string responseType)
        {
            return await _erpAppService.GetOrderDeliverInfo(docId, responseType);
        }

    }

}
