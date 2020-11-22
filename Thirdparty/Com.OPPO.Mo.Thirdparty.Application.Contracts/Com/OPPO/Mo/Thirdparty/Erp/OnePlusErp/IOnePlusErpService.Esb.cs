using Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Requests;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp
{
    /// <summary>
    /// Erp/OnePlus
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IOnePlusErpEsbService : IHttpApi
    {
        /// <summary>
        /// 获取拟价单信息
        /// </summary>
        /// <param name="request"><see cref="OnePlusErpPriceRequest"/></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_op_oa_price_iface_query")]
        Task<ErpResultResponseResult<OnePlusErpPriceInfo>> GetPriceInfo([PathQuery]OnePlusErpPriceRequest request);

        /// <summary>
        ///  一加检测供应商注册号（供应商准入流程）
        /// </summary>
        /// <param name="request"><see cref="OnePlusErpVendorRequest"/></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_po_vendors_v_query")]
        Task<ErpResultResponseResult<OnePlusInfo>> GetCuxPoVendors([PathQuery]OnePlusErpVendorRequest request);

        /// <summary>
        ///  SKU基础数据查询
        /// </summary>
        /// <param name="request"><see cref="OnePlusErpCuxOaItemRequest"/></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_oa_item_v_query")]
        Task<ErpResultResponseResult<OnePlusInfo>> OneplusErpCuxOaItemVQuery([PathQuery] OnePlusErpCuxOaItemRequest request);

        /// <summary>
        /// 采购单拟价导入
        /// </summary>
        /// <param name="request"><see cref="OnePlusErpPriceAddRequest"/></param>
        /// <returns></returns>
        [HttpPost("/oneplus/erp/oneplus_erp_OP_OA_PRICE_IFACE_Add")]
        Task<ErpResultResponseResult<OnePlusErpPriceAddDto>> OneplusErpOpOaPriceIfaceAdd([FormContent] OnePlusErpPriceAddRequest request);

        /// <summary>
        ///  获取拟价订单
        /// </summary>
        /// <param name="request"><see cref="OnePlusErpopOaPriceIfaceQueryRequest"/></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_op_oa_price_iface_query")]
        Task<ErpResultResponseResult<OnePlusInfo>> OnePlusErpOpOaPriceIfaceQuery([PathQuery] OnePlusErpopOaPriceIfaceQueryRequest request);

        /// <summary>
        /// 获取主体信息
        /// </summary>
        /// <param name="request"><see cref="OnePlusErpCuxExOuVQueryRequest"/></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_ex_ou_v_query")]
        Task<ErpResultResponseResult<OnePlusInfo>> OnePlusErpCuxExOuVQuery([PathQuery] OnePlusErpCuxExOuVQueryRequest request);

        /// <summary>
        /// 获取财务系统价格
        /// </summary>
        /// <param name="request"><see cref="OnePlusErpCuxPoVendItemPriceRequest"/></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_po_vend_item_price_v_query")]
        Task<ErpResultResponseResult<OnePlusInfo>> CuxPoVendItemPriceVQuery([PathQuery] OnePlusErpCuxPoVendItemPriceRequest request);

        /// <summary>
        /// 获取采购员
        /// </summary>
        /// <param name="request"><see cref="OnePlusErpAgentsRequest"/></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_po_agents_v_query")]
        Task<ErpResultResponseResult<OnePlusInfo>> CuxPoAgentsVQuery([PathQuery] OnePlusErpAgentsRequest request);

        /// <summary>
        /// 采购单导入头部
        /// </summary>
        /// <param name="request"><see cref="OnePlusErpAgentsRequest"/></param>
        /// <returns></returns>
        [HttpPost("/oneplus/erp/oneplus_erp_cux_po_oa_headers_iface_add")]
        Task<ErpResultResponseResult<OnePlusErpHeadersIfaceDto>> CuxPoOaHeadersIfaceAdd([FormContent] OnePlusErpHeadersRequest request);

        /// <summary>
        /// 采购单导入主体部分
        /// </summary>
        /// <param name="request"><see cref="OnePlusErpAgentsRequest"/></param>
        /// <returns></returns>
        [HttpPost("/oneplus/erp/oneplus_erp_cux_po_oa_lines_iface_add")]
        Task<ErpResultResponseResult<OnePlusErpDto>> CuxPoOaLinesIfaceAdd([FormContent] OnePlusErpLinesRequest request);

        /// <summary>
        /// 核算主体查询
        /// </summary>
        /// <param name="request"><see cref="OnePlusErpBodyRequest"/></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_ex_ou_v_query_with_page")]
        Task<ErpResultResponseResult<OnePlusInfo>> CuxExOuVQueryWithPage([PathQuery] OnePlusErpBodyRequest request);

        /// <summary>
        /// 查询个人银行信息
        /// </summary>
        /// <param name="request"><see cref="OnePlusBankCardRequest"/></param>
        /// <returns></returns>
        [HttpGet("/oneplus/ps/oneplus_PS_C_PYE_BANK_VW_Query")]
        Task<ErpResultResponseResult<OnePlusInfo>> GetBankCardInfo([PathQuery] OnePlusBankCardRequest request);

        /// <summary>
        /// 根据流程单号id查询付款信息
        /// </summary>
        /// <param name="request"><see cref="OnePlusPayTransRequest"/></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_ex_pay_trans_v_Query")]
        Task<ErpResultResponseResult<OnePlusInfo>> GetPayTransInfoById([PathQuery] OnePlusPayTransRequest request);

        /// <summary>
        /// 报销通用接口(heard信息)
        /// </summary>
        /// <param name="request"><see cref="OnePlusCuxOaApHeaderIfaceRequest"/></param>
        /// <returns></returns>
        [HttpPost("/oneplus/erp/oneplus_erp_CUX_OA_AP_HEADER_IFACE_Add")]
        Task<ErpResultResponseResult<OnePlusToErpDto>> CuxOaApHeaderIfaceAdd([FormContent] OnePlusCuxOaApHeaderIfaceRequest request);

        /// <summary>
        /// 报销通用接口(Line信息)
        /// </summary>
        /// <param name="request"><see cref="OnePlusOaApLineIfaceTransRequest"/></param>
        /// <returns></returns>
        [HttpPost("/oneplus/erp/oneplus_erp_CUX_OA_AP_LINE_IFACE_Add")]
        Task<ErpResultResponseResult<OnePlusToErpDto>> CuxOaApLineIfaceAdd([FormContent] OnePlusOaApLineIfaceTransRequest request);

        /// <summary>
        /// 查询收货结果
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_po_trans_v_query")]
        Task<ErpResultResponseResult<OnePlusInfo>> GetReceivingResult([PathQuery] OnePlusErpReceivingResultInput request);

        /// <summary>
        /// 查询ERP SKU表的数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("/oneplus/erp/oneplus_erp_cux_oa_item_ec_v_query_all")]
        Task<ErpResultResponseResult<OnePlusInfo>> GetErpAllSkuInfo([PathQuery] OnePlusGetErpSkuInfoRequest request);
    }
}
