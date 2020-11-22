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
    /// 达观搜索模块数据删除InputItem
    /// </summary>
    public class DataGrandModuleDataDeleteInputItem : BaseDataGrandDataInputItem
    {
        /// <summary>
        /// <see cref="DataGrandModuleDataDeleteInputItem"/>
        /// </summary>
        public DataGrandModuleDataDeleteInputItem() : base(MO2DataGrandDataCategory.module)
        {
            LanguageType = MO2DataGrandLanguageType.Default;
        }

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
