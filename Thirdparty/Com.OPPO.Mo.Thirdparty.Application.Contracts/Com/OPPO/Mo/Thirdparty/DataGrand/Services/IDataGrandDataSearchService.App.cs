using Com.OPPO.Mo.Thirdparty.DataGrand.Dtos;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Services
{
    public interface IDataGrandDataSearchAppService : IApplicationService
    {
        /// <summary>
        /// 聚合搜索
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="dataGrandAggregateSearchInput"><see cref="DataGrandAggregateSearchInput"/></param>
        /// <returns></returns>
        Task<Result<DataGrandSearchOutput>> AggregateSearch( string userCode, DataGrandAggregateSearchInput dataGrandAggregateSearchInput);

        /// <summary>
        /// 发文聚合搜索
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="dataGrandArticleAggregateSearchInput"><see cref="DataGrandArticleAggregateSearchInput"/></param>
        /// <returns></returns>
        Task<Result<DataGrandSearchOutput>> ArticleAggregateSearch(string userCode, DataGrandArticleAggregateSearchInput dataGrandArticleAggregateSearchInput);

        /// <summary>
        /// 便签聚合搜索
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="dataGrandMailAggregateSearchInput"><see cref="DataGrandMailAggregateSearchInput"/></param>
        /// <returns></returns>
        Task<Result<DataGrandSearchOutput>> MailAggregateSearch(string userCode, DataGrandMailAggregateSearchInput dataGrandMailAggregateSearchInput);

        /// <summary>
        /// 模块聚合搜索
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="dataGrandModuleAggregateSearchInput"><see cref="DataGrandModuleAggregateSearchInput"/></param>
        /// <returns></returns>
        Task<Result<DataGrandSearchOutput>> ModuleAggregateSearch(string userCode, DataGrandModuleAggregateSearchInput dataGrandModuleAggregateSearchInput);
    }
}
