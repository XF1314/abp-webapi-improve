using Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp
{
    /// <summary>
    /// OnePlusErp
    /// </summary>
    public interface IOnePlusErpAppService : IApplicationService
    {
        /// <summary>
        /// 获取拟价单信息
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="oaNum">MO文件编号</param>
        /// <returns></returns>
        Task<Result<List<OnePlusPriceInfoDto>>> GetPriceInfo(string language, string oaNum);

        /// <summary>
        /// 一加采购检查供应商登记注册号
        /// </summary>
        /// <param name="orgId">组织编号</param>
        /// <param name="vendorNumber">供应商编码</param>
        /// <returns></returns>
        Task<Result<List<OnplusErpVendorDto>>> GetCuxPoVendors(string orgId, string vendorNumber);

        /// <summary>
        /// SKU基础数据查询
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="organizationId">ERP库存组织ID</param>
        /// <param name="skuCode">SKU code</param>
        /// <param name="skuId">ERP Item Id</param>
        /// <param name="uom">SKU主单位</param>
        /// <returns></returns>
        Task<Result<List<OneplusErpCuxOaItemDto>>> GetCuxOaItem(string language, string organizationId, string skuCode, string skuId, string uom);

        /// <summary>
        /// 采购单拟价导入
        /// </summary>
        /// <param name="inputs"><see cref="OnePlusErpPriceInput"/>采购单拟价导入输入参数</param>
        /// <returns></returns>
        Task<Result<OnePlusErpPriceAddDto>> OneplusErpOpOaPriceIfaceAdd(OnePlusErpPriceInput inputs);

        /// <summary>
        ///  获取拟价订单
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="oaNum">MO文件编号</param>
        /// <returns></returns>
        Task<Result<List<OnePlusErpopOaPriceIfaceQueryDto>>> GetOnePlusErpopOaPriceIface(string language, string oaNum);

        /// <summary>
        ///  获取主体信息
        /// </summary>
        /// <param name="input"><see cref="OnePlusErpCuxExOuVQueryInput"/></param>
        /// <returns></returns>
        Task<Result<List<OnePlusErpCuxExOuVQueryDto>>> GetOnePlusErpCuxExOuV(OnePlusErpCuxExOuVQueryInput input);

        /// <summary>
        ///  获取财务系统价格
        /// </summary>
        /// <param name="input"><see cref="OnePlusErpCuxPoVendItemPriceInput"/></param>
        /// <returns></returns>
        Task<Result<List<OnePlusErpCuxPoVendItemPriceDto>>> GetCuxPoVendItemPriceV(OnePlusErpCuxPoVendItemPriceInput input);

        /// <summary>
        /// 获取采购员
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="agentId">组织ID</param>
        /// <param name="agentName">组织名称</param>
        /// <param name="employeeNumber">工号</param>
        /// <returns></returns>
        Task<Result<List<OnePlusErpAgentsDto>>> GetAgents(string language, string agentId, string agentName, string employeeNumber);

        /// <summary>
        /// 采购单导入头部
        /// </summary>
        /// <param name="input"><see cref="PoHeadersInterfaceInfoInput"/>采购单导入信息</param>
        /// <returns></returns>
        Task<Result<OnePlusErpHeadersIfaceDto>> HeadersIfaceAdd(PoHeadersInterfaceInfoInput input);

        /// <summary>
        /// 采购单导入主体部分
        /// </summary>
        /// <param name="input"><see cref="PoLinesInput"/>采购单导入主体部分信息</param>
        /// <returns></returns>
        Task<Result<OnePlusToErpDto>> LinesIfaceAdd(PoLinesInput input);

        /// <summary>
        ///  核算主体查询
        /// </summary>
        /// <param name="input"><see cref="OnePlusErpBodyInput"/></param>
        /// <returns></returns>
        Task<Result<List<OnePlusErpBodyDto>>> GetCuxExOuVQueryWithPage(OnePlusErpBodyInput input);

        /// <summary>
        ///  查询个人银行信息
        /// </summary>
        /// <param name="empId">员工工号</param>
        /// <returns></returns>
        Task<Result<List<OnePlusBankCardDto>>> GetBankCardByEmpId(string empId);

        /// <summary>
        ///  根据流程单号id查询付款信息
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="id">程单号id</param>
        /// <returns></returns>
        Task<Result<List<OnePlusPayTransDto>>> GetPayTransInfoById(string language, string id);

        /// <summary>
        /// 抛送报销信息头部至ERP
        /// </summary>
        /// <param name="input"><see cref="OnePluesHeardToErpInput"/></param>
        /// <returns></returns>
        Task<Result<OnePlusToErpDto>> CommonReimGeneralHeardToErp(OnePluesHeardToErpInput input);

        /// <summary>
        /// 抛送报销行信息至ERP
        /// </summary>
        /// <param name="input"><see cref="OnePluesLineToErpInput"/></param>
        /// <returns></returns>
        Task<Result<OnePlusToErpDto>> CommonReimGeneralLineToErp(OnePluesLineToErpInput input);

        /// <summary>
        /// 查询收货结果
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<Result<List<OnePlusErpReceivingResultInfoDto>>> GetReceivingResult(OnePlusErpReceivingResultInput input);

        /// <summary>
        /// 查询ERP SKU表的数据
        /// </summary>
        /// <returns></returns>
        Task<Result<List<OnePlusErpSkuInfoDto>>> GetErpAllSkuInfo(string language);
    }
}
