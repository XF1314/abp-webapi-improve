using Com.OPPO.Mo.Thirdparty.Erp.ErpSrm.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpSrm
{

    /// <summary>
    /// Erp/srm
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IErpSrmEsbService : IHttpApi
    {
     
        /// <summary>
        /// 获取验收单信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/erp/srm/srm_get_checkbill_info")]
        Task<ErpSrmCheckBillInfoResponse> GetCheckBillInfo([PathQuery]ErpSrmCheckBillInfoQueryRequest query);

        /// <summary>
        /// 根据料号获取库存信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/erp/srm/srm_mtrlno_stock")]
        Task<ErpSrmMtrlnoStockResponse> GetMtrlnoStock([PathQuery]ErpSrmMtrlnoStockQueryRequest query);

        /// <summary>
        /// 采购风险申请单写入erp 【第三方接口：/erp/srm/srm_deliver_check_insert_batch_2】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/erp/srm/srm_deliver_check_insert_batch_2")] 
        Task<EsbResponse> PurchaseOrderToErpPush([FormContent]ErpPurchaseOrderPushRequest query);

        /// <summary>
        /// 采购风险申请单写入erp1 【第三方接口：/erp/srm/srm_deliver_check_insert_batch_1】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/erp/srm/srm_deliver_check_insert_batch_1")]
        Task<EsbResponse> PurchaseOrderToErpPush1([FormContent]ErpPurchaseOrderPushRequest query);

        /// <summary>
        /// 更新进货检验报告数据1 【第三方接口：/erp/srm/srm_deliver_status_update_1】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/erp/srm/srm_deliver_status_update_1")]
        Task<EsbResponse> DeliverStatusUpdate_1([FormContent]ErpDeliverStatusUpdateARequest query);

        /// <summary>
        /// 更新进货检验报告数据2 【第三方接口：/erp/srm/srm_deliver_status_update_2】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/erp/srm/srm_deliver_status_update_2")]
        Task<EsbResponse> DeliverStatusUpdate_2([FormContent]ErpDeliverStatusUpdateBRequest query);

        /// <summary>
        /// 信息更新 【第三方接口：/erp/srm/updateifreceivingreportrepeat】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/erp/srm/srm_deliver_status_update_2")]
        Task<EsbResponse> UpdateIfReceivingReportRepeat([FormContent]LinesRequest query);
    }

}
