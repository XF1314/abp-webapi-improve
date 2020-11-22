using Newtonsoft.Json;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.DiDi.Dtos
{
    /// <summary>
    /// 用车制度输出参数
    /// </summary>
    public class DiDiRegulationDto
    {
        /// <summary>
        /// 0表示成功，非0表示失败
        /// </summary>
        public int Errno { get; set; }

        /// <summary>
        /// errno=0时为常量"SUCCESS"，errno!=0时为错误信息
        /// </summary>
        public string Errmsg { get; set; }

        /// <summary>
        /// 制度列表信息
        /// </summary>
        public List<DiDiBodyDto> Body { get; set; }
    }

    /// <summary>
    /// 制度列表信息
    /// </summary>
    public class DiDiBodyDto
    {
        /// <summary>
        /// 制度id
        /// </summary>
        public string RegulationId { get; set; }

        /// <summary>
        /// 制度名称
        /// </summary>
        public string RegulationName { get; set; }

        /// <summary>
        /// 制度状态（0-已停用、1-启用中）
        /// </summary>
        public int RegulationStatus { get; set; }

        /// <summary>
        /// 因公出行场景（0-个人用车、1-商务出行、2-差旅、3-加班、4-办公地点通勤、91-代叫车、92-接送机）
        /// </summary>
        public int SceneType { get; set; }

        /// <summary>
        /// 是否使用个人限额（0-不使用、1-使用），差旅制度默认返回不使用
        /// </summary>
        public int IsUseQuota { get; set; }

        /// <summary>
        /// 制度是否需要审批(0-无需审批，1-需审批)
        /// </summary>
        public int IsApproval { get; set; }

    }
}
