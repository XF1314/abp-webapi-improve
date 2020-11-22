using Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics
{

    /// <summary>
    /// Erp/Basics
    /// </summary>
    public interface IErpBasicsAppService : IApplicationService
    {

        /// <summary>
        /// 校验原材料和替代料是否在一个组 【第三方接口：/erp/basics/count_of_plm_item_subs_group】
        /// </summary>
        /// <param name="factoryCode">厂别,必填</param>
        /// <param name="primaryItemCode">主料,必填</param>
        /// <param name="subsItemCode">替代料,必填</param>
        /// <param name="responseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        Task<Result> CheckMtlOldAndNew(string factoryCode, string primaryItemCode, string subsItemCode, string responseType);


        /// <summary>
        /// 根据整机物料编码获取虚拟组件信息 
        /// </summary>
        /// <param name="ItemCode"> 整机物料编码</param>
        /// <returns></returns>
        Task<Result<List<VirtualComponent>>> GetERPVirtualComponentCode(string ItemCode);


        /// <summary>
        /// 查询ERP组织信息列表 【第三方接口：/erp/basics/org_list】
        /// </summary>
        /// <param name="StartDate">起始时间,可不填</param>
        /// <param name="EndDate">截止时间,可不填</param>
        /// <param name="ResponseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        Task<Result<ErpOrgInfoBody>> GetOrgList(string StartDate, string EndDate, string ResponseType);


        /// <summary>
        /// 获取客户/代理地址及GSTIN 【第三方接口：/erp/basics/ebs_get_customer_list1】
        /// </summary>
        /// <param name="AccountName">客户名称,必填</param>
        /// <param name="AccountNumber">客户编码,可不填</param>
        /// <param name="Language">default: ZHS,可不填</param>
        /// <returns></returns>
        Task<Result<List<CustomerInfo>>> GetCustomerInfo(string AccountName, string AccountNumber, string Language);


        /// <summary>
        /// 根据组织代码取ERP库位和储位 【第三方接口：/erp/basics/inventory_and_location_list】
        /// </summary>
        /// <param name="OrganizationCode">客户名称,必填,JM</param>
        /// <param name="Language">default: ZHS,可不填</param>
        /// <returns></returns>
        Task<Result<List<ErpInventoryInfo>>> GetInventoryAndLocationList(string OrganizationCode, string Language);


        /// <summary>
        /// 根据物料代码、组织代码(默认主组织)查询ERP物料代码信息 【第三方接口：/erp/basics/mtl_code_get】
        /// </summary>
        /// <param name="ItemCode">物料代码,必填</param>
        /// <param name="OrganizationCode">组织代码default: IM,可不填</param>
        /// <param name="ResponseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        Task<Result<Material>> GetItemInfo(string ItemCode, string OrganizationCode, string ResponseType);

        /// <summary>
        /// 根据物料代码、组织代码(默认主组织)查询ERP物料代码信息 【第三方接口：/erp/basics/mtl_code_get_new】
        /// </summary>
        /// <param name="ItemCode">物料代码,必填</param>
        /// <param name="OrganizationCode">组织代码default: IM,可不填</param>
        /// <param name="ResponseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        Task<Result<Material>> GetItemInfoNew(string ItemCode, string OrganizationCode, string ResponseType);
    }
}
