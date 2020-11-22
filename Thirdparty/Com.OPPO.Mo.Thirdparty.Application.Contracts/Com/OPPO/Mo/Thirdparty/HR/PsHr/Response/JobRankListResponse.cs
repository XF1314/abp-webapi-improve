using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Response
{
    public class JobRankListResponse
    {
        /// <summary>
        /// 行数
        /// </summary>
        public int TotalRows { get; set; }

        /// <summary>
        /// 返回的职务职级数据
        /// </summary>
        public List<JobRank> Datas { get; set; }
    }


    public class JobRank
    {
        /// <summary>
        /// 集合ID
        /// </summary>
        public string SetId { get; set; }
        /// <summary>
        /// 岗位代码
        /// </summary>
        public string JobCode { get; set; }
        /// <summary>
        /// 岗位描述
        /// </summary>
        public string JobDescription { get; set; }
        /// <summary>
        /// 通道
        /// </summary>
        public string JobLevelCode { get; set; }
        /// <summary>
        /// 通道描述
        /// </summary>
        public string JobLevelDescription { get; set; }
    }
}
