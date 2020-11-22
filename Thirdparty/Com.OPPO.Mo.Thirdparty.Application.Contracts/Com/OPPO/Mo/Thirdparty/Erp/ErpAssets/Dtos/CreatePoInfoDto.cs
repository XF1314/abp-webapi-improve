using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Dtos
{

    public class CreatePoInfoDto:CreatePoInfoBaseDto
    {
       
        /// <summary>
        /// 税码
        /// </summary>
        public string TaxCode { get; set; }
        /// <summary>
        /// 来源订单
        /// </summary>
        public string SourceOrder { get; set; }
        /// <summary>
        /// 来源系统
        /// </summary>
        public string SourceSystem { get; set; }
    }
}
