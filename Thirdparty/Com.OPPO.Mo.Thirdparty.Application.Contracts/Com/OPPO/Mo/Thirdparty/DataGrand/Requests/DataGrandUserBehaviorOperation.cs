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
    /// 达观搜索用户行为Operation
    /// </summary>
    /// <typeparam name="TDataGrandUserBehaviorInputItem"></typeparam>
    public class DataGrandUserBehaviorOperation<TDataGrandUserBehaviorInputItem>
               where TDataGrandUserBehaviorInputItem : BaseDataGrandUserBehaviorInputItem
    {
        /// <summary>
        /// <see cref="DataGrandUserBehaviorOperation{TBaseDataGrandUserBehaviorInputItem}"/>
        /// </summary>
        /// <param name="dataGrandDataOperationType"><see cref="DataGrandDataOperationType"/></param>
        /// <param name="operationInputItem"><see cref="BaseDataGrandUserBehaviorInputItem"/></param>
        public DataGrandUserBehaviorOperation(DataGrandDataOperationType dataGrandDataOperationType, TDataGrandUserBehaviorInputItem operationInputItem)
        {
            OperationType = dataGrandDataOperationType;
            BehaviorInputItem = operationInputItem;
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
        public TDataGrandUserBehaviorInputItem BehaviorInputItem { get; private set; }

    }
}
