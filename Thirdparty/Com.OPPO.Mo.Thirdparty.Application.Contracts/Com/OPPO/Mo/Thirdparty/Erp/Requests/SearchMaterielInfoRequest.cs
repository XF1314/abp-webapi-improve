using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    public class SearchMaterielInfoRequest: BaseEsbRequest
    {
        /// <summary>
        /// 物料编码
        /// </summary>
        public string item_code { get; set; }
        /// <summary>
        /// 物料描述
        /// </summary>
        public string item_desc { get; set; }
        /// <summary>
        /// 大类名称
        /// </summary>
        public string major_category { get; set; }
        /// <summary>
        /// 小类名称
        /// </summary>
        public string minor_category { get; set; }
        /// <summary>
        /// 组织代码
        /// </summary>
        public string organization_code { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int page_index { get; set; }
        /// <summary>
        /// 页大小
        /// </summary>
        public int page_size { get; set; }
    }
}
