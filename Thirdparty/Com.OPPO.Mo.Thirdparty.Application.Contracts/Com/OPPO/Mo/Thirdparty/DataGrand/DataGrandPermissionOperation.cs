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
    /// 达观搜索权限操作
    /// </summary>
    public class DataGrandPermissionOperation<TDataGrandPermissionInputItem> where TDataGrandPermissionInputItem : BaseDataGrandPermissionInputItem
    {
        /// <summary>
        /// <see cref="DataGrandPermissionOperation{TDataGrandPermissionInputItem}"/>
        /// </summary>
        /// <param name="dataGrandPermissionOperationType"><see cref="DataGrandPermissionOperationType"/></param>
        public DataGrandPermissionOperation(DataGrandPermissionOperationType dataGrandPermissionOperationType, TDataGrandPermissionInputItem permissionInputItem)
        {
            OperationType = dataGrandPermissionOperationType;
            PermissionInputItem = permissionInputItem;
        }

        /// <summary>
        /// 【必填项】<see cref="DataGrandPermissionOperationType"/>
        /// </summary>
        [JsonProperty("cmd")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataGrandPermissionOperationType OperationType { get; private set; }

        /// <summary>
        /// 【必填项】<see cref="TDataGrandPermissionInputItem"/>
        /// </summary>
        [JsonProperty("item")]
        public TDataGrandPermissionInputItem PermissionInputItem { get; private set; }

    }
}
