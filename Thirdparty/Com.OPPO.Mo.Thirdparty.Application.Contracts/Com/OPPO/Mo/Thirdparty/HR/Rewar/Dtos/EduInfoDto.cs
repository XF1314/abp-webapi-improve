using Newtonsoft.Json;
using System;

namespace Com.OPPO.Mo.Thirdparty.Hr.Rewar.Dtos
{
    /// <summary>
    /// 教育经历信息实体信息
    /// </summary>
    public class EduInfoDto
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        [JsonProperty("EMPLID")] 
        public string EmplId { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [JsonProperty("START_DT")]
        public DateTime StartDt { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [JsonProperty("END_DT")]
        public DateTime EndDt { get; set; }


        /// <summary>
        /// 学历
        /// </summary>
        [JsonProperty("EDU_LVL")]
        public string EduLvl { get; set; }

        /// <summary>
        /// 学历描述
        /// </summary>
        [JsonProperty("EDU_LVL_DESCR")]
        public string EduLvlDescr { get; set; }

        /// <summary>
        /// 学位
        /// </summary>
        [JsonProperty("DEGREE")]
        public string Degree { get; set; }

        /// <summary>
        /// 学位描述
        /// </summary>
        [JsonProperty("DEGREE_DESCR")]
        public string DegreeDescr { get; set; }

        /// <summary>
        /// 学校
        /// </summary>
        [JsonProperty("SCHOOL_DESCR")]
        public string SchoolDescr { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        [JsonProperty("MAJOR_DESCR")]
        public string MajorDescr { get; set; }
    }
}
