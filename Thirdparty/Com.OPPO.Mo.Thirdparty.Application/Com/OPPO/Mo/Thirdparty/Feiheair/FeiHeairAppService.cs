using Com.OPPO.Mo.Thirdparty.Feiheair.Dtos;
using Com.OPPO.Mo.Thirdparty.Feiheair.Requests;
using Com.OPPO.Mo.Thirdparty.Feiheair.Services;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Feiheair
{
    /// <summary>
    ///飞鹤如意差服务实现类
    /// </summary>
    [Authorize]
    public class FeiHeairAppService : ThirdpartyAppServiceBase, IFeiHeairAppService
    {
        private readonly IFeiHeairServiceWebApiService _feiHeairServiceWebApiService;

        public FeiHeairAppService(IFeiHeairServiceWebApiService feiHeairServiceWebApiService)
        {
            _feiHeairServiceWebApiService = feiHeairServiceWebApiService;
        }

        /// <summary>
        /// 获取飞鹤key
        /// </summary>
        /// <returns></returns>
        public async Task<Result<FeiHeairKeyDto>> GetKey()
        {
            var response = await _feiHeairServiceWebApiService.GeKey(new FeiHeairKeyRequest { });

            var info = ObjectMapper.Map<FeiHeairKeyInfo, FeiHeairKeyDto>(response);

            return Result.FromData(info);
        }

        /// <summary>
        /// 创建出差申请单
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="input"><see cref="FeiHeairApplyInput"/></param>
        /// <returns></returns>
        public async Task<Result<FeiHeairCreateDto>> ApplyData(string key, string userCode, FeiHeairApplyInput input)
        {
            if (string.IsNullOrWhiteSpace(key))
                return Result.FromError<FeiHeairCreateDto>($"缺失参数{nameof(key)}。");

            if (string.IsNullOrWhiteSpace(userCode))
                return Result.FromError<FeiHeairCreateDto>($"缺失参数{nameof(userCode)}。");

            if (input == null)
                return Result.FromError<FeiHeairCreateDto>($"缺失参数{nameof(input)}。");

            var jsonData = JsonConvert.SerializeObject(input);

            var response = await _feiHeairServiceWebApiService.ApplyData(new FeiHeairApplyDataRequest
            {
                Key = key,
                UserCode = userCode,
                Data = jsonData
            });

            var info = ObjectMapper.Map<FeiHeairRespone, FeiHeairCreateDto>(response);

            return Result.FromData(info);
        }


        /// <summary>
        /// 获取申请单（订单）对应的订单数据
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="type">类型（1：申请单号；2：订单号列表（多个订单号用英文,隔开））</param>
        /// <param name="id">单号（值取决于type参数）</param>
        /// <returns></returns>
        public async Task<Result<FeiHeairOrderDto>> GetOrderList(string key, string userCode, string type, string id)
        {
            if (string.IsNullOrWhiteSpace(key))
                return Result.FromError<FeiHeairOrderDto>($"缺失参数{nameof(key)}。");

            if (string.IsNullOrWhiteSpace(userCode))
                return Result.FromError<FeiHeairOrderDto>($"缺失参数{nameof(userCode)}。");

            if (string.IsNullOrWhiteSpace(type))
                return Result.FromError<FeiHeairOrderDto>($"缺失参数{nameof(type)}。");

            if (string.IsNullOrWhiteSpace(id))
                return Result.FromError<FeiHeairOrderDto>($"缺失参数{nameof(id)}。");

            var response = await _feiHeairServiceWebApiService.GetOrderList(new FeiHeairOrderRequest
            {
                Key = key,
                UserCode = userCode,
                Type = type,
                Id = id
            });

            var info = ObjectMapper.Map<FeiHeairOrderInfo, FeiHeairOrderDto>(response);

            return Result.FromData(info);
        }

        /// <summary>
        /// 主动获取消息
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="lastID">消息Id</param>
        /// <returns></returns> 
        public async Task<Result<FeiHeairOrderMsgDto>> GetOrdeMsg(string key, string userCode, string lastID)
        {
            if (string.IsNullOrWhiteSpace(key))
                return Result.FromError<FeiHeairOrderMsgDto>($"缺失参数{nameof(key)}。");

            if (string.IsNullOrWhiteSpace(lastID))
                return Result.FromError<FeiHeairOrderMsgDto>($"缺失参数{nameof(lastID)}。");

            if (string.IsNullOrWhiteSpace(userCode))
                return Result.FromError<FeiHeairOrderMsgDto>($"缺失参数{nameof(userCode)}。");


            var response = await _feiHeairServiceWebApiService.GetOrdeMsg(new FeiHeairOrderMsgRequest
            {
                Key = key,
                UserCode = userCode,
                LastID = lastID
            });

            return Result.FromData(response);
        }



        ///// <summary>
        ///// 获取飞鹤自动登录URL
        ///// </summary>
        ///// <param name="userCode">用户代码</param>
        ///// <param name="userName">用户名</param>
        ///// <param name="orderNumber">订单号</param>
        ///// <returns></returns>
        //public async Task<Result<string>> GetLoginUrl(string userCode, string userName, string orderNumber)
        //{
        //    if (string.IsNullOrWhiteSpace(userCode))
        //        return Result.FromError<string>($"缺失参数{nameof(userCode)}。");

        //    else if (userCode.Equals("system"))
        //        return Result.FromError<string>($"{nameof(userCode)}参数不能用 system。");

        //    if (string.IsNullOrWhiteSpace(userName))
        //        return Result.FromError<string>($"缺失参数{nameof(userName)}。");

        //    if (string.IsNullOrWhiteSpace(orderNumber))
        //        return Result.FromError<string>($"缺失参数{nameof(orderNumber)}。");

        //    var response = await _feiHeairServiceWebApiService.GetLoginUrl(new FeiHeairLoginRequest
        //    {
        //        UserCode = userCode,
        //        UserName = userName,
        //        OrderNumber = orderNumber
        //    });

        //    return Result.FromData(response);
        //}

    }
}
