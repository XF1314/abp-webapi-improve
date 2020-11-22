using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    ///  达观搜索提示词操作请求模型
    /// </summary>
    /// <typeparam name="TDataGrandSuggestionInputItem"></typeparam>
    public class DataGrandSuggestionOperationRequest<TDataGrandSuggestionInputItem> : BaseDataGrandSuggestionRequest
        where TDataGrandSuggestionInputItem : BaseDataGrandSuggestionInputItem
    {
        /// <summary>
        /// <see cref="DataGrandDataOperationRequest{TDataGrandTableRowOperation}"/>
        /// </summary>
        public DataGrandSuggestionOperationRequest()
        {
            TableName = ThirdpartyConsts.DataGrandSuggestTableName;
            DataOperations = new List<DataGrandSuggestionOperation<TDataGrandSuggestionInputItem>> { };
        }

        /// <summary>
        /// 【必填项】表名称
        /// </summary>
        [JsonProperty("table_name")]
        public string TableName { get; private set; }

        /// <summary>
        /// <see cref="DataGrandDataOperation{TDataGrandSuggestInputItem}"/>
        /// </summary>
        [JsonIgnore]
        public List<DataGrandSuggestionOperation<TDataGrandSuggestionInputItem>> DataOperations { get; set; }

        /// <summary>
        /// 提示词操作内容
        /// </summary>
        [JsonProperty("table_content")]
        public string TableContent
        {
            get
            {
                if (!DataOperations.Any())
                    throw new Exception("请明确提示词操作的内容。");
                else
                {
                    return JsonConvert.SerializeObject(DataOperations);
                }
            }
        }
    }
}

