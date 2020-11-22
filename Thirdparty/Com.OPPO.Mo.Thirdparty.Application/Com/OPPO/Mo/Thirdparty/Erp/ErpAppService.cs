using Com.OPPO.Mo.Thirdparty.Erp.Dtos;
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
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Erp
{
    [Authorize]
    public class ErpAppService : ThirdpartyAppServiceBase, IErpAppService
    {
        /// <summary>
        /// EAM-检查部门代码是否有对应的字库信息
        /// <param name="orgCode">组织编码</param>
        /// <param name="departmentCode">部门编码</param>
        /// </summary>
        /// <returns>Y:表示存在，N：表示不存在</returns>
        public async Task<Result<List<ErpDepartmentFlagDto>>> DepartmentExists(string orgCode, string departmentCode)
        {
            if (string.IsNullOrWhiteSpace(orgCode))
                return Result.FromError<List<ErpDepartmentFlagDto>>($"缺失参数{nameof(orgCode)}。");

            if (string.IsNullOrWhiteSpace(departmentCode))
                return Result.FromError<List<ErpDepartmentFlagDto>>($"缺失参数{nameof(departmentCode)}。");


            var service = ServiceProvider.GetRequiredService<IErpServiceInfoEsbService>();

            var response = await service.DepartmentExists(new ErpDepartmentRequest
            {
                OrgCode = orgCode,
                DepartmentCode = departmentCode
            });

            var res = ObjectMapper.Map<List<ErpDepartmentFlagInfo>, List<ErpDepartmentFlagDto>>(response.Body.Data);

            return Result.FromData(res);
        }

        /// <summary>
        /// 通过部门代码查询部门名称
        /// <param name="deptCode">部门代码</param>
        /// </summary>
        /// <returns>返回部门信息</returns>
        public async Task<Result<ErpDepartmentDto>> GetDepartmentByCode(string deptCode)
        {
            if (string.IsNullOrWhiteSpace(deptCode))
                return Result.FromError<ErpDepartmentDto>($"缺失参数{nameof(deptCode)}。");

            var service = ServiceProvider.GetRequiredService<IErpServiceInfoEsbService>();

            var response = await service.GetDepartmentByCode(new ErpDepartmentQueryRequest
            {
                DepartmentCode = deptCode
            });

            var info = ObjectMapper.Map<ErpDepartmentInfo, ErpDepartmentDto>(response.Data.Data);

            return Result.FromData(info);
        }

        /// <summary>
        /// PLM获取ERP样品库同步处理结果信息
        /// </summary>
        /// <param name="batchId">批次</param>
        /// <returns>返回物资样品编号集合</returns>
        public async Task<Result<List<ErpLocatorDto>>> GetLocatorCodeList(string batchId)
        {
            if (string.IsNullOrWhiteSpace(batchId))
                return Result.FromError<List<ErpLocatorDto>>($"缺失参数{nameof(batchId)}。");

            var erpServiceInfoWebApiService = ServiceProvider.GetRequiredService<IErpServiceInfoEsbService>();

            var response = await erpServiceInfoWebApiService.GetMaterielSampleList(new ErpSampleBatchRequest { BatchId = batchId });

            var res = ObjectMapper.Map<List<ErpLocatorInfo>, List<ErpLocatorDto>>(response);


            return Result.FromData(res);
        }

        /// <summary>
        /// 根据物料代码和组织编码获取物料信息
        /// </summary>
        /// <param name="materialCode">物料代码</param>
        /// <param name="orgCode">组织代码</param>
        /// <returns></returns>
        public async Task<Result<List<ErpMaterialDto>>> GetItemList(string materialCode, string orgCode)
        {
            if (string.IsNullOrWhiteSpace(materialCode))
                return Result.FromError<List<ErpMaterialDto>>($"缺失参数{nameof(materialCode)}。");

            if (string.IsNullOrWhiteSpace(orgCode))
                return Result.FromError<List<ErpMaterialDto>>($"缺失参数{nameof(orgCode)}。");


            var erpServiceInfoWebApiService = ServiceProvider.GetRequiredService<IErpServiceInfoEsbService>();

            var response = await erpServiceInfoWebApiService.GetItemList(new ErpMaterialQueryRequest
            {
                OrgCode = orgCode,
                MaterialCode = materialCode
            });

            var res = ObjectMapper.Map<List<ErpMaterialInfo>, List<ErpMaterialDto>>(response.Body.Data);

            return Result.FromData(res);
        }


        /// <summary>
        /// 查询有库存现有量的货位
        /// </summary>
        /// <param name="orgCode">组织编码</param>
        /// <param name="subpool">转出部门编码</param>
        /// <param name="materialCode">物料代码</param>
        /// <returns>返回物资样品编号集合</returns>
        public async Task<Result<ErpLocatorListInfoDto>> GetOnhandExistsLocatorList(string orgCode, string subpool, string materialCode)
        {
            if (string.IsNullOrWhiteSpace(materialCode))
                return Result.FromError<ErpLocatorListInfoDto>($"缺失参数{nameof(materialCode)}。");

            if (string.IsNullOrWhiteSpace(orgCode))
                return Result.FromError<ErpLocatorListInfoDto>($"缺失参数{nameof(orgCode)}。");


            var erpServiceInfoWebApiService = ServiceProvider.GetRequiredService<IErpServiceInfoEsbService>();

            var response = await erpServiceInfoWebApiService.GetOnhandLocatorList(new ErpOnhandLocatorQueryRequest
            {
                OrgCode = orgCode,
                SubinvCode = subpool,
                Code = materialCode
            });

            return Result.FromData(response.Body);
        }

        /// <summary>
        /// 根据物料编码、组织编码、部门编码，查询物料现有量
        /// </summary>
        /// <param name="itemCode">物料编码</param>
        /// <param name="orgCode">组织编码</param>
        /// <param name="locatorCode">部门编码 </param>
        /// <param name="subinvCode">部门编码</param>
        /// <returns></returns>
        public async Task<Result<List<ErpOnhandQtyDto>>> GetItemOnhandQtyList(string itemCode, string orgCode, string locatorCode, string subinvCode)
        {
            if (string.IsNullOrWhiteSpace(itemCode))
                return Result.FromError<List<ErpOnhandQtyDto>>($"缺失参数{nameof(itemCode)}。");

            if (string.IsNullOrWhiteSpace(orgCode))
                return Result.FromError<List<ErpOnhandQtyDto>>($"缺失参数{nameof(orgCode)}。");

            var erpServiceInfoWebApiService = ServiceProvider.GetRequiredService<IErpServiceInfoEsbService>();

            var response = await erpServiceInfoWebApiService.GetOnhandQtyList(new ErpOnhandQtyQueryRequest
            {
                ItemCode = itemCode,
                OrgCode = orgCode,
                LocatorCode = locatorCode,
                SubinvCode = subinvCode
            });

            var res = ObjectMapper.Map<List<ErpOnhandQtyInfo>, List<ErpOnhandQtyDto>>(response.Body.Data);

            return Result.FromData(res);
        }

        /// <summary>
        /// 设备调拨_设备台账信息
        /// </summary>
        /// <param name="instanceCode">设备编码</param>
        /// <param name="language">语言</param>
        /// <param name="orgCode">组织代码</param>
        /// <returns></returns>
        public async Task<Result<List<ErpInstanceInfoDto>>> GetInstanceInfoList(string instanceCode, string language, string orgCode)
        {
            if (string.IsNullOrWhiteSpace(instanceCode))
                return Result.FromError<List<ErpInstanceInfoDto>>($"缺失参数{nameof(instanceCode)}。");
            if (string.IsNullOrWhiteSpace(orgCode))
                return Result.FromError<List<ErpInstanceInfoDto>>($"缺失参数{nameof(orgCode)}。");


            var erpServiceInfoWebApiService = ServiceProvider.GetRequiredService<IErpServiceInfoEsbService>();

            var response = await erpServiceInfoWebApiService.GetInstanceInfoList(new ErpInstanceRequest
            {
                InstanceCode = instanceCode,
                Language = language,
                OrgCode = orgCode
            });

            var res = ObjectMapper.Map<List<ErpInstanceInfo>, List<ErpInstanceInfoDto>>(response.Body.Data);

            return Result.FromData(res);
        }

        /// <summary>
        /// EAM-设备调拨_部门账户信息 【第三方接口：/erp/eam/get_asset_instance_info_list】
        /// </summary>
        /// <param name="deptIn">转入部门</param>
        /// <param name="language">语言</param>
        /// <param name="orgCode">组织代码</param>
        /// <returns></returns>
        public async Task<Result<List<ErpDepFaDto>>> GetDeptFaInfoList(string deptIn, string language, string orgCode)
        {
            if (string.IsNullOrWhiteSpace(deptIn))
                return Result.FromError<List<ErpDepFaDto>>($"缺失参数{nameof(deptIn)}。");
            if (string.IsNullOrWhiteSpace(orgCode))
                return Result.FromError<List<ErpDepFaDto>>($"缺失参数{nameof(orgCode)}。");

            var erpServiceInfoWebApiService = ServiceProvider.GetRequiredService<IErpServiceInfoEsbService>();

            var response = await erpServiceInfoWebApiService.GetDeptFaInfoList(new ErpDepFaInfoRequest
            {
                DeptIn = deptIn,
                Language = language,
                OrgCode = orgCode
            });

            var res = ObjectMapper.Map<List<ErpDepFaInfo>, List<ErpDepFaDto>>(response.Body.Data);

            return Result.FromData(res);

        }

        /// <summary>
        /// 固定资产和设备信息查询
        /// </summary>
        /// <param name="assetNum">固定资产编号</param>
        /// <param name="language">语言</param>
        /// <param name="orgCode">组织代码</param>
        /// <returns></returns>
        public async Task<Result<List<ErpAssetInstanceDto>>> GetAssetInstanceInfoList(string assetNum, string language, string orgCode)
        {
            if (string.IsNullOrWhiteSpace(assetNum))
                return Result.FromError<List<ErpAssetInstanceDto>>($"缺失参数{nameof(assetNum)}。");

            if (string.IsNullOrWhiteSpace(orgCode))
                return Result.FromError<List<ErpAssetInstanceDto>>($"缺失参数{nameof(orgCode)}。");

            var erpServiceInfoWebApiService = ServiceProvider.GetRequiredService<IErpServiceInfoEsbService>();

            var response = await erpServiceInfoWebApiService.GetAssetInstanceInfoList(new ErpAssetInstanceRequest
            {
                AssetNum = assetNum,
                Language = language,
                OrgCode = orgCode
            });

            var res = ObjectMapper.Map<List<ErpAssetInstanceInfo>, List<ErpAssetInstanceDto>>(response.Body.Data);
            return Result.FromData(res);
        }

        /// <summary>
        /// 添加设备调拨
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Result> AddInstanceTransfer(ErpEqptInstanceInput input)
        {
            var erpServiceInfoWebApiService = ServiceProvider.GetRequiredService<IErpServiceInfoEsbService>();

            if (input is null)
            {
                return Result.FromError($"缺失参数{nameof(input)}。");
            }

            var info = ObjectMapper.Map<ErpEqptInstanceInput, ErpEqptInstanceRequest>(input);

            var response = await erpServiceInfoWebApiService.AddInstanceTransfer(info);

            if (response.Body.Code >= 0)
                return Result.Ok();
            else
            {
                var message = $"【{response.ResultCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }

        /// <summary>
        /// 根据货币获取汇率信息
        /// </summary>
        /// <param name="currency">货币</param>
        /// <returns>返回货币汇率信息</returns>
        public async Task<Result<List<ErpConversionDto>>> GetConversion(string currency)
        {
            if (string.IsNullOrWhiteSpace(currency))
                return Result.FromError<List<ErpConversionDto>>($"缺失参数{nameof(currency)}。");

            var erpBasicsWebApiService = ServiceProvider.GetRequiredService<IErpBasicDataEsbService>();

            var response = await erpBasicsWebApiService.GetConversion(new ErpConversionRequest
            {
                ConversionDate = DateTime.Now.ToString("yyyy-MM-dd"),
                ConversionType = "Corporate",
                FromCurrency = currency,
                ToCurrency = "CNY"
            });

            var conversion = ObjectMapper.Map<List<ErpConversionInfo>, List<ErpConversionDto>>(response.Body.Data);

            return Result.FromData(conversion);

        }

        /// <summary>
        /// 获取收款公司清单
        /// </summary>
        /// <param name="vendor">供应商</param>
        /// <param name="pou">签约主体代码</param>
        /// <returns>返回收款公司清单信息</returns>
        public async Task<Result<List<ErpVendorDto>>> GetVendor(string vendor, string pou)
        {
            if (string.IsNullOrWhiteSpace(vendor))
                return Result.FromError<List<ErpVendorDto>>($"缺失参数{nameof(vendor)}。");
            if (string.IsNullOrWhiteSpace(pou))
                return Result.FromError<List<ErpVendorDto>>($"缺失参数{nameof(pou)}。");

            var erpBasicsWebApiService = ServiceProvider.GetRequiredService<IErpAssestEsbService>();

            var response = await erpBasicsWebApiService.GetConversion(new ErpVendorInfoGetRequest
            {
                VendorName = vendor,
                Pou = pou
            });

            var res = ObjectMapper.Map<List<ErpVendorInfo>, List<ErpVendorDto>>(response.Body.Data);

            return Result.FromData(res);
        }

        /// <summary>
        /// 获取付款款公司清单
        /// </summary>
        /// <param name="orgCode">组织编码</param>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>返回收款公司清单信息</returns>
        public async Task<Result<List<ErpPaymentDto>>> GetVendorTwo(string orgCode, int pageIndex, int pageSize)
        {
            var erpBasicsWebApiService = ServiceProvider.GetRequiredService<IErpAssestEsbService>();

            var response = await erpBasicsWebApiService.GetConversionTwo(new ErpPaymentRequest
            {
                OrgCode = orgCode,
                PageIndex = pageIndex,
                PageSize = pageSize
            });

            var res = ObjectMapper.Map<List<ErpPaymentInfo>, List<ErpPaymentDto>>(response.Body.Data);

            return Result.FromData(res);
        }

        /// <summary>
        /// 付款通知单传ERP
        /// </summary>
        /// <param name="input">付款通知单传ERP对应参数json</param>
        public async Task<Result> InvoicesPush(ErpInvoicesPushInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Invoices))
                return Result.FromError($"{input.Invoices}不能为空。");

            //TODO:验证Invoices是否合格的Json格式

            else
            {
                var erpCallbackWebApiService = ServiceProvider.GetRequiredService<IErpCallbackEsbService>();

                var response = await erpCallbackWebApiService.ApInvoicesPush(new ErpInvoicesPushRequest
                {
                    Invoices = input.Invoices
                });

                if (response.Body.Code >= 0)
                    return Result.Ok();
                else
                {
                    var message = $"【{response.ResultCode}】{response.Body.Message}";
                    Logger.LogWarning(message);
                    return Result.FromError(message);
                }

            }
        }

        /// <summary>
        /// 更新科目信息【第三方接口：/erp/assets/pubget_push】
        /// </summary>
        /// <param name="dtos"> 数据集合</param>
        /// <returns></returns>
        public async Task<Result> ToolingFixtureApplicationPush(List<ErpToolingFixtureApplicationApprovalInfoDto> dtos)
        {
            var erpCallbackWebApiService = ServiceProvider.GetRequiredService<IErpAssestEsbService>();
            var datas = ObjectMapper.Map<List<ErpToolingFixtureApplicationApprovalInfoDto>, List<ErpToolingFixtureApplicationApprovalInfo>>(dtos);
            var response = await erpCallbackWebApiService.ToolingFixtureApplicationPush(new PoLinesRequest
            {
                PoLines = JsonConvert.SerializeObject(datas)
            });

            if (response.Body.BussinessCode == "0")
                return Result.Ok(response.Body.Message);
            else
            {
                var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }

        }

        /// <summary>
        /// 查询物料信息
        /// </summary>
        /// <param name="input">付款通知单传ERP对应参数json</param>
        public async Task<Result<MaterialInfos>> SearchMaterielInfos(SearchMaterielInfo MaterielInfo)
        {
            //if (string.IsNullOrWhiteSpace(MaterielInfo.MaterialDesc))
            //    return Result.FromError<MaterialInfos>($"{MaterielInfo.MaterialDesc}不能为空。");

            if (MaterielInfo.PageSize == 0)
                return Result.FromError<MaterialInfos>($"{MaterielInfo.PageSize}不能为0。");

            else
            {
                var erpCallbackWebApiService = ServiceProvider.GetRequiredService<IErpBasicDataEsbService>();

                var response = await erpCallbackWebApiService.SearchMaterielInfoList(new SearchMaterielInfoRequest
                {
                    item_code = MaterielInfo.MaterialCode,
                    item_desc = MaterielInfo.MaterialDesc,
                    major_category = MaterielInfo.MajorCategory,
                    minor_category = MaterielInfo.MinorCategory,
                    organization_code = MaterielInfo.OrganizationCode,
                    page_index = MaterielInfo.PageIndex,
                    page_size = MaterielInfo.PageSize
                });
                var datas = ObjectMapper.Map<List<MaterialInfoDto>, List<MaterialInfo>>(response.Response.MaterialCodes);

                MaterialInfos infos = new MaterialInfos();
                infos.TotalCount = response.Response.TotalCount;
                infos.MaterialCodes = datas;
                return Result.FromData(infos);
            }
        }

        /// <summary>
        /// 通过资产代码获取资产描述 
        /// </summary>
        /// <param name="AssetsNumber"> 资产代码</param>
        /// <returns></returns>
        public async Task<Result<AssetInfo>> GetAssetsInfoByAssetsCode(string AssetsNumber)
        {
            var apiService = ServiceProvider.GetRequiredService<IErpEsbService>();
            ErpAssetsInfoQueryRequest queryRequest = new ErpAssetsInfoQueryRequest { AssetsNumber = AssetsNumber };
            var response = await apiService.GetAssetsInfoByAssetsCode(queryRequest);

            if (response.Body.Info != null)
                return Result.Ok(response.Body.Info);
            else
            {
                var message = $"【{response}】";
                Logger.LogError(message);
                return Result.FromError<AssetInfo>(message);
            }


        }

    }
}
