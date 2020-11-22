using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Dtos
{
    /// <summary>
    /// 发文信息
    /// </summary>
    public class ArticleInfo
    {
        /// <summary>
        /// <see cref="ArticleInfo"/>
        /// </summary>
        public ArticleInfo()
        {
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
        /// 发文Id
        /// </summary>
        public string FormInstanceCode { get; set; }

        /// <summary>
        /// 流程模板Id
        /// </summary>
        public int ProcessSetId { get; set; }

        /// <summary>
        /// 流程名称
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// 【必填项】控件名称拼接产生，以\3分割
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// 发文状态
        /// </summary>
        public string FormStatus { get; set; }

        /// <summary>
        /// 发文标题
        /// </summary>
        public string FormTitle { get; set; }

        /// <summary>
        /// 发文内容
        /// </summary>
        public string FormContent { get; set; }

        /// <summary>
        /// 附件Urls
        /// </summary>
        public List<string> AttachmentUrls { get; set; }

        /// <summary>
        /// 附件名称s,如有多个，请用\3分隔，并保持与attachments的顺序一致
        /// </summary>
        public List<string> AttachmentNames { get; set; }

        /// <summary>
        /// 拟制人工号
        /// </summary>
        public List<string> CreatorUserCodes { get; set; }

        /// <summary>
        /// 拟制人姓名
        /// </summary>
        public List<string> CreatorUserNames { get; set; }

        /// <summary>
        /// 拟制部门名称
        /// </summary>
        public string CreatorDepartmentName { get; set; }

        /// <summary>
        /// 拟制时间
        /// </summary>
        [JsonConverter(typeof(DateTimeStringConverter))]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 审批人工号s
        /// </summary>
        public List<string> AuditorUserCodes { get; set; }

        /// <summary>
        /// 审批人姓名s，如有多个，请用\3拼接
        /// </summary>
        public string AuditorNames { get; set; }

        /// <summary>
        /// 当前审批节点名称
        /// </summary>
        public string AuditActivityName { get; set; }

        /// <summary>
        /// 最后审批人姓名
        /// </summary>
        public string LastAuditorUserName { get; set; }

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
                { "forminstancecode","formInstanceCode" },
                { "procsetid","processSetId" },
                { "controlnames","keyWords" },
                { "formstatus","formStatus" },
                { "title","formTitle" },
                { "content","formContent" },
                { "attachments","attachmentUrls" },
                { "attachmentnames","attachmentNames" },
                { "createusercode","creatorUserCodes" },
                { "createusername","creatorUserNames" },
                { "creationdepartmentname","creatorDepartmentName" },
                { "creationtime","creationTime" },
                { "auditorcodes","auditorUserCodes" },
                { "auditornames","auditorNames" },
                { "auditactivityname","auditActivityName" },
                { "lastauditorname","lastAuditorUserName" },
                { "lastmodifytime","lastModifyTime" },
                { "sim_score","score" },
            });
    }

    /// <summary>
    /// 发文来源
    /// </summary>
    public enum ArticleSource
    {
        /// <summary>
        ///  全部
        /// </summary>
        [Display(Name = "全部")]
        All = 0,

        /// <summary>
        ///  我的起草
        /// </summary>
        [Display(Name = "我的起草")]
        MyDrafting = 1,

        /// <summary>
        ///  我的审批
        /// </summary>
        [Display(Name = "我的审批")]
        MyApproval = 2,

        /// <summary>
        ///  
        /// </summary>
        [Display(Name = "我的阅读")]
        MyReading = 3,

        /// <summary>
        ///  我已审批
        /// </summary>
        [Display(Name = "我已审批")]
        MyApproved = 4,

    }
}
