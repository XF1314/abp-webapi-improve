using Com.OPPO.Mo.Thirdparty.RealmeOpenApi.Requests;
using Com.OPPO.Mo.Thirdparty.RealmeOpenApi.Responses;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.RealmeOpenApi.Services
{
    /// <summary>
    /// Realme刷机工具编译信息WebApi服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.RealmeOpenApiHost)]
    public interface IRealmeBrushToolsCompileInfoWebApiService : IHttpApi
    {
        /// <summary>
        /// 新增刷机工具编译信息
        /// </summary>
        /// <param name="realmeBrushToolsCompileInfoAddRequest"><see cref="RealmeBrushToolsCompileInfoAddRequest"/></param>
        /// <returns></returns>
        [HttpPost("rf/api/realme_mo/brush_tools_compile_info_import")]
        Task<RealmeOpenApiResponse> AddExportBrushToolCompileInfo([FormContent] RealmeBrushToolsCompileInfoAddRequest realmeBrushToolsCompileInfoAddRequest);
    }
}
