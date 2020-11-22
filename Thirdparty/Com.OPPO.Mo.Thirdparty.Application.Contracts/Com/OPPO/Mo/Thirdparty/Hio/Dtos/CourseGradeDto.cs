namespace Com.OPPO.Mo.Thirdparty.Hio.Dtos
{
    /// <summary>
    /// 学生成绩输出类
    /// </summary>
    public class CourseGradeDto
    {
        /// <summary>
        /// 用户工号
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string Trained { get; set; }

        /// <summary>
        /// 成绩
        /// </summary>
        public int? Score { get; set; }
    }
}
