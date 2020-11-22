using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Dtos
{
    public  class DataGrandArticleAggregateSearchInput:BaseDataGrandAggregateSearchInput
    {
        /// <summary>
        /// 拟制人部门名称
        /// </summary>
        public string DrafterDepartmentName { get; set; }

        /// <summary>
        /// 拟制人姓名
        /// </summary>
        public string DrafterName { get; set; }

        /// <summary>
        /// 拟制人工号
        /// </summary>
        public string DrafterUserCode { get; set; }

        /// <summary>
        /// 审批人姓名
        /// </summary>
        public string AuditorName { get; set; }

        /// <summary>
        /// 审批人工号
        /// </summary>
        public string AuditorUserCode { get; set; }

        /// <summary>
        /// <see cref="FormInstanceStatus"/>
        /// </summary>
        public int? FormStatus { get; set; }

        /// <summary>
        /// 发文编号
        /// </summary>
        public string ArticleCode { get; set; }

        /// <summary>
        /// 流程模块Id
        /// </summary>
        public int? ProcessSettingId { get; set; }

        /// <summary>
        /// 拟制时间(From)
        /// </summary>
        public DateTime? DraftTimeFrom { get; set; }

        /// <summary>
        /// 拟制时间(To)
        /// </summary>
        public DateTime? DraftTimeTo { get; set; }

        /// <summary>
        /// 公布时间(From)
        /// </summary>
        public DateTime? PublicTimeFrom { get; set; }

        /// <summary>
        /// 公布时间(To)
        /// </summary>
        public DateTime? PublicTimeTo { get; set; }
    }
}
