using System;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Feiheair.Dtos
{
    /// <summary>
    /// 获取申请单(订单)对应订单数据输出信息
    /// </summary>
    public class FeiHeairOrderDto
    {

        public FeiHeairOrderDto()
        {
            OrderDatas = new List<FeiHeairOrderDataDto>();
        }
        /// <summary>
        /// 错误代码(0表示成功，其它为失败)
        /// </summary>
        public int ErrCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }

        /// <summary>
        /// 申请单状态（0:申请；1:通过；2:拒绝；3:取消）
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 订单数据列表
        /// </summary>
        public List<FeiHeairOrderDataDto> OrderDatas { get; set; }

    }

    /// <summary>
    /// 订单数据列表
    /// </summary>
    public class FeiHeairOrderDataDto
    {
        public FeiHeairOrderDataDto()
        {
            Tickets = new List<FeiHeairTicketsItemDto>();
            Policys = new List<FeiHeairPolicysItemDto>();
        }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 订单状态 0:预留 1:出票 2:取消
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 退改签类型
        /// </summary>
        public string TgzType { get; set; }

        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        ///  出票日期
        /// </summary>
        public DateTime? PrintDate { get; set; }

        /// <summary>
        /// 订票人
        /// </summary>
        public string Orderer { get; set; }

        /// <summary>
        /// 申请单号
        /// </summary>
        public string ApplicationDh { get; set; }

        /// <summary>
        /// 关联订单号
        /// </summary>
        public string OrderIdRef { get; set; }

        /// <summary>
        /// 应付款
        /// </summary>
        public string RecPrice { get; set; }

        /// <summary>
        /// 保险费
        /// </summary>
        public string InsurancePrice { get; set; }

        /// <summary>
        /// 保险人
        /// </summary>
        public string InsurancePerson { get; set; }

        /// <summary>
        /// 飞机乘机人列表
        /// </summary>
        public List<FeiHeairTicketsItemDto> Tickets { get; set; }
        /// <summary>
        /// 违反差旅政策列表
        /// </summary>
        public List<FeiHeairPolicysItemDto> Policys { get; set; }



    }

    /// <summary>
    /// 飞机乘机人列表
    /// </summary>
    public class FeiHeairTicketsItemDto
    {
        /// <summary>
        /// ?
        /// </summary>
        public string Auto { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 证件号
        /// </summary>
        public string CardID { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string CertType { get; set; }

        /// <summary>
        /// 出发城市
        /// </summary>
        public string FrCityName { get; set; }

        /// <summary>
        /// 到达城市
        /// </summary>
        public string ToCityName { get; set; }

        /// <summary>
        /// 航班号
        /// </summary>
        public string FlightID { get; set; }

        /// <summary>
        /// 乘机日
        /// </summary>
        public string FlyDate { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        public DateTime? FlyTime { get; set; }

        /// <summary>
        /// 到达时间
        /// </summary>
        public DateTime? ArriveTime { get; set; }

        /// <summary>
        /// 舱位
        /// </summary>
        public string Bunk { get; set; }

        /// <summary>
        /// 票面价
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// 税费
        /// </summary>
        public Decimal ACF { get; set; }

        /// <summary>
        /// 税费
        /// </summary>
        public Decimal BAF { get; set; }

        /// <summary>
        /// 服务费
        /// </summary>
        public string ServiceCharge { get; set; }

        /// <summary>
        /// 全价
        /// </summary>
        public string FullPrice { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public string Discount { get; set; }
        /// <summary>
        /// 机票应付款
        /// </summary>
        public string RecPrice { get; set; }

        /// <summary>
        /// 退票费
        /// </summary>
        public Decimal CReturnFee { get; set; }

        /// <summary>
        /// 票号
        /// </summary>
        public string TicketNo { get; set; }

        /// <summary>
        /// 退改签类型
        /// </summary>
        public string TgzType { get; set; }

        /// <summary>
        /// 仓位等级
        /// </summary>
        public string CabClass { get; set; }

        /// <summary>
        /// 提前订票天数
        /// </summary>
        public string BeforeDay { get; set; }

    }

    /// <summary>
    /// 违反差旅政策列表
    /// </summary>
    public class FeiHeairPolicysItemDto
    {
        /// <summary>
        /// ?
        /// </summary>
        public string Auto { get; set; }

        /// <summary>
        /// 政策类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 违反原因
        /// </summary>
        public string Reason { get; set; }
    }
}
