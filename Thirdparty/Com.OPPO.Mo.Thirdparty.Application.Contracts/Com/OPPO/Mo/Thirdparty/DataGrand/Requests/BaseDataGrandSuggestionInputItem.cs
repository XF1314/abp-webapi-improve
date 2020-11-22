using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    /// 基础达观搜索提示词InputItem
    /// </summary>
    public class BaseDataGrandSuggestionInputItem
    {
        private string _itemId;

        /// <summary>
        /// 数据项Id
        /// </summary>
        public const string ITEM_ID = "itemid";


        /// <summary>
        /// <see cref="BaseDataGrandSuggestionInputItem"/>
        /// </summary>
        public BaseDataGrandSuggestionInputItem()
        {
        }

        /// <summary>
        /// 【必填项】数据记录Id
        /// </summary>
        [JsonProperty("itemid")]
        public string ItemId
        {
            get
            {
                if (!string.IsNullOrEmpty(_itemId))
                    return _itemId;
                else
                    return GenerateConventionalItemId();
            }
            set { _itemId = value; }
        }

        /// <summary>
        /// 生成ItemId
        /// </summary>
        /// <returns></returns>
        public virtual string GenerateConventionalItemId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
