using Com.OPPO.Mo.Thirdparty.DataGrand.Dtos;
using Com.OPPO.Mo.Thirdparty.DataGrand.Requests;
using Com.OPPO.Mo.Thirdparty.DataGrand.Responses;
using Com.OPPO.Mo.Thirdparty.DataGrand.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    [Authorize]
    public class DataGrandDataSearchAppService : ThirdpartyAppServiceBase, IDataGrandDataSearchAppService
    {
        private readonly IDataGrandDataSearchWebApiService _dataGrandDataSearchWebApiService;

        public DataGrandDataSearchAppService(IDataGrandDataSearchWebApiService dataGrandDataSearchWebApiService)
        {
            _dataGrandDataSearchWebApiService = dataGrandDataSearchWebApiService;
        }

        /// <inheritdoc/>
        public async Task<Result<DataGrandSearchOutput>> AggregateSearch(string userCode, DataGrandAggregateSearchInput dataGrandAggregateSearchInput)
        {
            var dataGrandSearchOutput = new DataGrandSearchOutput();
            var aggregateQueryRequest = AssembleAggregateQueryRequest(userCode, dataGrandAggregateSearchInput);

            var aggregateQueryResponse = await _dataGrandDataSearchWebApiService.GetDataGrandAggregateDataAsync(aggregateQueryRequest);
            if (!aggregateQueryResponse.IsOk)
            {
                var message = aggregateQueryResponse.Errors?.Message ?? aggregateQueryResponse.GatewayMessage;
                Logger.LogError(string.Join("\r\n", message, JsonConvert.SerializeObject(aggregateQueryRequest)), null);
                return Result.FromError<DataGrandSearchOutput>(message);
            }
            else
            {
                dataGrandSearchOutput = CastQueryResponseToSearchOutput(aggregateQueryResponse, dataGrandAggregateSearchInput.SearchScope);
                return Result.FromData(dataGrandSearchOutput);
            }            
        }

        /// <inheritdoc/>
        public async Task<Result<DataGrandSearchOutput>> ArticleAggregateSearch(string userCode, DataGrandArticleAggregateSearchInput dataGrandArticleAggregateSearchInput)
        {
            var dataGrandSearchOutput = new DataGrandSearchOutput();
            var aggregateQueryRequest = AssembleArticleAggregateQueryRequest(userCode, dataGrandArticleAggregateSearchInput);

            var aggregateQueryResponse = await _dataGrandDataSearchWebApiService.GetDataGrandAggregateDataAsync(aggregateQueryRequest);
            if (!aggregateQueryResponse.IsOk)
            {
                var message = aggregateQueryResponse.Errors?.Message ?? aggregateQueryResponse.GatewayMessage;
                Logger.LogError(string.Join("\r\n", message, JsonConvert.SerializeObject(aggregateQueryRequest)), null);
                return Result.FromError<DataGrandSearchOutput>(message);
            }
            else
            {
                dataGrandSearchOutput = CastQueryResponseToSearchOutput(aggregateQueryResponse, dataGrandArticleAggregateSearchInput.SearchScope);
                return Result.FromData(dataGrandSearchOutput);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<DataGrandSearchOutput>> MailAggregateSearch(string userCode, DataGrandMailAggregateSearchInput dataGrandMailAggregateSearchInput)
        {
            var dataGrandSearchOutput = new DataGrandSearchOutput();
            var aggregateQueryRequest = AssembleMailAggregateQueryRequest(userCode, dataGrandMailAggregateSearchInput);

            var aggregateQueryResponse = await _dataGrandDataSearchWebApiService.GetDataGrandAggregateDataAsync(aggregateQueryRequest);
            if (!aggregateQueryResponse.IsOk)
            {
                var message = aggregateQueryResponse.Errors?.Message ?? aggregateQueryResponse.GatewayMessage;
                Logger.LogError(string.Join("\r\n", message, JsonConvert.SerializeObject(aggregateQueryRequest)), null);
                return Result.FromError<DataGrandSearchOutput>(message);
            }
            else
            {
                dataGrandSearchOutput = CastQueryResponseToSearchOutput(aggregateQueryResponse, dataGrandMailAggregateSearchInput.SearchScope);
                return Result.FromData(dataGrandSearchOutput);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<DataGrandSearchOutput>> ModuleAggregateSearch(string userCode, DataGrandModuleAggregateSearchInput dataGrandModuleAggregateSearchInput)
        {
            var dataGrandSearchOutput = new DataGrandSearchOutput();
            var aggregateQueryRequest = AssembleModuleAggregateQueryRequest(userCode, dataGrandModuleAggregateSearchInput);

            var aggregateQueryResponse = await _dataGrandDataSearchWebApiService.GetDataGrandAggregateDataAsync(aggregateQueryRequest);
            if (!aggregateQueryResponse.IsOk)
            {
                var message = aggregateQueryResponse.Errors?.Message ?? aggregateQueryResponse.GatewayMessage;
                Logger.LogError(string.Join("\r\n", message, JsonConvert.SerializeObject(aggregateQueryRequest)), null);
                return Result.FromError<DataGrandSearchOutput>(message);
            }
            else
            {
                dataGrandSearchOutput = CastQueryResponseToSearchOutput(aggregateQueryResponse, dataGrandModuleAggregateSearchInput.SearchScope);
                return Result.FromData(dataGrandSearchOutput);
            }
        }

        private DataGrandSearchOutput CastQueryResponseToSearchOutput(DataGrandDataQueryResponse<JObject, DataGrandError> aggregateQueryResponse, DataGrandSearchScope searchScope)
        {
            var dataGrandSearchOutput = new DataGrandSearchOutput { TotalItemCount = aggregateQueryResponse.TotalCount };
            aggregateQueryResponse.ResultData.ForEach(x =>
            {
                var itemId = x.Property(BaseDataGrandDataInputItem.ITEM_ID).Value.ToString();
                var datacategory = (MO2DataGrandDataCategory)x.Property(BaseDataGrandDataInputItem.DATA_CATEGORY_ID).Value.ToObject<int>();
                var keyValuePair = new KeyValuePair<string, MO2DataGrandDataCategory>(itemId, datacategory);
                dataGrandSearchOutput.SortedItems.Add(keyValuePair);
                if (datacategory == MO2DataGrandDataCategory.form)
                {
                    //TODO:考虑AutoMapper??
                    var articleDataQueryOutputItem = x.ToObject<DataGrandArticleDataQueryOutputItem>();
                    dataGrandSearchOutput.ArticleItems.Add(CastArticleQueryResponseItemToSearchOutput(articleDataQueryOutputItem, searchScope));
                }
                else if (datacategory == MO2DataGrandDataCategory.mail)
                {
                    var mailDataQueryOutputItem = x.ToObject<DataGrandMailDataQueryOutputItem>();
                    dataGrandSearchOutput.MailItems.Add(CastMailQueryResponseItemToSearchOutput(mailDataQueryOutputItem, searchScope));
                }
                else if (datacategory == MO2DataGrandDataCategory.module)
                {
                    var moduleDataQueryOutputItem = x.ToObject<DataGrandModuleDataQueryOutputItem>();
                    dataGrandSearchOutput.ModuleItems.Add(CastModuleQueryResponseItemToSearchOutput(moduleDataQueryOutputItem, searchScope));
                }
            });

            dataGrandSearchOutput.ModuleItems.ForEach(y => y.ProcessFeildMapping());
            dataGrandSearchOutput.MailItems.ForEach(y => y.ProcessFeildMapping());
            dataGrandSearchOutput.ArticleItems.ForEach(y => y.ProcessFeildMapping());

            return dataGrandSearchOutput;
        }

        private static ModuleInfo CastModuleQueryResponseItemToSearchOutput(DataGrandModuleDataQueryOutputItem moduleDataQueryOutputItem, DataGrandSearchScope searchScope)
        {
            var moduleInfo = new ModuleInfo
            {
                ItemId = moduleDataQueryOutputItem.ItemId,
                DataCategory = moduleDataQueryOutputItem.DataCategory,
                ModuleType = moduleDataQueryOutputItem.ModuleType,
                ModuleId = moduleDataQueryOutputItem.ModuleId,
                ModuleName = moduleDataQueryOutputItem.ModuleName,
                Description = moduleDataQueryOutputItem.Description,
                Keywords = moduleDataQueryOutputItem.Keywords,
                LastModifyTime = moduleDataQueryOutputItem.LastModifyTime,
                Highlights = moduleDataQueryOutputItem.Highlights
            };

            if (searchScope == DataGrandSearchScope.Title)
                moduleInfo.Highlights.RemoveAll(z => z.TargetFieldName != DataGrandModuleDataAddInputItem.MODULE_NAME);
            else if (searchScope == DataGrandSearchScope.Description)
                moduleInfo.Highlights.RemoveAll(z => z.TargetFieldName != DataGrandModuleDataAddInputItem.MODULE_DESCRIPTION);

            return moduleInfo;
        }

        private static MailInfo CastMailQueryResponseItemToSearchOutput(DataGrandMailDataQueryOutputItem mailDataQueryOutputItem, DataGrandSearchScope searchScope)
        {
            var mailInfo = new MailInfo
            {
                ItemId = mailDataQueryOutputItem.ItemId,
                DataCategory = mailDataQueryOutputItem.DataCategory,
                MailCode = mailDataQueryOutputItem.MailCode,
                Title = mailDataQueryOutputItem.Title,
                Content = mailDataQueryOutputItem.Content,
                MailSource = mailDataQueryOutputItem.MailSource,
                Owner = mailDataQueryOutputItem.Owner,
                Sender = mailDataQueryOutputItem.Sender,
                SenderName = mailDataQueryOutputItem.SenderName,
                Receivers = mailDataQueryOutputItem.Receivers,
                ReceiverNames = mailDataQueryOutputItem.ReceiverNames,
                AttachmentUrls = new List<string> { }, //出于安全考虑，附件地址信息不返回前端 mailDataQueryOutputItem.AttachmentUrls,
                AttachmentNames = mailDataQueryOutputItem.AttachmentNames,
                CreationTime = mailDataQueryOutputItem.CreationTime,
                SendTime = mailDataQueryOutputItem.SendTime,
                LastModifyTime = mailDataQueryOutputItem.LastModifyTime,
                Highlights = mailDataQueryOutputItem.Highlights
            };

            if (searchScope == DataGrandSearchScope.Title)
                mailInfo.Highlights.RemoveAll(z => z.TargetFieldName != DataGrandMailDataAddInputItem.TITLE);
            else if (searchScope == DataGrandSearchScope.Description)
                mailInfo.Highlights.RemoveAll(z => z.TargetFieldName != DataGrandMailDataAddInputItem.CONTENT);

            return mailInfo;
        }

        private static ArticleInfo CastArticleQueryResponseItemToSearchOutput(DataGrandArticleDataQueryOutputItem articleDataQueryOutputItem, DataGrandSearchScope searchScope)
        {
            var articleInfo = new ArticleInfo
            {
                ItemId = articleDataQueryOutputItem.ItemId,
                DataCategory = articleDataQueryOutputItem.DataCategory,
                FormInstanceCode = articleDataQueryOutputItem.FormInstanceCode,
                ProcessSetId = articleDataQueryOutputItem.ProcessSetId,
                Keywords = articleDataQueryOutputItem.KeyWords,
                FormStatus = articleDataQueryOutputItem.FormStatus,
                FormTitle = articleDataQueryOutputItem.FormTitle,
                FormContent = articleDataQueryOutputItem.FormContent,
                AttachmentUrls = new List<string> { }, //出于安全考虑，附件地址信息不返回前端 articleDataQueryOutputItem.AttachmentNames,
                AttachmentNames = articleDataQueryOutputItem.AttachmentNames,
                CreatorUserCodes = articleDataQueryOutputItem.CreatorUserCodes,
                CreatorUserNames = articleDataQueryOutputItem.CreatorUserNames,
                CreatorDepartmentName = articleDataQueryOutputItem.CreatorDepartmentName,
                CreationTime = articleDataQueryOutputItem.CreationTime,
                AuditorUserCodes = articleDataQueryOutputItem.AuditorUserCodes,
                AuditorNames = articleDataQueryOutputItem.AuditorNames,
                AuditActivityName = articleDataQueryOutputItem.AuditActivityName,
                LastAuditorUserName = articleDataQueryOutputItem.LastAuditorUserName,
                LastModifyTime = articleDataQueryOutputItem.LastModifyTime,
                Highlights = articleDataQueryOutputItem.Highlights
            };

            if (searchScope == DataGrandSearchScope.Title)
                articleInfo.Highlights.RemoveAll(z => z.TargetFieldName != DataGrandArticleDataAddInputItem.TITLE);
            else if (searchScope == DataGrandSearchScope.Description)
                articleInfo.Highlights.RemoveAll(z => z.TargetFieldName != DataGrandArticleDataAddInputItem.CONTENT);

            return articleInfo;
        }

        private static DataGrandAggregateQueryRequest AssembleAggregateQueryRequest(string userCode, DataGrandAggregateSearchInput dataGrandAggregateSearchInput)
        {
            var aggregateQueryRequest = new DataGrandAggregateQueryRequest(dataGrandAggregateSearchInput.LanguageType)
            {
                DataCategory = MO2DataGrandDataCategory.all,
                UserCode = userCode,
                Keyword = dataGrandAggregateSearchInput.Keyword,
                Position = dataGrandAggregateSearchInput.Offset,
                Count = dataGrandAggregateSearchInput.Count,
                DateTimeFrom = dataGrandAggregateSearchInput.DateTimeFrom,
                DateTimeTo = dataGrandAggregateSearchInput.DateTimeTo
            };

            return aggregateQueryRequest;
        }

        private static DataGrandAggregateQueryRequest AssembleArticleAggregateQueryRequest(string userCode, DataGrandArticleAggregateSearchInput dataGrandArticleAggregateSearchInput)
        {
            var aggregateQueryRequest = new DataGrandAggregateQueryRequest(dataGrandArticleAggregateSearchInput.LanguageType)
            {
                DataCategory = MO2DataGrandDataCategory.form,
                UserCode = userCode,
                Keyword = dataGrandArticleAggregateSearchInput.Keyword,
                Position = dataGrandArticleAggregateSearchInput.Offset,
                Count = dataGrandArticleAggregateSearchInput.Count,
            };

            if (!string.IsNullOrWhiteSpace(dataGrandArticleAggregateSearchInput.DrafterDepartmentName))
                aggregateQueryRequest.FuzzyFilterItems.Add(DataGrandArticleDataAddInputItem.CREATOR_DEPARTMENT_NAME, dataGrandArticleAggregateSearchInput.DrafterDepartmentName);
            if (!string.IsNullOrWhiteSpace(dataGrandArticleAggregateSearchInput.DrafterName))
                aggregateQueryRequest.ExactFilterItems.Add(DataGrandArticleDataAddInputItem.CREATOR_USER_NAME, dataGrandArticleAggregateSearchInput.DrafterName);
            if (!string.IsNullOrWhiteSpace(dataGrandArticleAggregateSearchInput.DrafterUserCode))
                aggregateQueryRequest.ExactFilterItems.Add(DataGrandArticleDataAddInputItem.CREATER_USER_CODE, dataGrandArticleAggregateSearchInput.DrafterUserCode);
            if (!string.IsNullOrWhiteSpace(dataGrandArticleAggregateSearchInput.AuditorName))
                aggregateQueryRequest.FuzzyFilterItems.Add(DataGrandArticleDataAddInputItem.AUDITOR_NAMES, dataGrandArticleAggregateSearchInput.AuditorName);
            if (!string.IsNullOrWhiteSpace(dataGrandArticleAggregateSearchInput.AuditorUserCode))
                aggregateQueryRequest.ExactFilterItems.Add(DataGrandArticleDataAddInputItem.AUDITOR_USER_CODES, dataGrandArticleAggregateSearchInput.AuditorUserCode);
            if (!string.IsNullOrWhiteSpace(dataGrandArticleAggregateSearchInput.ArticleCode))
                aggregateQueryRequest.ExactFilterItems.Add(DataGrandArticleDataAddInputItem.ARTICLE_CODE, dataGrandArticleAggregateSearchInput.ArticleCode);
            if (dataGrandArticleAggregateSearchInput.ProcessSettingId.HasValue)
                aggregateQueryRequest.ExactFilterItems.Add(DataGrandArticleDataAddInputItem.PROCESS_SETTING_ID, dataGrandArticleAggregateSearchInput.ProcessSettingId.Value.ToString());
            if (dataGrandArticleAggregateSearchInput.FormStatus.HasValue && dataGrandArticleAggregateSearchInput.FormStatus.Value != -1)//为配合前端效果，约定-1代表所有
                aggregateQueryRequest.ExactFilterItems.Add(DataGrandArticleDataAddInputItem.FORM_STATUS, dataGrandArticleAggregateSearchInput.FormStatus.Value.ToString());

            if (dataGrandArticleAggregateSearchInput.PublicTimeFrom.HasValue || dataGrandArticleAggregateSearchInput.PublicTimeTo.HasValue)
            {
                //FormInstanceStatus.Public:6
                // FormInstanceStatus.Approved:3
                var publicStatus = string.Format("{0},{1}", 3, 6);
                if (aggregateQueryRequest.ExactFilterItems.ContainsKey(DataGrandArticleDataAddInputItem.FORM_STATUS))
                    aggregateQueryRequest.ExactFilterItems[DataGrandArticleDataAddInputItem.FORM_STATUS] = publicStatus;
                else
                    aggregateQueryRequest.ExactFilterItems.Add(DataGrandArticleDataAddInputItem.FORM_STATUS, publicStatus);
            }
            if (dataGrandArticleAggregateSearchInput.PublicTimeFrom.HasValue)
                aggregateQueryRequest.DatetimeFilterItems.Add(new DataGrandDatetimeComparision
                {
                    DateTimeFieldName = DataGrandArticleDataAddInputItem.LAST_MODIFY_TIME,
                    comparisonOperator = DataGrandDatetimeComparisonOperator.GreaterOrEqual,
                    DateTime = dataGrandArticleAggregateSearchInput.PublicTimeFrom.Value
                });
            if (dataGrandArticleAggregateSearchInput.PublicTimeTo.HasValue)
                aggregateQueryRequest.DatetimeFilterItems.Add(new DataGrandDatetimeComparision
                {
                    DateTimeFieldName = DataGrandArticleDataAddInputItem.LAST_MODIFY_TIME,
                    comparisonOperator = DataGrandDatetimeComparisonOperator.LessOrEqual,
                    DateTime = dataGrandArticleAggregateSearchInput.PublicTimeTo.Value
                });

            if (dataGrandArticleAggregateSearchInput.DraftTimeFrom.HasValue)
                aggregateQueryRequest.DatetimeFilterItems.Add(new DataGrandDatetimeComparision
                {
                    DateTimeFieldName = DataGrandArticleDataAddInputItem.CREATION_TIME,
                    comparisonOperator = DataGrandDatetimeComparisonOperator.GreaterOrEqual,
                    DateTime = dataGrandArticleAggregateSearchInput.DraftTimeFrom.Value
                });
            if (dataGrandArticleAggregateSearchInput.DraftTimeTo.HasValue)
                aggregateQueryRequest.DatetimeFilterItems.Add(new DataGrandDatetimeComparision
                {
                    DateTimeFieldName = DataGrandArticleDataAddInputItem.CREATION_TIME,
                    comparisonOperator = DataGrandDatetimeComparisonOperator.LessOrEqual,
                    DateTime = dataGrandArticleAggregateSearchInput.DraftTimeTo.Value
                });

            return aggregateQueryRequest;
        }
       
        private static DataGrandAggregateQueryRequest AssembleMailAggregateQueryRequest(string userCode, DataGrandMailAggregateSearchInput dataGrandMailAggregateSearchInput)
        {
            var aggregateQueryRequest = new DataGrandAggregateQueryRequest(dataGrandMailAggregateSearchInput.LanguageType)
            {
                DataCategory = MO2DataGrandDataCategory.mail,
                UserCode = userCode,
                Keyword = dataGrandMailAggregateSearchInput.Keyword,
                Position = dataGrandMailAggregateSearchInput.Offset,
                Count = dataGrandMailAggregateSearchInput.Count,
            };

            if (!string.IsNullOrWhiteSpace(dataGrandMailAggregateSearchInput.SenderName))
                aggregateQueryRequest.FuzzyFilterItems.Add(DataGrandMailDataAddInputItem.SENDER_NAME, dataGrandMailAggregateSearchInput.SenderName);
            if (!string.IsNullOrWhiteSpace(dataGrandMailAggregateSearchInput.SenderUserCode))
                aggregateQueryRequest.ExactFilterItems.Add(DataGrandMailDataAddInputItem.SENDER_USER_CODE, dataGrandMailAggregateSearchInput.SenderUserCode);
            if (!string.IsNullOrWhiteSpace(dataGrandMailAggregateSearchInput.ReceiverName))
                aggregateQueryRequest.FuzzyFilterItems.Add(DataGrandMailDataAddInputItem.RECEIVER_NAMES, dataGrandMailAggregateSearchInput.ReceiverName);
            if (!string.IsNullOrWhiteSpace(dataGrandMailAggregateSearchInput.ReceiverUserCode))
                aggregateQueryRequest.ExactFilterItems.Add(DataGrandMailDataAddInputItem.RECEIVER_USER_CODES, dataGrandMailAggregateSearchInput.ReceiverUserCode);
            if (dataGrandMailAggregateSearchInput.MailSource.HasValue && dataGrandMailAggregateSearchInput.MailSource.Value != DataGrandMailSource.all)
                aggregateQueryRequest.ExactFilterItems.Add(DataGrandMailDataAddInputItem.MAIL_TYPE, dataGrandMailAggregateSearchInput.MailSource.Value.ToString());
            if (dataGrandMailAggregateSearchInput.SendTimeFrom.HasValue)
                aggregateQueryRequest.DatetimeFilterItems.Add(new DataGrandDatetimeComparision
                {
                    DateTimeFieldName = DataGrandMailDataAddInputItem.SEND_TIME,
                    comparisonOperator = DataGrandDatetimeComparisonOperator.GreaterOrEqual,
                    DateTime = dataGrandMailAggregateSearchInput.SendTimeFrom.Value
                });
            if (dataGrandMailAggregateSearchInput.SendTimeTo.HasValue)
                aggregateQueryRequest.DatetimeFilterItems.Add(new DataGrandDatetimeComparision
                {
                    DateTimeFieldName = DataGrandMailDataAddInputItem.SEND_TIME,
                    comparisonOperator = DataGrandDatetimeComparisonOperator.LessOrEqual,
                    DateTime = dataGrandMailAggregateSearchInput.SendTimeTo.Value
                });


            return aggregateQueryRequest;
        }
       
        private static DataGrandAggregateQueryRequest AssembleModuleAggregateQueryRequest(string userCode, DataGrandModuleAggregateSearchInput dataGrandModuleAggregateSearchInput)
        {
            var aggregateQueryRequest = new DataGrandAggregateQueryRequest(dataGrandModuleAggregateSearchInput.LanguageType)
            {
                DataCategory = MO2DataGrandDataCategory.module,
                UserCode = userCode,
                Keyword = dataGrandModuleAggregateSearchInput.Keyword,
                Position = dataGrandModuleAggregateSearchInput.Offset,
                Count = dataGrandModuleAggregateSearchInput.Count,
            };


            if (dataGrandModuleAggregateSearchInput.ModuleType.HasValue && dataGrandModuleAggregateSearchInput.ModuleType != MO2DataGrandModuleType.all)
                aggregateQueryRequest.ExactFilterItems.Add(DataGrandModuleDataAddInputItem.MODULE_TYPE, dataGrandModuleAggregateSearchInput.ModuleType.Value.ToString());

            if (!string.IsNullOrWhiteSpace(dataGrandModuleAggregateSearchInput.Keyword))
            {
                if (dataGrandModuleAggregateSearchInput.SearchScope == DataGrandSearchScope.Title)
                    //此处在搜索那边做了映射处理，也就是说搜全部时title参数会用来过滤模块数据中的modulename
                    aggregateQueryRequest.FuzzyFilterItems.Add(DataGrandModuleDataAddInputItem.MODULE_NAME, dataGrandModuleAggregateSearchInput.Keyword);
                else if (dataGrandModuleAggregateSearchInput.SearchScope == DataGrandSearchScope.Description)
                    //此处在搜索那边做了映射处理，也就是说搜全部时content参数会用来过滤模块数据中的description
                    aggregateQueryRequest.FuzzyFilterItems.Add(DataGrandModuleDataAddInputItem.MODULE_DESCRIPTION, dataGrandModuleAggregateSearchInput.Keyword);
            }

            return aggregateQueryRequest;
        }
    }
}
