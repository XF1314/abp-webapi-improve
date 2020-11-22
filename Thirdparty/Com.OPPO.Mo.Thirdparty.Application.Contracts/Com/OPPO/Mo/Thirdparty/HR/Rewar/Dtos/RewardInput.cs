using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.Hr.Rewar.Dtos
{
    /// <summary>
    ///员工奖惩 Input
    /// </summary>
    public class RewardInput
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// 员工编码
        /// </summary>
        [Required]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// 员工类型
        /// </summary>
        [Required]
        public string EmployeeType { get; set; }

        /// <summary>
        /// Pin Number
        /// </summary>
        [Required]
        public string PinNumber { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [Required]
        public string Amount { get; set; }

        /// <summary>
        /// 货币类型
        /// </summary>
        [Required]
        public string CurrencyType { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        [Required]
        public string ActionType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Required]
        public string Remark { get; set; }

        /// <summary>
        /// 发文编码
        /// </summary>
        [Required]
        public string FormInstanceCode { get; set; }

        /// <summary>
        /// 原因
        /// </summary>
        [Required]
        public string Reason { get; set; }

        /// <summary>
        /// 奖分
        /// </summary>
        [Required]
        public string Point { get; set; }

    }
}
