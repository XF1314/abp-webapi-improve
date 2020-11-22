using Com.OPPO.Mo.Thirdparty.Erp.ErpAssets;
using Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Responses;
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
    /// ERP/assets 资源
    /// </summary>
    [Area("erp")]
    [Route("api/mo/thirdparty/erp/assets")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class ErpAssetsController : AbpController, IErpAssetsAppService
    {
        private readonly IErpAssetsAppService _erpAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="erpAppService"></param>
        public ErpAssetsController(IErpAssetsAppService erpAppService)
        {
            _erpAppService = erpAppService;
        }


        /// <summary>
        /// 根据文件编号查询采购单信息 【第三方接口：/erp/assets/po_list】
        /// </summary>
        /// <param name="docId">文件编号,必填</param>
        /// <param name="language">语言</param>
        /// <returns></returns>
        [HttpGet("query-purchaseorder-by-docid")]
        public async Task<Result<List<PoLinesInfo>>> QueryPurchaseOrderByDocId([Required]string docId, string language)
        {
            return await _erpAppService.QueryPurchaseOrderByDocId(docId, language);
        }

        /// <summary>
        /// 创建PO,设备请购,工装夹治具 【第三方接口：/erp/assets/create_po】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("create-po-info")]
        public async Task<Result<List<PoLineBase>>> CreatePo(List<CreatePoInfoDto> dto)
        {
            return await _erpAppService.CreatePo(dto);
        }

        /// <summary>
        /// PO入仓确认 【第三方接口：/erp/assets/po_deliver】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("po-warehousing-confirm")]
        public async Task<Result<PoLine>> PoWarehousingConfirm(PoWarehousingDto dto)
        {
            return await _erpAppService.PoWarehousingConfirm(dto);
        }

        /// <summary>
        /// 供应商税率获取 【第三方接口：/erp/assets/vender_tax_get】
        /// </summary>
        /// <param name="orgCode">组织代码,必填</param>
        /// <param name="vendorCode">供应商代码,必填</param>
        /// <param name="language">语言,非必填</param>
        /// <returns></returns>
        [HttpGet("query-vender-tax")]
        public async Task<Result<VenderTax>> GetVenderTax([Required]string orgCode, [Required]string vendorCode, string language)
        {
            return await _erpAppService.GetVenderTax(orgCode, vendorCode, language);
        }


        /// <summary>
        /// 创建PO,设备请购,工装夹治具 【第三方接口：/erp/assets/create_po_line】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("create-po-line")]
        public async Task<Result<List<PoLineRet>>> CreatePoLine(List<CreatePoDto> dto)
        {
            return await _erpAppService.CreatePoLine(dto);
        }

        /// <summary>
        /// 普通设备请购获取最新单价 【第三方接口：/erp/assets/bbk_po_from_oa】
        /// </summary>
        /// <param name="itemCode">资产代码,必填</param>
        /// <param name="vendorCode">供应商代码,必填</param>
        /// <param name="language">语言,非必填</param>
        /// <returns></returns>
        [HttpGet("query-latest-unitprice-to-item")]
        public async Task<Result<bbkInfo>> GetLatestUnitPrice([Required]string itemCode, string vendorCode, string language)
        {
            return await _erpAppService.GetLatestUnitPrice(itemCode, vendorCode, language);
        }


        /// <summary>
        /// 根据文件编号查询采购单信息 【第三方接口：/erp/assets/po_list_fun】
        /// </summary>
        /// <param name="docId">文件编号,非必填</param>
        /// <param name="poNumber">采购单号,非必填</param>
        /// <param name="language">语言,非必填</param>
        /// <returns></returns>
        [HttpGet("query-po-list-by-docid")]
        public async Task<Result<List<PurchaseOrder>>> GetPoListByDocId(string docId, string poNumber, string language)
        {
            return await _erpAppService.GetPoListByDocId(docId, poNumber, language);
        }

        /// <summary>
        /// 删除下单临时表数据接口 【第三方接口：/erp/assets/po_delete】
        /// </summary>
        /// <param name="seqId">序号,必填</param>
        /// <param name="responseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        [HttpDelete("delete-po-list-by-seqid")]
        public async Task<Result> DeletePoBySeqId([Required]string seqId, string responseType)
        {
            return await _erpAppService.DeletePoBySeqId(seqId, responseType);
        }

        /// <summary>
        /// 紧急设备请购推送接口 【第三方接口：/erp/assets/equipment_purchase】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("equipment-purchase-push")]
        public async Task<Result> EquipmentPurchasePush(List<EquipmentPurchaseDto> dto)
        {
            return await _erpAppService.EquipmentPurchasePush(dto);
        }

    }
}
