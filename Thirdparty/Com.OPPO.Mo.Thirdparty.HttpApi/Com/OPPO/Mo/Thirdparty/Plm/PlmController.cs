using Com.OPPO.Mo.Thirdparty.Plm;
using Com.OPPO.Mo.Thirdparty.Plm.Dtos;
using Com.OPPO.Mo.Thirdparty.Plm.Responses;
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
    /// Oppo/plm 资源
    /// </summary>
    [Area("plm")]
    [Route("api/mo/thirdparty/plm")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class PlmController : AbpController, IPlmAppService
    {
        private readonly IPlmAppService _erpAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="erpAppService"></param>
        public PlmController(IPlmAppService erpAppService)
        {
            _erpAppService = erpAppService;
        }


        /// <summary>
        /// 从ERP查询物料是否是制造件 【第三方接口：/oppo/plm/erp/erp_make_item】
        /// </summary>
        /// <param name="orgCode">组织代码,必填</param>
        /// <param name="itemCode">物料号,必填</param>
        /// <returns></returns>
        [HttpGet("query-iteminfo-to-erp")]
        public async Task<Result<ItemMake>> QueryItemInfoToERP([Required]string orgCode, [Required]string itemCode)
        {
            return await _erpAppService.QueryItemInfoToERP(orgCode, itemCode);
        }

        /// <summary>
        /// 根据sourcePartNumber获取PLM中BOM结构父项信息 【第三方接口：/oppo/plm/plm_parent_partinfo_list】
        /// </summary>
        /// <param name="sourcePartNumber">,必填</param>
        /// <param name="replacePartNumber">,必填</param>
        /// <returns></returns>
        [HttpGet("query-parentinfo-by-number")]
        public async Task<Result<List<ParentPartinforResponse>>> GetPlmParentPartinfoList([Required]string sourcePartNumber, [Required]string replacePartNumber)
        {
            return await _erpAppService.GetPlmParentPartinfoList(sourcePartNumber, replacePartNumber);
        }


        /// <summary>
        /// 抛物料替代建立/失效到PLM【第三方接口：/oppo/plm/plm_comsub_insert】
        /// </summary>
        /// <param name="subs"></param>
        /// <returns></returns>
        [HttpPost("add-subsinfo-to-plm")]
        public async Task<Result<List<SubstitutesResponse>>> InsertSubsInfoToPLM(List<SubstitutesDto> subs)
        {
            return await _erpAppService.InsertSubsInfoToPLM(subs);
        }

        /// <summary>
        /// 抛物料替代建立/失效到ERP【第三方接口：/oppo/plm/erp/erp_comsub_insert】
        /// </summary>
        /// <param name="subs"></param>
        /// <returns></returns>
        [HttpPost("add-subsinfo-to-erp")]
        public async Task<Result> InsertSubsInfoToERP(List<SubstitutesDto> subs)
        {
            return await _erpAppService.InsertSubsInfoToERP(subs);
        }

        /// <summary>
        /// 从ERP查询替代料新增/失效/主次料调整信息【第三方接口：/oppo/plm/erp/erp_comsub_list】
        /// </summary>
        /// <param name="docNumber">文件编号</param>
        /// <returns></returns>
        [HttpGet("query-subsinfo-to-erp")]
        public async Task<Result<List<ComsubResponse>>> QuerySubsInfoToERP(string docNumber)
        {
            return await _erpAppService.QuerySubsInfoToERP(docNumber);
        }


    }

}
