using Com.OPPO.Mo.Thirdparty.Mes.Dtos;
using Com.OPPO.Mo.Thirdparty.Mes.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Mes.Services
{


    /// <summary>
    /// Mes外销软体信息应用服务接口
    /// </summary>
    public interface IMesExportSoftwareInfoAppService : IApplicationService
    {
        /// <summary>
        /// 新增外销软件信息s
        /// </summary>
        /// <param name="mesExportSoftwareInfoDtos"><see cref="List{MesExportSoftwareInfoDto}"/></param>
        /// <returns></returns>
        Task<Result> AddExportSoftwareInfo(List<MesExportSoftwareInfoDto> mesExportSoftwareInfoDtos);

        /// <summary>
        /// 根据认证机型获取生产机型
        /// </summary>
        /// <returns></returns>
        Task<Result<List<ProdModelDto>>> GetSMTModelByExtModel();

    }
}
