using Com.OPPO.Mo.Thirdparty.DataGrand.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索模块数据新增InputItem
    /// </summary>
    public class DataGrandModuleDataAddInputItem : BaseDataGrandDataInputItem
    {
        public const string MODULE_NAME = "modulename";
        public const string LANGUAGE_TYPE = "language";
        public const string MODULE_TYPE = "type";
        public const string MODULE_DESCRIPTION = "description";

        /// <summary>
        /// <see cref="DataGrandModuleDataAddInputItem"/>
        /// </summary>
        public DataGrandModuleDataAddInputItem() : base(MO2DataGrandDataCategory.module)
        {
            Roles = new List<string>();
            Keywords = new List<string>();
            LanguageType = MO2DataGrandLanguageType.Default;
        }

        /// <summary>
        /// 【必填项】模块Id
        /// </summary>
        [JsonProperty("moduleid")]
        public string ModuleId { get; set; }

        /// <summary>
        /// 【必填项】功能或流程模块名称
        /// </summary>
        [JsonProperty(MODULE_NAME)]
        public string ModuleName { get; set; }

        /// <summary>
        /// 【必填项】<see cref="MO2DataGrandModuleType"/>
        /// </summary>
        [JsonProperty(MODULE_TYPE)]
        [JsonConverter(typeof(StringEnumConverter))]
        public MO2DataGrandModuleType ModuleType { get; set; }

        /// <summary>
        /// 【必填项】<see cref="MO2DataGrandLanguageType"/>
        /// </summary>
        [JsonProperty(LANGUAGE_TYPE)]
        public MO2DataGrandLanguageType LanguageType { get; set; }

        /// <summary>
        /// 【必填项】模块描述
        /// </summary>
        [JsonProperty(MODULE_DESCRIPTION)]
        public string Description { get; set; }

        /// <summary>
        /// 【必填项】流程/功能控件参数名拼接，以\3分割
        /// </summary>
        [JsonProperty("keywords")]
        [JsonConverter(typeof(MO2DataGrandStringListConverter))]
        public List<string> Keywords { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [JsonProperty(LAST_MODIFY_TIME)]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime LastModifyTime { get; set; }

        /// <summary>
        /// 【必填项】该条数据对应的权限角色列表，列表元素为string类型，
        /// 可能为userid、groupid或departid的抽象角色，采用加前缀的方式进行区分，
        /// userid前加"u_"，groupid前加"g_"，departid前加"d_"，对于权限角色，业务系统可以进行自定义，
        /// 保证角色的唯一性，保证与用户侧的角色一致即可，如：[“u_1002”, “g_2001”, “d_2001”]
        /// </summary>
        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

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
