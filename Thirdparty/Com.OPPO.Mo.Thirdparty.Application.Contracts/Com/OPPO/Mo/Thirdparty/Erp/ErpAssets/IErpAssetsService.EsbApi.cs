using Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Responses;
using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets
{

    /// <summary>
    /// Erp/Assets
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IErpAssetsService : IHttpApi
    {

        /// <summary>
        /// 根据文件编号查询采购单信息 【第三方接口：/erp/assets/po_list】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/erp/assets/po_list")]
        Task<PurchaseOrderResponse> QueryPurchaseOrderByDocId([PathQuery] QueryPurchaseOrderRequest query);

        /// <summary>
        /// 创建PO,设备请购,工装夹治具 【第三方接口：/erp/assets/create_po】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/erp/assets/create_po")]
        Task<CreatePoInfoResponse> CreatePo([FormContent] PoLinesRequest query);

        /// <summary>
        /// PO入仓确认 【第三方接口：/erp/assets/po_deliver】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/erp/assets/po_deliver")]
        Task<PoWarehousingResponse> PoWarehousingConfirm([FormContent] PoLinesRequest query);

        /// <summary>
        /// 供应商税率获取 【第三方接口：/erp/assets/vender_tax_get】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/erp/assets/vender_tax_get")]
        Task<VenderTaxResponse> GetVenderTax([PathQuery] QueryVenderTaxRequest query);


        /// <summary>
        /// 创建PO,按行号,设备请购,工装夹治具 【第三方接口：/erp/assets/create_po_line】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/erp/assets/create_po_line")]
        Task<PoLineResponse> CreatePoLine([FormContent] PoLinesRequest query);


        /// <summary>
        /// 普通设备请购获取最新单价 【第三方接口：/erp/assets/bbk_po_from_oa】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/erp/assets/bbk_po_from_oa")]
        Task<LatestUnitPriceResponse> GetLatestUnitPrice([PathQuery] QueryLatestUnitPriceRequest query);


        /// <summary>
        /// 根据文件编号查询采购单信息 【第三方接口：/erp/assets/po_list_fun】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/erp/assets/po_list_fun")]
        Task<PoListResponse> GetPoListByDocId([PathQuery] QueryPoListRequest query);

        /// <summary>
        /// 删除下单临时表数据接口 【第三方接口：/erp/assets/po_delete】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/erp/assets/po_delete")]
        Task<EsbResponse> DeletePoBySeqId([FormContent] DeletePoRequest query);

        /// <summary>
        /// 紧急设备请购推送接口 【第三方接口：/erp/assets/equipment_purchase】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/erp/assets/equipment_purchase")]
        Task<EsbResponse> EquipmentPurchasePush([FormContent] LinesRequest query);
    }
}
