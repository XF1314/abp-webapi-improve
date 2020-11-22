using Com.OPPO.Mo.Thirdparty.DataGrand.Dtos;
using Com.OPPO.Mo.Thirdparty.DataGrand.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索
    /// </summary>
    [Area("datagrand")]
    [Route("api/mo/thirdparty/datagrand/data")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class DataGrandDataSearchController : AbpController, IDataGrandDataSearchAppService
    {
        private readonly IDataGrandDataSearchAppService _dataGrandDataSearchAppService;

        public DataGrandDataSearchController(IDataGrandDataSearchAppService dataGrandDataSearchAppService)
        {
            _dataGrandDataSearchAppService = dataGrandDataSearchAppService;
        }

        /// <summary>
        /// 获取聚合数据
        /// </summary>
        /// <param name="employeeCode">用户编码</param>
        /// <param name="dataGrandAggregateSearchInput"><see cref="BaseDataGrandAggregateSearchInput"/></param>
        /// <returns></returns>
        [HttpGet]
        [Route("all/{employeeCode}")]
        public async Task<Result<DataGrandSearchOutput>> AggregateSearch(string employeeCode, [FromQuery] DataGrandAggregateSearchInput dataGrandAggregateSearchInput)
        {
            var result = await _dataGrandDataSearchAppService.AggregateSearch(employeeCode, dataGrandAggregateSearchInput);
            if (!result.IsOk())
                Logger.LogWarning(result.Msg);

            return result;
        }

        /// <summary>
        /// 发文数据聚合搜索
        /// </summary>
        /// <param name="employeeCode">用户编码</param>
        /// <param name="dataGrandArticleAggregateSearchInput"><see cref="DataGrandArticleAggregateSearchInput"/></param>
        /// <returns></returns>
        [HttpGet]
        [Route("article/{employeeCode}")]
        public async Task<Result<DataGrandSearchOutput>> ArticleAggregateSearch(string employeeCode, DataGrandArticleAggregateSearchInput dataGrandArticleAggregateSearchInput)
        {
            var result = await _dataGrandDataSearchAppService.ArticleAggregateSearch(employeeCode, dataGrandArticleAggregateSearchInput);
            if (!result.IsOk())
                Logger.LogWarning(result.Msg);

            return result;
        }

        /// <summary>
        /// 便签数据聚合搜索
        /// </summary>
        /// <param name="employeeCode">用户编码</param>
        /// <param name="dataGrandMailAggregateSearchInput"><see cref="DataGrandMailAggregateSearchInput"/></param>
        /// <returns></returns>
        [HttpGet]
        [Route("mail/{employeeCode}")]
        public async Task<Result<DataGrandSearchOutput>> MailAggregateSearch(string employeeCode, DataGrandMailAggregateSearchInput dataGrandMailAggregateSearchInput)
        {
            var result = await _dataGrandDataSearchAppService.MailAggregateSearch(employeeCode, dataGrandMailAggregateSearchInput);
            if (!result.IsOk())
                Logger.LogWarning(result.Msg);

            return result;
        }

        /// <summary>
        /// 模块数据聚合搜索
        /// </summary>
        /// <param name="employeeCode">用户编码</param>
        /// <param name="dataGrandModuleAggregateSearchInput"><see cref="DataGrandModuleAggregateSearchInput"/></param>
        /// <returns></returns>
        [HttpGet]
        [Route("module/{employeeCode}")]
        public async Task<Result<DataGrandSearchOutput>> ModuleAggregateSearch(string employeeCode, DataGrandModuleAggregateSearchInput dataGrandModuleAggregateSearchInput)
        {
            var result = await _dataGrandDataSearchAppService.ModuleAggregateSearch(employeeCode, dataGrandModuleAggregateSearchInput);
            if (!result.IsOk())
                Logger.LogWarning(result.Msg);

            return result;
        }
    }
}
