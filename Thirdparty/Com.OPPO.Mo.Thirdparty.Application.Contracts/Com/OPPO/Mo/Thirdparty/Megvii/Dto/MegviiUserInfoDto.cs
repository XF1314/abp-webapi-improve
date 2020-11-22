using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Megvii.Dto
{
    //: BaseUserInfoDto
    public class MegviiUserInfoDto
    {

        /// <summary>
        /// 类型，0员工，1访客，2vip，3黄名单
        /// </summary>
        public int SubjectType { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string JobNumber { get; set; }

        /// <summary>
        /// 访客开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 访客结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        ///// <summary>
        ///// 底库id列表
        ///// </summary>
        //[MaxLength(256)]
        //public List<double> PhotoIds { get; set; }

        /// <summary>
        /// 分组id
        /// </summary>
        public List<int> GroupIds { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
