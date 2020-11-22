using Com.OPPO.Mo.Thirdparty.Erp.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.ErpOrder;
using Com.OPPO.Mo.Thirdparty.Erp.ErpOrder.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpOrder.Responses;
using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using Com.OPPO.Mo.Thirdparty.Erp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Erp
{

    [Authorize]
    public class ErpOrderAppService : ThirdpartyAppServiceBase, IErpOrderAppService
    {
        /// <summary>
        /// 营销样机流程创建so 【第三方接口：/erp/orders/order_line_push】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Result> OrderLinePush(List<ErpOrderLineDto> dto)
        { 
            var service = ServiceProvider.GetRequiredService<IErpOrderEsbService>();
            var query = ObjectMapper.Map<List<ErpOrderLineDto>, List<ErpOrderLine>>(dto);
            var response = await service.OrderLinePush(new SoLinesRequest
            {
                Data = JsonConvert.SerializeObject(query)
            });

            if (response.Body.BussinessCode == "0")
                return Result.Ok();
            else
            {
                var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }

        /// <summary>
        /// 获取订单号和交货编号 【第三方接口：/erp/orders/get_order_deliver_info】
        /// </summary>
        /// <param name="DocId">文件编号,必填</param>
        /// <param name="ResponseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        public async Task<Result<List<DetailsItem>>> GetOrderDeliverInfo(string DocId, string ResponseType)
        {
            var service = ServiceProvider.GetRequiredService<IErpOrderEsbService>();
            ErpOrderDeliverInfoQueryRequest query = new ErpOrderDeliverInfoQueryRequest
            {
                DocId = DocId,
                ResponseType = ResponseType
            };
            var response = await service.GetOrderDeliverInfo(query);

            if (response.Response.Code == null) { 
                var datas = ObjectMapper.Map<List<DetailsItemDto>, List<DetailsItem>>(response.Response.results);
                return Result.FromData(datas);
            }
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogError(message);
                return Result.FromError<List<DetailsItem>>(message);
            }
        }

    }

}
