using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Dtos
{
    public class LeaveBatchData
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string employee_id { get; set; }
        /// <summary>
        /// 文件编号
        /// </summary>
        public string formInstance_code { get; set; }
        /// <summary>
        /// 请假开始日期
        /// </summary>
        public string begin_date { get; set; }
        /// <summary>
        /// 请假开始时间
        /// </summary>
        public string begin_time { get; set; }
        /// <summary>
        /// 请假结束日期
        /// </summary>
        public string end_date { get; set; }
        /// <summary>
        /// 请假结束日期
        /// </summary>
        public string end_time { get; set; }
        /// <summary>
        /// 请假总天数
        /// </summary>
        public float c_days { get; set; }
        /// <summary>
        /// 事假
        /// </summary>
        public float c_abs_days01 { get; set; }
        /// <summary>
        /// 年休假
        /// </summary>
        public float c_abs_days02 { get; set; }
        /// <summary>
        /// 周末假
        /// </summary>
        public float c_abs_days03 { get; set; }
        /// <summary>
        /// 看护假
        /// </summary>
        public float c_abs_days04 { get; set; }
        /// <summary>
        /// 婚假
        /// </summary>
        public float c_abs_days05 { get; set; }
        /// <summary>
        /// 产检假
        /// </summary>
        public float c_abs_days06 { get; set; }
        /// <summary>
        /// 产假
        /// </summary>
        public float c_abs_days07 { get; set; }
        /// <summary>
        /// 病假
        /// </summary>
        public float c_abs_days08 { get; set; }
        /// <summary>
        /// 公司特殊放假或法定节假日+多胞胎假+流产假+难产假+探亲假
        /// </summary>
        public float c_abs_days09 { get; set; }
        /// <summary>
        /// 工伤假
        /// </summary>
        public float c_abs_days10 { get; set; }
        /// <summary>
        /// 丧假
        /// </summary>
        public float c_abs_days11 { get; set; }
        /// <summary>
        /// 当前日期
        /// </summary>
        public string approval_date { get; set; }
        /// <summary>
        /// 当前日期
        /// </summary>
        public string approve_date { get; set; }
        /// <summary>
        /// 请假事由
        /// </summary>
        public string leave_cause { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string comments { get; set; }
        /// <summary>
        /// 与请假是否相符,默认值为Y
        /// </summary>
        public string flag { get; set; }
        /// <summary>
        /// 是否有销假资料,默认值为N
        /// </summary>
        public string flag1 { get; set; }
        
    }
}
