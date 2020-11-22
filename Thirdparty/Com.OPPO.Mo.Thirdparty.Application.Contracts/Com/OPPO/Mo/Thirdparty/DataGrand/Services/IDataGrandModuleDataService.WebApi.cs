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
    /// 达观搜索模块数据服务WebApi接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.DataGrandHost)]
    public interface IDataGrandModuleDataWebApiService : IHttpApi
    {
        /// <summary>
        /// 达观搜索模块数据新增或者覆盖
        /// </summary>
        /// <param name="dataOperationRequest"><see cref="DataGrandDataOperation{DataGrandModuleDataAddInputItem}"/></param>
        /// <returns></returns>
        [HttpPost("/search/data/mo")]
        Task<DataGrandResponse<DataGrandError>> AddOrCoverDataGrandModuleDataAsync([MulitpartContent] DataGrandDataOperationRequest<DataGrandModuleDataAddInputItem> dataOperationRequest);

        /// <summary>
        /// 达观搜索模块数据删除Input
        /// </summary>
        /// <param name="dataOperationRequest"><see cref="DataGrandDataOperation{DataGrandModuleDataDeleteInputItem}"/></param>
        /// <returns></returns>
        [HttpPost("/search/data/mo")]
        Task<DataGrandResponse<DataGrandError>> DeleteDataGrandModuleDataAsync([MulitpartContent]DataGrandDataOperationRequest<DataGrandModuleDataDeleteInputItem> dataOperationRequest);

        /// <summary>
        /// 达观搜索模块数据更新
        /// </summary>
        /// <param name="dataOperationRequest"><see cref="DataGrandDataOperation{DataGrandModuleDataUpdateInputItem}"/></param>
        /// <returns></returns>
        [HttpPost("/search/data/mo")]
        Task<DataGrandResponse<DataGrandError>> UpdateDataGrandModuleDataAsync([MulitpartContent]DataGrandDataOperationRequest<DataGrandModuleDataUpdateInputItem> dataOperationRequest);

        /// <summary>
        /// 达观搜索模块关键字更新
        /// </summary>
        /// <param name="dataOperationRequest"><see cref="DataGrandDataOperation{DataGrandModuleKeywordsUpdateInputItem}"/></param>
        /// <returns></returns>
        [HttpPost("/search/data/mo")]
        Task<DataGrandResponse<DataGrandError>> UpdateDataGrandModuleKeywordsAsync([MulitpartContent]DataGrandDataOperationRequest<DataGrandModuleKeywordsUpdateInputItem> dataOperationRequest);

        /// <summary>
        /// 达观搜索模块权限更新 
        /// </summary>
        /// <param name="dataOperationRequest"><see cref="DataGrandDataOperation{DataGrandModuleDataUpdateInputItem}"/></param>
        /// <returns></returns>
        [HttpPost("/search/data/mo")]
        Task<DataGrandResponse<DataGrandError>> UpdateDataGrandModulePermssionAsync([MulitpartContent]DataGrandDataOperationRequest<DataGrandModulePermissionUpdateInputItem> dataOperationRequest);
    }
}
