using Com.OPPO.Mo.Thirdparty.Feiheair.Dtos;
using Com.OPPO.Mo.Thirdparty.Feiheair.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.DiDi
{
    /// <summary>
    /// feiheair
    /// </summary>
    [Area("feiheair")]
    [Route("api/mo/thirdparty/feiheair/")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class FeiHeairController : AbpController, IFeiHeairAppService
    {
        private readonly IFeiHeairAppService _feiHeairAppService;

        public FeiHeairController(IFeiHeairAppService feiHeairAppService)
        {
            _feiHeairAppService = feiHeairAppService;
        }

        /// <summary>
        /// 获取Key 【第三方接口：/get_new_key.aspx】
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-key")]
        public async Task<Result<FeiHeairKeyDto>> GetKey()
        {
            return await _feiHeairAppService.GetKey();
        }

        /// <summary>
        /// 创建出差申请单 【第三方接口：/QA/ApplyData.aspx】
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="input">创建出差申请单输入参数</param>
        /// <returns></returns>
        [HttpPost("create-apply-data")]
        public async Task<Result<FeiHeairCreateDto>> ApplyData(string key, string userCode, FeiHeairApplyInput input)
        {
            return await _feiHeairAppService.ApplyData(key,userCode,input);
        }

        /// <summary>
        /// 获取申请单（订单）对应的订单数据 【第三方接口：/QA/getApplicationOrderList.aspx】
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="type">类型（1：申请单号；2：订单号列表（多个订单号用英文,隔开））</param>
        /// <param name="id">单号（值取决于type参数）</param>
        /// <returns></returns>    
        [HttpGet("get-application-order-list")]
        public async Task<Result<FeiHeairOrderDto>> GetOrderList(string key, string userCode, string type, string id)
        {
            return await _feiHeairAppService.GetOrderList(key, userCode, type, id);
        }

        ///// <summary>
        ///// 获取飞鹤自动登录URL 【第三方接口：/login_other.aspx】
        ///// </summary>
        ///// <param name="userCode">用户代码</param>
        ///// <param name="userName">用户名</param>
        ///// <param name="orderNumber">订单号</param>
        ///// <returns></returns>
        //[HttpGet("get-login-url")]
        //public async Task<Result<string>> GetLoginUrl(string userCode, string userName, string orderNumber)
        //{
        //    return await _feiHeairAppService.GetLoginUrl(userCode, userName, orderNumber);
        //}

        /// <summary>
        /// 主动获取消息 【第三方接口：/QA/getOrdeMsg.aspx】
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="lastID">消息Id</param>
        /// <returns></returns> 
        [HttpGet("get-orde-msg")]
        public async Task<Result<FeiHeairOrderMsgDto>> GetOrdeMsg(string key, string userCode,string lastID)
        {
            return await _feiHeairAppService.GetOrdeMsg(key,userCode, lastID);
        }
    }
}
