using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Dtos
{
    public class OnePlusItemDto
    {
        /// <summary>
        /// 人员工号
        /// </summary>
        public string EmployId { get; set; }

        /// <summary>
        /// 文件编号
        /// </summary>
        public string TransferPaymntId { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public double SeqNum { get; set; }
        /// <summary>
        /// 实际处理月份,例2015/12
        /// </summary>
        public string Month { get; set; }
        /// <summary>
        /// 员工奖励
        /// </summary>
        public double EmployeeReward { get; set; }
        /// <summary>
        /// 交通补贴
        /// </summary>
        public double TransportationSubsidy { get; set; }
        /// <summary>
        /// 其它税前
        /// </summary>
        public double OtherPreTax { get; set; }
        /// <summary>
        /// 其它税后
        /// </summary>
        public double OtherTaxes { get; set; }
        /// <summary>
        /// 奖励金额
        /// </summary>
        public double RewardAmount { get; set; }
        /// <summary>
        /// 绩效扣分金额
        /// </summary>
        public double AmountOfPerformanceDeduction { get; set; }
        /// <summary>
        /// 内推奖金
        /// </summary>
        public double InternalBonus { get; set; }
        /// <summary>
        /// 专利奖金
        /// </summary>
        public double PatentBonus { get; set; }
        /// <summary>
        /// 公司级别表彰奖励
        /// </summary>
        public double CompanyLevelReward { get; set; }
        /// <summary>
        /// 中心级别表彰奖励
        /// </summary>
        public double CenterLevelAwards { get; set; }
        /// <summary>
        /// 研发项目奖惩
        /// </summary>
        public double RewardsAndPunishments { get; set; }
        /// <summary>
        /// 举报奖励
        /// </summary>
        public double RewardForReporting { get; set; }
        /// <summary>
        /// 年会抽奖
        /// </summary>
        public double AnnualMeetingDraw { get; set; }
        /// <summary>
        /// 政府项目福利
        /// </summary>
        public double GovernmentProjectWelfare { get; set; }
        /// <summary>
        /// 违规扣款
        /// </summary>
        public double ViolationsDeduction { get; set; }
        /// <summary>
        /// 财务扣款
        /// </summary>
        public double FinancialDeduction { get; set; }
        /// <summary>
        /// 外籍发票
        /// </summary>
        public double ForeignInvoice { get; set; }
        /// <summary>
        /// 派驻租房补贴
        /// </summary>
        public double RentSubsidy { get; set; }
        /// <summary>
        /// 扣税不发薪
        /// </summary>
        public double NoSalaryWithTaxDeduction { get; set; }
        /// <summary>
        /// 扣房租
        /// </summary>
        public double DeductionOfRent { get; set; }
        /// <summary>
        /// 扣水电
        /// </summary>
        public double WaterAndElectricity { get; set; }
        /// <summary>
        /// 资产赔偿
        /// </summary>
        public double AssetCompensation { get; set; }
        /// <summary>
        /// 行政后勤扣款
        /// </summary>
        public double AdministrativeLogisticsDeduction { get; set; }
        /// <summary>
        /// 工签收入扣款
        /// </summary>
        public double DeductionOfWorkPermitIncome { get; set; }


        /// <summary>
        /// 系数
        /// </summary>
        public int Rate { get; set; }
        /// <summary>
        /// 绩效奖金
        /// </summary>
        public double AchievementBonus { get; set; }
        /// <summary>
        /// 执行状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 添加者
        /// </summary>
        public string AddedBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 更新者
        /// </summary>
        public string UpdatedBy { get; set; }
    }
}
