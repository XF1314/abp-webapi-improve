using Com.OPPO.Mo.Thirdparty.Mes.Dtos;
using Com.OPPO.Mo.Thirdparty.Mes.Requests;
using Com.OPPO.Mo.Thirdparty.Mes.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Mes
{
    /// <summary>
    /// Mes外销软体信息
    /// </summary>
    [Area("mes")]
    [Route("api/mo/thirdparty/mes/export-software-info/")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class MesExportSoftwareInfosController : AbpController, IMesExportSoftwareInfoAppService
    {
        private readonly IMesExportSoftwareInfoAppService _mesExportSoftwareInfoAppService;

        /// <summary>
        /// <see cref="MesExportSoftwareInfosController"/>
        /// </summary>
        public MesExportSoftwareInfosController(IMesExportSoftwareInfoAppService mesExportSoftwareInfoAppService)
        {
            _mesExportSoftwareInfoAppService = mesExportSoftwareInfoAppService;
        }


        /// <summary>
        /// 新增外销软件信息【第三方接口：/mes/basics/export_software_info_insert】
        /// </summary>
        /// <param name="mesExportSoftwareInfoDtos"><see cref="List{MesExportSoftwareInfoDto}"/></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<Result> AddExportSoftwareInfo(List<MesExportSoftwareInfoDto> mesExportSoftwareInfoDtos)
        {
            return await _mesExportSoftwareInfoAppService.AddExportSoftwareInfo(mesExportSoftwareInfoDtos);
        }


        /// <summary>
        /// 根据认证机型获取生产机型
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-smt-model-all")]
        public async Task<Result<List<ProdModelDto>>> GetSMTModelByExtModel()
        {
            return await _mesExportSoftwareInfoAppService.GetSMTModelByExtModel();
        }

    }
}
