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
    /// 达观搜索发文数据新增InputItem
    /// </summary>
    public class DataGrandArticleDataAddInputItem : BaseDataGrandDataInputItem
    {
        public const string CREATER_USER_CODE = "createusercode";//createusercode
        public const string CREATOR_USER_NAME = "createusername";        
        public const string CREATOR_DEPARTMENT_NAME = "creationdepartmentname";
        public const string CREATION_TIME = "creationtime";
        public const string AUDITOR_USER_CODES = "auditorcodes";
        public const string APPROVED_AUDITOR_USER_CODES = "approvedauditorcodes";
        public const string AUDITOR_NAMES = "auditornames";
        public const string CURRENT_AUDITOR_USER_CODES = "currentauditorcodes";
        public const string CURRENT_AUDITOR_NAMES = "currentauditornames";
        public const string ARTICLE_CODE = "forminstancecode";
        public const string LANGUAGE_TYPE = "language";
        public const string FORM_STATUS = "formstatus";
        public const string PROCESS_SETTING_ID = "procsetid";    

        /// <summary>
        /// <see cref="DataGrandArticleDataAddInputItem"/>
        /// </summary>
        public DataGrandArticleDataAddInputItem() : base(MO2DataGrandDataCategory.form)
        {
            AttachmentUrls = new List<string>();
            AttachmentNames = new List<string>();
            ControlNames = new List<string>();
            Roles = new List<string>();
        }

        /// <summary>
        /// 【必填项】发文Id
        /// </summary>
        [JsonProperty(ARTICLE_CODE)]
        public string FormInstanceCode { get; set; }

        /// <summary>
        /// 【必填项】流程模板Id
        /// </summary>
        [JsonProperty(PROCESS_SETTING_ID)]
        public int ProcessSetId { get; set; }

        /// <summary>
        /// 【必填项】发文状态
        /// </summary>
        [JsonProperty(FORM_STATUS)]
        public string FormStatus { get; set; }

        /// <summary>
        /// 【必填项】环节状态??
        /// </summary>
        [JsonProperty("linkstatus")]
        public string LinkStatus { get; set; }

        /// <summary>
        /// 【必填项】控件名称拼接产生，以\3分割
        /// </summary>
        [JsonProperty("controlnames")]
        [JsonConverter(typeof(MO2DataGrandStringListConverter))]
        public List<string> ControlNames { get; set; }

        /// <summary>
        /// 【必填项】发文标题
        /// </summary>
        [JsonProperty(TITLE)]
        public string FormTitle { get; set; }

        /// <summary>
        /// 【必填项】发文内容
        /// </summary>
        [JsonProperty(CONTENT)]
        public string FormContent { get; set; }

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
        /// 【必填项】拟制人工号s
        /// </summary>
        [JsonProperty(CREATER_USER_CODE)]
        public List<string> CreatorUserCodes { get; set; }

        /// <summary>
        /// 【必填项】拟制人姓名s
        /// </summary>
        [JsonProperty(CREATOR_USER_NAME)]
        //[JsonConverter(typeof(MO2DataGrandStringListConverter))]
        public List<string> CreatorUserNames { get; set; }

        /// <summary>
        /// 【必填项】拟制部门名称
        /// </summary>
        [JsonProperty(CREATOR_DEPARTMENT_NAME)]
        public string CreatorDepartmentName { get; set; }

        /// <summary>
        /// 【必填项】拟制时间
        /// </summary>
        [JsonProperty(CREATION_TIME)]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime CreationTime { get; set; }        

        /// <summary>
        /// 【必填项】待审批人工号s
        /// </summary>
        [JsonProperty(CURRENT_AUDITOR_USER_CODES)]
        public List<string> CurrentAuditorUserCodes { get; set; }

        /// <summary>
        /// 【必填项】待审批人姓名s，如有多个，请用\3拼接
        /// </summary>
        [JsonProperty(CURRENT_AUDITOR_NAMES)]
        [JsonConverter(typeof(MO2DataGrandStringListConverter))]
        public List<string> CurrentAuditorNames { get; set; }

        /// <summary>
        /// 【必填项】已审批人工号s
        /// </summary>
        [JsonProperty(APPROVED_AUDITOR_USER_CODES)]
        public List<string> ApprovedAuditorUserCodes { get; set; }

        /// <summary>
        /// 【必填项】所有审批人工号s，不包括拟制人
        /// </summary>
        [JsonProperty(AUDITOR_USER_CODES)]
        public List<string> AuditorUserCodes { get; set; }

        /// <summary>
        /// 【必填项】所有审批人姓名s，如有多个，请用\3拼接
        /// </summary>
        [JsonProperty(AUDITOR_NAMES)]
        [JsonConverter(typeof(MO2DataGrandStringListConverter))]
        public List<string> AuditorNames { get; set; }

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
        /// 【必填项】最后审批人姓名
        /// </summary>
        [JsonProperty("lastauditorname")]
        public string LastAuditorUserName { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [JsonProperty(LAST_MODIFY_TIME)]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime LastModifyTime { get; set; }

        /// <summary>
        /// 【可填项】动态控件搜索项，utf-8 编码,允许在某些情况下留空
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string,object> ControlValueItem { get; set; }

        /// <summary>
        /// 【必填项】该条数据对应的权限角色列表，列表元素为string类型，可能为userId、groupId或departId的抽象角色，
        /// 采用加前缀的方式进行区分，userId前加"u_"，groupId前加"g_"，departId前加"d_"，对于权限角色，
        /// 业务系统可以进行自定义，保证角色的唯一性，保证与用户侧的角色一致即可。
        /// 如: [“u_1002”, “g_2001”, “d_2001”]
        /// </summary>
        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

        /// <summary>
        /// 【必填项】语言
        /// </summary>
        [JsonProperty("language")]
        public MO2DataGrandLanguageType LanguageType { get; set; }

        /// <summary>
        /// 【必填项】用户唯一标识ID，审批人为工号，读者为环节ID
        /// </summary>
        public string UserItemID { get; set; }

        /// <summary>
        /// 生成ItemId(如果区别对待同一发文的不同审批阶段，那么需要调整此方法的实现)
        /// </summary>
        /// <returns></returns>
        public override string GenerateConventionalItemId()
        {
            return string.Format("{0}_{1}_{2}", FormInstanceCode, UserItemID, (int)LanguageType);
        }

    }
}
