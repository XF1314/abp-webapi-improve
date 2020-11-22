using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    public class ErpToolingFixtureApplicationApprovalInfoDto
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        public string FormInstanceCode { get; set; }
        /// <summary>
        /// 类型：默认COMMON
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 财务十一段合成：公司代码.事业部代码.部门代码.区域代码.渠道代码.产品线代码.主科目代码.子科目代码.预算编码代码.贸易伙伴代码.保留代码.
        /// </summary>
        public string AccountCode { get; set; }
    }
}
