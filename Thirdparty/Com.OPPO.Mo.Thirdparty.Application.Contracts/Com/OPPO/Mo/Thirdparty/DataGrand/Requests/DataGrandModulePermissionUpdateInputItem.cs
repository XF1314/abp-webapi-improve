using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    /// 达观搜索模块权限更新InputItem
    /// </summary>
    public sealed class DataGrandModulePermissionUpdateInputItem : BaseDataGrandDataInputItem
    {
        /// <summary>
        /// <see cref="DataGrandModulePermissionUpdateInputItem"/>
        /// </summary>
        public DataGrandModulePermissionUpdateInputItem() : base(MO2DataGrandDataCategory.module)
        {
            Roles = new List<string>();
            LanguageType = MO2DataGrandLanguageType.Default;
        }

        /// <summary>
        /// 【必填项】该条数据对应的权限角色列表，列表元素为string类型，
        /// 可能为userid、groupid或departid的抽象角色，采用加前缀的方式进行区分，
        /// userid前加"u_"，groupid前加"g_"，departid前加"d_"，对于权限角色，业务系统可以进行自定义，
        /// 保证角色的唯一性，保证与用户侧的角色一致即可，如：[“u_1002”, “g_2001”, “d_2001”]
        /// </summary>
        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [JsonProperty(LAST_MODIFY_TIME)]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime LastModifyTime { get; set; }

        /// <summary>
        /// 【必填项】模块Id
        /// </summary>
        [JsonIgnore]
        public string ModuleId { get; set; }

        /// <summary>
        /// 【必填项】<see cref="MO2DataGrandModuleType"/>
        /// </summary>
        [JsonIgnore]
        public MO2DataGrandModuleType ModuleType { get; set; }

        /// <summary>
        /// 【必填项】<see cref="MO2DataGrandLanguageType"/>
        /// </summary>
        [JsonIgnore]
        public MO2DataGrandLanguageType LanguageType { get; set; }

        /// <summary>
        /// 生成ItemId
        /// </summary>
        /// <returns></returns>
        public override string GenerateConventionalItemId()
        {
            var itemIdLanguagePrefix = LanguageType == MO2DataGrandLanguageType.Chinese
                ? ThirdpartyConsts.DataGrandChineseItemIdPrefix
                : LanguageType == MO2DataGrandLanguageType.English
                ? ThirdpartyConsts.DataGrandEnglishItemIdPrefix
                : ThirdpartyConsts.DataGrandChineseItemIdPrefix;


            if (ModuleType == MO2DataGrandModuleType.process)
                return string.Format("{0}{1}{2}", itemIdLanguagePrefix, ThirdpartyConsts.DataGrandProcessModulePrefix, ModuleId);
            else if (ModuleType == MO2DataGrandModuleType.function)
                return string.Format("{0}{1}{2}", itemIdLanguagePrefix, ThirdpartyConsts.DataGrandFunctionModulePrefix, ModuleId);
            else if (ModuleType == MO2DataGrandModuleType.extension)
                return string.Format("{0}{1}{2}", itemIdLanguagePrefix, ThirdpartyConsts.DataGrandExtensionModulePrefix, ModuleId);
            else
            {
                throw new Exception("未知的模块类型");
            }
        }
    }
}
