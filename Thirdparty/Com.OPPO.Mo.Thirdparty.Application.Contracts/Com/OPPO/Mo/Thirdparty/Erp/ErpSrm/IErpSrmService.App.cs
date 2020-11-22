using Com.OPPO.Mo.Thirdparty.Erp.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpSrm.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpSrm
{

    /// <summary>
    /// Erp/srm
    /// </summary>
    public interface IErpSrmAppService : IApplicationService
    {

        /// <summary>
        /// 获取验收单信息 【第三方接口：/erp/srm/srm_get_checkbill_info】
        /// </summary>
        /// <param name="OrganizationCode">组织代码,必填</param>
        /// <param name="ReceiptNumber">验收单号,必填</param>
        /// <param name="MaterialNumber">物料号,必填</param>
        /// <param name="Language">default: ZHS,可不填</param>
        /// <returns></returns>
        Task<Result<ErpSrmStockBody>> GetCheckBillInfo(string OrganizationCode, string ReceiptNumber, string MaterialNumber, string Language);

        /// <summary>
        /// 根据料号获取库存信息 【第三方接口：/erp/srm/srm_mtrlno_stock】
        /// </summary>
        /// <param name="OrganizationCode">组织代码,必填</param>
        /// <param name="MaterialNumber">料号,必填</param>
        /// <param name="Language">default: ZHS,可不填</param>
        /// <returns></returns>
        Task<Result<ErpSrmStockBody>> GetMtrlnoStock(string OrganizationCode, string MaterialNumber, string Language);

        /// <summary>
        /// 采购风险申请单写入erp 【第三方接口：/erp/srm/srm_deliver_check_insert_batch_2】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Result> PurchaseOrderToErpPush(List<ErpPurchaseOrderDto> dto);

        /// <summary>
        /// 采购风险申请单写入erp1 【第三方接口：/erp/srm/srm_deliver_check_insert_batch_1】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Result> PurchaseOrderToErpPush1(List<PurchaseReportDto> dto);

        /// <summary>
        /// 更新进货检验报告数据1 【第三方接口：/erp/srm/srm_deliver_status_update_1】
        /// </summary>
        /// <param name="DocId">文件编号,必填</param>
        /// <param name="Status">状态,必填</param>
        /// <returns></returns>
        Task<Result> DeliverStatusUpdate_1(string DocId, string Status);

        /// <summary>
        /// 更新进货检验报告数据2 【第三方接口：/erp/srm/srm_deliver_status_update_2】
        /// </summary>
        /// <param name="DocId">文件编号,必填</param>
        /// <param name="Status">状态,必填</param>
        /// <param name="IqcStatus">iqc状态,必填</param>
        /// <returns></returns>
        Task<Result> DeliverStatusUpdate_2(string DocId, string Status, string IqcStatus);


        /// <summary>
        /// 信息更新 【第三方接口：/erp/srm/updateifreceivingreportrepeat】
        /// </summary>
        /// <param name="dto">信息集合</param>
        /// <returns></returns>
        Task<Result> UpdateIfReceivingReportRepeat(List<UpdateIfreceivingDto> dto);


    }
}
