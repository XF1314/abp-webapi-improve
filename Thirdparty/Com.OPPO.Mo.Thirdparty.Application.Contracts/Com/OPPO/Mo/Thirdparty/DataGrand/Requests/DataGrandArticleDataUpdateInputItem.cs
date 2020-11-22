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
    /// 达观搜索发文数据更新InputItem
    /// </summary>
    public class DataGrandArticleDataUpdateInputItem : BaseDataGrandDataInputItem
    {
        /// <summary>
        /// <see cref="DataGrandArticleDataUpdateInputItem"/>
        /// </summary>
        public DataGrandArticleDataUpdateInputItem() : base(MO2DataGrandDataCategory.form)
        {
            Roles = new List<string>();
        }

        /// <summary>
        /// 【必填项】发文Id
        /// </summary>
        [JsonIgnore]
        public string FormInstanceCode { get; set; }

        /// <summary>
        /// 【必填项】当前审批节点Id
        /// </summary>
        [JsonIgnore]
        public string AuditActivityId { get; set; }

        /// <summary>
        /// 【必填项】当前审批节点名称
        /// </summary>
        [JsonProperty("auditactivityname")]
        public string AuditActivityName { get; set; }

        /// <summary>
        /// 【必填项】审批人姓名s，如有多个，请用\3拼接
        /// </summary>
        [JsonProperty("auditornames")]
        [JsonConverter(typeof(MO2DataGrandStringListConverter))]
        public List<string> AuditorNames { get; set; }

        /// <summary>
        /// 【必填项】审批人工号s
        /// </summary>
        [JsonProperty("auditorcodes")]
        public List<string> AuditorUserCodes { get; set; }

        /// <summary>
        /// 【必填项】最后审批人姓名
        /// </summary>
        [JsonProperty("lastauditorname")]
        public string LastAuditorUserName { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [JsonProperty("lastmodifytime")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime LastModifyTime { get; private set; }

        /// <summary>
        /// 【必填项】附件Urls
        /// </summary>
        [JsonProperty("attachments")]
        public List<string> AttachmentUrls { get; set; }

        /// <summary>
        /// 【必填项】附件名称s,如有多个，请用\3分隔，并保持与attachments的顺序一致
        /// </summary>
        [JsonProperty("attachmentnames")]
        [JsonConverter(typeof(MO2DataGrandStringListConverter))]
        public List<string> AttachmentNames { get; set; }

        /// <summary>
        /// 【必填项】发文内容
        /// </summary>
        [JsonProperty("content")]
        public string FormContent { get; set; }

        /// <summary>
        /// 【必填项】该条数据对应的权限角色列表，列表元素为string类型，
        /// 可能为userid、groupid或departid的抽象角色，采用加前缀的方式进行区分，
        /// userid前加"u_"，groupid前加"g_"，departid前加"d_"，对于权限角色，业务系统可以进行自定义，
        /// 保证角色的唯一性，保证与用户侧的角色一致即可，如：[“u_1002”, “g_2001”, “d_2001”]
        /// </summary>
        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

        /// <summary>
        /// 生成ItemId(如果区别对待同一发文的不同审批阶段，那么需要调整此方法的实现)
        /// </summary>
        /// <returns></returns>
        public override string GenerateConventionalItemId()
        {
            return string.Format("{0}_{1}", FormInstanceCode, AuditActivityId);
        }

    }
}
