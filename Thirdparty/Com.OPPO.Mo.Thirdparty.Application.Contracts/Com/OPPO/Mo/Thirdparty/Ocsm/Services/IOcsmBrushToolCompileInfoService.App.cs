using Com.OPPO.Mo.Thirdparty.Ocsm.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Ocsm.Services
{
    /// <summary>
    ///  Ocsm系统刷机编译信息应用服务接口
    /// </summary>
    public interface IOcsmBrushToolCompileInfoAppService : IApplicationService
    {
        /// <summary>
        /// 新增内销刷机编译信息
        /// </summary>
        /// <param name="ocsmBrushToolsCompileInfoAddInput"><see cref="OcsmBrushToolsCompileInfoAddInput"/></param>
        ///<returns></returns>
        Task<Result> AddDomesticBrushToolCompileInfo(OcsmBrushToolsCompileInfoAddInput ocsmBrushToolsCompileInfoAddInput);

        /// <summary>
        /// 新增外销刷机编译信息-旧
        /// </summary>
        /// <param name="ocsmBrushToolsCompileInfoAddInput"><see cref="OcsmBrushToolsCompileInfoAddInput"/></param>   
        /// <returns></returns>
        Task<Result> AddExportBrushToolCompileInfo(OcsmBrushToolsCompileInfoAddInput ocsmBrushToolsCompileInfoAddInput);

        /// <summary>
        /// 新增外销刷机编译信息-新
        /// </summary>
        /// <param name="ocsmBrushToolsCompileInfoAddInput"><see cref="OcsmBrushToolsCompileInfoAddInput"/></param>
        /// <returns></returns>
        Task<Result> AddExportBrushToolCompileInfo_New(OcsmBrushToolsCompileInfoAddInput ocsmBrushToolsCompileInfoAddInput);
    }
}
