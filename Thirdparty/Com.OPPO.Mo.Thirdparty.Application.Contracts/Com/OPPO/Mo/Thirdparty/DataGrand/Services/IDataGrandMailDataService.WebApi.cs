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
    /// 达观搜索便签数据服务WebApi接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.DataGrandHost)]
    public interface IDataGrandMailDataWebApiService : IHttpApi
    {
        /// <summary>
        /// 达观搜索便签数据新增或者覆盖
        /// </summary>
        /// <param name="dataOperationRequest"><see cref="DataGrandDataOperationRequest{DataGrandMailDataAddInputItem}"/></param>
        /// <returns></returns>
        [HttpPost("/search/data/mo")]
        Task<DataGrandResponse<DataGrandError>> DataGrandMailDataAddOrCoverAsync([MulitpartContent]DataGrandDataOperationRequest<DataGrandMailDataAddInputItem> dataOperationRequest);

        /// <summary>
        /// 达观搜索便签数据更新
        /// </summary>
        /// <param name="dataOperationRequest"><see cref="DataGrandDataOperationRequest{DataGrandMailDataUpdateInputItem}"/></param>
        /// <returns></returns>
        [HttpPost("/search/data/mo")]
        Task<DataGrandResponse<DataGrandError>> DataGrandMailDataUpdateAsync([MulitpartContent] DataGrandDataOperationRequest<DataGrandMailDataUpdateInputItem> dataOperationRequest);

        /// <summary>
        /// 达观搜索便签数据删除
        /// </summary>
        /// <param name="dataOperationRequest"><see cref="DataGrandDataOperationRequest{DataGrandMailDataDeleteInputItem}"/></param>
        /// <returns></returns>
        [HttpPost("/search/data/mo")]
        Task<DataGrandResponse<DataGrandError>> DataGrandMailDataDeleteAsync([MulitpartContent] DataGrandDataOperationRequest<DataGrandMailDataDeleteInputItem> dataOperationRequest);
    }
}
