using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    /// 基础达观搜索数据InputItem
    /// </summary>
    public abstract class BaseDataGrandDataInputItem
    {
        private string _itemId;

        /// <summary>
        /// 数据项Id
        /// </summary>
        public const string ITEM_ID = "itemid";

        /// <summary>
        /// 数据类型Id
        /// </summary>
        public const string DATA_CATEGORY_ID = "cateid";

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public const string LAST_MODIFY_TIME = "lastmodifytime";

        /// <summary>
        /// 标题
        /// </summary>
        public const string TITLE = "title";

        /// <summary>
        /// 内容
        /// </summary>
        public const string CONTENT = "content";

        /// <summary>
        /// <see cref="BaseDataGrandDataInputItem"/>
        /// </summary>
        /// <param name="dataCategory"><see cref="MO2DataGrandDataCategory"/></param>
        public BaseDataGrandDataInputItem(MO2DataGrandDataCategory dataCategory)
        {
            DataCategory = dataCategory;
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
        /// 【必填项】<see cref="MO2DataGrandDataCategory"/>
        /// </summary>
        [JsonProperty("cateid")]
        //[JsonConverter(typeof(StringEnumConverter))]
        public MO2DataGrandDataCategory DataCategory { get; private set; }

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
