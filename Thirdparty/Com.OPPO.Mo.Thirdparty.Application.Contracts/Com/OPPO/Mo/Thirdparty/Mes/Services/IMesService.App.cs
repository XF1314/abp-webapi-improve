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
    /// Mes认证公开文件/生产方案量产
    /// </summary>
    public interface IMesAppService : IApplicationService
    {
        /// <summary>
        /// 查询销售国家数据
        /// </summary>
        /// <returns></returns>
        Task<Result<MesCountryDataBody>> GetCountryList(string conutryCode, string countryType, string ResponseType);

        /// <summary>
        /// 通过资产代码获取资产描述
        /// </summary>
        /// <returns></returns>
        Task<Result<List<MesProductModelResponse>>> GetCoverageChangeModelName(string AssetsNumber);

        /// <summary>
        /// 将mo单据数据写入MES系统【第三方接口：/mes/basics/mes_mo_document_insert】
        /// </summary>
        /// <param name="dtos">数据集合</param>
        /// <returns></returns>
        Task<Result> AddMoDocToMes(List<MarketingPrototypeInfoDto> dtos);
    }
}
