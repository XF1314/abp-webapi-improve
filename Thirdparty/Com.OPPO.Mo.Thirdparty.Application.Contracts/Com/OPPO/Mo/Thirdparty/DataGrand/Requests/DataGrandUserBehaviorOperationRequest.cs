using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    /// 达观搜索用户行为操作请求模型
    /// </summary>
    public class DataGrandUserBehaviorOperationRequest<TBaseDataGrandUserBehaviorInputItem> : BaseDataGrandDataRequest
        where TBaseDataGrandUserBehaviorInputItem : BaseDataGrandUserBehaviorInputItem
    {
        /// <summary>
        /// <see cref="DataGrandUserBehaviorOperationRequest{TDataGrandDataInputItem}"/>
        /// </summary>
        public DataGrandUserBehaviorOperationRequest()
        {
            TableName = ThirdpartyConsts.DataGrandUserBehaviorTableName;
            DataOperations = new List<DataGrandUserBehaviorOperation<TBaseDataGrandUserBehaviorInputItem>> { };
        }

        /// <summary>
        /// 【必填项】表名称
        /// </summary>
        [JsonProperty("table_name")]
        public string TableName { get; private set; }

        /// <summary>
        /// <see cref="DataGrandUserBehaviorOperation{TDataGrandDataInputItem}"/>
        /// </summary>
        [JsonIgnore]
        public List<DataGrandUserBehaviorOperation<TBaseDataGrandUserBehaviorInputItem>> DataOperations { get; set; }

        /// <summary>
        /// 用户行为操作内容
        /// </summary>
        [JsonProperty("table_content")]
        public string TableContent
        {
            get
            {
                if (!DataOperations.Any())
                    throw new Exception("请明确用户行为操作的内容。");
                else
                {
                    return JsonConvert.SerializeObject(DataOperations);
                }
            }
        }
    }
}
