using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    /// 达观搜索用户点击行为新增InputItem
    /// </summary>
    public class DataGrandUserClickBehaviorAddInputItem : BaseDataGrandUserBehaviorInputItem
    {
        /// <summary>
        /// <see cref="DataGrandUserClickBehaviorAddInputItem"/>
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="dataCategory"><see cref="MO2DataGrandDataCategory"/></param>
        /// <param name="itemId">用户点击对象的itemid</param>
        public DataGrandUserClickBehaviorAddInputItem(string userCode, MO2DataGrandDataCategory dataCategory, string itemId) : base(userCode, dataCategory, MO2DataGrandBehaviorType.search_click,itemId)
        {


        }

    }
}
