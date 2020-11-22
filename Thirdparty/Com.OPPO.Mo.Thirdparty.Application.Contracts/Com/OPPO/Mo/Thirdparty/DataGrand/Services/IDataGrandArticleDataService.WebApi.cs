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
    /// 达观搜索发文数据服务WebApi接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    public interface IDataGrandArticleDataWebApiService : IHttpApi
    {
        /// <summary>
        /// 达观搜索发文数据新增或者覆盖
        /// </summary>
        /// <param name="dataOperationRequest"><see cref="DataGrandDataOperationRequest{DataGrandArticleDataAddInputItem}"/></param>
        /// <returns></returns>
        [HttpPost("/search/data/mo")]
        Task<DataGrandResponse<DataGrandError>> AddOrCoverDataGrandArticleDataAsync([MulitpartContent] DataGrandDataOperationRequest<DataGrandArticleDataAddInputItem> dataOperationRequest);

        /// <summary>
        /// 达观搜索发文数据更新
        /// </summary>
        /// <param name="dataOperationRequest"><see cref="DataGrandDataOperationRequest{DataGrandArticleDataUpdateInputItem}"/></param>
        /// <returns></returns>
        [HttpPost("/search/data/mo")]
        Task<DataGrandResponse<DataGrandError>> UpdateDataGrandArticleDataAsync([MulitpartContent] DataGrandDataOperationRequest<DataGrandArticleDataUpdateInputItem> dataOperationRequest);

        /// <summary>
        /// 达观搜索发文数据删除
        /// </summary>
        /// <param name="dataOperationRequest"><see cref="DataGrandDataOperationRequest{DataGrandArticleDataDeleteInputItem}"/></param>
        /// <returns></returns>
        [HttpPost("/search/data/mo")]
        Task<DataGrandResponse<DataGrandError>> DeleteDataGrandArticleDataAsync([MulitpartContent] DataGrandDataOperationRequest<DataGrandArticleDataDeleteInputItem> dataOperationRequest);
    }
}
