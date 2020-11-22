using Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp
{
    /// <summary>
    /// 一加服务实现类
    /// </summary>
    [Authorize]
    public class OnePlusErpAppService : ThirdpartyAppServiceBase, IOnePlusErpAppService
    {
        public readonly IOnePlusErpEsbService _onePlusErpEsbService;

        public OnePlusErpAppService(IOnePlusErpEsbService onePlusErpEsbService)
        {
            _onePlusErpEsbService = onePlusErpEsbService;
        }

        /// <summary>
        /// 获取拟价单信息
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="oaNum">MO文件编号</param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusPriceInfoDto>>> GetPriceInfo(string language, string oaNum)
        {
            if (string.IsNullOrWhiteSpace(oaNum))
            {
                return Result.FromError<List<OnePlusPriceInfoDto>>($"缺失参数{nameof(oaNum)}。");
            }

            var response = await _onePlusErpEsbService.GetPriceInfo(new OnePlusErpPriceRequest
            {
                Language = language,
                OaNum = oaNum
            });

            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusPriceInfoDto>>(response.Body.Data);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Data}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusPriceInfoDto>>(message);
            }
        }

        /// <summary>
        /// 一加采购检查供应商登记注册号
        /// </summary>
        /// <param name="orgId">组织编号</param>
        /// <param name="vendorNumber">供应商编码</param>
        /// <returns></returns>
        public async Task<Result<List<OnplusErpVendorDto>>> GetCuxPoVendors(string orgId, string vendorNumber)
        {
            if (string.IsNullOrWhiteSpace(orgId))
            {
                return Result.FromError<List<OnplusErpVendorDto>>($"缺失参数{nameof(orgId)}。");
            }

            var response = await _onePlusErpEsbService.GetCuxPoVendors(new OnePlusErpVendorRequest
            {
                OrgId = orgId,
                VendorNumber = vendorNumber
            });

            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnplusErpVendorDto>>(response.Body.Data);

                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Data}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnplusErpVendorDto>>(message);
            }
        }

        /// <summary>
        /// SKU基础数据查询
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="organizationId">ERP库存组织ID</param>
        /// <param name="skuCode">SKU code</param>
        /// <param name="skuId">ERP Item Id</param>
        /// <param name="uom">SKU主单位</param>
        /// <returns></returns>
        public async Task<Result<List<OneplusErpCuxOaItemDto>>> GetCuxOaItem(string language, string organizationId, string skuCode, string skuId, string uom)
        {
            if (string.IsNullOrWhiteSpace(skuCode))
            {
                return Result.FromError<List<OneplusErpCuxOaItemDto>>($"缺失参数{nameof(skuCode)}。");
            }

            var response = await _onePlusErpEsbService.OneplusErpCuxOaItemVQuery(new OnePlusErpCuxOaItemRequest
            {
                Language = language,
                OrganizationId = organizationId,
                SkuCode = skuCode,
                SkuId = skuId,
                Uom = uom
            });

            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OneplusErpCuxOaItemDto>>(response.Body.Data);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Data}";
                Logger.LogWarning(message);
                return Result.FromError<List<OneplusErpCuxOaItemDto>>(message);
            }
        }

        /// <summary>
        /// 采购单拟价导入
        /// </summary>
        /// <param name="lines"><see cref="OnePlusErpPriceInput"/>采购单拟价导入输入参数</param> 
        /// <returns></returns>
        public async Task<Result<OnePlusErpPriceAddDto>> OneplusErpOpOaPriceIfaceAdd(OnePlusErpPriceInput input)
        {
            var response = await _onePlusErpEsbService.OneplusErpOpOaPriceIfaceAdd(new OnePlusErpPriceAddRequest
            {
                Lines = input.Line
            });

            if (response.Body.Code == "0")
            {
                return Result.FromData(response.Body);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Msg}";
                Logger.LogWarning(message);
                return Result.FromError<OnePlusErpPriceAddDto>(message);
            }
        }

        /// <summary>
        ///  获取拟价订单
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="oaNum">MO文件编号</param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusErpopOaPriceIfaceQueryDto>>> GetOnePlusErpopOaPriceIface(string language, string oaNum)
        {
            if (string.IsNullOrWhiteSpace(oaNum))
            {
                return Result.FromError<List<OnePlusErpopOaPriceIfaceQueryDto>>($"缺失参数{nameof(oaNum)}。");
            }

            var response = await _onePlusErpEsbService.OnePlusErpOpOaPriceIfaceQuery(new OnePlusErpopOaPriceIfaceQueryRequest
            {
                Language = language,
                OaNum = oaNum
            });

            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusErpopOaPriceIfaceQueryDto>>(response.Body.Data);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusErpopOaPriceIfaceQueryDto>>(message);
            }
        }

        /// <summary>
        ///  获取主体信息
        /// </summary>
        /// <param name="input"><see cref="OnePlusErpCuxExOuVQueryInput"/></param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusErpCuxExOuVQueryDto>>> GetOnePlusErpCuxExOuV(OnePlusErpCuxExOuVQueryInput input)
        {
            if (string.IsNullOrWhiteSpace(input.OrgId))
            {
                return Result.FromError<List<OnePlusErpCuxExOuVQueryDto>>($"缺失参数{nameof(input.OrgId)}。");
            }

            var response = await _onePlusErpEsbService.OnePlusErpCuxExOuVQuery(new OnePlusErpCuxExOuVQueryRequest
            {
                Language = input.Language,
                OrgId = input.OrgId,
                OrgCode = input.OrgCode,
                OrgName = input.OrgName,
                PsLeId = input.PsLeId,
                TargetCurrencyCode = input.TargetCurrencyCode
            });

            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusErpCuxExOuVQueryDto>>(response.Body.Data);

                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusErpCuxExOuVQueryDto>>(message);
            }
        }

        /// <summary>
        ///  获取财务系统价格
        /// </summary>
        /// <param name="input"><see cref="OnePlusErpCuxPoVendItemPriceInput"/></param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusErpCuxPoVendItemPriceDto>>> GetCuxPoVendItemPriceV(OnePlusErpCuxPoVendItemPriceInput input)
        {
            if (string.IsNullOrWhiteSpace(input.ItemName))
            {
                return Result.FromError<List<OnePlusErpCuxPoVendItemPriceDto>>($"缺失参数{nameof(input.ItemName)}。");
            }

            if (string.IsNullOrWhiteSpace(input.OuId))
            {
                return Result.FromError<List<OnePlusErpCuxPoVendItemPriceDto>>($"缺失参数{nameof(input.OuId)}。");
            }

            var response = await _onePlusErpEsbService.CuxPoVendItemPriceVQuery(new OnePlusErpCuxPoVendItemPriceRequest
            {
                Language = input.Language,
                CurrencyCode = input.CurrencyCode,
                ItemId = input.ItemId,
                ItemName = input.ItemName,
                OuId = input.OuId,
                OuName = input.OuName,
                PrimaryUomCode = input.PrimaryUomCode,
                VendorId = input.VendorId,
                VendorName = input.VendorName
            });

            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusErpCuxPoVendItemPriceDto>>(response.Body.Data);

                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusErpCuxPoVendItemPriceDto>>(message);
            }
        }

        /// <summary>
        /// 获取采购员
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="agentId">组织ID</param>
        /// <param name="agentName">组织名称</param>
        /// <param name="employeeNumber">工号</param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusErpAgentsDto>>> GetAgents(string language, string agentId, string agentName, string employeeNumber)
        {
            if (string.IsNullOrWhiteSpace(employeeNumber))
            {
                return Result.FromError<List<OnePlusErpAgentsDto>>($"缺失参数{nameof(employeeNumber)}。");
            }

            var response = await _onePlusErpEsbService.CuxPoAgentsVQuery(new OnePlusErpAgentsRequest
            {
                Language = language,
                Id = agentId,
                Name = agentName,
                Number = employeeNumber
            });

            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusErpAgentsDto>>(response.Body.Data);

                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusErpAgentsDto>>(message);
            }
        }

        /// <summary>
        /// 采购单导入头部
        /// </summary>
        /// <param name="input"><see cref="PoHeadersInterfaceInfoInput"/>采购单导入信息</param>
        /// <returns></returns>
        public async Task<Result<OnePlusErpHeadersIfaceDto>> HeadersIfaceAdd(PoHeadersInterfaceInfoInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Lines))
            {
                return Result.FromError<OnePlusErpHeadersIfaceDto>($"缺失参数{nameof(input.Lines)}。");
            }

            var response = await _onePlusErpEsbService.CuxPoOaHeadersIfaceAdd(new OnePlusErpHeadersRequest
            {
                Lines = input.Lines,
                RespType = input.RespType
            });

            if (response.Body.Code == "0")
            {
                OnePlusErpHeadersIfaceDto dto = new OnePlusErpHeadersIfaceDto
                {
                    Code = response.Body.Code,
                    HeaderId = response.Body.HeaderId
                };

                return Result.FromData(dto);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.HeaderId}";
                Logger.LogWarning(message);
                return Result.FromError<OnePlusErpHeadersIfaceDto>(message);
            }
        }

        /// <summary>
        /// 采购单导入主体部分
        /// </summary>
        /// <param name="input"><see cref="PoHeadersInterfaceInfoInput"/>采购单导入主体部分信息</param>
        /// <returns></returns>
        public async Task<Result<OnePlusToErpDto>> LinesIfaceAdd(PoLinesInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Lines))
            {
                return Result.FromError<OnePlusToErpDto>($"缺失参数{nameof(input.Lines)}。");
            }

            //var lines = JsonConvert.SerializeObject(input);

            var response = await _onePlusErpEsbService.CuxPoOaLinesIfaceAdd(new OnePlusErpLinesRequest
            {
                Lines = input.Lines,
                RespType = input.RespType
            });

            if (response.Body.Code == "1")
            {
                OnePlusToErpDto dto = new OnePlusToErpDto
                {
                    Code = response.Body.Code,
                    Msg = response.Body.Msg
                };

                return Result.FromData(dto);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Msg}";
                Logger.LogWarning(message);
                return Result.FromError<OnePlusToErpDto>(message);
            }
        }

        /// <summary>
        ///  核算主体查询
        /// </summary>
        /// <param name="input"><see cref="OnePlusErpBodyInput"/></param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusErpBodyDto>>> GetCuxExOuVQueryWithPage(OnePlusErpBodyInput input)
        {

            var response = await _onePlusErpEsbService.CuxExOuVQueryWithPage(new OnePlusErpBodyRequest
            {
                Between = input.Between,
                From = input.From,
                Country = input.Country,
                Language = input.Language,
                OrgCode = input.OrgCode,
                OrgName = input.OrgName,
                PsLeId = input.PsLeId
            });

            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusErpBodyDto>>(response.Body.Data);

                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusErpBodyDto>>(message);
            }
        }

        /// <summary>
        ///  查询个人银行信息
        /// </summary>
        /// <param name="empId">员工工号</param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusBankCardDto>>> GetBankCardByEmpId(string empId)
        {
            if (string.IsNullOrWhiteSpace(empId))
            {
                return Result.FromError<List<OnePlusBankCardDto>>($"缺失参数{nameof(empId)}。");
            }

            var response = await _onePlusErpEsbService.GetBankCardInfo(new OnePlusBankCardRequest
            {
                Empid = empId
            });

            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusBankCardDto>>(response.Body.Data);

                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusBankCardDto>>(message);
            }
        }

        /// <summary>
        ///  根据流程单号id查询付款信息
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="id">程单号id</param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusPayTransDto>>> GetPayTransInfoById(string language, string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return Result.FromError<List<OnePlusPayTransDto>>($"缺失参数{nameof(id)}。");
            }

            var response = await _onePlusErpEsbService.GetPayTransInfoById(new OnePlusPayTransRequest
            {
                Language = language,
                Id = id
            });

            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusPayTransDto>>(response.Body.Data);

                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusPayTransDto>>(message);
            }
        }

        /// <summary>
        /// 抛送报销信息头部至ERP
        /// </summary>
        /// <param name="input"><see cref="OnePluesHeardToErpInput"/></param>
        /// <returns></returns>
        public async Task<Result<OnePlusToErpDto>> CommonReimGeneralHeardToErp(OnePluesHeardToErpInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Lines))
            {
                return Result.FromError<OnePlusToErpDto>($"缺失参数{nameof(input.Lines)}。");
            }

            var response = await _onePlusErpEsbService.CuxOaApHeaderIfaceAdd(new OnePlusCuxOaApHeaderIfaceRequest
            {
                Lines = input.Lines,
                RespType = input.RespType,
            });

            if (response.Body.Code == "1")
            {
                OnePlusToErpDto info = new OnePlusToErpDto
                {
                    Code = response.Body.Code,
                    Msg = response.Body.Msg
                };
                return Result.FromData(info);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Msg}";
                Logger.LogWarning(message);
                return Result.FromError<OnePlusToErpDto>(message);
            }
        }

        /// <summary>
        /// 抛送报销行信息至ERP
        /// </summary>
        /// <param name="input"><see cref="OnePluesLineToErpInput"/></param>
        /// <returns></returns>
        public async Task<Result<OnePlusToErpDto>> CommonReimGeneralLineToErp(OnePluesLineToErpInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Lines))
            {
                return Result.FromError<OnePlusToErpDto>($"缺失参数{nameof(input.Lines)}。");
            }

            var response = await _onePlusErpEsbService.CuxOaApLineIfaceAdd(new OnePlusOaApLineIfaceTransRequest
            {
                Lines = input.Lines,
                RespType = input.RespType,
            });

            if (response.Body.Code == "1")
            {
                OnePlusToErpDto info = new OnePlusToErpDto
                {
                    Code = response.Body.Code,
                    Msg = response.Body.Msg
                };
                return Result.FromData(info);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Msg}";
                Logger.LogWarning(message);
                return Result.FromError<OnePlusToErpDto>(message);
            }
        }

        /// <summary>
        /// 查询收货结果
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Result<List<OnePlusErpReceivingResultInfoDto>>> GetReceivingResult(OnePlusErpReceivingResultInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Po_Number))
            {
                return Result.FromError<List<OnePlusErpReceivingResultInfoDto>>($"缺失参数{nameof(input.Po_Number)}。");
            }

            var response = await _onePlusErpEsbService.GetReceivingResult(input);

            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusErpReceivingResultInfoDto>>(response.Body.Data);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Data}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusErpReceivingResultInfoDto>>(message);
            }
        }
        /// <summary>
        /// 查询ERP SKU表的数据
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<OnePlusErpSkuInfoDto>>> GetErpAllSkuInfo(string language)
        {
            var response = await _onePlusErpEsbService.GetErpAllSkuInfo(new OnePlusGetErpSkuInfoRequest {Language = language });
            if (response.Body.Code == "0")
            {
                var data = JsonConvert.DeserializeObject<List<OnePlusErpSkuInfoDto>>(response.Body.Data);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Body.Code}】{response.Body.Data}";
                Logger.LogWarning(message);
                return Result.FromError<List<OnePlusErpSkuInfoDto>>(message);
            }
        }


    }
}
