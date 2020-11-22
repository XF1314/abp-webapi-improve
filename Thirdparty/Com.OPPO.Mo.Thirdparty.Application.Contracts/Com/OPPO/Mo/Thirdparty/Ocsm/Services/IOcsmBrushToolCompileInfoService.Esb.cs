using Com.OPPO.Mo.Thirdparty.Ocsm.Requests;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Ocsm.Services
{
    /// <summary>
    /// Ocsm系统刷机编译信息Esb服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    //[WebApiClientComposeReturn(EnsureSuccessStatusCode = false)]
    public interface IOcsmBrushToolCompileInfoEsbService : IHttpApi
    {
        /// <summary>
        /// 新增外销刷机编译信息-旧
        /// </summary>
        /// <param name="ocsmBrushToolsCompileInfoAddRequest"><see cref="OcsmBrushToolsCompileInfoAddRequest"/></param>
        /// <returns></returns>
        [HttpPost("/oppo/salesforce/brush_tools_compile_info_import")]
        Task<EsbResponse> AddExportBrushToolCompileInfo([FormContent] OcsmBrushToolsCompileInfoAddRequest ocsmBrushToolsCompileInfoAddRequest);

        /// <summary>
        /// 新增内销刷机编译信息
        /// </summary>
        /// <param name="ocsmBrushToolsCompileInfoAddRequest"><see cref="OcsmBrushToolsCompileInfoAddRequest"/></param>
        /// <returns></returns>
        [HttpPost("/ocsm/brush_tools_compile_info_import")]
        Task<EsbResponse> AddDomesticBrushToolCompileInfo([FormContent] OcsmBrushToolsCompileInfoAddRequest ocsmBrushToolsCompileInfoAddRequest);

    }
}
