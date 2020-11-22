using Com.OPPO.Mo.Thirdparty.RealmeOpenApi.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.RealmeOpenApi.Services
{
    /// <summary>
    /// Realme刷机工具编译信息应用服务接口
    /// </summary>
    public interface IRealmeBrushToolsCompileInfoAppService : IApplicationService
    {
        /// <summary>
        /// 新增刷机工具编译信息
        /// </summary>
        /// <param name="realmeBrushToolsCompileInfoAddInput"><see cref="RealmeBrushToolsCompileInfoAddInput"/></param>
        /// <returns></returns>
        Task<Result> AddExportBrushToolCompileInfo(RealmeBrushToolsCompileInfoAddInput realmeBrushToolsCompileInfoAddInput);
    }
}
