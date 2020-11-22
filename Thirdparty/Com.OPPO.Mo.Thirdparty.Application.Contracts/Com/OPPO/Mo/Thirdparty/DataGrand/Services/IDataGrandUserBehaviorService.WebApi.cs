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
    /// 达观搜索用户行为服务WebApi接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.DataGrandHost)]
    public interface IDataGrandUserBehaviorWebApiService : IHttpApi
    {
        /// <summary>
        /// 新增用户搜索行为
        /// </summary>
        /// <param name="behaviorOperationRequest"><see cref="DataGrandUserBehaviorOperationRequest{DataGrandUserSearchBehaviorAddInputItem}"/></param>
        /// <returns></returns>
        [HttpPost("/search/upload/action/mo")]
        Task<DataGrandResponse<DataGrandError>> AddDataGrandUserSearchBehaviorAsync([MulitpartContent]DataGrandUserBehaviorOperationRequest<DataGrandUserSearchBehaviorAddInputItem> behaviorOperationRequest);

        /// <summary>
        /// 新增用户点击行为
        /// </summary>
        /// <param name="behaviorOperationRequest"><see cref="DataGrandUserBehaviorOperationRequest{DataGrandUserClickBehaviorAddInputItem}"/></param>
        /// <returns></returns>
        [HttpPost("/search/upload/action/mo")]
        Task<DataGrandResponse<DataGrandError>> AddDataGrandUserClickBehaviorAsync([MulitpartContent]DataGrandUserBehaviorOperationRequest<DataGrandUserClickBehaviorAddInputItem> behaviorOperationRequest);
    }
}
