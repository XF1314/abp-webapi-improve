using Com.OPPO.Mo.Thirdparty.Erp.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Erp.Services
{
    /// <summary>
    /// Erp  WebApi Service
    /// </summary>
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IErpServiceInfoEsbService : IHttpApi
    {
        /// <summary>
        /// EAM-检查部门代码是否有对应的字库信息
        /// <param name="department"><see cref="ErpDepartmentRequest"/></param>
        /// </summary>
        /// <returns>Y:表示存在，N：表示不存在</returns>
        [HttpGet("/erp/eam/get_department_exists_flag")]
        Task<ErpResponse<List<ErpDepartmentFlagInfo>>> DepartmentExists([PathQuery] ErpDepartmentRequest department);

        /// <summary>
        /// 通过部门代码查询部门名称
        /// <param name="department"><see cref="ErpDepartmentQueryRequest"/></param>
        /// </summary>
        /// <returns></returns>
        [HttpGet("/erp/assets/mtl_department_get")]
        Task<ErpDepResponse<ErpDepartmentInfo>> GetDepartmentByCode([PathQuery] ErpDepartmentQueryRequest department);

        /// <summary>
        /// PLM获取ERP样品库同步处理结果信息
        /// </summary>
        /// <param name="request"><see cref="ErpSampleBatchRequest"/></param>
        /// <returns>返回物资样品编号集合</returns>
        [HttpGet("/oppo/plm/erp/erp_materiel_sample_list")]
        Task<List<ErpLocatorInfo>> GetMaterielSampleList(ErpSampleBatchRequest request);

        /// <summary>
        /// 查询物料
        /// </summary>
        /// <param name="erpMaterialQueryRequest"></param>
        /// <returns></returns>
        [HttpGet("/erp/eam/get_item_list")]
        Task<ErpResponse<List<ErpMaterialInfo>>> GetItemList([PathQuery] ErpMaterialQueryRequest erpMaterialQueryRequest);

        /// <summary>
        /// 查询有库存现有量的货位
        /// </summary>
        /// <param name="request"><see cref="ErpOnhandLocatorQueryRequest"/></param>
        /// <returns></returns>
        [HttpGet("/erp/eam/get_onhand_exists_locator_list")]
        Task<ErpResultResponseResult<ErpLocatorListInfoDto>> GetOnhandLocatorList([PathQuery] ErpOnhandLocatorQueryRequest request);

        /// <summary>
        /// 查询物料现有量
        /// </summary>
        /// <param name="request"><see cref="ErpOnhandQtyQueryRequest"/></param>
        /// <returns></returns>
        [HttpGet("/erp/eam/get_item_onhand_qty_list")]
        Task<ErpResponse<List<ErpOnhandQtyInfo>>> GetOnhandQtyList([PathQuery] ErpOnhandQtyQueryRequest request);

        /// <summary>
        /// 查询物料现有量
        /// </summary>
        /// <param name="request"><see cref="ErpInstanceRequest"/></param>
        /// <returns></returns>
        [HttpGet("/erp/eam/get_instance_info_list")]
        Task<ErpResponse<List<ErpInstanceInfo>>> GetInstanceInfoList([PathQuery] ErpInstanceRequest request);

        /// <summary>
        /// 固定资产和设备信息查询
        /// </summary>
        /// <param name="request"><see cref="ErpAssetInstanceRequest"/></param>
        /// <returns></returns>
        [HttpGet("/erp/eam/get_asset_instance_info_list")]
        Task<ErpResponse<List<ErpAssetInstanceInfo>>> GetAssetInstanceInfoList([PathQuery] ErpAssetInstanceRequest request);

        /// <summary>
        /// EAM-设备调拨_部门账户信息
        /// </summary>
        /// <param name="request"><see cref="ErpDepFaInfoRequest"/></param>
        /// <returns></returns>
        [HttpGet("/erp/eam/get_dept_fa_info_list")]
        Task<ErpResponse<List<ErpDepFaInfo>>> GetDeptFaInfoList([PathQuery] ErpDepFaInfoRequest request);

        /// <summary>
        /// 添加设备调拨
        /// </summary>
        /// <param name="request"><see cref="ErpEqptInstanceRequest"/></param>
        /// <returns></returns>
        [HttpPost("/erp/eam/eqpt_instance_transfer")]
        Task<ErpResultResponseResult<ErpResponseInfo>> AddInstanceTransfer([FormContent] ErpEqptInstanceRequest request);

    }
}
