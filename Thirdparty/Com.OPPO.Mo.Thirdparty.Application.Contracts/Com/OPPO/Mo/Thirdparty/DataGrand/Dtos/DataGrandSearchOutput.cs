using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Dtos
{
    /// <summary>
    /// 达观搜索Output
    /// </summary>
    public class DataGrandSearchOutput
    {
        /// <summary>
        /// <see cref="DataGrandSearchOutput"/>
        /// </summary>
        public DataGrandSearchOutput()
        {
            MailItems = new List<MailInfo> { };
            ModuleItems = new List<ModuleInfo> { };
            ArticleItems = new List<ArticleInfo> { };

            SortedItems = new List<KeyValuePair<string, MO2DataGrandDataCategory>> { };
        }


        /// <summary>
        /// 数据项总数
        /// </summary>
        public long TotalItemCount { get; set; }

        /// <summary>
        /// 有序的数据Items
        /// </summary>
        public List<KeyValuePair<string, MO2DataGrandDataCategory>> SortedItems { get; set; }

        /// <summary>
        /// <see cref="List{ModuleInfo}"/>模块信息s
        /// </summary>
        public List<ModuleInfo> ModuleItems { get; set; }

        /// <summary>
        /// <see cref="List{ArticleInfo}"/>发文数据项s
        /// </summary>
        public List<ArticleInfo> ArticleItems { get; set; }

        /// <summary>
        /// <see cref="List{MailInfo}"/>便签数据项s
        /// </summary>
        public List<MailInfo> MailItems { get; set; }
    }
}
