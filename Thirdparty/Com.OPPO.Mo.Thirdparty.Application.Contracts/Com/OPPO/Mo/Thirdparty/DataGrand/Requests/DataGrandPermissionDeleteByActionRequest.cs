using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    /// 达观搜索按操作批次删除权限请求模型
    /// </summary>
    public class DataGrandPermissionDeleteByActionRequest : ISignatureBasedDataGrandRequest,IAppIdInfo
    {
        /// <summary>
        /// <see cref="DataGrandPermissionDeleteByActionRequest"/>
        /// </summary>  
        /// <param name="actionId">标识一个批次的操作，即用户的⾏为标识，如果是-1，则删除全部上报的数据，否则删除action_id下的数据</param>
        public DataGrandPermissionDeleteByActionRequest( string actionId )
        {
            ActionId = actionId;
            DateTime = DateTime.Now;
        }

        /// <summary>
        /// 【必填项】应用标识，由达观搜索提供
        /// </summary>
        [JsonProperty("appid")]
        public string AppId { get;  set; }

        /// <summary>
        /// 【必填项】标识一个批次的操作，即用户的⾏为标识，如果是-1，则删除全部上报的数据，否则删除action_id下的数据
        /// </summary>
        [JsonProperty("action_id")]
        public string ActionId { get; private set; }

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
