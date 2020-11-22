using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Dtos
{
    /// <summary>
    /// 便签信息
    /// </summary>
    public class MailInfo
    {
        /// <summary>
        /// <see cref="MailInfo"/>
        /// </summary>
        public MailInfo()
        {
            Uri = "/";
            PlaceHolderImageUri = "";
        }

        /// <summary>
        /// 数据记录Id
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// 统一资源定位符(相对)
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// 占位图片Uri
        /// </summary>
        public string PlaceHolderImageUri { get; set; }

        /// <summary>
        /// <see cref="MO2DataGrandDataCategory"/>
        /// </summary>
        public MO2DataGrandDataCategory DataCategory { get; set; }

        /// <summary>
        /// 邮件编码
        /// </summary>
        public string MailCode { get; set; }

        /// <summary>
        /// 邮件标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// <see cref="DataGrandMailSource"/>
        /// </summary>
        public DataGrandMailSource MailSource { get; set; }

        /// <summary>
        /// 拥有者（帐号或Id）
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// 发送者（帐号或Id）
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// 发送者姓名
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// 所有接收者s（帐号或Id）
        /// </summary>
        public List<string> Receivers { get; set; }

        /// <summary>
        /// 所有接收者姓名以,拼接
        /// </summary>
        public List<string> ReceiverNames { get; set; }

        /// <summary>
        /// 附件地址s
        /// </summary>
        public List<string> AttachmentUrls { get; set; }

        /// <summary>
        /// 附件名称s,以\3拼接
        /// </summary>
        public List<string> AttachmentNames { get; set; }

        /// <summary>
        /// 便签创建时间
        /// </summary>
        [JsonConverter(typeof(DateTimeStringConverter))]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 便签发送时间
        /// </summary>
        [JsonConverter(typeof(DateTimeStringConverter))]
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [JsonConverter(typeof(DateTimeStringConverter))]
        public DateTime LastModifyTime { get; set; }

        /// <summary>
        /// 高亮s
        /// </summary>
        public List<DataGrandHighlightOutputItem> Highlights { get; set; }

        /// <summary>
        /// 处理字段映射
        /// </summary>
        public void ProcessFeildMapping()
        {
            if (Highlights != null)
            {
                Highlights.ForEach(x => {
                    x.TargetFieldName = FeildMappings[x.TargetFieldName];
                });
            }
        }

        /// <summary>
        /// MO与达观搜索的字段映射
        /// </summary>
        [JsonIgnore]
        private readonly ReadOnlyDictionary<string, string> FeildMappings = new ReadOnlyDictionary<string, string>(
            new Dictionary<string, string>
            {
                { "itemid","itemId" },
                { "cateid","dataCategory" },
                { "mailid","mailCode" },
                { "title","title" },
                { "content","content" },
                { "mailtype","mailSource" },
                { "owner","owner" },
                { "sender","sender" },
                { "sendername","senderName" },
                { "receivers","receivers" },
                { "receivernames","receiverNames" },
                { "fileurls","attachmentUrls" },
                { "filenames","attachmentNames" },
                { "creationtime","creationTime" },
                { "sendtime","sendTime" },
                { "lastmodifytime","lastModifyTime" },
                { "sim_score","score" }
            });
    }
}
