using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Dtos
{
    public class BaseDataGrandAggregateSearchInput
    {
        /// <summary>
        /// <see cref="BaseDataGrandAggregateSearchInput"/>
        /// </summary>
        public BaseDataGrandAggregateSearchInput()
        {
            LanguageType = MO2DataGrandLanguageType.Default;
            Count = ThirdpartyConsts.DefaultDataGrandPageSize;
            SearchScope = DataGrandSearchScope.All;
            Offset = 0;
        }

        /// <summary>
        /// <see cref="MO2DataGrandLanguageType"/>
        /// </summary>
        public MO2DataGrandLanguageType LanguageType { get; set; }

        /// <summary>
        /// <see cref="DataGrandSearchScope"/>
        /// </summary>
        public DataGrandSearchScope SearchScope { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 分页返回结果的开始项，默认为0。注意offset不是起始页数，而是当前页的起始条数。比如每页返回条数count=10, 则第1页的offset=0, 第2页的offset=10,以此类推。
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// 每页返回的结果条数，默认为20，最大为50，例如当offset为10，count为20时，返回搜索结果的第10-30条结果。
        /// </summary>
        public int Count { get; set; }
    }
}
