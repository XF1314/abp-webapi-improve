using Com.OPPO.Mo.Thirdparty.Erp.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpBasics;
using Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Responses;
using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using Com.OPPO.Mo.Thirdparty.Erp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Erp
{

    //[Authorize]
    public class ErpBasicsAppService : ThirdpartyAppServiceBase, IErpBasicsAppService
    {
        /// <summary>
        /// 校验原材料和替代料是否在一个组 【第三方接口：/erp/basics/count_of_plm_item_subs_group】
        /// </summary>
        /// <param name="factoryCode">厂别,必填</param>
        /// <param name="primaryItemCode">主料,必填</param>
        /// <param name="subsItemCode">替代料,必填</param>
        /// <param name="responseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        public async Task<Result> CheckMtlOldAndNew(string factoryCode, string primaryItemCode, string subsItemCode, string responseType)
        { 
            var service = ServiceProvider.GetRequiredService<IErpBasicsEsbService>();

            var response = await service.CheckMtlOldAndNew(new CheckItemIsGroupRequest
            {
                FactoryCode = factoryCode,
                PrimaryItemCode = primaryItemCode,
                SubsItemCode = subsItemCode,
                ResponseType = responseType
            });

            if (response.response.count == "1")
                return Result.Ok(response.response.msg);
            else
            {
                var message = $"【{response.response.code}】{response.response.msg}-{response.response.count}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }

        /// <summary>
        /// 根据整机物料编码获取虚拟组件信息 【第三方接口：/erp/basics/get_ph_item_num】
        /// </summary>
        /// <param name="ItemCode"> 整机物料编码</param>
        /// <returns></returns>
        public async Task<Result<List<VirtualComponent>>> GetERPVirtualComponentCode(string ItemCode)
        {

            var apiService = ServiceProvider.GetRequiredService<IErpBasicsEsbService>();
            ErpVirtualComponentQueryRequest queryRequest = new ErpVirtualComponentQueryRequest { ItemCode = ItemCode };
            var response = await apiService.GetERPVirtualComponentCode(queryRequest);
            if (response.Response.results != null)
            {
                var datas = ObjectMapper.Map<List<VirtualComponentDto>, List<VirtualComponent>>(response.Response.results);
                return Result.FromData(datas);
            }
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogError(message);
                return Result.FromError<List<VirtualComponent>>(message);
            }

        }


        /// <summary>
        /// 查询ERP组织信息列表 【第三方接口：/erp/basics/org_list】
        /// </summary>
        /// <param name="StartDate">起始时间,可不填</param>
        /// <param name="EndDate">截止时间,可不填</param>
        /// <param name="ResponseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        public async Task<Result<ErpOrgInfoBody>> GetOrgList(string StartDate, string EndDate, string ResponseType)
        {

            var apiService = ServiceProvider.GetRequiredService<IErpBasicsEsbService>();
            ErpOrgListQueryRequest queryRequest = new ErpOrgListQueryRequest { StartDate = StartDate, EndDate = EndDate, ResponseType = ResponseType };
            var response = await apiService.GetOrgList(queryRequest);
            if (response.Response.Code == null)
            {
                var datas = ObjectMapper.Map<List<OrgInfoDto>, List<OrgInfo>>(response.Response.orgs);
                ErpOrgInfoBody orgInfoBody = new ErpOrgInfoBody { RowCount = response.Response.total_results, Datas = datas };
                return Result.FromData(orgInfoBody);
            }
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogError(message);
                return Result.FromError<ErpOrgInfoBody>(message);
            }

        }


        /// <summary>
        /// 获取客户/代理地址及GSTIN 【第三方接口：/erp/basics/ebs_get_customer_list1】
        /// </summary>
        /// <param name="ouName">OU名称,必填</param>
        /// <param name="accountNumber">客户/代理代码,可不填</param>
        /// <param name="Language">default: ZHS,可不填</param>
        /// <returns></returns>
        public async Task<Result<List<CustomerInfo>>> GetCustomerInfo(string ouName, string accountNumber, string Language)
        {

            var apiService = ServiceProvider.GetRequiredService<IErpBasicsEsbService>();
            ErpCustomerInfoQueryRequest queryRequest = new ErpCustomerInfoQueryRequest { AccountName = ouName, AccountNumber = accountNumber, Language = Language };
            var response = await apiService.GetCustomerInfo(queryRequest);
            if (response.Response.Code == null) {
                var datas = ObjectMapper.Map<List<CustomerInfoDto>, List<CustomerInfo>>(response.Response.results);
                return Result.FromData(datas);
            }
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogError(message);
                return Result.FromError<List<CustomerInfo>>(message);
            }

        }

        /// <summary>
        /// 根据组织代码取ERP库位和储位 【第三方接口：/erp/basics/inventory_and_location_list】
        /// </summary>
        /// <param name="OrganizationCode">组织代码,必填</param>
        /// <param name="Language">default: ZHS,可不填</param>
        /// <returns></returns>
        public async Task<Result<List<ErpInventoryInfo>>> GetInventoryAndLocationList(string OrganizationCode, string Language)
        {
            var apiService = ServiceProvider.GetRequiredService<IErpBasicsEsbService>();
            ErpLocationInfoQueryRequest queryRequest = new ErpLocationInfoQueryRequest { OrganizationCode = OrganizationCode, Language = Language };
            var response = await apiService.GetInventoryAndLocationList(queryRequest);
            var datas = ObjectMapper.Map<List<ErpInventoryInfoDto>, List<ErpInventoryInfo>>(response);
            return Result.FromData(datas);

        }

        /// <summary>
        /// 根据物料代码、组织代码(默认主组织)查询ERP物料代码信息 【第三方接口：/erp/basics/mtl_code_get】
        /// </summary>
        /// <param name="ItemCode">物料代码,必填</param>
        /// <param name="OrganizationCode">组织代码default: IM,可不填</param>
        /// <param name="ResponseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        public async Task<Result<Material>> GetItemInfo(string ItemCode, string OrganizationCode, string ResponseType)
        {

            var apiService = ServiceProvider.GetRequiredService<IErpBasicsEsbService>();
            ErpItemInfoQueryRequest queryRequest = new ErpItemInfoQueryRequest { ItemCode = ItemCode, OrganizationCode = OrganizationCode, ResponseType = ResponseType };
            var response = await apiService.GetItemInfo(queryRequest);
            if (response.Response.Code == null)
            {
                var datas = ObjectMapper.Map<MaterialDto, Material>(response.Response.materialcode);
                return Result.FromData(datas);
            }
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogError(message);
                return Result.FromError<Material>(message);
            }

        }

        /// <summary>
        /// 根据物料代码、组织代码(默认主组织)查询ERP物料代码信息(新)【第三方接口：/erp/basics/mtl_code_get_new】
        /// </summary>
        /// <param name="ItemCode">物料代码,必填</param>
        /// <param name="OrganizationCode">组织代码default: IM,可不填</param>
        /// <param name="ResponseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        public async Task<Result<Material>> GetItemInfoNew(string ItemCode, string OrganizationCode, string ResponseType)
        {

            var apiService = ServiceProvider.GetRequiredService<IErpBasicsEsbService>();
            ErpItemInfoQueryRequest queryRequest = new ErpItemInfoQueryRequest { ItemCode = ItemCode, OrganizationCode = OrganizationCode, ResponseType = ResponseType };
            var response = await apiService.GetItemInfoNew(queryRequest);
            if (response.Response.Code == null)
            {
                var datas = ObjectMapper.Map<MaterialDto, Material>(response.Response.materialcode);
                return Result.FromData(datas);
            }
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogError(message);
                return Result.FromError<Material>(message);
            }

        }
    }

}
