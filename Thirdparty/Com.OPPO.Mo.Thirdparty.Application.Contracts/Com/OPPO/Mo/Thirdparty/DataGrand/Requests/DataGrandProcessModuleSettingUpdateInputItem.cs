using Com.OPPO.Mo.Thirdparty;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    /// 达观搜索流程模块设置更新Input
    /// </summary>
    public class DataGrandProcessModuleSettingUpdateInputItem : BaseDataGrandDataInputItem
    {
        /// <summary>
        /// <see cref="DataGrandProcessModuleSettingUpdateInputItem"/>
        /// </summary>
        public DataGrandProcessModuleSettingUpdateInputItem() : base(MO2DataGrandDataCategory.module)
        {
        }

        /// <summary>
        /// 【必填项】功能或流程模块名称
        /// </summary>
        [JsonProperty("modulename")]
        public string ModuleName { get; set; }

        /// <summary>
        /// 【必填项】模块描述
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [JsonProperty("lastmodifytime")]
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
        /// 生成ItemId
        /// </summary>
        /// <returns></returns>
        public override string GenerateConventionalItemId()
        {
            if (ModuleType == MO2DataGrandModuleType.process)
                return ThirdpartyConsts.DataGrandProcessModulePrefix + ModuleId;
            else if (ModuleType == MO2DataGrandModuleType.function)
                return ThirdpartyConsts.DataGrandFunctionModulePrefix + ModuleId;
            else
            {
                throw new Exception("未知的模块类型");
            }
        }
    }
}
