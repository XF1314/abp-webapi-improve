using Com.OPPO.Mo.Thirdparty.Jms.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Jms
{
    /// <summary>
    /// 跳板机系统
    /// </summary>
    [Area("jms")]
    [Route("api/mo/thirdparty/jms")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class JmsController : AbpController, IJmsAppService
    {
        private readonly IJmsAppService _jmsAppService;

        /// <summary>
        /// <see cref="JmsController"/>
        /// </summary>
        public JmsController(IJmsAppService jmsAppService)
        {
            _jmsAppService = jmsAppService;
        }

        /// <summary>
        /// 获取所有跳板机产品【第三方接口：api/oppo/v1/mo/product-list】
        /// </summary>
        /// <returns></returns>
        [HttpGet("products")]
        public async Task<Result<List<string>>> GetAllJmsProducts()
        {
            return await _jmsAppService.GetAllJmsProducts();
        }

        /// <summary>
        /// 根据跳板机产品获取服务【第三方接口：api/oppo/v1/mo/get-service-by-product】
        /// </summary>
        /// <param name="product">产品</param>
        /// <returns></returns>
        [HttpGet("services/get-by-product")]
        public async Task<Result<List<string>>> GetServiceByProduct(string product)
        {
            return await _jmsAppService.GetServiceByProduct(product);
        }

        /// <summary>
        /// 根据跳板机产品和服务获取模块【第三方接口：api/oppo/v1/mo/get-module-by-product-service】
        /// </summary>
        /// <param name="product">产品</param>
        /// <param name="service">服务</param>
        /// <returns></returns>
        [HttpGet("modules/get-by-product-service")]
        public async Task<Result<List<string>>> GetModuleByProductAndService(string product, string service)
        {
            return await _jmsAppService.GetModuleByProductAndService(product, service);
        }

        /// <summary>
        /// 根据跳板机ip获取服务器信息【第三方接口：api/oppo/v1/mo/host/info】
        /// </summary>
        /// <param name="ip">ip 地址</param>
        /// <returns></returns>
        [HttpGet("hosts/get-by-ip")]
        public async Task<Result<JmsHostDto>> GetHostInfoByIp(string ip)
        {
            return await _jmsAppService.GetHostInfoByIp(ip);
        }

        /// <summary>
        /// 根据跳板机主机名称获取服务器信息【第三方接口：api/oppo/v1/mo/host/info】
        /// </summary>
        /// <param name="hostName">主机名称</param>
        /// <returns></returns>
        [HttpGet("hosts/get-by-name")]
        public async Task<Result<JmsHostDto>> GetHostInfoByHostName(string hostName)
        {
            return await _jmsAppService.GetHostInfoByHostName(hostName);
        }

        /// <summary>
        /// 根据用户和业务树获取跳板机业务Owner【第三方接口：api/oppo/v1/mo/business/owner】
        /// </summary>
        /// <param name="userCode">用户工号</param>
        /// <param name="bussinesses">业务s</param>
        /// <returns></returns>
        [HttpGet("business-owner")]
        public async Task<Result<JmsBusinessOwnerDto>> GetJmsBusinessOwnerByUserAndBusinessTree(string userCode, List<string> bussinesses)
        {
            return await _jmsAppService.GetJmsBusinessOwnerByUserAndBusinessTree(userCode, bussinesses);
        }

        /// <summary>
        /// 新增跳板机权限【第三方接口：api/oppo/v1/mo/asset-permissions/add】
        /// </summary>
        /// <param name="jmsPermissionAddInput"><see cref="JmsPermissionAddInput"/></param>
        /// <returns></returns>
        [HttpPost("permissions")]
        public async Task<Result> AddPermission(JmsPermissionAddInput jmsPermissionAddInput)
        {
            return await _jmsAppService.AddPermission(jmsPermissionAddInput);
        }

        /// <summary>
        /// 跳板机流程结束回调，驳回或者审批完成【第三方接口：api/oppo/v1/mo/tmp-perm/update】
        /// </summary>
        /// <param name="jmsProcessFinishCallbackInput"><see cref="JmsProcessFinishCallbackInput"/></param>
        /// <returns></returns>
        [HttpPost("callback-when-process-finished")]
        public async Task<Result> CallbackWhenProcessFinished(JmsProcessFinishCallbackInput jmsProcessFinishCallbackInput)
        {
            return await _jmsAppService.CallbackWhenProcessFinished(jmsProcessFinishCallbackInput);
        }
    }
}
