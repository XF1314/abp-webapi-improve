using Com.OPPO.Mo.Thirdparty.Erp.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using Com.OPPO.Mo.Thirdparty.Erp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.ERP
{
    /// <summary>
    /// ERP 资源
    /// </summary>
    [Area("erp")]
    [Route("api/mo/thirdparty/erp/")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class ErpController : AbpController, IErpAppService, IErpExpennseRemburementAppService
    {
        private readonly IErpAppService _erpAppService;
        private readonly IErpExpennseRemburementAppService _erpExpennseRemburementAppService;

        public ErpController(IErpAppService erpAppService, IErpExpennseRemburementAppService erpExpennseRemburementAppService)
        {
            _erpAppService = erpAppService;
            _erpExpennseRemburementAppService = erpExpennseRemburementAppService;
        }

        /// <summary>
        /// EAM-检查部门代码是否有对应的字库信息 【第三方接口：/erp/eam/get_department_exists_flag】
        /// </summary>
        /// <param name="orgCode">组织编码</param>
        /// <param name="departmentCode">部门代码</param>
        /// <returns></returns>
        [HttpGet("get-department-exists-flag")]
        public async Task<Result<List<ErpDepartmentFlagDto>>> DepartmentExists(string orgCode, string departmentCode)
        {
            return await _erpAppService.DepartmentExists(orgCode, departmentCode);
        }

        /// <summary>
        /// 通过部门代码查询部门名称 【第三方接口：/erp/assets/mtl_department_get】
        /// </summary>
        /// <param name="deptCode">部门代码</param>
        /// <returns></returns>
        [HttpGet("get-department-by-deptCode")]
        public async Task<Result<ErpDepartmentDto>> GetDepartmentByCode(string deptCode)
        {
            return await _erpAppService.GetDepartmentByCode(deptCode);
        }

        /// <summary>
        /// 根据物料代码和组织编码获取物料信息  【第三方接口：/erp/eam/get_item_list】
        /// </summary>
        /// <param name="materialCode">物料代码</param>
        /// <param name="orgCode">组织代码</param>
        /// <returns></returns>
        [HttpGet("get-itemList")]
        public async Task<Result<List<ErpMaterialDto>>> GetItemList(string materialCode, string orgCode)
        {
            return await _erpAppService.GetItemList(materialCode, orgCode);
        }

        /// <summary>
        /// PLM获取ERP样品库同步处理结果信息 【第三方接口：/oppo/plm/erp/erp_materiel_sample_list】
        /// </summary>
        /// <param name="batchId">批次ID</param>
        /// <returns>返回物资样品编号集合</returns>
        [HttpGet("get-locatorcodelist-by-batchId")]
        public async Task<Result<List<ErpLocatorDto>>> GetLocatorCodeList(string batchId)
        {
            return await _erpAppService.GetLocatorCodeList(batchId);
        }

        /// <summary>
        /// EAM-查询有库存现有量的货位 【第三方接口：/erp/eam/get_onhand_exists_locator_list】
        /// </summary>
        /// <param name="orgCode">组织编码</param>
        /// <param name="subpool">转出部门编码</param>
        /// <param name="itemCode">物料代码</param>
        /// <returns>返回物资样品编号集合</returns>
        [HttpGet("get-onhand-exists-locator-list")]
        public async Task<Result<ErpLocatorListInfoDto>> GetOnhandExistsLocatorList(string orgCode, string subpool, string itemCode)
        {
            return await _erpAppService.GetOnhandExistsLocatorList(orgCode, subpool, itemCode);
        }

        /// <summary>
        /// 根据物料编码、组织编码、部门编码，查询物料现有量 【第三方接口：/erp/eam/get_item_onhand_qty_list】
        /// </summary>
        /// <param name="itemCode">物料编码</param>
        /// <param name="orgCode">组织编码</param>
        /// <param name="locatorCode">部门编码 </param>
        /// <param name="subinvCode">部门编码</param>
        /// <returns></returns>
        [HttpGet("get-onhand-qty-list")]
        public async Task<Result<List<ErpOnhandQtyDto>>> GetItemOnhandQtyList(string itemCode, string orgCode, string locatorCode, string subinvCode)
        {
            return await _erpAppService.GetItemOnhandQtyList(itemCode, orgCode, locatorCode, subinvCode);
        }

        /// <summary>
        /// 设备调拨_设备台账信息 【第三方接口：/erp/eam/get_asset_instance_info_list】
        /// </summary>
        /// <param name="assetNum">固定资产编号</param>
        /// <param name="language">语言</param>
        /// <param name="orgCode">组织代码</param>
        /// <returns></returns>
        [HttpGet("get-asset-instance-info-list")]
        public async Task<Result<List<ErpAssetInstanceDto>>> GetAssetInstanceInfoList(string assetNum, string language, string orgCode)
        {
            return await _erpAppService.GetAssetInstanceInfoList(assetNum, language, orgCode);
        }

        /// <summary>
        /// EAM-设备调拨_部门账户信息 【第三方接口：/erp/eam/get_asset_instance_info_list】
        /// </summary>
        /// <param name="deptIn">转入部门</param>
        /// <param name="language">语言</param>
        /// <param name="orgCode">组织代码</param>
        /// <returns></returns>
        [HttpGet("get-dept-fa-info-list")]
        public async Task<Result<List<ErpDepFaDto>>> GetDeptFaInfoList(string deptIn, string language, string orgCode)
        {
            return await _erpAppService.GetDeptFaInfoList(deptIn, language, orgCode);
        }

        /// <summary>
        /// EAM-设备调拨_设备台账信息 【第三方接口：/erp/eam/get_instance_info_list】
        /// </summary>
        /// <param name="instanceCode">设备编码</param>
        /// <param name="language">语言</param>
        /// <param name="orgCode">组织代码</param>
        /// <returns></returns>
        [HttpGet("get-instance-info-list")]
        public async Task<Result<List<ErpInstanceInfoDto>>> GetInstanceInfoList(string instanceCode, string language, string orgCode)
        {
            return await _erpAppService.GetInstanceInfoList(instanceCode, language, orgCode);
        }

        /// <summary>
        /// 设备调拨_调拨信息 【第三方接口：/erp/eam/eqpt_instance_transfer】
        /// </summary>
        /// <param name="input">设备调拨实体信息</param>
        /// <returns></returns>
        [HttpPost("eqpt-instance-transfer")]
        public async Task<Result> AddInstanceTransfer(ErpEqptInstanceInput input)
        {
            return await _erpAppService.AddInstanceTransfer(input);
        }

        /// <summary>
        /// 根据货币获取汇率信息 【第三方接口：/erp/basics/get_conversion】
        /// </summary>
        /// <param name="currency">货币</param>
        /// <returns>返回货币汇率信息</returns>
        [HttpGet("get-conversions")]
        public async Task<Result<List<ErpConversionDto>>> GetConversion(string currency)
        {
            return await _erpAppService.GetConversion(currency);
        }
        /// <summary>
        /// 获取收款公司清单 【第三方接口：/erp/assets/vender_code_ou】
        /// </summary>
        /// <param name="vendor">供应商代码</param>
        /// <param name="pou">签约主体代码</param>
        /// <returns>返回收款公司清单信息</returns>
        [HttpGet("get-vendors")]
        public async Task<Result<List<ErpVendorDto>>> GetVendor(string vendor, string pou)
        {
            return await _erpAppService.GetVendor(vendor, pou);
        }

        /// <summary>
        /// 获取付款款公司清单 【第三方接口：/erp/cbm/cbm_all_org_get】
        /// </summary>
        /// <param name="orgCode">组织编码</param>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>返回收款公司清单信息</returns>
        [HttpGet("get-pays")]
        public async Task<Result<List<ErpPaymentDto>>> GetVendorTwo(string orgCode, int pageIndex, int pageSize)
        {
            return await _erpAppService.GetVendorTwo(orgCode, pageIndex, pageSize);
        }

        /// <summary>
        /// 付款通知单传ERP 【第三方接口：/erp/finance/ap_invoices_push】
        /// </summary>
        /// <param name="invoices">付款通知单传ERP对应参数json</param>
        /// <returns></returns>
        [HttpPost("ap-invoices-push")]
        public async Task<Result> InvoicesPush(ErpInvoicesPushInput invoices)
        {
            return await _erpAppService.InvoicesPush(invoices);
        }
        /// <summary>
        /// 更新科目信息【第三方接口：/erp/assets/pubget_push】
        /// </summary>
        /// <param name="dtos"> 数据集合</param>
        /// <returns></returns>
        [HttpPost("toolingfixture-push")]
        public async Task<Result> ToolingFixtureApplicationPush(List<ErpToolingFixtureApplicationApprovalInfoDto> dtos)
        {
            return await _erpAppService.ToolingFixtureApplicationPush(dtos);
        }

        /// <summary>
        /// 查询物料信息 
        /// </summary>
        /// <param name="MaterielInfo"> 查询参数</param>
        /// <returns></returns>
        [HttpPost("materiel-search")]
        public async Task<Result<MaterialInfos>> SearchMaterielInfos(SearchMaterielInfo MaterielInfo)
        {
            return await _erpAppService.SearchMaterielInfos(MaterielInfo);
        }

        /// <summary>
        /// 查询核销预付款 【第三方接口：/erp/expenses/get_prepay_amount_list】
        /// </summary>
        /// <param name="invoiceNum">报销单号</param>
        /// <param name="respType">返回格式，支持json/xml两种格式，默认为json格</param>
        /// <returns></returns>
        [HttpGet("get-prepay-amount-list")]
        public async Task<Result<List<ErpPrepayAmountDto>>> GetPrepayAmountList(string invoiceNum, string respType)
        {
            return await _erpExpennseRemburementAppService.GetPrepayAmountList(invoiceNum, respType);
        }

        /// <summary>
        /// 据报销人工号查询银行账号信息 【第三方接口：/erp/expenses/bank_account_get】
        /// </summary>
        /// <param name="emplId">销人工号</param>
        /// <returns></returns>
        [HttpGet("get-bank-account-by-empid")]
        public async Task<Result<ErpBankAccountDto>> GetBankAccountByEmpId(string emplId)
        {
            return await _erpExpennseRemburementAppService.GetBankAccountByEmpId(emplId);
        }

        /// <summary>
        /// 个人借款信息查询 【第三方接口：/erp/expenses/prepay_list1】
        /// </summary>
        /// <param name="emplId">员工工号</param>
        /// <param name="ouId">纳税单位ID</param>
        /// <param name="respType">返回格式，支持json/xml两种格式，默认为json格式</param>
        /// <returns></returns>
        [HttpGet("get-prepay-list")]
        public async Task<Result<List<ErpPrepayDto>>> GetPrepayList(string emplId, string ouId, string respType)
        {
            return await _erpExpennseRemburementAppService.GetPrepayList(emplId, ouId, respType);
        }

        /// <summary>
        /// 费用报销数据推送 【第三方接口：/erp/expenses/expenses_push】
        /// </summary>
        /// <param name="input">费用报销数据推送输入参数</param>
        /// <returns></returns>
        [HttpPost("expenses-push")]
        public async Task<Result> ExpensesPush(ErpExpensesPushInput input)
        {
            return await _erpExpennseRemburementAppService.ExpensesPush(input);
        }

        /// <summary>
        /// MO费用报销 【第三方接口：/erp/expenses/import_expenses】
        /// </summary>
        /// <param name="input">MO费用报销输入参数</param>
        /// <returns></returns>
        [HttpPost("import_expenses")]
        public async Task<Result> ImportExpenses(ErpImportExpensesPushInput input)
        {
            return await _erpExpennseRemburementAppService.ImportExpenses(input);
        }

        /// <summary>
        /// MO费用报销驳回处理 【第三方接口：/erp/expenses/mo_process_reject】
        /// </summary>
        /// <param name="input">MO费用报销驳回处理输入参数</param>
        /// <returns></returns>
        [HttpPost("process-reject")]
        public async Task<Result> ProcessReject(ErpProcessRejectInput input)
        {
            return await _erpExpennseRemburementAppService.ProcessReject(input);
        }

       
        /// <summary>
        /// 通过资产代码获取资产描述 【第三方接口：/erp/assets/assets_info_get】
        /// </summary>
        /// <param name="assetsNumber"> 资产代码</param>
        /// <returns></returns>
        [HttpGet("query-assets-by-code")]
        public async Task<Result<AssetInfo>> GetAssetsInfoByAssetsCode([Required]string  assetsNumber)
        {
            return await _erpAppService.GetAssetsInfoByAssetsCode(assetsNumber);
        }

        /// <summary>
        /// 报销单号获取接口 【第三方接口：/erp/expenses/expenses_seq_get】
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-expenses_seq")]
        public async Task<Result<ErpExpensesSeqDto>> GetExpensesSeq()
        {
            return await _erpExpennseRemburementAppService.GetExpensesSeq();
        }



    }
}
