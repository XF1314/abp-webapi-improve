using Com.OPPO.Mo.Thirdparty.DataGrand.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索便签（邮件）数据新增InputItem
    /// </summary>
    public class DataGrandMailDataAddInputItem : BaseDataGrandDataInputItem
    {
        public const string SENDER_NAME = "sendername";
        public const string SENDER_USER_CODE = "sender";
        public const string RECEIVER_NAMES = "receivernames";
        public const string RECEIVER_USER_CODES = "receivers";
        public const string SEND_TIME = "sendtime";
        public const string MAIL_TYPE = "mailtype";
        public const string LANGUAGE_TYPE = "language";

        /// <summary>
        /// <see cref="DataGrandMailDataAddInputItem"/>
        /// </summary>
        public DataGrandMailDataAddInputItem() : base(MO2DataGrandDataCategory.mail)
        {
            AttachmentUrls = new List<string>();
            AttachmentNames = new List<string>();
            Receivers = new List<string>();
            ReceiverNames = new List<string>();
            LanguageType = MO2DataGrandLanguageType.Default;
        }

        /// <summary>
        /// 【必填项】邮件编码
        /// </summary>
        [JsonProperty("mailid")]
        public string MailCode { get; set; }

        /// <summary>
        /// 【必填项】邮件标题
        /// </summary>
        [JsonProperty(TITLE)]
        public string Title { get; set; }

        /// <summary>
        /// 【必填项】邮件内容
        /// </summary>
        [JsonProperty(CONTENT)]
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
        /// 【必填项】拥有者（帐号或Id）
        /// </summary>
        [JsonProperty("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// 【必填项】发送者（帐号或Id）
        /// </summary>
        [JsonProperty(SENDER_USER_CODE)]
        public string Sender { get; set; }

        /// <summary>
        /// 【必填项】发送者姓名
        /// </summary>
        [JsonProperty(SENDER_NAME)]
        public string SenderName { get; set; }

        /// <summary>
        /// 【必填项】收件人s（帐号或Id）
        /// 如邮箱类型为<see cref="DataGrandMailSource.inbox"/>，则为单值列表；
        /// 如邮箱类型为<see cref="DataGrandMailSource.outbox"/>，则为多值列表（收件人id或部门id）
        /// </summary>
        [JsonProperty(RECEIVER_USER_CODES)]
        public List<string> Receivers { get; set; }

        /// <summary>
        /// 【必填项】所有接受者姓名s,以\3拼接
        /// </summary>
        [JsonProperty(RECEIVER_NAMES)]
        [JsonConverter(typeof(MO2DataGrandStringListConverter))]
        public List<string> ReceiverNames { get; set; }

        /// <summary>
        /// 【必填项】<see cref="DataGrandMailSource"/>
        /// </summary>
        [JsonProperty(MAIL_TYPE)]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataGrandMailSource MailSource { get; set; }

        /// <summary>
        /// 便签创建时间
        /// </summary>
        [JsonProperty("creationtime")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 便签发送时间
        /// </summary>
        [JsonProperty(SEND_TIME)]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [JsonProperty(LAST_MODIFY_TIME)]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime LastModifyTime { get; set; }

        /// <summary>
        /// 【必填项】<see cref="MO2DataGrandLanguageType"/>
        /// </summary>
        [JsonProperty(LANGUAGE_TYPE)]
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

    /// <summary>
    /// 达观搜索便签数据来源
    /// </summary>
    public enum DataGrandMailSource
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Display(Name = "所有")]
        all = 0,

        /// <summary>
        /// 收件箱
        /// </summary>
        [Display(Name = "收件箱")]
        inbox = 1,

        /// <summary>
        /// 发件箱
        /// </summary>
        [Display(Name = "发件箱")]
        outbox = 2,

        /// <summary>
        /// 废纸篓
        /// </summary>
        [Display(Name = "废纸篓")]
        trashbox = 3,

        /// <summary>
        /// 草稿箱
        /// </summary>
        [Display(Name = "草稿箱")]
        draftbox = 4
    }
}
