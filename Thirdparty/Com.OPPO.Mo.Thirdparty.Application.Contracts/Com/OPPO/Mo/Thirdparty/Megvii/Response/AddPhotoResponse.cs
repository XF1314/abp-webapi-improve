using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Megvii.Response
{
   
    public class AddPhotoResponse
    {
        /// <summary>
        /// 公司id
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// photo id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 原图保存地址
        /// </summary>
        public string OriginUrl { get; set; }
        /// <summary>
        /// 质量
        /// </summary>
        public double Quality { get; set; }
        /// <summary>
        /// subject id
        /// </summary>
        public int SubjectId { get; set; }
        /// <summary>
        /// 底库保存路径
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public int Version { get; set; }
    }

}
