using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.DiDi.Dtos
{
    /// <summary>
    /// 创建DD审批输入参数
    /// </summary>
    public class DiDiCreateInput
    {
        public DiDiCreateInput()
        {
            ApprovalType = ApprovalType.Travel;
        }

        /// <summary>
        /// 授权后的access token
        /// </summary>
        [Required]
        public string AccessToken { get;  set; }

        /// <summary>
        /// 申请人手机号
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// 审批单类型（1-差旅 travel、2-商务出行 business trip按次数、3-商务出行 business trip按日期）只能选择其一
        /// </summary>
        [JsonIgnore]
        public ApprovalType ApprovalType { get; set; }

        /// <summary>
        /// 旅行详细信息（ApprovalType=1必传，其余不传）
        /// </summary>      
        public TravelDetail TravelDetail { get; set; }

        /// <summary>
        /// 制度Id
        /// </summary>
        [Required]
        public string RegulationId { get; set; }
    }

    /// <summary>
    /// 旅行详细信息
    /// </summary>
    public class TravelDetail
    {
        /// <summary>
        /// 行程开始日期，如2017-01-10
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 行程结束日期，如2017-02-01
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 行程路线，行程使用的制度(regulation_id)中，出差城市配置为无需填写时，trips可为空。否则必传，需按照行程顺序填写
        /// </summary>
        public IList<DiDiTrips> Trips { get; set; }

        /// <summary>
        /// 行程终点城市是否包含市内用车权限（0-不包含，1-包含），trips最后一行视为终点城市
        /// </summary>
        public EndCityRule EndCityRule { get; set; }
    }

    /// <summary>
    ///  审批单类型
    /// </summary>
    public enum ApprovalType
    {
        /// <summary>
        /// 差旅
        /// </summary>
        [Description("差旅")]
        Travel = 1,

        /// <summary>
        /// 商务出行
        /// </summary>
        [Description("商务出行按次数")]
        BusinessTripNumber = 2,

        /// <summary>
        /// 商务出行按日期
        /// </summary>
        [Description("商务出行按日期")]
        BusinessTripNumberDate = 3
    }

    /// <summary>
    ///  是否包含市内用车权限
    /// </summary>
    public enum EndCityRule
    {
        /// <summary>
        /// 不包含
        /// </summary>
        [Description("不包含")]
        NoContain = 0,

        /// <summary>
        /// 包含
        /// </summary>
        [Description("包含")]
        Contain = 1
    }
}
