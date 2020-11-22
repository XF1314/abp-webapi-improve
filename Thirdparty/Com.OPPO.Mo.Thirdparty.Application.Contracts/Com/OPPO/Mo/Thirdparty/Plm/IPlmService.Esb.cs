using Com.OPPO.Mo.Thirdparty.Plm.Dtos;
using Com.OPPO.Mo.Thirdparty.Plm.Requests;
using Com.OPPO.Mo.Thirdparty.Plm.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Plm
{

    /// <summary>
    /// oppo/plm
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IPlmEsbService : IHttpApi
    {

        /// <summary>
        /// 从ERP查询物料是否是制造件
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/oppo/plm/erp/erp_make_item")]
        Task<List<ItemMakeDto>> QueryItemInfoToERP([PathQuery]QueryItemInfoRequest query);


        /// <summary>
        /// 根据sourcePartNumber获取PLM中BOM结构父项信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/oppo/plm/plm_parent_partinfo_list")]
        Task<PlmBaseResponse<List<ParentPartinforResponse>>> GetPlmParentPartinfoList([PathQuery]QueryParentInfoRequest query);

        /// <summary>
        ///  抛物料替代建立/失效到PLM【第三方接口：/oppo/plm/plm_comsub_insert】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/oppo/plm/plm_comsub_insert")]
        Task<PlmBaseResponse<List<SubstitutesResponse>>> InsertSubsInfoToPLM([FormContent]InsertSubsInfoRequest query);

        /// <summary>
        ///  抛物料替代建立/失效到ERP【第三方接口：/oppo/plm/erp/erp_comsub_insert】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("/oppo/plm/erp/erp_comsub_insert")]
        Task<EsbResponse> InsertSubsInfoToERP([FormContent]InsertSubsInfoRequest query);


        /// <summary>
        /// 从ERP查询替代料新增/失效/主次料调整信息【第三方接口：/oppo/plm/erp/erp_comsub_list】
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/oppo/plm/erp/erp_comsub_list")]
        Task<List<SubstitutesResponseDto>> QuerySubsInfoToERP([PathQuery]QueryComSubRequest query);
    }

}
