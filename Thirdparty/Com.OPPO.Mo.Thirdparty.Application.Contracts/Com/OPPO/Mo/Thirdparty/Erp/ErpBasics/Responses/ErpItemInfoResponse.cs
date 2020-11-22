using Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Responses
{
  
    public class Material
    {
        /// <summary>
        /// 组织id
        /// </summary>
        public int OrgId { get; set; }
        /// <summary>
        /// 类别id
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// 组织代码
        /// </summary>
        public string OrgCode { get; set; }
        /// <summary>
        /// 物料代码
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 专业类别
        /// </summary>
        public string MajorCategory { get; set; }
        /// <summary>
        /// 次要类别
        /// </summary>
        public string MinorCategory { get; set; }
        /// <summary>
        /// 主要计量单位代码
        /// </summary>
        public string PrimaryUomCode { get; set; }
        /// <summary>
        /// 物料类别
        /// </summary>
        public string ItemType { get; set; }
        /// <summary>
        /// 固定倍数
        /// </summary>
        public int FixedLotMultiplier { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 上次更新日期
        /// </summary>
        public DateTime LastUpdateDate { get; set; }
        /// <summary>
        /// 采购模型
        /// </summary>
        public string PurchaseModel { get; set; }
        /// <summary>
        /// 采购员
        /// </summary>
        public string Buyer { get; set; }
        /// <summary>
        /// 采购员？
        /// </summary>
        public string BuyZykf { get; set; }
        /// <summary>
        /// 探员姓名
        /// </summary>
        public string AgentName { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string VmiInv { get; set; }
    }


    public class ErpItemInfoBody
    {
        /// <summary>
        /// 物料信息
        /// </summary>
        public MaterialDto materialcode { get; set; }

        /// <summary>
        /// 返回编码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }

    }

    public class ErpItemInfoResponse
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        [JsonProperty("response")]
        public ErpItemInfoBody Response { get; set; }
    }


}
