using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.Feiheair.Dtos
{
    /// <summary>
    /// 创建出差申请单输入参数
    /// </summary>
    public class FeiHeairApplyInput
    {
        public FeiHeairApplyInput()
        {
            CostCenterList = new List<FeiHeairCostCenterListDto>();

            AirLineList = new List<FeiHeairAirLineDto>();

            TrainAirLineList = new List<FeiHeairTrainAirLineDto>();

            HotelAirLineList = new List<FeiHeairHotelAirLineDto>();

            Passenger = new List<FeiHeairPassengerItemDto>();
        }

        /// <summary>
        /// 出差申请单号
        /// </summary>
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// 申请人工号
        /// </summary>
        [Required]
        [JsonProperty("applyID")]
        public string ApplyID { get; set; }

        /// <summary>
        /// 申请人姓名
        /// </summary>
        [Required]
        [JsonProperty("applyName")]
        public string ApplyName { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [JsonProperty("applyDate")]
        public DateTime ApplyDate { get; set; }

        /// <summary>
        /// 申请人部门
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 状态 0:申请 1:通过 2:拒绝 3:取消
        /// </summary>
        [Required]
        public int State { get; set; }

        /// <summary>
        /// 交通工具 可多选,用逗号分隔如:1,2,3 (1:汽车2:火车3:飞机)
        /// </summary>
        [Required]
        public string Vehicle { get; set; }

        /// <summary>
        /// 出差开始日期
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// 出差结束日期
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 成本中心(用来承担费用的部门名称)
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary>
        /// 成本中心(用来承担费用的部门名称，接收多个成本中心)
        /// </summary>
        [JsonProperty("costCenterList")]
        public List<FeiHeairCostCenterListDto> CostCenterList { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// 机票折扣 范围：0-1000
        /// </summary>
        public string Discount { get; set; }

        /// <summary>
        /// 舱位等级 1.经济舱 2.公务头等舱
        /// </summary>
        public string CabClass { get; set; }

        /// <summary>
        /// 火车席别  1.商务座  2.特等座 3.一等座 4.二等座 5.高级软卧 6.软卧  7.硬卧 8.软座  9.硬座
        /// </summary>
        public string SeatCode { get; set; }

        /// <summary>
        ///酒店星级  1.经济/客栈 2.三星/舒适 3.四星/高档  4.五星/豪华
        /// </summary>
        public string HotelStar { get; set; }

        /// <summary>
        ///机票航线节点 此节点为空，表示不限航线和乘机日，可以订出差有效日期内的所有航线航班；如此节点不为空，即只可订此节点规定的航线
        /// </summary> 
        [JsonProperty("airLine")]
        public List<FeiHeairAirLineDto> AirLineList { get; set; }

        /// <summary>
        /// 火车节点 此节点为空，表示不限行程，可以订出差有效日期内的所有行程；如此节点不为空，即只可订此节点规定的行程
        /// </summary>
        [JsonProperty("trainAirLine")]
        public List<FeiHeairTrainAirLineDto> TrainAirLineList { get; set; }

        /// <summary>
        /// 酒店节点 此节点为空，表示不限行程，可以订出差有效日期内的所有行程；如此节点不为空，即只可订此节点规定的行程
        /// </summary>
        [JsonProperty("hotelAirLine")]
        public List<FeiHeairHotelAirLineDto> HotelAirLineList { get; set; }

        /// <summary>
        /// 出差人节点 此节点为空，表示不限出差人
        /// </summary>
        [JsonProperty("Passenger")]
        public List<FeiHeairPassengerItemDto> Passenger { get; set; }

    }

    /// <summary>
    /// 成本中心
    /// </summary>
    public class FeiHeairCostCenterListDto
    {
        /// <summary>
        ///成本中心
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary>
        ///对应项目
        /// </summary>
        public string ProjectGroup { get; set; }

        /// <summary>
        ///预算编码
        /// </summary>
        public string BudgetCode { get; set; }

    }

    /// <summary>
    /// 机票航线节点
    /// </summary>
    public class FeiHeairAirLineDto
    {
        /// <summary>
        ///出发城市
        /// </summary>
        public string FrCity { get; set; }

        /// <summary>
        /// 出发城市三字码
        /// </summary>
        public string FrCityCode { get; set; }

        /// <summary>
        /// 到达城市
        /// </summary>
        public string ToCity { get; set; }

        /// <summary>
        /// 到达城市三字码
        /// </summary>
        public string ToCityCode { get; set; }

        /// <summary>
        /// 乘机开始日期
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime BeginFlyDate { get; set; }

        /// <summary>
        /// 乘机结束日期
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime EndFlyDate { get; set; }

        /// <summary>
        /// 最早出发时间  格式(小时:分钟)：“09:05”
        /// </summary>
        public string EarlyFlyTime { get; set; }

        /// <summary>
        /// 最晚出发时间  格式(小时:分钟)：“09:05”
        /// </summary>
        public string LastFlyTime { get; set; }

        /// <summary>
        /// 航班号 只能设一个航班号，比如：ZH1893
        /// </summary>
        public string FlightID { get; set; }

        /// <summary>
        /// 出差人列表 为空代表不限制出差人，多个出差人用逗号(,)隔开，
        /// </summary>
        public string NameList { get; set; }
    }

    /// <summary>
    /// 火车节点
    /// </summary>
    public class FeiHeairTrainAirLineDto
    {
        /// <summary>
        /// 出发站
        /// </summary>
        public string FromStation { get; set; }

        /// <summary>
        /// 到达站
        /// </summary>
        public string ToStation { get; set; }

        /// <summary>
        /// 乘车开始日期
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        /// <summary>
        /// 乘车结束日期
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }

        /// <summary>
        /// 最早出发时间  格式(小时:分钟)：“09:05”
        /// </summary>
        public string EarlyFromTime { get; set; }

        /// <summary>
        /// 最晚出发时间 格式(小时:分钟)：“09:05”
        /// </summary>
        public string LastFromTime { get; set; }


        /// <summary>
        /// 车次号
        /// </summary>
        public string TrainCode { get; set; }

        /// <summary>
        /// 出差人列表
        /// </summary>
        public string NameList { get; set; }

    }

    /// <summary>
    /// 酒店节点
    /// </summary>
    public class FeiHeairHotelAirLineDto
    {
        /// <summary>
        /// 入住城市
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 入住开始日期
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 入住结束日期
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// 最晚抵店 格式(小时:分钟)：“09:05”
        /// </summary>
        public string LastArriveTime { get; set; }

        /// <summary>
        /// 出差人列表 如果需要指定出差人，在此节点设置，为空代表不限制出差人，多个出差人用逗号(,)隔开，比如：张三、李四
        /// </summary>
        public string NameList { get; set; }

    }

    /// <summary>
    /// 出差人节点
    /// </summary>
    public class FeiHeairPassengerItemDto
    {

        /// <summary>
        /// 员工工号
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 所属部门 员工所属的部门名称，格式如下：网优事业部（总）/湖南分公司  多级的部份必须从最顶级开始一级一级列出，上级部门与下级部门之间用“/”分隔(注意：贵司公司名固定为第一级，所以公司名不要传过来，只要传下面的部门过来)
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// 证件类型 乘机人证件类型
        ///1.身份证
        ///2.护照
        ///3.因公护照
        ///4.港澳通行证
        ///5.台湾通行证
        ///6.户口簿
        ///7.学生证
        ///8.回乡证
        ///9.台胞证
        ///10.军人证
        ///11.港澳台居民居住证
        ///12.外国人永久居留身份证
        ///13.其它
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string CardID { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Tel { get; set; }
    }


}
