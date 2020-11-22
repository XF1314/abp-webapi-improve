using Com.OPPO.Mo.Thirdparty.DataGrand.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索数据操作
    /// </summary>
    /// <typeparam name="TDataGrandDataInputItem"><see cref="BaseDataGrandDataInputItem"/></typeparam>
    public class DataGrandDataOperation<TDataGrandDataInputItem> where TDataGrandDataInputItem : BaseDataGrandDataInputItem
    {
        /// <summary>
        /// <see cref="DataGrandDataOperation{TDataGrandDataOperationInputItem}"/>
        /// </summary>
        /// <param name="dataGrandDataOperationType"><see cref="DataGrandDataOperationType"/></param>
        /// <param name="operationInputItem"><see cref="BaseDataGrandDataInputItem"/></param>
        public DataGrandDataOperation(DataGrandDataOperationType dataGrandDataOperationType, TDataGrandDataInputItem operationInputItem)
        {
            OperationType = dataGrandDataOperationType;
            OperationInputItem = operationInputItem;
        }

        /// <summary>
        /// <see cref="DataGrandDataOperationType"/>
        /// </summary>
        [JsonProperty("cmd")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataGrandDataOperationType OperationType { get; private set; }

        /// <summary>
        /// <see cref="List{TDataGrandDataInputItem}"/>
        /// </summary>
        [JsonProperty("fields")]
        public TDataGrandDataInputItem OperationInputItem { get; private set; }

    }
}
