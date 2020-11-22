using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpSrm.Dtos
{
    public class UpdateIfreceivingDto
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        public string DocId { get; set; }
        /// <summary>
        /// 收据编号
        /// </summary>
        public string ReceiptNumber { get; set; }
        /// <summary>
        /// 物料编号
        /// </summary>
        public string MaterialCode { get; set; }
    }
}
