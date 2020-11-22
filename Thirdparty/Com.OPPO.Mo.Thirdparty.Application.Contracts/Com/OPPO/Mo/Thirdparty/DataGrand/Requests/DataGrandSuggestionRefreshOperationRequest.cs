using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    /// 提示词清空操作Request
    /// </summary>
    public class DataGrandSuggestionRefreshOperationRequest : BaseDataGrandSuggestionRequest
    {
        private DataGrandSuggestionRefreshOperation _dataOperation;
        /// <summary>
        /// <see cref="DataGrandDataOperationRequest{TDataGrandTableRowOperation}"/>
        /// </summary>
        public DataGrandSuggestionRefreshOperationRequest(DataGrandSuggestionOperationType dataGrandSuggestionOperationType)
        {
            TableName = ThirdpartyConsts.DataGrandSuggestTableName;
            _dataOperation = new DataGrandSuggestionRefreshOperation(dataGrandSuggestionOperationType);
        }

        /// <summary>
        /// 【必填项】表名称
        /// </summary>
        [JsonProperty("table_name")]
        public string TableName { get; private set; }

        /// <summary>
        /// 提示词操作内容
        /// </summary>
        [JsonProperty("table_content")]
        public string TableContent
        {
            get
            {
                if (_dataOperation == null)
                    throw new Exception("请明确提示词操作的内容。");
                else
                {
                    return JsonConvert.SerializeObject(new List<DataGrandSuggestionRefreshOperation> { _dataOperation });
                }
            }
        }

        /// <summary>
        /// 达观搜索提示词清空操作
        /// </summary>
        private class DataGrandSuggestionRefreshOperation
        {
            /// <summary>
            /// <see cref="DataGrandSuggestionRefreshOperation"/>
            /// </summary>
            /// <param name="dataGrandSuggestionOperationType"></param>
            public DataGrandSuggestionRefreshOperation(DataGrandSuggestionOperationType dataGrandSuggestionOperationType)
            {
                if (dataGrandSuggestionOperationType != DataGrandSuggestionOperationType.refresh_all
                    && dataGrandSuggestionOperationType != DataGrandSuggestionOperationType.refresh_private
                    && dataGrandSuggestionOperationType != DataGrandSuggestionOperationType.refresh_public)
                    throw new Exception(string.Format("达观搜索提示词清空操作只支持{0}、{1}以及{2}三种类型的操作。",
                        DataGrandSuggestionOperationType.refresh_all,
                        DataGrandSuggestionOperationType.refresh_private,
                         DataGrandSuggestionOperationType.refresh_public));

                OperationType = dataGrandSuggestionOperationType;
                OperationInputItem = new { };
            }

            /// <summary>
            /// <see cref="DataGrandSuggestionOperationType"/>
            /// </summary>
            [JsonProperty("cmd")]
            [JsonConverter(typeof(StringEnumConverter))]
            public DataGrandSuggestionOperationType OperationType { get; private set; }

            /// <summary>
            /// <see cref="List{TDataGrandDataInputItem}"/>
            /// </summary>
            [JsonProperty("fields")]
            public object OperationInputItem { get; private set; }
        }
    }
}
