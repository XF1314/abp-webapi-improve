using Com.OPPO.Mo.Thirdparty.Mes.Requests;
using Com.OPPO.Mo.Thirdparty.Mes.Responses;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Mes.Services
{
    /// <summary>
    /// Mes外销软件信息EsbService
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IMesExportSoftwareInfoEsbService : IHttpApi
    {
        /// <summary>
        /// 新增外销软件信息
        /// </summary>
        /// <param name="mesExportSoftwareInfoAddRequest"><see cref="MesExportSoftwareInfoAddRequest"/></param>
        /// <returns></returns>
        [HttpPost("/mes/basics/export_software_info_insert")]
        Task<EsbResponse> AddExportSoftwareInfo([FormContent] MesExportSoftwareInfoAddRequest mesExportSoftwareInfoAddRequest);


        /// <summary>
        /// 根据认证机型获取生产机型
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("/mes/extranet/mes_get_smt_model_by_ext_model")]
        Task<MesRespons<List<ProductModelInfo>>> GetSMTModelByExtModel([PathQuery]ProdModelRequest request);
    }
}
