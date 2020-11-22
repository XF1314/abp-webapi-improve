using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.HR.PsHr.Response
{
    public class PersonnelGroup
    {
        /// <summary>
        ///  厂区描述
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 厂区位置
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 底库使用情况:人数
        /// </summary>
        public int SubjectCount { get; set; }
        /// <summary>
        /// 人员类型
        /// </summary>
        public int SubjectType { get; set; }
        /// <summary>
        /// 更新数据的账号
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public double UpdateTime { get; set; }
    }
}
