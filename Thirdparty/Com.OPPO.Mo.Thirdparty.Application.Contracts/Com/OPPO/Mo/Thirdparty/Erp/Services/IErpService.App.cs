using Com.OPPO.Mo.Thirdparty.Erp.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Erp.Services
{
    /// <summary>
    /// Erp应用服务接口
    /// </summary>
    public interface IErpAppService : IApplicationService
    {
        /// <summary>
        /// EAM-检查部门代码是否有对应的字库信息
        /// <param name="orgCode">组织编码</param>
        /// <param name="departmentCode">部门编码</param>
        /// </summary>
        /// <returns>Y:表示存在，N：表示不存在</returns>
        Task<Result<List<ErpDepartmentFlagDto>>> DepartmentExists(string orgCode, string departmentCode);

        /// <summary>
        /// 通过部门代码查询部门名称
        /// <param name="deptCode">部门代码</param>
        /// </summary>
        /// <returns>返回部门信息</returns>
        Task<Result<ErpDepartmentDto>> GetDepartmentByCode(string deptCode);

        /// <summary>
        /// 根据部门编码和组织编码获取物资样品编号集合
        /// </summary>
        /// <param name="batchId">批次ID</param>
        /// <returns>返回物资样品编号集合</returns>
        Task<Result<List<ErpLocatorDto>>> GetLocatorCodeList(string batchId);

        /// <summary>
        /// 根据物料代码和组织编码获取物料信息
        /// </summary>
        /// <param name="materialCode">物料代码</param>
        /// <param name="orgCode">组织代码</param>
        /// <returns></returns>
        Task<Result<List<ErpMaterialDto>>> GetItemList(string materialCode, string orgCode);

        /// <summary>
        /// 查询有库存现有量的货位
        /// </summary>
        /// <param name="orgCode">组织编码</param>
        /// <param name="subpool">转出部门编码</param>
        /// <param name="materialCode">物料代码</param>
        /// <returns>返回物资样品编号集合</returns>
        Task<Result<ErpLocatorListInfoDto>> GetOnhandExistsLocatorList(string orgCode, string subpool, string materialCode);

        /// <summary>
        /// 根据物料编码、组织编码、部门编码，查询物料现有量
        /// </summary>
        /// <param name="itemCode">物料编码</param>
        /// <param name="orgCode">组织编码</param>
        /// <param name="locatorCode">部门编码 </param>
        /// <param name="subinvCode">部门编码</param>
        /// <returns></returns>
        Task<Result<List<ErpOnhandQtyDto>>> GetItemOnhandQtyList(string itemCode, string orgCode, string locatorCode, string subinvCode);

        /// <summary>
        /// 设备调拨_设备台账信息
        /// </summary>
        /// <param name="assetNum">固定资产编号</param>
        /// <param name="language">语言</param>
        /// <param name="orgCode">组织代码</param>
        /// <returns></returns>
        Task<Result<List<ErpInstanceInfoDto>>> GetInstanceInfoList(string assetNum, string language, string orgCode);

        /// <summary>
        /// EAM-设备调拨_部门账户信息 【第三方接口：/erp/eam/get_asset_instance_info_list】
        /// </summary>
        /// <param name="deptIn">转入部门</param>
        /// <param name="language">语言</param>
        /// <param name="orgCode">组织代码</param>
        /// <returns></returns>
        Task<Result<List<ErpDepFaDto>>> GetDeptFaInfoList(string deptIn, string language, string orgCode);

        /// <summary>
        /// 固定资产和设备信息查询
        /// </summary>
        /// <param name="assetNum">固定资产编号</param>
        /// <param name="language">语言</param>
        /// <param name="orgCode">组织代码</param>
        /// <returns></returns>
        Task<Result<List<ErpAssetInstanceDto>>> GetAssetInstanceInfoList(string assetNum, string language, string orgCode);

        /// <summary>
        /// 添加设备调拨
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<Result> AddInstanceTransfer(ErpEqptInstanceInput input);

        /// <summary>
        /// 获取汇率
        /// </summary>
        /// <param name="currency">货币</param>
        /// <returns>返回汇率集合信息</returns>
        Task<Result<List<ErpConversionDto>>> GetConversion(string currency);

        /// <summary>
        /// 获取收款公司清单
        /// </summary>
        /// <param name="vendor">供应商代码</param>
        /// <param name="poou">签约主体代码</param>
        /// <returns>返回收款公司清单信息</returns>
        Task<Result<List<ErpVendorDto>>> GetVendor(string vendor, string poou);

        /// <summary>
        /// 获取付款款公司清单
        /// </summary>
        /// <param name="orgCode">组织编码</param>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>返回收款公司清单信息</returns>
        Task<Result<List<ErpPaymentDto>>> GetVendorTwo(string orgCode,int pageIndex, int pageSize);

        /// <summary>
        /// 付款通知单传ERP
        /// </summary>
        /// <param name="invoices">付款通知单传ERP对应参数json</param>
        /// <returns></returns>
        Task<Result> InvoicesPush(ErpInvoicesPushInput invoices);

        /// <summary>
        /// 更新科目信息【第三方接口：/erp/assets/pubget_push】
        /// </summary>
        /// <param name="dtos"> 数据集合</param>
        /// <returns></returns>
        Task<Result> ToolingFixtureApplicationPush(List<ErpToolingFixtureApplicationApprovalInfoDto> dtos);

        /// <summary>
        /// 查询物料信息
        /// </summary>
        /// <param name="MaterielInfo">物料信息</param>
        Task<Result<MaterialInfos>> SearchMaterielInfos(SearchMaterielInfo MaterielInfo);


        /// <summary>
        /// 通过资产代码获取资产描述 
        /// </summary>
        /// <param name="AssetsNumber"> 资产代码</param>
        /// <returns></returns>
        Task<Result<AssetInfo>> GetAssetsInfoByAssetsCode(string AssetsNumber);


    }
}
