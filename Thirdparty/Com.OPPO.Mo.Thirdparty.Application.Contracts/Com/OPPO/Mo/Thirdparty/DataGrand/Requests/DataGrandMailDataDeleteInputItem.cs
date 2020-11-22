using Com.OPPO.Mo.Thirdparty.DataGrand.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索便签（邮件）数据删除InputItem
    /// </summary>
    public class DataGrandMailDataDeleteInputItem : BaseDataGrandDataInputItem
    {
        /// <summary>
        /// <see cref="DataGrandMailDataDeleteInputItem"/>
        /// </summary>
        public DataGrandMailDataDeleteInputItem() : base(MO2DataGrandDataCategory.mail)
        {

        }

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
        /// 【必填项】便签拥有者的员工编码（即收件人/发件人工号）
        /// </summary>
        [JsonIgnore]
        public string Owner { get; set; }

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
