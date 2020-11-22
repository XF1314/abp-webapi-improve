using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Requests
{

    public class OnePlusItem
    {
        /// <summary>
        /// 人员工号
        /// </summary>
        [JsonProperty("emplId")]
        public string EmployId { get; set; }

        /// <summary>
        /// 文件编号
        /// </summary>
        [JsonProperty("transferPaymntId")] 
        public string TransferPaymntId { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [JsonProperty("seqnum")]
        public double SeqNum { get; set; }
        /// <summary>
        /// 实际处理月份,例2015/12
        /// </summary>
        [JsonProperty("calPrdId")] 
        public string Month { get; set; }
        /// <summary>
        /// 员工奖励
        /// </summary>
        [JsonProperty("cAmt001")] 
        public double EmployeeReward { get; set; }
        /// <summary>
        /// 交通补贴
        /// </summary>
        [JsonProperty("cAmt002")] 
        public double TransportationSubsidy { get; set; }
        /// <summary>
        /// 其它税前
        /// </summary>
        [JsonProperty("cAmt003")] 
        public double OtherPreTax { get; set; }
        /// <summary>
        /// 其它税后
        /// </summary>
        [JsonProperty("cAmt004")]
        public double OtherTaxes { get; set; }
        /// <summary>
        /// 奖励金额
        /// </summary>
        [JsonProperty("cAmt005")] 
        public double RewardAmount { get; set; }
        /// <summary>
        /// 绩效扣分金额
        /// </summary>
        [JsonProperty("cAmt006")] 
        public double AmountOfPerformanceDeduction { get; set; }
        /// <summary>
        /// 内推奖金
        /// </summary>
        [JsonProperty("cAmt007")]
        public double InternalBonus { get; set; }
        /// <summary>
        /// 专利奖金
        /// </summary>
        [JsonProperty("cAmt008")]
        public double PatentBonus { get; set; }
        /// <summary>
        /// 公司级别表彰奖励
        /// </summary>
        [JsonProperty("cAmt009")]
        public double CompanyLevelReward { get; set; }
        /// <summary>
        /// 中心级别表彰奖励
        /// </summary>
        [JsonProperty("cAmt010")] 
        public double CenterLevelAwards { get; set; }
        /// <summary>
        /// 研发项目奖惩
        /// </summary>
        [JsonProperty("cAmt011")] 
        public double RewardsAndPunishments { get; set; }
        /// <summary>
        /// 举报奖励
        /// </summary>
        [JsonProperty("cAmt012")]
        public double RewardForReporting { get; set; }
        /// <summary>
        /// 年会抽奖
        /// </summary>
        [JsonProperty("cAmt013")] 
        public double AnnualMeetingDraw { get; set; }
        /// <summary>
        /// 政府项目福利
        /// </summary>
        [JsonProperty("cAmt014")] 
        public double GovernmentProjectWelfare { get; set; }
        /// <summary>
        /// 违规扣款
        /// </summary>
        [JsonProperty("cAmt015")] 
        public double ViolationsDeduction { get; set; }
        /// <summary>
        /// 财务扣款
        /// </summary>
        [JsonProperty("cAmt016")] 
        public double FinancialDeduction { get; set; }
        /// <summary>
        /// 外籍发票
        /// </summary>
        [JsonProperty("cAmt017")] 
        public double ForeignInvoice { get; set; }
        /// <summary>
        /// 派驻租房补贴
        /// </summary>
        [JsonProperty("cAmt018")] 
        public double RentSubsidy { get; set; }
        /// <summary>
        /// 扣税不发薪
        /// </summary>
        [JsonProperty("cAmt019")] 
        public double NoSalaryWithTaxDeduction { get; set; }
        /// <summary>
        /// 扣房租
        /// </summary>
        [JsonProperty("cAmt020")] 
        public double DeductionOfRent { get; set; }
        /// <summary>
        /// 扣水电
        /// </summary>
        [JsonProperty("cAmt021")] 
        public double WaterAndElectricity { get; set; }
        /// <summary>
        /// 资产赔偿
        /// </summary>
        [JsonProperty("cAmt022")] 
        public double AssetCompensation { get; set; }
        /// <summary>
        /// 行政后勤扣款
        /// </summary>
        [JsonProperty("cAmt023")] 
        public double AdministrativeLogisticsDeduction { get; set; }
        /// <summary>
        /// 工签收入扣款
        /// </summary>
        [JsonProperty("cAmt024")] 
        public double DeductionOfWorkPermitIncome { get; set; }


        /// <summary>
        /// 系数
        /// </summary>
        [JsonProperty("cPerfRate")] 
        public int Rate { get; set; }
        /// <summary>
        /// 绩效奖金
        /// </summary>
        [JsonProperty("cAdjAmtPers")] 
        public double AchievementBonus { get; set; }
        /// <summary>
        /// 执行状态
        /// </summary>
        [JsonProperty("cEffStatus")] 
        public string Status { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [JsonProperty("hrsRowAddDttm")]
        [JsonConverter(typeof(DateTimeStringConverter))]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 添加者
        /// </summary>
        [JsonProperty("hrsRowAddOprid")] 
        public string AddedBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonProperty("hrsRowUpdDttm")]
        [JsonConverter(typeof(DateTimeStringConverter))]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 更新者
        /// </summary>
        [JsonProperty("hrsRowUpdOprid")] 
        public string UpdatedBy { get; set; }
    }

}
