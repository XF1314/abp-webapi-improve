using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Dtos
{

    public class bbkInfoDto: PoLineBaseDto
    {
        /// <summary>
        /// 本次请求Id（用于追踪问题）
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// 接受编码
        /// </summary>
        [JsonProperty("receive_num")]
        public string ReceiveNum { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [JsonProperty("unit_price")]
        public string UnitPrice { get; set; }
        /// <summary>
        /// 税
        /// </summary>
        [JsonProperty("price_tax")]
        public double PriceTax { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        [JsonProperty("seq_id")]
        public int SeqId { get; set; }
        /// <summary>
        /// OU名称
        /// </summary>
        [JsonProperty("ou_name")]
        public string OuName { get; set; }
        /// <summary>
        /// 组织代码
        /// </summary>
        [JsonProperty("org_code")]
        public string OrgCode { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [JsonProperty("ItemDesc")] 
        public string item_desc { get; set; }


        /// <summary>
        /// 截止日期
        /// </summary>
        [JsonProperty("need_by_date")]
        [JsonConverter(typeof(DateStringConverter))]
        public DateTime NeedbyDate { get; set; }
        /// <summary>
        /// 申请者
        /// </summary>
        [JsonProperty("apply_by")]
        public string ApplyBy { get; set; }
        /// <summary>
        /// 申请日期
        /// </summary>
        [JsonProperty("apply_date")] 
        public DateTime ApplyDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("comments")]
        public string Comments { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [JsonProperty("create_by")] 
        public int CreateBy { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [JsonProperty("create_date")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 买方姓名
        /// </summary>
        [JsonProperty("buyer_name")]
        public string BuyerName { get; set; }
        /// <summary>
        /// 买方电话
        /// </summary>
        [JsonProperty("buyer_phone")]
        public string BuyerPhone { get; set; }
        /// <summary>
        /// 装运地址
        /// </summary>
        [JsonProperty("ship_address")]
        public string ShipAddress { get; set; }



        /// <summary>
        /// 错误消息
        /// </summary>
        [JsonProperty("err_msg")] 
        public string ErrMsg { get; set; }
    }

}
