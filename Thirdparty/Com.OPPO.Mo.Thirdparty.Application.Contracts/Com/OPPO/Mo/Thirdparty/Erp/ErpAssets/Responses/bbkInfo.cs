using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Responses
{
    public class bbkInfo: PoLineBase
    {
        /// <summary>
        /// 本次请求Id（用于追踪问题）
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// 接受编码
        /// </summary>
        public string ReceiveNum { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public string UnitPrice { get; set; }
        /// <summary>
        /// 税
        /// </summary>
        public double PriceTax { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        public int SeqId { get; set; }
        /// <summary>
        /// OU名称
        /// </summary>
        public string OuName { get; set; }
        /// <summary>
        /// 组织代码
        /// </summary>
        public string OrgCode { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string item_desc { get; set; }


        /// <summary>
        /// 截止日期
        /// </summary>
        public DateTime NeedbyDate { get; set; }
        /// <summary>
        /// 申请者
        /// </summary>
        public string ApplyBy { get; set; }
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime ApplyDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 买方姓名
        /// </summary>
        public string BuyerName { get; set; }
        /// <summary>
        /// 买方电话
        /// </summary>
        public string BuyerPhone { get; set; }
        /// <summary>
        /// 装运地址
        /// </summary>
        public string ShipAddress { get; set; }



        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrMsg { get; set; }
    }
}
