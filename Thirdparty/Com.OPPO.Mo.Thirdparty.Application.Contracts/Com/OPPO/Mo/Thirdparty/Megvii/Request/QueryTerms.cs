
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Megvii.Request
{
    public class QueryTerms
    {
        /// <summary>
        /// 查询页数,非必填
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }
        /// <summary>
        /// 一页条数,非必填
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }
        /// <summary>
        /// 名称,非必填
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 解释,非必填
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }
        /// <summary>
        /// 更新信息人员名称,非必填
        /// </summary>
        [JsonProperty("update_user_name")]
        public string UpdateUserName { get; set; }
        /// <summary>
        /// 排序字段enum: 'id', 'name', 'subject_type', 'update_time', 'update_by', 'subject_count',非必填
        /// </summary>
        [JsonProperty("order_by")]
        public string OrderBy { get; set; }

        /// <summary>
        /// 升降序enum: 'asc', 'desc',非必填
        /// </summary>
        [JsonProperty("order")]
        public string Order { get; set; }
        /// <summary>
        /// 查询的数据类型0: 员工 1:访客 不传或者其他: 全部,非必填
        /// </summary>
        [JsonProperty("subject_type")]
        public string SubjectType { get; set; }
    }
}
