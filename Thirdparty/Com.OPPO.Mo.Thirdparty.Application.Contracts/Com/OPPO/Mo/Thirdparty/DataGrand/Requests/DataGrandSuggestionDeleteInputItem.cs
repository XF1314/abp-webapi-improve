using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    /// 达观搜索提示词删除InputItem
    /// </summary>
    public class DataGrandSuggestionDeleteInputItem : BaseDataGrandSuggestionInputItem
    {
        /// <summary>
        /// <see cref="DataGrandSuggestionDeleteInputItem"/>
        /// </summary>
        public DataGrandSuggestionDeleteInputItem(string itemId) 
        {
            ItemId = itemId;
        }
    }
}
