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
    /// 达观搜索提示词新增Input
    /// </summary>
    public class DataGrandSuggestionAddInputItem : BaseDataGrandSuggestionInputItem
    {
        /// <summary>
        /// <see cref="DataGrandSuggestionAddInputItem"/>
        /// </summary>
        public DataGrandSuggestionAddInputItem()
        {
            SuggestionId = Guid.NewGuid().ToString("N");
            SuggestionSource = DataGrandSuggestionSource.System;
            PermissionType = DataGrandSuggestionPermissionType.@public;
            CreationTime = DateTime.Now;
            LastUpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 提示Id
        /// </summary>
        [JsonIgnore]
        public string SuggestionId { get; set; }

        /// <summary>
        ///【必填项】 <see cref="DataGrandSuggestionSource"/>
        /// </summary>
        [JsonProperty("source")]
        public DataGrandSuggestionSource SuggestionSource { get; set; }

        /// <summary>
        /// 【必填项】<see cref="DataGrandSuggestionPermissionType"/>
        /// </summary>
        [JsonProperty("permission")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataGrandSuggestionPermissionType PermissionType { get; private set; }

        /// <summary>
        /// 【必填项】提示词
        /// </summary>
        [JsonProperty("keyword")]
        public string SuggestionWord { get; set; }

        /// <summary>
        /// 【必填项】提示词权重（0~10）
        /// </summary>
        [JsonProperty("weight")]
        public double Weight { get; set; }

        /// <summary>
        /// 【必填项】创建时间
        /// </summary>
        [JsonProperty("create_time")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 【必填项】最后更新时间
        /// </summary>
        [JsonProperty("last_update_time")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime LastUpdateTime { get; set; }

        /// <summary>
        /// 生成ItemId
        /// </summary>
        /// <returns></returns>
        public override string GenerateConventionalItemId()
        {
            if (SuggestionSource == DataGrandSuggestionSource.ExtensionModule
                || SuggestionSource == DataGrandSuggestionSource.FunctionModule
                || SuggestionSource == DataGrandSuggestionSource.ProcessModule)
            {
                if (string.IsNullOrWhiteSpace(SuggestionId))
                    throw new Exception(string.Format("{0}、{1}、{2}类型提示词必须提供SuggestionId。",
                        DataGrandSuggestionSource.ExtensionModule.ToString(),
                        DataGrandSuggestionSource.FunctionModule.ToString(),
                        DataGrandSuggestionSource.FunctionModule.ToString()));
                else if (SuggestionSource == DataGrandSuggestionSource.ExtensionModule)
                    return string.Format("{0}{1}", ThirdpartyConsts.DataGrandExtensionModuleSuggestionPrefix, SuggestionId);
                else if (SuggestionSource == DataGrandSuggestionSource.FunctionModule)
                    return string.Format("{0}{1}", ThirdpartyConsts.DataGrandFunctionModulePrefix, SuggestionId);
                else
                    return string.Format("{0}{1}", ThirdpartyConsts.DataGrandProcessModuleSuggestionPrefix, SuggestionId);
            }
            else
            {
                return string.Format("{0}{1}", ThirdpartyConsts.DataGrandCustomSuggestionPrefix, SuggestionWord.Md5Digest());
            }
        }
    }
}
