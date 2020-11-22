using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    /// 达观搜索权限操作请求模型
    /// </summary>
    public class DataGrandPermissionOperationRequest<TDataGrandPermissionInputItem> : ISignatureBasedDataGrandRequest,IAppIdInfo
        where TDataGrandPermissionInputItem : BaseDataGrandPermissionInputItem
    {
        /// <summary>
        /// <see cref="DataGrandPermissionOperationRequest{TDataGrandPermissionInputItem}"/>
        /// </summary>
        public DataGrandPermissionOperationRequest()
        {
            ActionId = Guid.NewGuid().ToString("N");
            DateTime = DateTime.Now;
            PermissionOperations = new List<DataGrandPermissionOperation<TDataGrandPermissionInputItem>>();
        }

        /// <summary>
        /// 【必填项】应用标识，由达观搜索提供
        /// </summary>
        [JsonProperty("appid")]
        public string AppId { get;  set; }

        /// <summary>
        /// 【必填项】标识一个批次的操作
        /// </summary>
        [JsonProperty("action_id")]
        public string ActionId { get; private set; }

        /// <summary>
        ///【必填项】 达观搜索权限操作s
        /// </summary>
        [JsonIgnore]
        public List<DataGrandPermissionOperation<TDataGrandPermissionInputItem>> PermissionOperations { get; set; }

        /// <summary>
        ///【必填项】 达观搜索权限操作s
        /// </summary>
        [JsonProperty("content")]
        public string Content
        {
            get
            {
                if (!PermissionOperations.Any())
                    throw new Exception("请明确数据操作的内容");
                else
                {
                    return JsonConvert.SerializeObject(PermissionOperations);
                }
            }
        }

        /// <summary>
        /// 【必填项】调用接口时的秒级时间戳，如1561945554。
        /// 如客户端与服务端的时间相差在10分钟以上，接口调用失败，请确保服务器时间的准确性
        /// </summary>
        [JsonProperty("time")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime DateTime { get; private set; }

        /// <summary>
        /// 【必填项】参数签名，防止请求被劫持篡改参数
        /// </summary>
        [JsonProperty("sign")]
        public string Sign { get; set; }
    }

}
