using Com.OPPO.Mo.Thirdparty.DataGrand.Requests;
using Com.OPPO.Mo.Thirdparty.DataGrand.Responses;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Services
{
    /// <summary>
    /// 达观搜索数据查询WebApi接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.DataGrandHost)]
    public interface IDataGrandDataSearchWebApiService : IHttpApi
    {
        /// <summary>
        /// 达观搜索发文数据搜索
        /// </summary>
        /// <param name="dataQueryRequest"><see cref="DataGrandArticleDataQueryRequest"/></param>
        /// <returns></returns>
        [HttpGet("/search/app/search/mo")]
        Task<DataGrandDataQueryResponse<DataGrandArticleDataQueryOutputItem, DataGrandError>> GetDataGrandArticleDataAsync([PathQuery]DataGrandArticleDataQueryRequest dataQueryRequest);

        /// <summary>
        /// 达观搜索便签数据搜索
        /// </summary>
        /// <param name="dataQueryRequest"><see cref="DataGrandMailDataQueryRequest"/></param>
        /// <returns></returns>
        [HttpGet("/search/app/search/mo")]
        Task<DataGrandDataQueryResponse<DataGrandMailDataQueryOutputItem, DataGrandError>> GetDataGrandMailDataAsync([PathQuery] DataGrandMailDataQueryRequest dataQueryRequest);

        /// <summary>
        /// 达观搜索模块数据搜索
        /// </summary>
        /// <param name="dataQueryRequest"><see cref="DataGrandModuleDataQueryRequest"/></param>
        /// <returns></returns>
        [HttpGet("/search/app/search/mo")]
        Task<DataGrandDataQueryResponse<DataGrandModuleDataQueryOutputItem, DataGrandError>> GetDataGrandModuleDataAsync([PathQuery]DataGrandModuleDataQueryRequest dataQueryRequest);

        /// <summary>
        /// 达观搜索数据聚合查询
        /// </summary>
        /// <param name="dataQueryRequest"><see cref="DataGrandAggregateQueryRequest"/></param>
        /// <returns></returns>
        [HttpGet("/search/app/search/mo")]
        Task<DataGrandDataQueryResponse<JObject, DataGrandError>> GetDataGrandAggregateDataAsync([PathQuery]DataGrandAggregateQueryRequest dataQueryRequest);

        /// <summary>
        /// 获取提示词
        /// </summary>
        /// <param name="suggestionRequest"><see cref="DataGrandSuggestionRequest"/></param>
        /// <returns></returns>
        [HttpGet("/search/app/suggest/mo")]
        Task<DataGrandResponse<List<DataGrandSuggestionOutputItem>, DataGrandError>> GetDataGrandSuggestionAsync([PathQuery] DataGrandSuggestionRequest suggestionRequest);
    }
}
