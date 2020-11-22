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
    /// 达观搜索权限服务WebApi接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.DataGrandHost)]
    public interface IDataGrandPermissionWebApiService : IHttpApi
    {
        /// <summary>
        /// 达观搜索权限新增或覆盖(记录存在则更新，不存在则新增)
        /// </summary>
        /// <param name="permissionOperationRequest"><see cref="DataGrandPermissionOperationRequest{DataGrandPermissionAddInputItem}"/></param>
        /// <returns></returns>
        //[HttpPost("/permission/upload/mo?ss=232&kk=232")]
        [HttpPost("/search/permission/upload/mo")]
        Task<DataGrandResponse<string>> AddOrCoverDataGrandPermissionAsync([MulitpartContent] DataGrandPermissionOperationRequest<DataGrandPermissionAddOrUpdateInputItem> permissionOperationRequest);

        /// <summary>
        /// 达观搜索权限删除
        /// </summary>
        /// <param name="permissionOperationRequest"><see cref="DataGrandPermissionOperationRequest{DataGrandPermissionDeleteInputItem}"/></param>
        /// <returns></returns>
        [HttpPost("/search/permission/upload/mo")]
        Task<DataGrandResponse<string>> DeleteDataGrandPermissionAsync([MulitpartContent] DataGrandPermissionOperationRequest<DataGrandPermissionDeleteInputItem> permissionOperationRequest);

        /// <summary>
        /// 按操作批次清空达观搜索权限
        /// </summary>
        /// <param name="deletePermissionByActionRequest"><see cref="DataGrandPermissionDeleteByActionRequest"/></param>
        /// <returns></returns>
        [HttpPost("/search/permission/refresh/mo")]
        Task<DataGrandResponse<string>> DeleteDataGrandPermissionByActionIdAsync([MulitpartContent]DataGrandPermissionDeleteByActionRequest deletePermissionByActionRequest);

        /// <summary>
        /// 达观搜索权限按用户批量删除
        /// </summary>
        /// <param name="deletePermissionByUserRequest"><see cref="DataGrandPermissionDeleteByUserRequest"/></param>
        /// <returns></returns>
        [HttpPost("/search/permission/refresh_batch/mo")]
        Task<DataGrandResponse<string>> DeleteDataGrandPermissionByUserAsync([FormContent]DataGrandPermissionDeleteByUserRequest deletePermissionByUserRequest);

        /// <summary>
        /// 达观搜索权限查询
        /// </summary>
        /// <param name="permissionQueryRequest"><see cref="DataGrandPermissionQueryRequest"/></param>
        /// <returns></returns>
        [HttpPost("/search/permission/search/mo")]
        Task<DataGrandPermissionQueryResponse> QueryDataGrandPermissionAsync([PathQuery] DataGrandPermissionQueryRequest permissionQueryRequest);

    }
}
