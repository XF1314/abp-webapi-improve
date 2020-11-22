using Com.OPPO.Mo.Thirdparty.DataGrand.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索提示词操作
    /// </summary>
    /// <typeparam name="TDataGrandSuggestOperationInputItem"></typeparam>
    public class DataGrandSuggestionOperation<TDataGrandSuggestOperationInputItem> where TDataGrandSuggestOperationInputItem : BaseDataGrandSuggestionInputItem
    {
        /// <summary>
        /// <see cref="DataGrandSuggestionOperation{TDataGrandSuggestOperationInputItem}"/>
        /// </summary>
        /// <param name="dataGrandSuggestionOperationType"><see cref="DataGrandSuggestionOperationType"/></param>
        /// <param name="operationInputItem"><see cref="DataGrandSuggestionOperationType"/></param>
        public DataGrandSuggestionOperation(DataGrandSuggestionOperationType dataGrandSuggestionOperationType, TDataGrandSuggestOperationInputItem operationInputItem)
        {
            if (dataGrandSuggestionOperationType != DataGrandSuggestionOperationType.add
                && dataGrandSuggestionOperationType != DataGrandSuggestionOperationType.delete)
                throw new Exception(string.Format("达观搜索提示词清空操作只支持{0}和{1}}两种类型的操作。",
                    DataGrandSuggestionOperationType.add, DataGrandSuggestionOperationType.delete));

            OperationType = dataGrandSuggestionOperationType;
            OperationInputItem = operationInputItem;
        }

        /// <summary
        /// <see cref="DataGrandSuggestionOperationType"/>
        /// </summary>
        [JsonProperty("cmd")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataGrandSuggestionOperationType OperationType { get; private set; }

        /// <summary>
        /// <see cref="List{TDataGrandDataInputItem}"/>
        /// </summary>
        [JsonProperty("fields")]
        public TDataGrandSuggestOperationInputItem OperationInputItem { get; private set; }

    }
}