using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Dtos
{
    public class DataGrandMailAggregateSearchInput:BaseDataGrandAggregateSearchInput
    {
        /// <summary>
        /// <see cref="DataGrandMailSource"/>
        /// </summary>
        public DataGrandMailSource? MailSource { get; set; }

        /// <summary>
        /// 发送人姓名
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// 发送人工号
        /// </summary>
        public string SenderUserCode { get; set; }

        /// <summary>
        /// 收件人姓名
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// 收件人工号
        /// </summary>
        public string ReceiverUserCode { get; set; }

        /// <summary>
        /// 发送时间(From)
        /// </summary>
        public DateTime? SendTimeFrom { get; set; }

        /// <summary>
        /// 发送时间(To)
        /// </summary>
        public DateTime? SendTimeTo { get; set; }
    }
}
