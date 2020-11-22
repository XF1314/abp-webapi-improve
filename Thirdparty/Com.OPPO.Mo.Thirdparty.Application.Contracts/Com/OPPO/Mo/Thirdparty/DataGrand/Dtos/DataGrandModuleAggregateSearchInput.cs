using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Dtos
{
    public class DataGrandModuleAggregateSearchInput : BaseDataGrandAggregateSearchInput
    {
        /// <summary>
        /// 模块类型
        /// </summary>
        public MO2DataGrandModuleType? ModuleType { get; set; }
    }
}
