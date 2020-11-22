using Com.OPPO.Mo.Thirdparty.DataGrand.Requests;
using Com.OPPO.Mo.Thirdparty.DataGrand.Responses;
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
    /// 达观搜索提示词服务WebApi接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.DataGrandHost)]
    public interface IDataGrandSuggestionWebApiService : IHttpApi
    {
        /// <summary>
        /// 分页获取提示词
        /// </summary>
        /// <param name="suggestionDataQueryRequest"><see cref="DataGrandSuggestionDataQueryRequest"/></param>
        /// <returns></returns>
        [HttpGet("/search/suggest/search/mo")]
        Task<DataGrandDataQueryResponse<DataGrandSuggestionQueryOutputItem, DataGrandError>> GetPagedDataGrandSuggestionAsync([PathQuery] DataGrandSuggestionDataQueryRequest suggestionDataQueryRequest);

        /// <summary>
        /// 新增或者覆盖提示词
        /// </summary>
        /// <param name="suggestionOperationRequest"><see cref="DataGrandDataOperation{DataGrandSuggestionAddInputItem}"/></param>
        /// <returns></returns>
        [HttpPost("/search/suggest/action/mo")]
        Task<DataGrandResponse<DataGrandError>> AddOrCoverSuggestionAsync([MulitpartContent]DataGrandSuggestionOperationRequest<DataGrandSuggestionAddInputItem> suggestionOperationRequest);

        /// <summary>
        /// 删除提示词
        /// </summary>
        /// <param name="suggestionOperationRequest"><see cref="DataGrandDataOperation{DataGrandSuggestionDeleteInput}"/></param>
        /// <returns></returns>
        [HttpPost("/search/suggest/action/mo")]
        Task<DataGrandResponse<DataGrandError>> DeleteDataGrandSuggesionAsync([MulitpartContent]DataGrandSuggestionOperationRequest<DataGrandSuggestionDeleteInputItem> suggestionOperationRequest);

        /// <summary>
        /// 清空提示词，包括：
        /// 1、全量删除<see cref="DataGrandSuggestionOperationType.refresh_all"/>
        /// 2、删除私有<see cref="DataGrandSuggestionOperationType.refresh_private"/>
        /// 3、删除公有<see cref="DataGrandSuggestionOperationType.refresh_public"/>
        /// </summary>
        /// <param name="suggestionOperationRequest"><see cref="DataGrandSuggestionRefreshOperationRequest"/></param>
        /// <returns></returns>
        [HttpPost("/search/suggest/batch/mo")]
        Task<DataGrandResponse<DataGrandError>> RefreshDataGrandSuggestionAsync([MulitpartContent]DataGrandSuggestionRefreshOperationRequest suggestionOperationRequest);
    }
}
