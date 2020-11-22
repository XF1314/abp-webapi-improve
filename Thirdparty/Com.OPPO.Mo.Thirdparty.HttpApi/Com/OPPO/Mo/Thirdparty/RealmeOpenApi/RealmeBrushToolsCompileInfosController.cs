using Com.OPPO.Mo.Thirdparty.RealmeOpenApi.Dtos;
using Com.OPPO.Mo.Thirdparty.RealmeOpenApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.RealmeOpenApi
{
    /// <summary>
    /// Realme刷机编译信息
    /// </summary>
    [Area("realme-openapi")]
    [Route("api/mo/thirdparty/realme-openapi/brush-tool-compile-info")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class RealmeBrushToolsCompileInfosController : AbpController, IRealmeBrushToolsCompileInfoAppService
    {
        private readonly IRealmeBrushToolsCompileInfoAppService _realmeBrushToolsCompileInfoAppService;

        /// <summary>
        /// <see cref="RealmeBrushToolsCompileInfosController"/>
        /// </summary>
        public RealmeBrushToolsCompileInfosController(IRealmeBrushToolsCompileInfoAppService realmeBrushToolsCompileInfoAppService)
        {
            _realmeBrushToolsCompileInfoAppService = realmeBrushToolsCompileInfoAppService;
        }

        /// <summary>
        /// 新增Realme刷机编译信息【第三方接口：/api/realme_mo/brush_tools_compile_info_import】
        /// </summary>
        /// <param name="realmeBrushToolsCompileInfoAddInput"><see cref="RealmeBrushToolsCompileInfoAddInput"/></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<Result> AddExportBrushToolCompileInfo([FromForm]RealmeBrushToolsCompileInfoAddInput realmeBrushToolsCompileInfoAddInput)
        {
            return await _realmeBrushToolsCompileInfoAppService.AddExportBrushToolCompileInfo(realmeBrushToolsCompileInfoAddInput);
        }
    }
}
