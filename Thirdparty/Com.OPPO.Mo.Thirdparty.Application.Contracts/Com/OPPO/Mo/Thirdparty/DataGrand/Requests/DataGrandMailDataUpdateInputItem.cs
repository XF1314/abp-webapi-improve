using Com.OPPO.Mo.Thirdparty.DataGrand.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索便签（邮件）数据更新InputItem
    /// </summary>
    public class DataGrandMailDataUpdateInputItem : BaseDataGrandDataInputItem
    {
        /// <summary>
        /// <see cref="DataGrandMailDataUpdateInputItem"/>
        /// </summary>
        public DataGrandMailDataUpdateInputItem() : base(MO2DataGrandDataCategory.mail)
        {
            LanguageType = MO2DataGrandLanguageType.Default;
        }

        /// <summary>
        /// 【必填项】邮件标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }


        /// <summary>
        /// 【必填项】邮件内容
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// 【必填项】附件地址s
        /// </summary>
        [JsonProperty("fileurls")]
        public List<string> AttachmentUrls { get; set; }

        /// <summary>
        /// 【必填项】附件名称s,以\3拼接
        /// </summary>
        [JsonProperty("filenames")]
        [JsonConverter(typeof(MO2DataGrandStringListConverter))]
        public List<string> AttachmentNames { get; set; }

        /// <summary>
        /// 【必填项】发送者（帐号或Id）
        /// </summary>
        [JsonProperty("sender")]
        public string Sender { get; set; }

        /// <summary>
        /// 【必填项】发送者姓名
        /// </summary>
        [JsonProperty("sendername")]
        public string SenderName { get; set; }

        /// <summary>
        /// 便签发送时间
        /// </summary>
        [JsonProperty("sendtime")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 【必填项】邮件编码
        /// </summary>
        [JsonIgnore]
        public string MailCode { get; set; }

        /// <summary>
        /// 【必填项】<see cref="DataGrandMailSource"/>
        /// </summary>
        [JsonIgnore]
        public DataGrandMailSource MailSource { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [JsonProperty(LAST_MODIFY_TIME)]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime LastModifyTime { get; set; }

        /// <summary>
        /// 【必填项】拥有者（帐号或Id）
        /// </summary>
        [JsonProperty("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// 【必填项】<see cref="MO2DataGrandLanguageType"/>
        /// </summary>
        [JsonProperty("language")]
        public MO2DataGrandLanguageType LanguageType { get; private set; }

        /// <summary>
        /// 生成ItemId
        /// </summary>
        /// <returns></returns>
        public override string GenerateConventionalItemId()
        {
            if (string.IsNullOrWhiteSpace(Owner))
                throw new Exception("请明确当前便签的拥有者，即收件人/发件人工号");

            if (MailSource == DataGrandMailSource.inbox)
                return string.Format("{0}{1}_{2}", ThirdpartyConsts.DataGrandInboxMailPrefix, MailCode, Owner);
            else if (MailSource == DataGrandMailSource.outbox)
                return string.Format("{0}{1}_{2}", ThirdpartyConsts.DataGrandOutboxMailPrefix, MailCode, Owner);
            else if (MailSource == DataGrandMailSource.trashbox)
                return string.Format("{0}{1}_{2}", ThirdpartyConsts.DataGrandTrashboxMailPrefix, MailCode, Owner);
            else if (MailSource == DataGrandMailSource.draftbox)
                return string.Format("{0}{1}_{2}", ThirdpartyConsts.DataGrandOutboxMailPrefix, MailCode, Owner);
            else
            {
                throw new Exception(string.Format("不支持便签数据来源为:{0}的ItemId自动生成", MailSource.ToString()));
            }
        }
    }
}
