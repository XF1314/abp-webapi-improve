using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos
{
    /// <summary>
    /// 任职资格信息推送输入参数
    /// </summary>
    public class PsQualificationPushInput
    {
        /// <summary>
        /// 任职资格信息:  { "emplid": "80083625", "job_function": "008", "job_sub_func": "012", "eff_date": "2016-05-25", "status": "A", "pass_status": "Y", "c_rate_lvl": "20", "c_rate_rank": "1", "score": 60.00, "remark": "test", "c_op_rzz": "", "c_op_rz_auth": "", "created_by": "80055890", "scores": [ { "emplid": "80083625", "job_function": "008", "job_sub_func": "012", "eff_date": "2016-05-25", "judges": "80055890", "judges_comments": "teset1", "judges_performance": "teset1", "score": 60.10 }, { "emplid": "80083625", "job_function": "008", "job_sub_func": "012", "eff_date": "2016-05-25", "judges": "80020851", "judges_comments": "teset1", "judges_performance": "teset1", "score": 60.10 } ] }
        /// </summary> 
        [Required]
        public string DataJson { get; set; }
    }
}
