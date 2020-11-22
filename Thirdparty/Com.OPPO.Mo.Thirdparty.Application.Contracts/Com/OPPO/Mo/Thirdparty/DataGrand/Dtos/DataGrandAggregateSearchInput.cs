using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Dtos
{
    public class DataGrandAggregateSearchInput : BaseDataGrandAggregateSearchInput
    {
        /// <summary>
        /// 时间(From)
        /// (发文状态为已公布&&发文公布时间>=DateTimeFrom)||(发文拟制时间>=DateTimeFrom)||(便签发送时间>=DateTimeFrom)
        /// </summary>
        public DateTime? DateTimeFrom { get; set; }

        /// <summary>
        /// 时间(To)
        /// (发文状态为已公布&&发文公布时间<=DateTimeFrom)||(发文拟制时间<=DateTimeFrom)||(便签发送时间<=DateTimeFrom)
        /// </summary>
        public DateTime? DateTimeTo { get; set; }
    }
}
