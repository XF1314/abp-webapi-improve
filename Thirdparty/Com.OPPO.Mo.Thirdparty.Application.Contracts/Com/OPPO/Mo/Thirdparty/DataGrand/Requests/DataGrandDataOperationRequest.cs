using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    /// 达观搜索通用数据操作请求模型
    /// </summary>
    public class DataGrandDataOperationRequest<TDataGrandDataInputItem> : BaseDataGrandDataRequest
        where TDataGrandDataInputItem : BaseDataGrandDataInputItem
    {
        /// <summary>
        /// <see cref="DataGrandDataOperationRequest{TDataGrandTableRowOperation}"/>
        /// </summary>
        public DataGrandDataOperationRequest()
        {
            TableName = ThirdpartyConsts.DataGrandDataTableName;
            DataOperations = new List<DataGrandDataOperation<TDataGrandDataInputItem>> { };
        }

        /// <summary>
        /// 【必填项】表名称
        /// </summary>
        [JsonProperty("table_name")]
        public string TableName { get; private set; }

        /// <summary>
        /// <see cref="DataGrandDataOperation{TDataGrandDataInputItem}"/>
        /// </summary>
        [JsonIgnore]
        public List<DataGrandDataOperation<TDataGrandDataInputItem>> DataOperations { get; set; }

        /// <summary>
        /// 数据操作内容
        /// </summary>
        [JsonProperty("table_content")]
        public string TableContent
        {
            get
            {
                if (!DataOperations.Any())
                    throw new Exception("请明确数据操作的内容。");
                else
                {
                    return JsonConvert.SerializeObject(DataOperations);
                }
            }
        }
    }
}
