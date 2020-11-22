using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索时间比较
    /// </summary>
    public class DataGrandDatetimeComparision
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string DateTimeFieldName { get; set; }

        /// <summary>
        /// 比较符
        /// </summary>
        public DataGrandDatetimeComparisonOperator comparisonOperator { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 时间戳(秒)
        /// </summary>
        public long DateTimeStamp { get { return (long)(DateTime - ThirdpartyConsts.DataGrandEraTime).TotalSeconds; } }
    }
}
