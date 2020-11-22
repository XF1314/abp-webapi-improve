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
    /// 基础达观搜索用户行为InputItem
    /// </summary>
    public class BaseDataGrandUserBehaviorInputItem
    {
        /// <summary>
        /// <see cref="BaseDataGrandUserBehaviorInputItem"/>
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="dataCategory"><see cref="MO2DataGrandDataCategory"/></param>
        /// <param name="behaviorType"><see cref="MO2DataGrandBehaviorType"/></param>
        /// <param name="itemId">搜索行为固定传2，点击行为传点击对象的itemid</param>
        public BaseDataGrandUserBehaviorInputItem(string userCode,  MO2DataGrandDataCategory dataCategory, MO2DataGrandBehaviorType behaviorType,string itemId)
        {
            DataCategory = dataCategory;
            BehaviorType = behaviorType;
            DateTime = DateTime.Now;
            UserCode = userCode;
            ItemId = itemId;
        }

        /// <summary>
        /// <see cref="MO2DataGrandDataCategory"/>
        /// 【通用字段】MO包括 "all", "form", "mail", "module"
        /// </summary>
        [JsonProperty("module")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MO2DataGrandDataCategory DataCategory { get; private set; }

        /// <summary>
        /// <see cref="MO2DataGrandBehaviorType"/>
        /// 【通用字段】用户行为，包括 "search", "search_click", "sort", 后续可拓展至其他行为
        /// </summary>
        [JsonProperty("action_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MO2DataGrandBehaviorType BehaviorType { get; private set; }

        /// <summary>
        /// 【通用字段】行为发生的时间，使用linux时间戳。未传递时使用当前系统时间
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime DateTime { get; private set; }

        /// <summary>
        /// 【通用字段】用户工号
        /// </summary>
        [JsonProperty("userid")]
        public string UserCode { get; private set; }

        /// <summary>
        /// 【通用字段】用户所属部门名称，如“营销部”
        /// </summary>
        [JsonProperty("depart")]
        public string DepartmentName { get; set; }

        /// <summary>
        /// 【通用字段】用户所属组织代码，如“320013”
        /// </summary>
        [JsonProperty("orgcode")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// 【通用字段】用户职务名称，如“终端管理员”
        /// </summary>
        [JsonProperty("jobtitle")]
        public string JobTilte { get; set; }

        /// <summary>
        /// 【通用字段】搜索行为固定传2，点击行为传点击对象的itemid
        /// </summary>
        [JsonProperty("itemid")]
        public string ItemId { get; private  set; }

        /// <summary>
        /// 通用字段】用户职务等级，如“12级”
        /// </summary>
        [JsonProperty("joblevel")]
        public string JobLevel { get; set; }

        /// <summary>
        /// 【附加字段】
        /// 当为搜索时，可以通过该参数传递过滤条件：{ "filter": "author=张三" }；
        /// 当为点击时，可以通过该参数传递点击条目类型：{ "itemtype": "form" }
        /// </summary>
        [JsonProperty("other_info")]
        public object OtherInformation { get; set; }
    }
}
