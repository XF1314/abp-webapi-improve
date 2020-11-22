using Com.OPPO.Mo.Thirdparty.Erp.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpSrm;
using Com.OPPO.Mo.Thirdparty.Erp.ErpSrm.Dtos;
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
    /// ERP/srm 资源/进货检验报告
    /// </summary>
    [Area("erp")]
    [Route("api/mo/thirdparty/erp/srm")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class ErpSrmController : AbpController, IErpSrmAppService
    {
        private readonly IErpSrmAppService _erpAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="erpAppService"></param>
        public ErpSrmController(IErpSrmAppService erpAppService)
        {
            _erpAppService = erpAppService;
        }


        /// <summary>
        /// 获取验收单信息 【第三方接口：/erp/srm/srm_get_checkbill_info】
        /// </summary>
        /// <param name="orgCode">组织代码,必填</param>
        /// <param name="ReceiptNumber">验收单号,必填</param>
        /// <param name="materialCode">料号,必填</param>
        /// <param name="language">default: ZHS,可不填</param>
        /// <returns></returns>
        [HttpGet("query-checkbill-info")]
        public async Task<Result<ErpSrmStockBody>> GetCheckBillInfo([Required]string orgCode, [Required]string ReceiptNumber, [Required]string materialCode, string language)
        {
            return await _erpAppService.GetCheckBillInfo(orgCode, ReceiptNumber, materialCode, language);
        }


        /// <summary>
        /// 根据料号获取库存信息 【第三方接口：/erp/srm/srm_mtrlno_stock】
        /// </summary>
        /// <param name="orgCode">组织代码,必填</param>
        /// <param name="materialCode">料号,必填</param>
        /// <param name="language">default: ZHS,可不填</param>
        /// <returns></returns>
        [HttpGet("query-mtrlno-stock")]
        public async Task<Result<ErpSrmStockBody>> GetMtrlnoStock([Required]string orgCode, [Required]string materialCode, string language)
        {
            return await _erpAppService.GetMtrlnoStock(orgCode, materialCode, language);
        }

        /// <summary>
        /// 采购风险申请单写入erp 【第三方接口：/erp/srm/srm_deliver_check_insert_batch_2】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("add-purchase-order-to-erp")]
        public async Task<Result> PurchaseOrderToErpPush(List<ErpPurchaseOrderDto> dto)
        {
            return await _erpAppService.PurchaseOrderToErpPush(dto);
        }

        /// <summary>
        /// 采购风险申请单写入erp 【第三方接口：/erp/srm/srm_deliver_check_insert_batch_1】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("add-purchase-order-to-erp1")]
        public async Task<Result> PurchaseOrderToErpPush1(List<PurchaseReportDto> dto)
        {
            return await _erpAppService.PurchaseOrderToErpPush1(dto);
        }

        /// <summary>
        /// 更新进货检验报告数据1 【第三方接口：/erp/srm/srm_deliver_status_update_1】
        /// </summary>
        /// <param name="docId">文件编号,必填</param>
        /// <param name="status">状态,必填</param>
        /// <returns></returns>
        [HttpPut("update-deliver-status1")]
        public async Task<Result> DeliverStatusUpdate_1([Required]string docId, [Required]string status)
        {
            return await _erpAppService.DeliverStatusUpdate_1(docId, status);
        }

        /// <summary>
        /// 更新进货检验报告数据2 【第三方接口：/erp/srm/srm_deliver_status_update_2】
        /// </summary>
        /// <param name="docId">文件编号,必填</param>
        /// <param name="status">状态,必填</param>
        /// <param name="IqcStatus">iqc状态,必填</param>
        /// <returns></returns>
        [HttpPut("update-deliver-status2")]
        public async Task<Result> DeliverStatusUpdate_2([Required]string docId, [Required]string status, [Required]string IqcStatus)
        {
            return await _erpAppService.DeliverStatusUpdate_2(docId, status, IqcStatus);
        }

        /// <summary>
        /// 信息更新 【第三方接口：/erp/srm/updateifreceivingreportrepeat】
        /// </summary>
        /// <param name="dtos">信息集合</param>
        /// <returns></returns>
        [HttpPut("update-ifreceiving-report")]
        public async Task<Result> UpdateIfReceivingReportRepeat(List<UpdateIfreceivingDto> dtos)
        {
            return await _erpAppService.UpdateIfReceivingReportRepeat(dtos);
        }

    }
}
