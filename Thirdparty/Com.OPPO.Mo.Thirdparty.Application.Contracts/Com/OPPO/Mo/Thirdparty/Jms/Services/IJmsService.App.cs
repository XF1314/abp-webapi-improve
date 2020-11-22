using Com.OPPO.Mo.Thirdparty.Jms.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Jms
{
    /// <summary>
    /// 跳板机 应用服务
    /// </summary>
    public interface IJmsAppService : IApplicationService
    {
        /// <summary>
        /// 获取所有跳板机产品
        /// </summary>
        /// <returns></returns>
        Task<Result<List<string>>> GetAllJmsProducts();

        /// <summary>
        /// 根据跳板机产品获取服务
        /// </summary>
        /// <param name="product">产品</param>
        /// <returns></returns>
        Task<Result<List<string>>> GetServiceByProduct(string product);

        /// <summary>
        /// 根据跳板机产品和服务获取模块
        /// </summary>
        /// <param name="product">产品</param>
        /// <param name="service">服务</param>
        /// <returns></returns>
        Task<Result<List<string>>> GetModuleByProductAndService(string product, string service);

        /// <summary>
        /// 根据跳板机ip获取服务器信息
        /// </summary>
        /// <param name="ip">ip</param>
        /// <returns></returns>
        Task<Result<JmsHostDto>> GetHostInfoByIp(string ip);

        /// <summary>
        /// 根据跳板机主机名称获取服务器信息
        /// </summary>
        /// <param name="hostName">主机名称</param>
        /// <returns></returns>
        Task<Result<JmsHostDto>> GetHostInfoByHostName(string hostName);

        /// <summary>
        /// 根据用户和业务树获取跳板机业务Owner
        /// </summary>
        /// <param name="userCode">用户工号</param>
        /// <param name="bussinesses">业务s</param>
        /// <returns></returns>
        Task<Result<JmsBusinessOwnerDto>> GetJmsBusinessOwnerByUserAndBusinessTree(string userCode, List<string> bussinesses);

        /// <summary>
        /// 新增跳板机权限
        /// </summary>
        /// <param name="jmsPermissionAddInput"><see cref="JmsPermissionAddInput"/></param>
        /// <returns></returns>
        Task<Result> AddPermission(JmsPermissionAddInput jmsPermissionAddInput);

        /// <summary>
        /// 跳板机流程结束回调
        /// </summary>
        /// <param name="jmsProcessFinishCallbackInput"><see cref="JmsProcessFinishCallbackInput"/></param>
        /// <returns></returns>
        Task<Result> CallbackWhenProcessFinished(JmsProcessFinishCallbackInput jmsProcessFinishCallbackInput);
    }
}
