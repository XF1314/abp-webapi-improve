using Com.OPPO.Mo.Thirdparty.DataGrand.Dtos;
using Com.OPPO.Mo.Thirdparty.DataGrand.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索发文数据查询OutputItem
    /// </summary>
    public class DataGrandArticleDataQueryOutputItem
    {
        /// <summary>
        /// <see cref="DataGrandArticleDataQueryOutputItem"/>
        /// </summary>
        public DataGrandArticleDataQueryOutputItem()
        {
            Highlights = new List<DataGrandHighlightOutputItem>();
        }

        /// <summary>
        /// 数据记录Id
        /// </summary>
        [JsonProperty("itemid")]
        public string ItemId { get; protected set; }

        /// <summary>
        /// <see cref="MO2DataGrandDataCategory"/>
        /// </summary>
        [JsonProperty("cateid")]
        //[JsonConverter(typeof(StringEnumConverter))]
        public MO2DataGrandDataCategory DataCategory { get; private set; }

        /// <summary>
        /// 发文Id
        /// </summary>
        [JsonProperty("forminstancecode")]
        public string FormInstanceCode { get; set; }

        /// <summary>
        /// 流程模板Id
        /// </summary>
        [JsonProperty("procsetid")]
        public int ProcessSetId { get; set; }

        /// <summary>
        /// 【必填项】控件名称拼接产生，以\3分割
        /// </summary>
        [JsonProperty("controlnames")]
        public string KeyWords { get; set; }

        /// <summary>
        /// 发文状态
        /// </summary>
        [JsonProperty("formstatus")]
        public string FormStatus { get; set; }

        /// <summary>
        /// 发文标题
        /// </summary>
        [JsonProperty("title")]
        public string FormTitle { get; set; }

        /// <summary>
        /// 发文内容
        /// </summary>
        [JsonProperty("content")]
        public string FormContent { get; set; }

        /// <summary>
        /// 附件Urls
        /// </summary>
        [JsonProperty("attachments")]
        public List<string> AttachmentUrls { get; set; }

        /// <summary>
        /// 附件名称s,如有多个，请用\3分隔，并保持与attachments的顺序一致
        /// </summary>
        [JsonProperty("attachmentnames")]
        [JsonConverter(typeof(MO2DataGrandStringListConverter))]
        public List<string> AttachmentNames { get; set; }

        /// <summary>
        /// 拟制人工号
        /// </summary>
        [JsonProperty("createusercode")]
        public List<string> CreatorUserCodes { get; set; }

        /// <summary>
        /// 拟制人姓名
        /// </summary>
        [JsonProperty("createusername")]
        [JsonConverter(typeof(MO2DataGrandStringListConverter))]
        public List<string> CreatorUserNames { get; set; }

        /// <summary>
        /// 拟制部门名称
        /// </summary>
        [JsonProperty("creationdepartmentname")]
        public string CreatorDepartmentName { get; set; }

        /// <summary>
        /// 拟制时间
        /// </summary>
        [JsonProperty("creationtime")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 审批人工号s
        /// </summary>
        [JsonProperty("auditorcodes")]
        public List<string> AuditorUserCodes { get; set; }

        /// <summary>
        /// 审批人姓名s，如有多个，请用\3拼接
        /// </summary>
        [JsonProperty("auditornames")]
        public string AuditorNames { get; set; }

        /// <summary>
        /// 当前审批节点名称
        /// </summary>
        [JsonProperty("auditactivityname")]
        public string AuditActivityName { get; set; }

        /// <summary>
        /// 最后审批人姓名
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
