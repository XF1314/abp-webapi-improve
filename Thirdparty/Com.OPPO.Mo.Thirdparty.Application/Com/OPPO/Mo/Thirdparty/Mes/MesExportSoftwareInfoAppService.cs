using Com.OPPO.Mo.Thirdparty.Mes.Dtos;
using Com.OPPO.Mo.Thirdparty.Mes.Requests;
using Com.OPPO.Mo.Thirdparty.Mes.Responses;
using Com.OPPO.Mo.Thirdparty.Mes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Mes
{
    /// <summary>
    /// Mes外销软体信息应用服务
    /// </summary>
    [Authorize]
    public class MesExportSoftwareInfoAppService : ThirdpartyAppServiceBase, IMesExportSoftwareInfoAppService
    {
        private readonly IConfiguration _configuration;
        private readonly IMesExportSoftwareInfoEsbService _mesExportSoftwareInfoEsbService;

        /// <summary>
        /// <see cref="MesExportSoftwareInfoAppService"/>
        /// </summary>
       
        public MesExportSoftwareInfoAppService(IConfiguration configuration,
            IMesExportSoftwareInfoEsbService mesExportSoftwareInfoEsbService)
        {
            _configuration = configuration;
            _mesExportSoftwareInfoEsbService = mesExportSoftwareInfoEsbService;
        }

        /// <inheritdoc/>
        public async Task<Result> AddExportSoftwareInfo(List<MesExportSoftwareInfoDto> mesExportSoftwareInfoDtos)
        {
            if (!mesExportSoftwareInfoDtos.Any())
                return Result.FromError("软体信息不能为空。");
            else
            {
                var mesExposrtSoftwareInfos = ObjectMapper.Map<List<MesExportSoftwareInfoDto>, List<MesExportSoftwareInfo>>(mesExportSoftwareInfoDtos);
                mesExposrtSoftwareInfos.ForEach(x => x.AppId = _configuration[ThirdpartySettingNames.EsbAppId]);
                var response = await _mesExportSoftwareInfoEsbService.AddExportSoftwareInfo(new MesExportSoftwareInfoAddRequest
                {
                    SoftwareInfos = mesExposrtSoftwareInfos
                });
                if (response.IsOk)
                    return Result.Ok();
                else
                {
                    var message = $"【{response.Body?.BussinessCode}】{response.Body?.Message}";
                    Logger.LogError(message);
                    return Result.FromError(message);
                }
            }
        }

        /// <summary>
        /// 根据认证机型获取生产机型
        /// </summary>
        /// <param name="prodModel"></param>
        /// <returns></returns>
        public async Task<Result<List<ProdModelDto>>> GetSMTModelByExtModel()
        {
            var response = await _mesExportSoftwareInfoEsbService.GetSMTModelByExtModel(new ProdModelRequest { });

            var res = ObjectMapper.Map<List<ProductModelInfo>, List<ProdModelDto>>(response.Data.Data);

            return Result.FromData(res);

        }
    }
}
