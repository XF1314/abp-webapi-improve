using Com.OPPO.Mo.Thirdparty.Ocsm.Requests;
using Com.OPPO.Mo.Thirdparty.Ocsm.Responses;
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
    /// Ocsm系统刷机编译信息WebApi服务接口
    /// </summary>
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.OcsmHost)]
    public interface IOcsmBrushToolCompileInfoWebApiService : IHttpApi
    {
        /// <summary>
        /// 新增外销刷机编译信息-新
        /// </summary>
        /// <param name="ocsmEncryptedBrushToolCompileInfoAdd"></param>
        /// <returns></returns>
        [HttpPost("/api/tools/brush_tools_compile_info_import")]
        Task<OcsmWebApiResponse> AddExportBrushToolCompileInfo_New([FormContent]OcsmEncryptedBrushToolCompileInfoAddRequest ocsmEncryptedBrushToolCompileInfoAdd);
    }
}
