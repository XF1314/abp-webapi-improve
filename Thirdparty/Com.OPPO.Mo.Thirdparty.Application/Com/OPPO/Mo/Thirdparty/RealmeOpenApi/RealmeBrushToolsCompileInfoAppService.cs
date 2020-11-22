using Com.OPPO.Mo.Thirdparty.RealmeOpenApi.Dtos;
using Com.OPPO.Mo.Thirdparty.RealmeOpenApi.Requests;
using Com.OPPO.Mo.Thirdparty.RealmeOpenApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.RealmeOpenApi
{
    /// <summary>
    /// Realme刷机工具编译信息应用服务
    /// </summary>
    [Authorize]
    public class RealmeBrushToolsCompileInfoAppService : ThirdpartyAppServiceBase, IRealmeBrushToolsCompileInfoAppService
    {
        private readonly IRealmeBrushToolsCompileInfoWebApiService _realmeBrushToolsCompileInfoWebApiService;

        /// <inheritdoc>
        public RealmeBrushToolsCompileInfoAppService(IRealmeBrushToolsCompileInfoWebApiService realmeBrushToolsCompileInfoWebApiService)
        {
            _realmeBrushToolsCompileInfoWebApiService = realmeBrushToolsCompileInfoWebApiService;
        }

        /// <inheritdoc>
        public async Task<Result> AddExportBrushToolCompileInfo(RealmeBrushToolsCompileInfoAddInput realmeBrushToolsCompileInfoAddInput)
        {
            if (string.IsNullOrWhiteSpace(realmeBrushToolsCompileInfoAddInput.CompileInfo))
                return Result.FromError($"{realmeBrushToolsCompileInfoAddInput.CompileInfo}不能为空。");
            else
            {
                //TODO:验证CompileInfo是否合格的Json格式
                var response = await _realmeBrushToolsCompileInfoWebApiService.AddExportBrushToolCompileInfo(new RealmeBrushToolsCompileInfoAddRequest
                {
                    CompileInfo = realmeBrushToolsCompileInfoAddInput.CompileInfo
                });

                if (response.IsOk)
                    return Result.Ok();
                else
                {
                    var message = $"【{response.Code}】->【{response.Body?.BussinessCode}】{response.Body?.Message}";
                    Logger.LogError(message);
                    return Result.FromError(message);
                }
            }
        }
    }
}
