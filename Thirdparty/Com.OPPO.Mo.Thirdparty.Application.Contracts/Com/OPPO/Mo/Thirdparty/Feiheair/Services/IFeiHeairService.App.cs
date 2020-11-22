using Com.OPPO.Mo.Thirdparty.Feiheair.Dtos;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Feiheair.Services
{
    /// <summary>
    /// 飞鹤如意差服务接口
    /// </summary>
    public interface IFeiHeairAppService : IApplicationService
    {
        /// <summary>
        /// 获取飞鹤key
        /// </summary>
        /// <returns></returns>
        Task<Result<FeiHeairKeyDto>> GetKey();

        /// <summary>
        /// 创建出差申请单
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="input"><see cref="FeiHeairApplyInput"/></param>
        /// <returns></returns>
        Task<Result<FeiHeairCreateDto>> ApplyData(string key, string userCode, FeiHeairApplyInput input);


        ///// <summary>
        ///// 获取飞鹤自动登录URL
        ///// </summary>
        ///// <param name="userCode">用户代码</param>
        ///// <param name="userName">用户名</param>
        ///// <param name="orderNumber">订单号</param>
        ///// <returns></returns>
        //Task<Result<string>> GetLoginUrl(string userCode, string userName, string orderNumber);

        /// <summary>
        /// 获取申请单（订单）对应的订单数据
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="type">类型（1：申请单号；2：订单号列表（多个订单号用英文,隔开））</param>
        /// <param name="id">单号（值取决于type参数）</param>
        /// <returns></returns>
        Task<Result<FeiHeairOrderDto>> GetOrderList(string key,string userCode, string type, string id);

        /// <summary>
        /// 主动获取消息
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="lastID">消息Id</param>
        /// <returns></returns> 
        Task<Result<FeiHeairOrderMsgDto>> GetOrdeMsg(string key, string userCode,string lastID);

    }
}
