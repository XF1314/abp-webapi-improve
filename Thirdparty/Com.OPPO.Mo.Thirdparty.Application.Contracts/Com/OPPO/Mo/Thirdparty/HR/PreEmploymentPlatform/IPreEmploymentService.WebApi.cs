
using Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform.Request;
using Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform
{

    /// <summary>
    /// 预入职平台服务
    /// </summary>
    //[AutoReturn(EnsureSuccessStatusCode = false)]
    [ConfigurableHttpHost(ThirdpartySettingNames.PreWebApiHost)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    public interface IPreEmploymentWebApiService : IHttpApi
    {

        /// <summary>
        /// 员工数据同步接口
        /// </summary>
        /// <param name="employment"></param>
        /// <returns></returns>
        [HttpPost("/hostip/staff/info")]
        Task<SyncResponse> EmployeeDataSync([JsonContent]EmploymentRequest employment);

        /// <summary>
        /// 办公用具领用状态同步
        /// </summary>
        /// <param name="receiveState"></param>
        /// <returns></returns>
        [HttpPost("/hostip/entry/office")]
        Task<EsbResponseBody> ReceiveStateSync([JsonContent]ReceiveStateRequest receiveState);

        /// <summary>
        /// 招聘平台获取员工信息
        /// </summary>
        /// <param name="employQuery"></param>
        /// <returns></returns>
        [HttpPost("/recruit/queryRecruit")]
        Task<EmployDataResponse> GetEmployeeData([JsonContent]GetEmployRequest employQuery);
    }
}
