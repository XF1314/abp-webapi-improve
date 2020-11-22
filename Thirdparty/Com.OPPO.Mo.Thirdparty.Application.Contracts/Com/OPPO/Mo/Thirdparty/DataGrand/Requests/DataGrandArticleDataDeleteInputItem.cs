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
    /// 达观搜索发文数据删除InputItem
    /// </summary>
    public class DataGrandArticleDataDeleteInputItem:BaseDataGrandDataInputItem
    {
        /// <summary>
        /// <see cref="DataGrandArticleDataDeleteInputItem"/>
        /// </summary>
        public DataGrandArticleDataDeleteInputItem() : base(MO2DataGrandDataCategory.form)
        {
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
        public string UserItemID { get; set; }

        /// <summary>
        /// 【必填项】<see cref="MO2DataGrandLanguageType"/>
        /// </summary>
        [JsonIgnore]
        public MO2DataGrandLanguageType LanguageType { get; set; }

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
