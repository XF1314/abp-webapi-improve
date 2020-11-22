using Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets
{
    /// <summary>
    /// Erp/Assets
    /// </summary>
    public interface IErpAssetsAppService : IApplicationService
    {

        /// <summary>
        /// 根据文件编号查询采购单信息 【第三方接口：/erp/assets/po_list】
        /// </summary>
        /// <param name="docId">文件编号,必填</param>
        /// <param name="language">语言</param>
        /// <returns></returns>
        Task<Result<List<PoLinesInfo>>> QueryPurchaseOrderByDocId(string docId, string language);

        /// <summary>
        /// 创建PO,设备请购,工装夹治具 【第三方接口：/erp/assets/create_po】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Result<List<PoLineBase>>> CreatePo(List<CreatePoInfoDto> dto);

        /// <summary>
        /// PO入仓确认 【第三方接口：/erp/assets/po_deliver】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Result<PoLine>> PoWarehousingConfirm(PoWarehousingDto dto);

        /// <summary>
        /// 供应商税率获取 【第三方接口：/erp/assets/vender_tax_get】
        /// </summary>
        /// <param name="orgCode">组织代码,必填</param>
        /// <param name="vendorCode ">供应商代码,必填</param>
        /// <param name="language">语言,非必填</param>
        /// <returns></returns>
        Task<Result<VenderTax>> GetVenderTax(string orgCode, string vendorCode, string language);

        /// <summary>
        /// 创建PO,设备请购,工装夹治具 【第三方接口：/erp/assets/create_po_line】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Result<List<PoLineRet>>> CreatePoLine(List<CreatePoDto> dto);

        /// <summary>
        /// 普通设备请购获取最新单价 【第三方接口：/erp/assets/bbk_po_from_oa】
        /// </summary>
        /// <param name="itemCode">资产代码,必填</param>
        /// <param name="vendorCode ">供应商代码,必填</param>
        /// <param name="language">语言,非必填</param>
        /// <returns></returns>
        Task<Result<bbkInfo>> GetLatestUnitPrice(string itemCode, string vendorCode, string language);

        /// <summary>
        /// 根据文件编号查询采购单信息 【第三方接口：/erp/assets/po_list_fun】
        /// </summary>
        /// <param name="docId">文件编号,非必填</param>
        /// <param name="poNumber">采购单号,非必填</param>
        /// <param name="language">语言,非必填</param>
        /// <returns></returns>
        Task<Result<List<PurchaseOrder>>> GetPoListByDocId(string docId, string poNumber, string language);

        /// <summary>
        /// 删除下单临时表数据接口 【第三方接口：/erp/assets/po_delete】
        /// </summary>
        /// <param name="seqId">序号,必填</param>
        /// <param name="responseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        Task<Result> DeletePoBySeqId(string seqId, string responseType);

        /// <summary>
        /// 删除下单临时表数据接口 【第三方接口：/erp/assets/po_delete】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Result> EquipmentPurchasePush(List<EquipmentPurchaseDto> dto);

    }
}
