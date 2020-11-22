using Com.OPPO.Mo.Thirdparty.DataGrand.Dtos;
using Com.OPPO.Mo.Thirdparty.DataGrand.Responses;
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
    /// 达观搜索便签数据查询OutputItem
    /// </summary>
    public class DataGrandMailDataQueryOutputItem
    {
        /// <summary>
        /// <see cref="DataGrandMailDataQueryOutputItem"/>
        /// </summary>
        public DataGrandMailDataQueryOutputItem()
        {
            Highlights = new List<DataGrandHighlightOutputItem>();
        }

        /// <summary>
        /// 数据记录Id
        /// </summary>
        [JsonProperty("itemid")]
        public string ItemId { get;  set; }

        /// <summary>
        /// <see cref="MO2DataGrandDataCategory"/>
        /// </summary>
        [JsonProperty("cateid")]
        //[JsonConverter(typeof(StringEnumConverter))]
        public MO2DataGrandDataCategory DataCategory { get;  set; }

        /// <summary>
        /// 邮件编码
        /// </summary>
        [JsonProperty("mailid")]
        public string MailCode { get; set; }

        /// <summary>
        /// 邮件标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 邮件内容
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// <see cref="DataGrandMailSource"/>
        /// </summary>
        [JsonProperty("mailtype")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataGrandMailSource MailSource { get; set; }

        /// <summary>
        /// 拥有者（帐号或Id）
        /// </summary>
        [JsonProperty("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// 发送者（帐号或Id）
        /// </summary>
        [JsonProperty("sender")]
        public string Sender { get; set; }

        /// <summary>
        /// 发送者姓名
        /// </summary>
        [JsonProperty("sendername")]
        public string SenderName { get; set; }

        /// <summary>
        /// 所有接收者s（帐号或Id）
        /// </summary>
        [JsonProperty("receivers")]
        public List<string> Receivers { get; set; }

        /// <summary>
        /// 所有接收者姓名以,拼接
        /// </summary>
        [JsonProperty("receivernames")]
        [JsonConverter(typeof(MO2DataGrandStringListConverter))]
        public List<string> ReceiverNames { get; set; }

        /// <summary>
        /// 附件地址s
        /// </summary>
        [JsonProperty("fileurls")]
        public List<string> AttachmentUrls { get; set; }

        /// <summary>
        /// 附件名称s,以\3拼接
        /// </summary>
        [JsonProperty("filenames")]
        [JsonConverter(typeof(MO2DataGrandStringListConverter))]
        public List<string> AttachmentNames { get; set; }

        /// <summary>
        /// 便签创建时间
        /// </summary>
        [JsonProperty("creationtime")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 便签发送时间
        /// </summary>
        [JsonProperty("sendtime")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [JsonProperty("lastmodifytime")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime LastModifyTime { get; set; }

        /// <summary>
        /// 匹配度
        /// </summary>
        [JsonProperty("sim_score")]
        public double Score { get; set; }


        /// <summary>
        /// 高亮s
        /// </summary>
        [JsonProperty("highlight")]
        public List<DataGrandHighlightOutputItem> Highlights { get; set; }

    }
}
