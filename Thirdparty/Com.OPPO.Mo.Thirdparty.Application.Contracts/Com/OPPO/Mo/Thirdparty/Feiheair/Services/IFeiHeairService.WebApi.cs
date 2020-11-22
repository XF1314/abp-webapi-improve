using Com.OPPO.Mo.Thirdparty.Feiheair.Dtos;
using Com.OPPO.Mo.Thirdparty.Feiheair.Requests;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Feiheair.Services
{
    /// <summary>
    /// 飞鹤如意差 webApi
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = true)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.FeiheairApiHost)]
    public interface IFeiHeairServiceWebApiService : IHttpApi
    {
        /// <summary>
        /// 获取key
        /// </summary>
        /// <param name="request"><see cref="FeiHeairKeyRequest"/></param>
        /// <returns></returns> 
        [HttpGet("/get_new_key.aspx")]
        [XmlReturn]
        Task<FeiHeairKeyInfo> GeKey([PathQuery] FeiHeairKeyRequest request);

        /// <summary>
        /// 创建出差申请单
        /// </summary>
        /// <param name="request"><see cref="FeiHeairApplyDataRequest"/></param>
        /// <returns></returns> 
        [HttpPost("/QA/ApplyData.aspx")]
        [JsonReturn]
        Task<FeiHeairRespone> ApplyData([FormContent] FeiHeairApplyDataRequest request);

        /// <summary>
        /// 获取申请单（订单）对应的订单数据
        /// </summary>
        /// <param name="request"><see cref="FeiHeairOrderRequest"/></param>
        /// <returns></returns> 
        [HttpPost("/QA/getApplicationOrderList.aspx")]
        [JsonReturn]
        Task<FeiHeairOrderInfo> GetOrderList([FormContent] FeiHeairOrderRequest request);

        /// <summary>
        /// 获取飞鹤自动登录URL 
        /// </summary>
        /// <param name="request"><see cref="FeiHeairLoginRequest"/></param>
        /// <returns></returns> 
        [HttpGet("/login_other.aspx")]
        Task<string> GetLoginUrl([PathQuery] FeiHeairLoginRequest request);

        /// <summary>
        /// 主动获取消息
        /// </summary>
        /// <param name="request"><see cref="FeiHeairOrderMsgRequest"/></param>
        /// <returns></returns> 
        [HttpGet("/QA/getOrdeMsg.aspx")]
        [JsonReturn]
        Task<FeiHeairOrderMsgDto> GetOrdeMsg([PathQuery] FeiHeairOrderMsgRequest request);


    }
}
