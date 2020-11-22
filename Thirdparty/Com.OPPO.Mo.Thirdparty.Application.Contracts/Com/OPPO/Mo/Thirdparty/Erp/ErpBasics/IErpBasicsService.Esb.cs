using Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics
{

    /// <summary>
    /// Erp/Basics
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IErpBasicsEsbService : IHttpApi
    {

        /// <summary>
        ///  校验原材料和替代料是否在一个组 【第三方接口：/erp/basics/count_of_plm_item_subs_group】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/erp/basics/count_of_plm_item_subs_group")]
        Task<ErpCheckIsGroupResponse> CheckMtlOldAndNew([FormContent]CheckItemIsGroupRequest query);


        /// <summary>
        /// 根据整机物料编码获取虚拟组件信息 
        /// </summary>
        /// <param name="query"> </param>
        /// <returns></returns>
        [HttpGet("/erp/basics/get_ph_item_num")]
        Task<ErpVirtualComponentResponse> GetERPVirtualComponentCode([PathQuery] ErpVirtualComponentQueryRequest query);

        /// <summary>
        /// 查询ERP组织信息列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/erp/basics/org_list")]
        Task<ErpOrgInfoResponse> GetOrgList([PathQuery] ErpOrgListQueryRequest query);

        /// <summary>
        /// 获取客户/代理地址及GSTIN
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/erp/basics/ebs_get_customer_list1")]
        Task<ErpCustomerInfoResponse> GetCustomerInfo([PathQuery] ErpCustomerInfoQueryRequest query);

        /// <summary>
        /// 根据组织代码取ERP库位和储位
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/erp/basics/inventory_and_location_list")]
        Task<List<ErpInventoryInfoDto>> GetInventoryAndLocationList([PathQuery] ErpLocationInfoQueryRequest query);

        /// <summary>
        /// 根据物料代码、组织代码(默认主组织)查询ERP物料代码信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/erp/basics/mtl_code_get")]
        Task<ErpItemInfoResponse> GetItemInfo([PathQuery] ErpItemInfoQueryRequest query);


        /// <summary>
        /// 根据物料代码、组织代码(默认主组织)查询ERP物料代码信息（新）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/erp/basics/mtl_code_get_new")]
        Task<ErpItemInfoResponse> GetItemInfoNew([PathQuery] ErpItemInfoQueryRequest query);
    }
}
