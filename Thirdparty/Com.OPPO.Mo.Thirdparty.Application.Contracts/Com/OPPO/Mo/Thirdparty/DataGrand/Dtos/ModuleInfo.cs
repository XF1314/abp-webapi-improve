using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Dtos
{
    /// <summary>
    /// 模块(功能/流程)信息
    /// </summary>
    public class ModuleInfo
    {
        /// <summary>
        /// <see cref="ModuleInfo"/>
        /// </summary>
        public ModuleInfo()
        {
            NavigationUrl = "/";
            AccessUrl = "/";
            PlaceHolderImageUri = "";
        }

        /// <summary>
        /// 数据记录Id
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// 面包屑，譬如：营销管理—营销管理支持—营销系统软件开发申请
        /// </summary>
        public string Crumbs { get; set; }

        /// <summary>
        /// 导航地址(相对)
        /// 对于<see cref="MO2DataGrandModuleType.process"/>来说，对应其列表页
        /// 对于<see cref="MO2DataGrandModuleType.function"/>来说，同<see cref="ModuleInfo.AccessUrl"/>
        /// </summary>
        public string NavigationUrl { get; set; }

        /// <summary>
        /// 访问地址(相对)
        /// 对于<see cref="MO2DataGrandModuleType.process"/>来说，对应其拟制页
        /// 对于<see cref="MO2DataGrandModuleType.function"/>来说，同<see cref="ModuleInfo.NavigationUrl"/>
        /// </summary>
        public string AccessUrl { get; set; }

        /// <summary>
        /// 占位图片Uri
        /// </summary>
        public string PlaceHolderImageUri { get; set; }

        /// <summary>
        /// <see cref="MO2DataGrandDataCategory"/>
        /// </summary>
        public MO2DataGrandDataCategory DataCategory { get; set; }

        /// <summary>
        /// <see cref="MO2DataGrandModuleType"/>
        /// </summary>
        public MO2DataGrandModuleType ModuleType { get; set; }

        /// <summary>
        /// 模块Id
        /// </summary>
        public string ModuleId { get; set; }

        /// <summary>
        /// 功能或流程模块名称
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// 模块描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 流程/功能控件参数名拼接，以,分割
        /// </summary>
        public List<string> Keywords { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [JsonConverter(typeof(DateTimeStringConverter))]
        public DateTime LastModifyTime { get; set; }

        /// <summary>
        /// 高亮s
        /// </summary>
        public List<DataGrandHighlightOutputItem> Highlights { get; set; }

        /// <summary>
        /// 处理字段映射
        /// </summary>
        public void ProcessFeildMapping()
        {
            if (Highlights != null)
            {
                Highlights.ForEach(x => {
                    x.TargetFieldName = FeildMappings[x.TargetFieldName];
                });
            }
        }

        /// <summary>
        /// MO与达观搜索的字段映射
        /// </summary>
        [JsonIgnore]
        private readonly ReadOnlyDictionary<string, string> FeildMappings = new ReadOnlyDictionary<string, string>(
            new Dictionary<string, string>
            {
                { "itemid","itemId" },
                { "cateid","dataCategory" },
                { "moduleid","moduleId" },
                { "modulename","moduleName" },
                { "type","moduleType" },
                { "description","description" },
                { "keywords","keywords" },
                { "lastmodifytime","lastModifyTime" },
                { "sim_score","score" }
            });
    }
}
