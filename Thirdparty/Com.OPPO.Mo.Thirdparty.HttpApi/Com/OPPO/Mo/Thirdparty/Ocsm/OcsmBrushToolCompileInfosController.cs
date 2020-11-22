using Com.OPPO.Mo.Thirdparty.Ocsm.Dtos;
using Com.OPPO.Mo.Thirdparty.Ocsm.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Ocsm
{
    /// <summary>
    /// Ocsm刷机编译信息
    /// </summary>
    [Area("ocsm")]
    [Route("api/mo/thirdparty/ocsm/brush-tool-compile-info")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class OcsmBrushToolCompileInfosController : AbpController, IOcsmBrushToolCompileInfoAppService
    {
        private readonly IOcsmBrushToolCompileInfoAppService _ocsmBrushToolCompileInfoAppService;

        /// <summary>
        /// <see cref="OcsmBrushToolCompileInfosController"/>
        /// </summary>
        public OcsmBrushToolCompileInfosController(IOcsmBrushToolCompileInfoAppService ocsmBrushToolCompileInfoAppService)
        {
            _ocsmBrushToolCompileInfoAppService = ocsmBrushToolCompileInfoAppService;
        }

        /// <summary>
        /// 新增内销刷机编译信息【第三方接口：/ocsm/brush_tools_compile_info_import】
        /// </summary>
        /// <param name="ocsmBrushToolsCompileInfoAddInput"><see cref="OcsmBrushToolsCompileInfoAddInput"/></param>
        /// <returns></returns>
        [HttpPost]
        [Route("domestic")]
        public async Task<Result> AddDomesticBrushToolCompileInfo([FromForm]OcsmBrushToolsCompileInfoAddInput ocsmBrushToolsCompileInfoAddInput)
        {
            return await _ocsmBrushToolCompileInfoAppService.AddDomesticBrushToolCompileInfo(ocsmBrushToolsCompileInfoAddInput);
        }

        /// <summary>
        /// 新增外销刷机编译信息-旧【第三方接口：/oppo/salesforce/brush_tools_compile_info_import】
        /// </summary>
        /// <param name="ocsmBrushToolsCompileInfoAddInput"><see cref="OcsmBrushToolsCompileInfoAddInput"/></param>
        /// <returns></returns>
        [HttpPost]
        [Route("export")]
        public async Task<Result> AddExportBrushToolCompileInfo([FromForm] OcsmBrushToolsCompileInfoAddInput ocsmBrushToolsCompileInfoAddInput)
        {
            return await _ocsmBrushToolCompileInfoAppService.AddDomesticBrushToolCompileInfo(ocsmBrushToolsCompileInfoAddInput);
        }

        /// <summary>
        /// 新增外销刷机编译信息-新【第三方接口：/api/tools/brush_tools_compile_info_import】
        /// </summary>
        /// <param name="ocsmBrushToolsCompileInfoAddInput"><see cref="OcsmBrushToolsCompileInfoAddInput"/></param>
        /// <returns></returns>
        [HttpPost]
        [Route("export-new")]
        public async Task<Result> AddExportBrushToolCompileInfo_New([FromForm] OcsmBrushToolsCompileInfoAddInput ocsmBrushToolsCompileInfoAddInput)
        {
            return await _ocsmBrushToolCompileInfoAppService.AddExportBrushToolCompileInfo_New(ocsmBrushToolsCompileInfoAddInput);
        }
    }
}
