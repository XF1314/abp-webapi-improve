using System;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Feiheair.Dtos
{
    /// <summary>
    /// 主动获取消息输出参数
    /// </summary>  
    public class FeiHeairOrderMsgDto
    {
        public FeiHeairOrderMsgDto()
        {
            OrdeMsgList = new List<OrdeMsg>();

        }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }

        /// <summary>
        /// 0表示成功，其它为失败
        /// </summary>
        public int ErrCode { get; set; }

        public List<OrdeMsg> OrdeMsgList { get; set; }
    }


    /// <summary>
    /// 消息列表
    /// </summary>
    public class OrdeMsg
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 申请单号(出差申请单号)
        /// </summary>
        public string ApplyID { get; set; }

        /// <summary>
        /// 订单状态(-1：出错，0：预留，1：出票，2：取消，3：申请审批)
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 错误信息 如果State为-1，此列才会有内容
        /// </summary>
        public string errMsg { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateDate { get; set; }
    }
}
