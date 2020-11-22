using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.DiDi.Requests
{
    /// <summary>
    /// 创建滴滴审批单输入参数
    /// </summary>
    public class DiDiCreateRequest: IAppIdInfo, ICompanyId //ISignatureBasedRequest
    {
        /// <summary>
        /// <see cref="DiDiCreateRequest"/>
        /// </summary>
        public DiDiCreateRequest()
        {
            AppId = null;
        }

        /// <summary>
        /// 申请应用时分配的AppKey
        /// </summary>
        [JsonProperty("client_id")]
        public string AppId { get; set; }

        /// <summary>
        /// 授权后的access token
        /// </summary>
        [JsonProperty("access_token")]
        public string Token { get; set; }

        /// <summary>
        /// 当前时间戳
        /// </summary>
        [JsonProperty("timestamp")]
        public string DateTime { get; set; }

        /// <summary>
        /// 企业ID
        /// </summary>
        [JsonProperty("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        /// 申请人手机号
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 制度Id
        /// </summary>
        [JsonProperty("regulation_id")]
        public string RegulationId { get; set; }

        /// <summary>
        /// 审批单类型（1-差旅 travel、2-商务出行 business trip按次数、3-商务出行 business trip按日期）只能选择其一
        /// </summary>
        [JsonProperty("approval_type")]
        public int ApprovalType { get; set; }

        /// <summary>
        /// 旅行详细信息（ApprovalType=1必传，其余不传） TravelDetailInfo
        /// </summary>      
        [JsonProperty("travel_detail")]
        public object TravelDetail { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [JsonProperty(ThirdpartyConsts.DiDiOpenApiSignParameterName)]
        public string Sign { get; set; }

       
    }

    public class TravelDetailInfo
    {
        /// <summary>
        /// 行程开始日期，如2017-01-10
        /// </summary>
        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        /// <summary>
        /// 行程结束日期，如2017-02-01
        /// </summary>
        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        /// <summary>
        /// 行程路线，行程使用的制度(regulation_id)中，出差城市配置为无需填写时，trips可为空。否则必传，需按照行程顺序填写
        /// </summary>
        [JsonProperty("trips")]
        public IList<TripsInfo> Trips { get; set; }

        /// <summary>
        /// 行程终点城市是否包含市内用车权限（0-不包含，1-包含），trips最后一行视为终点城市
        /// </summary>
        [JsonProperty("end_city_rule")]
        public int EndCityRule { get; set; }
    }

    /// <summary>
    /// 旅行信息
    /// </summary>
    public class TripsInfo
    {
        /// <summary>
        /// 出发地城市名称，如北京市
        /// </summary>
        [JsonProperty("departure_city")]
        public string DepartureCity { get; set; }

        /// <summary>
        /// 出发地城市id(地级市id)
        /// </summary>
        [JsonProperty("departure_city_id")]
        public int DepartureCityId { get; set; }

        /// <summary>
        /// 目的地城市名称，如上海市
        /// </summary>
        [JsonProperty("destination_city")]
        public string DestinationCity { get; set; }

        /// <summary>
        /// 目的地城市id(地级市id)
        /// </summary>
        [JsonProperty("destination_city_id")]
        public int DestinationCityId { get; set; }

        /// <summary>
        /// 行程开始日期，如2017-01-10
        /// </summary>
        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        /// <summary>
        /// 行程结束日期，如2017-01-20
        /// </summary>
        [JsonProperty("end_date")]
        public string EndDate { get; set; }

    }
}
