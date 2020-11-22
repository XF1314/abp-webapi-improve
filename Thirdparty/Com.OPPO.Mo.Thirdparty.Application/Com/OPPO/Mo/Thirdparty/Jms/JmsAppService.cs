using Com.OPPO.Mo.Thirdparty.Jms.Dtos;
using Com.OPPO.Mo.Thirdparty.Jms.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Jms
{
    [Authorize]
    public class JmsAppService : ThirdpartyAppServiceBase, IJmsAppService
    {
        /// <inheritdoc/>
        public async Task<Result<List<string>>> GetAllJmsProducts()
        {
            var jmsProductInfoWebApiService = ServiceProvider.GetRequiredService<IJmsProductInfoWebApiService>();
            var response = await jmsProductInfoWebApiService.GetAllProducts(new BaseJmsRequest());

            if (response.IsOk)
                return Result.FromData(response.Body.Data);
            else
            {
                var message = $"【{response.Code}】{response.Message}";
                Logger.LogWarning(message);
                return Result.FromError<List<string>>(message);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<string>>> GetServiceByProduct(string product)
        {
            if (string.IsNullOrWhiteSpace(product))
                return Result.FromError<List<string>>($"缺失参数{nameof(product)}。");
            else
            {
                var jmsServiceInfoWebApiService = ServiceProvider.GetRequiredService<IJmsServiceInfoWebApiService>();
                var response = await jmsServiceInfoWebApiService.GetServiceByProduct(new JmsServiceQueryRequest
                {
                    Product = product
                });

                if (response.IsOk)
                    return Result.FromData(response.Body.Data);
                else
                {
                    var message = $"【{response.Code}】{response.Message}";
                    Logger.LogWarning(message);
                    return Result.FromError<List<string>>(message);
                }

            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<string>>> GetModuleByProductAndService(string product, string service)
        {
            if (string.IsNullOrWhiteSpace(product))
                return Result.FromError<List<string>>($"缺失参数{nameof(product)}。");
            else if (string.IsNullOrWhiteSpace(service))
                return Result.FromError<List<string>>($"缺失参数{nameof(service)}。");
            else
            {
                var jmsModuleInfoWebApiService = ServiceProvider.GetRequiredService<IJmsModuleInfoWebApiService>();
                var response = await jmsModuleInfoWebApiService.GetJmsModuleByProductAndService(new JmsModuleQueryRequest
                {
                    Product = product,
                    Service = service
                });

                if (response.IsOk)
                    return Result.FromData(response.Body.Data);
                else
                {
                    var message = $"【{response.Code}】{response.Message}";
                    Logger.LogWarning(message);
                    return Result.FromError<List<string>>(message);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<JmsHostDto>> GetHostInfoByHostName(string hostName)
        {
            if (string.IsNullOrWhiteSpace(hostName))
                return Result.FromError<JmsHostDto>($"缺失参数{nameof(hostName)}。");
            else
            {
                var jmsHostInfoWebApiService = ServiceProvider.GetRequiredService<IJmsHostInfoWebApiService>();
                var response = await jmsHostInfoWebApiService.GetHostInfoByIpOrHostName(new JmsHostInfoQueryRequest
                {
                    HostName = hostName
                });

                if (response.IsOk)
                    return Result.FromData(new JmsHostDto
                    {
                        Ip = response.Body.Data.Ip,
                        HostName = response.Body.Data.HostName,
                        Businesses = response.Body.Data.Businesses
                    });
                else
                {
                    var message = $"【{response.Code}】{response.Message}";
                    Logger.LogWarning(message);
                    return Result.FromError<JmsHostDto>(message);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<JmsHostDto>> GetHostInfoByIp(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
                return Result.FromError<JmsHostDto>($"缺失参数{nameof(ip)}。");
            else
            {
                var jmsHostInfoWebApiService = ServiceProvider.GetRequiredService<IJmsHostInfoWebApiService>();
                var response = await jmsHostInfoWebApiService.GetHostInfoByIpOrHostName(new JmsHostInfoQueryRequest
                {
                    Ip = ip
                });

                if (response.IsOk)
                    return Result.FromData(new JmsHostDto
                    {
                        Ip = response.Body.Data.Ip,
                        HostName = response.Body.Data.HostName,
                        Businesses = response.Body.Data.Businesses
                    });
                else
                {
                    var message = $"【{response.Code}】{response.Message}";
                    Logger.LogWarning(message);
                    return Result.FromError<JmsHostDto>(message);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<JmsBusinessOwnerDto>> GetJmsBusinessOwnerByUserAndBusinessTree(string userCode, List<string> bussinesses)
        {
            if (string.IsNullOrWhiteSpace(userCode))
                return Result.FromError<JmsBusinessOwnerDto>($"缺失参数{nameof(userCode)}。");
            else
            {
                var jmsBusinessInfoWebApiService = ServiceProvider.GetRequiredService<IJmsBusinessInfoWebApiService>();
                var response = await jmsBusinessInfoWebApiService.GetJmsBusinessOwnerByUserAndBusinessTree(new JmsBusinessOwnerQueryRequest
                {
                    UserCode = userCode,
                    Business = bussinesses
                });

                if (response.IsOk)
                    return Result.FromData(new JmsBusinessOwnerDto
                    {
                        IsOperator = response.Body.Data.IsOperator,
                        TestOwners = ObjectMapper.Map<List<JmsResponseUserInfo>, List<JmsUserDto>>(response.Body.Data.TestOwners),
                        DevelopOwners = ObjectMapper.Map<List<JmsResponseUserInfo>, List<JmsUserDto>>(response.Body.Data.DevelopOwners),
                        OperationOwners = ObjectMapper.Map<List<JmsResponseUserInfo>, List<JmsUserDto>>(response.Body.Data.OperationOwners),
                    }) ;
                else
                {
                    var message = $"【{response.Code}】{response.Message}";
                    Logger.LogWarning(message);
                    return Result.FromError<JmsBusinessOwnerDto>(message);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> AddPermission(JmsPermissionAddInput jmsPermissionAddInput)
        {
            if (jmsPermissionAddInput.User is null)
                return Result.FromError($"缺失参数{nameof(jmsPermissionAddInput.User)}。");
            else if (jmsPermissionAddInput.ApplyInfo is null)
                return Result.FromError($"缺失参数{nameof(jmsPermissionAddInput.ApplyInfo)}。");
            else
            {
                var jmsPermissionWebApiService = ServiceProvider.GetRequiredService<IJmsPermissionWebApiService>();
                var response = await jmsPermissionWebApiService.AddPermission(new JmsPermissionAddRequest
                {
                    User = new JmsRequestUserInfo
                    {
                        UserCode = jmsPermissionAddInput.User.UserCode,
                        UserName = jmsPermissionAddInput.User.UserName
                    },
                    ApplyInfo = new JmsPermissionApplyInfo
                    {
                        Role = jmsPermissionAddInput.ApplyInfo.Role,
                        Environment = jmsPermissionAddInput.ApplyInfo.Environment,
                        TermType = jmsPermissionAddInput.ApplyInfo.TermType,
                        TimeFrom = jmsPermissionAddInput.ApplyInfo.TimeFrom,
                        TimeTo = jmsPermissionAddInput.ApplyInfo.TimeTo,
                        Businesses = jmsPermissionAddInput.ApplyInfo.Businesses,
                        Hosts = jmsPermissionAddInput.ApplyInfo.Hosts,
                        Reason = jmsPermissionAddInput.ApplyInfo.Reason
                    }
                });

                if (response.IsOk)
                    return Result.Ok();
                else
                {
                    var message = $"【{response.Code}】{response.Message}";
                    Logger.LogWarning(message);
                    return Result.FromError(message);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> CallbackWhenProcessFinished(JmsProcessFinishCallbackInput jmsProcessFinishCallbackInput)
        {
            if (string.IsNullOrWhiteSpace(jmsProcessFinishCallbackInput.ProcessInstanceCode))
                return Result.FromError($"缺失参数{nameof(jmsProcessFinishCallbackInput.ProcessInstanceCode)}。");
            else
            {
                var jmsCallbackWebApiService = ServiceProvider.GetRequiredService<IJmsCallbackWebApiService>();
                var response = await jmsCallbackWebApiService.CallbackWhenProcessFinished(new JmsProcessFinishedCallbackRequest
                {
                    ApprovalInfo = new Mo2JmsApprovalInfo
                    {
                        ProcessInstanceCode = jmsProcessFinishCallbackInput.ProcessInstanceCode,
                        ApprovalStatus = jmsProcessFinishCallbackInput.ApprovalStatus
                    }
                });

                return Result.Ok();
            }
        }
    }
}
