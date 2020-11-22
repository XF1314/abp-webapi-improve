using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Megvii.Dto
{
    public class QueryTermsDto
    {
        /// <summary>
        /// 查询页数,非必填
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 一页条数,非必填
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// 名称,非必填
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 解释,非必填
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 更新信息人员名称,非必填
        /// </summary>
        public string UpdateUserName { get; set; }
        /// <summary>
        /// 排序字段enum: 'id', 'name', 'subject_type', 'update_time', 'update_by', 'subject_count',非必填
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// 升降序enum: 'asc', 'desc',非必填
        /// </summary>
        public string Order { get; set; }
        /// <summary>
        /// 查询的数据类型0: 员工 1:访客 不传或者其他: 全部,非必填
        /// </summary>
        public string SubjectType { get; set; }
    }
}
