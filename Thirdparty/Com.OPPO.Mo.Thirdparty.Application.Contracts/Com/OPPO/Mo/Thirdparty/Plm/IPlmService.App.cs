using Com.OPPO.Mo.Thirdparty.Plm.Dtos;
using Com.OPPO.Mo.Thirdparty.Plm.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Plm
{

    /// <summary>
    /// oppo/plm
    /// </summary>
    public interface IPlmAppService : IApplicationService
    {

        /// <summary>
        /// 从ERP查询物料是否是制造件 【第三方接口：/oppo/plm/erp/erp_make_item】
        /// </summary>
        /// <param name="organizationCode">组织代码,必填</param>
        /// <param name="itemCode">物料号,必填</param>
        /// <returns></returns>
       Task<Result<ItemMake>> QueryItemInfoToERP(string organizationCode, string itemCode);

        /// <summary>
        /// 根据sourcePartNumber获取PLM中BOM结构父项信息 【第三方接口：/oppo/plm/plm_parent_partinfo_list】
        /// </summary>
        /// <param name="sourcePartNumber">,必填</param>
        /// <param name="replacePartNumber">,必填</param>
        /// <returns></returns>
        Task<Result<List<ParentPartinforResponse>>> GetPlmParentPartinfoList(string sourcePartNumber, string replacePartNumber);


        /// <summary>
        /// 抛物料替代建立/失效到PLM【第三方接口：/oppo/plm/plm_comsub_insert】
        /// </summary>
        /// <param name="subs"></param>
        /// <returns></returns>
        Task<Result<List<SubstitutesResponse>>> InsertSubsInfoToPLM(List<SubstitutesDto> subs);

        /// <summary>
        /// 抛物料替代建立/失效到ERP【第三方接口：/oppo/plm/erp/erp_comsub_insert】
        /// </summary>
        /// <param name="subs"></param>
        /// <returns></returns>
        Task<Result> InsertSubsInfoToERP(List<SubstitutesDto> subs);

        /// <summary>
        /// 从ERP查询替代料新增/失效/主次料调整信息【第三方接口：/oppo/plm/erp/erp_comsub_list】
        /// </summary>
        /// <param name="docNumber">文件编号</param>
        /// <returns></returns>
        Task<Result<List<ComsubResponse>>> QuerySubsInfoToERP(string docNumber);
    }
}
