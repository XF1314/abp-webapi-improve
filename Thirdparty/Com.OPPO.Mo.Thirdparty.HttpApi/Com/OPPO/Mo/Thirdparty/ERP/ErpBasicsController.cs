using Com.OPPO.Mo.Thirdparty.Erp.ErpBasics;
using Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Responses;
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
    /// ERP/basics 资源
    /// </summary>
    [Area("erp")]
    [Route("api/mo/thirdparty/erp/basics")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class ErpBasicsController : AbpController, IErpBasicsAppService
    {
        private readonly IErpBasicsAppService _erpAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="erpAppService"></param>
        public ErpBasicsController(IErpBasicsAppService erpAppService)
        {
            _erpAppService = erpAppService;
        }


        /// <summary>
        /// 校验原材料和替代料是否在一个组 【第三方接口：/erp/basics/count_of_plm_item_subs_group】
        /// </summary>
        /// <param name="factoryCode">厂别,必填</param>
        /// <param name="primaryItemCode">主料,必填</param>
        /// <param name="subsItemCode">替代料,必填</param>
        /// <param name="responseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        [HttpPost("check-oldandnew-isgroup")]
        public async Task<Result> CheckMtlOldAndNew([Required]string factoryCode, [Required]string primaryItemCode, [Required]string subsItemCode,string responseType)
        {
            return await _erpAppService.CheckMtlOldAndNew(factoryCode, primaryItemCode, subsItemCode, responseType);
        }

        /// <summary>
        /// 根据整机物料编码获取虚拟组件信息 【第三方接口：/erp/basics/get_ph_item_num】
        /// </summary>
        /// <param name="itemCode"> 整机物料编码</param>
        /// <returns></returns>
        [HttpGet("query-virtualcomponent-info")]
        public async Task<Result<List<VirtualComponent>>> GetERPVirtualComponentCode([Required]string itemCode)
        {
            return await _erpAppService.GetERPVirtualComponentCode(itemCode);
        }


        /// <summary>
        /// 查询ERP组织信息列表 【第三方接口：/erp/basics/org_list】
        /// </summary>
        /// <param name="startDate">起始时间,可不填</param>
        /// <param name="endDate">截止时间,可不填</param>
        /// <param name="responseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        [HttpGet("query-organization-info")]
        public async Task<Result<ErpOrgInfoBody>> GetOrgList(string startDate, string endDate, string responseType)
        {
            return await _erpAppService.GetOrgList(startDate, endDate, responseType);
        }

        /// <summary>
        /// 获取客户/代理地址及GSTIN 【第三方接口：/erp/basics/ebs_get_customer_list1】
        /// </summary>
        /// <param name="ouName">OU名称,必填</param>
        /// <param name="accountNumber">客户/代理代码,可不填</param>
        /// <param name="language">default: ZHS,可不填</param>
        /// <returns></returns>
        [HttpGet("query-customer-info")]
        public async Task<Result<List<CustomerInfo>>> GetCustomerInfo([Required]string ouName, string accountNumber, string language)
        {
            return await _erpAppService.GetCustomerInfo(ouName, accountNumber, language);
        }

        /// <summary>
        /// 根据组织代码取ERP库位和储位 【第三方接口：/erp/basics/inventory_and_location_list】
        /// </summary>
        /// <param name="orgCode">组织代码,必填</param>
        /// <param name="language">default: ZHS,可不填</param>
        /// <returns></returns>
        [HttpGet("query-location-by-orgcode")]
        public async Task<Result<List<ErpInventoryInfo>>> GetInventoryAndLocationList([Required]string orgCode, string language)
        {
            return await _erpAppService.GetInventoryAndLocationList(orgCode, language);
        }


        /// <summary>
        /// 根据物料代码、组织代码(默认主组织)查询ERP物料代码信息 【第三方接口：/erp/basics/mtl_code_get】
        /// </summary>
        /// <param name="itemCode">物料代码,必填</param>
        /// <param name="orgCode">组织代码default: IM,可不填</param>
        /// <param name="responseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        [HttpGet("query-iteminfo-by-code")]
        public async Task<Result<Material>> GetItemInfo([Required]string itemCode, string orgCode, string responseType)
        {
            return await _erpAppService.GetItemInfo(itemCode, orgCode, responseType);
        }

        /// <summary>
        /// 根据物料代码、组织代码(默认主组织)查询ERP物料代码信息(新) 【第三方接口：/erp/basics/mtl_code_get_new】
        /// </summary>
        /// <param name="itemCode">物料代码,必填</param>
        /// <param name="orgCode">组织代码default: IM,可不填</param>
        /// <param name="responseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        [HttpGet("query-iteminfo-by-code-new")]
        public async Task<Result<Material>> GetItemInfoNew([Required]string itemCode, string orgCode, string responseType)
        {
            return await _erpAppService.GetItemInfoNew(itemCode, orgCode, responseType);
        }
    }
}
