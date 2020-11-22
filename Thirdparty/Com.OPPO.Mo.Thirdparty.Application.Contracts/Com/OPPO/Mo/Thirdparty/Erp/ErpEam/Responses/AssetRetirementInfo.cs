using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpEam.Responses
{

    public class AssetRetirementInfo
    {
        /// <summary>
        /// 实例编号
        /// </summary>
        public string InstanceNumber { get; set; }
        /// <summary>
        /// 资产编号
        /// </summary>
        public string AssetNumber { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        public double OriginalCost { get; set; }
        /// <summary>
        /// 预订/储备
        /// </summary>
        public double DeprnReserve { get; set; }
        /// <summary>
        /// 类别代码
        /// </summary>
        public string CategoryCode { get; set; }
        /// <summary>
        /// 书名
        /// </summary>
        public string BookName { get; set; }
        /// <summary>
        /// 剩余价值
        /// </summary>
        public double SurplusValue { get; set; }
        /// <summary>
        /// 付款公司OU
        /// </summary>
        public string OuName { get; set; }
        /// <summary>
        /// 组织代码
        /// </summary>
        public string OrgCode { get; set; }
    }
}
