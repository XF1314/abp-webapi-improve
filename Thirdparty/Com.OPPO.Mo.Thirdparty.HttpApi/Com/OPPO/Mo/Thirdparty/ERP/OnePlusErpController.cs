using Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp;
using Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.ERP
{
    /// <summary>
    /// OnePlus ERP 资源
    /// </summary>
    [Area("onepluserp")]
    [Route("api/mo/thirdparty/oneplus/erp")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class OnePlusErpController : AbpController, IOnePlusErpAppService
    {
        private readonly IOnePlusErpAppService _onePlusErpAppService;

        public OnePlusErpController(IOnePlusErpAppService onePlusErpAppService)
        {
            _onePlusErpAppService = onePlusErpAppService;
        }

        /// <summary>
        /// 获取拟价单信息 【第三方接口：/oneplus/erp/oneplus_erp_op_oa_price_iface_query】
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="oaNum">MO文件编号</param>
        /// <returns></returns>
        [HttpGet("oneplus_erp_op_oa_price_iface_query")]
        public async Task<Result<List<OnePlusPriceInfoDto>>> GetPriceInfo(string language, string oaNum)
        {
            return await _onePlusErpAppService.GetPriceInfo(language, oaNum);
        }

        /// <summary>
        /// 一加采购检查供应商登记注册号 【第三方接口：/oneplus/erp/oneplus_erp_cux_po_vendors_v_query】
        /// </summary>
        /// <param name="orgId">组织编号</param>
        /// <param name="vendorNumber">供应商编码</param>
        /// <returns></returns>
        [HttpGet("get_cux_po_vendors_v")]
        public async Task<Result<List<OnplusErpVendorDto>>> GetCuxPoVendors(string orgId, string vendorNumber)
        {
            return await _onePlusErpAppService.GetCuxPoVendors(orgId, vendorNumber);
        }

        /// <summary>
        /// SKU基础数据查询 【第三方接口：/oneplus/erp/oneplus_erp_cux_oa_item_v_query】
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="organizationId">ERP库存组织ID</param>
        /// <param name="skuCode">SKU code</param>
        /// <param name="skuId">ERP Item Id</param>
        /// <param name="uom">SKU主单位</param>
        /// <returns></returns>
        [HttpGet("get-cuxoa-item")]
        public async Task<Result<List<OneplusErpCuxOaItemDto>>> GetCuxOaItem(string language, string organizationId, string skuCode, string skuId, string uom)
        {
            return await _onePlusErpAppService.GetCuxOaItem(language, organizationId, skuCode, skuId, uom);
        }

        /// <summary>
        /// 采购单拟价导入 【第三方接口：/oneplus/erp/oneplus_erp_OP_OA_PRICE_IFACE_Add】
        /// </summary>
        /// <param name="input"><see cref="OnePlusErpPriceInput"/>采购单拟价导入输入参数</param>
        /// <returns></returns>
        [HttpPost("op_oa_price_iface_add")]
        public async Task<Result<OnePlusErpPriceAddDto>> OneplusErpOpOaPriceIfaceAdd(OnePlusErpPriceInput input)
        {
            return await _onePlusErpAppService.OneplusErpOpOaPriceIfaceAdd(input);
        }

        /// <summary>
        ///  获取拟价订单 【第三方接口：/oneplus/erp/oneplus_erp_op_oa_price_iface_query】
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="oaNum">MO文件编号</param>
        /// <returns></returns>
        [HttpGet("op_oa_price_iface_query")]
        public async Task<Result<List<OnePlusErpopOaPriceIfaceQueryDto>>> GetOnePlusErpopOaPriceIface(string language, string oaNum)
        {
            return await _onePlusErpAppService.GetOnePlusErpopOaPriceIface(language, oaNum);
        }

        /// <summary>
        ///  获取主体信息 【第三方接口：/oneplus/erp/oneplus_erp_cux_ex_ou_v_query】
        /// </summary>
        /// <param name="input"><see cref="OnePlusErpCuxExOuVQueryInput"/></param>
        /// <returns></returns>
        [HttpGet("cux_ex_ou_v_query")]
        public async Task<Result<List<OnePlusErpCuxExOuVQueryDto>>> GetOnePlusErpCuxExOuV(OnePlusErpCuxExOuVQueryInput input)
        {
            return await _onePlusErpAppService.GetOnePlusErpCuxExOuV(input);
        }

        /// <summary>
        ///  获取财务系统价格 【第三方接口：/oneplus/erp/oneplus_erp_cux_po_vend_item_price_v_query】
        /// </summary>
        /// <param name="input"><see cref="OnePlusErpCuxPoVendItemPriceInput"/></param>
        /// <returns></returns>
        [HttpGet("cux_po_vend_item_price_v_query")]
        public async Task<Result<List<OnePlusErpCuxPoVendItemPriceDto>>> GetCuxPoVendItemPriceV(OnePlusErpCuxPoVendItemPriceInput input)
        {
            return await _onePlusErpAppService.GetCuxPoVendItemPriceV(input);
        }


        /// <summary>
        /// 获取采购员 【第三方接口：/oneplus/erp/oneplus_erp_cux_po_agents_v_query】
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="agentId">组织ID</param>
        /// <param name="agentName">组织名称</param>
        /// <param name="employeeNumber">工号</param>
        /// <returns></returns>
        [HttpGet("cux_po_agents_v_query")]
        public async Task<Result<List<OnePlusErpAgentsDto>>> GetAgents(string language, string agentId, string agentName, string employeeNumber)
        {
            return await _onePlusErpAppService.GetAgents(language, agentId, agentName, employeeNumber);
        }

        /// <summary>
        /// 采购单导入头部 【第三方接口：/oneplus/erp/oneplus_erp_cux_po_oa_headers_iface_add】
        /// </summary>
        /// <param name="input"><see cref="PoHeadersInterfaceInfoInput"/>采购单导入信息</param>
        /// <returns></returns>
        [HttpPost("cux_po_oa_headers_iface_add")]
        public async Task<Result<OnePlusErpHeadersIfaceDto>> HeadersIfaceAdd(PoHeadersInterfaceInfoInput input)
        {
            return await _onePlusErpAppService.HeadersIfaceAdd(input);
        }

        /// <summary>
        /// 采购单导入主体部分 【第三方接口：/oneplus/erp/oneplus_erp_cux_po_oa_lines_iface_add】
        /// </summary>
        /// <param name="input"><see cref="PoLinesInput"/>采购单导入信息</param>
        /// <returns></returns>
        [HttpPost("cux_po_oa_lines_iface_add")]
        public async Task<Result<OnePlusToErpDto>> LinesIfaceAdd(PoLinesInput input)
        {
            return await _onePlusErpAppService.LinesIfaceAdd(input);
        }

        /// <summary>
        ///  核算主体查询 【第三方接口：/oneplus/erp/oneplus_erp_cux_ex_ou_v_query_with_page】
        /// </summary>
        /// <param name="input"><see cref="OnePlusErpBodyInput"/></param>
        /// <returns></returns>
        [HttpGet("cux_ex_ou_v_query_with_page")]
        public async Task<Result<List<OnePlusErpBodyDto>>> GetCuxExOuVQueryWithPage(OnePlusErpBodyInput input)
        {
            return await _onePlusErpAppService.GetCuxExOuVQueryWithPage(input);
        }

        /// <summary>
        ///  查询个人银行信息 【第三方接口：/oneplus/ps/oneplus_PS_C_PYE_BANK_VW_Query】
        /// </summary>
        /// <param name="empId">员工工号</param>
        /// <returns></returns>
        [HttpGet("get-bankcard-by-empid")]
        public async Task<Result<List<OnePlusBankCardDto>>> GetBankCardByEmpId(string empId)
        {
            return await _onePlusErpAppService.GetBankCardByEmpId(empId);
        }

        /// <summary>
        ///  根据流程单号id查询付款信息 【第三方接口：/oneplus/erp/oneplus_erp_cux_ex_pay_trans_v_Query】
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="id">程单号id(MO单号对应ID)</param>
        /// <returns></returns>
        [HttpGet("cux_ex_pay_trans_v_query")]
        public async Task<Result<List<OnePlusPayTransDto>>> GetPayTransInfoById(string language, string id)
        {
            return await _onePlusErpAppService.GetPayTransInfoById(language, id);
        }

        /// <summary>
        /// 抛送报销信息头部至ERP 【第三方接口：/oneplus/erp/oneplus_erp_CUX_OA_AP_HEADER_IFACE_Add】
        /// </summary>
        /// <param name="input"><see cref="OnePluesHeardToErpInput"/></param>
        /// <returns></returns>
        [HttpPost("commonreim-general-heard-to-erp")]
        public async Task<Result<OnePlusToErpDto>> CommonReimGeneralHeardToErp(OnePluesHeardToErpInput input)
        {
            return await _onePlusErpAppService.CommonReimGeneralHeardToErp(input);
        }

        /// <summary>
        /// 抛送报销行信息至ERP 【第三方接口：/oneplus/erp/oneplus_erp_CUX_OA_AP_LINE_IFACE_Add】
        /// </summary>
        /// <param name="input"><see cref="OnePluesLineToErpInput"/></param>
        /// <returns></returns>
        [HttpPost("commonreim-general-line-to-erp")]
        public async Task<Result<OnePlusToErpDto>> CommonReimGeneralLineToErp(OnePluesLineToErpInput input)
        {
            return await _onePlusErpAppService.CommonReimGeneralLineToErp(input);
        }

        /// <summary>
        /// 查询收货结果 【第三方接口：/oneplus/erp/oneplus_erp_cux_po_trans_v_query】
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("oneplus_erp_cux_po_trans_v_query")]
        public async Task<Result<List<OnePlusErpReceivingResultInfoDto>>> GetReceivingResult(OnePlusErpReceivingResultInput input)
        {
            return await _onePlusErpAppService.GetReceivingResult(input);
        }

        /// <summary>
        /// 查询ERP SKU表的数据  【第三方接口：/oneplus/erp/oneplus_erp_cux_oa_item_ec_v_query_all】
        /// </summary>
        /// <returns></returns>
        [HttpGet("oneplus_erp_cux_oa_item_ec_v_query_all")]
        public async Task<Result<List<OnePlusErpSkuInfoDto>>> GetErpAllSkuInfo(string language)
        {
            return await _onePlusErpAppService.GetErpAllSkuInfo(language);
        }
    }
}
