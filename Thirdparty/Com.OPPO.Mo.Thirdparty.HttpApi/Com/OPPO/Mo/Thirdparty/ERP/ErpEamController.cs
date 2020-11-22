using Com.OPPO.Mo.Thirdparty.Erp.ErpEam;
using Com.OPPO.Mo.Thirdparty.Erp.ErpEam.Responses;
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
    /// ERP/eam 资源
    /// </summary>
    [Area("erp")]
    [Route("api/mo/thirdparty/erp/eam")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class ErpEamController : AbpController, IErpEamAppService
    {
        private readonly IErpEamAppService _erpAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="erpAppService"></param>
        public ErpEamController(IErpEamAppService erpAppService)
        {
            _erpAppService = erpAppService;
        }

        /// <summary>
        /// EAM-资产报废_资产信息查询 【第三方接口：/erp/eam/get_eqpt_retirement_list】
        /// </summary>
        /// <param name="assetCode">设备编码或者资产编码,必填</param>info_number
        /// <param name="language">语言,非必填</param>
        /// <returns></returns>
        [HttpGet("query-asset-retirement-list")]
        public async Task<Result<List<AssetRetirementInfo>>> GetAssetRetirementList([Required]string assetCode, string language)
        {
            return await _erpAppService.GetAssetRetirementList(assetCode, language);
        }

    }
}
