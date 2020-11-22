
using Com.OPPO.Mo.Thirdparty.Erp.ErpEam.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpEam
{

    /// <summary>
    /// ERP/eam 资源
    /// </summary>
    public interface IErpEamAppService : IApplicationService
    {

        /// <summary>
        /// EAM-资产报废_资产信息查询 【第三方接口：/erp/eam/get_eqpt_retirement_list】
        /// </summary>
        /// <param name="assetCode">设备编码或者资产编码,必填</param>info_number
        /// <param name="language">语言,非必填</param>
        /// <returns></returns>
        Task<Result<List<AssetRetirementInfo>>> GetAssetRetirementList(string assetCode, string language);

    }
}
