using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Visitors.Dtos
{

    public class AuthercateDataDto
    {
        /// <summary>
        /// 单号
        /// </summary>
       [Required] 
        public string MoNo { get; set; }
        /// <summary>
        /// 申请单类型,门禁申请、会议室申请、机房、试产车间申请（必传，默认“试产车间申请”）
        /// </summary>
        [Required] 
        public string MoType { get; set; }
        /// <summary>
        /// 员工ID、客餐卡号，必传
        /// </summary>
        [Required] 
        public string EmpNo { get; set; }
        /// <summary>
        /// 权限类别,权限申请、权限取消
        /// </summary>
        [Required] 
        public string RType { get; set; }
        /// <summary>
        /// 申请日期,必传
        /// </summary>
        [Required] 
        public DateTime RDate { get; set; }
        /// <summary>
        /// 权限开始时间,表单中“进入时间”必传
        /// </summary>
        [Required] 
        public DateTime RStartTime { get; set; }
        /// <summary>
        /// 权限结束时间,表单中“截止时间”必传
        /// </summary>
        [Required] 
        public DateTime REndTime { get; set; }
        /// <summary>
        /// 门禁类型,InBio、T4S、T32、F2（默认，880）必传
        /// </summary>
        [Required] 
        public string DevType { get; set; }
        /// <summary>
        /// 设备ID,表单中下拉框“位置”代码,必传
        /// </summary>
        [Required] 
        public int DevID { get; set; }
        /// <summary>
        /// 设备名称,表单中下拉框“位置”名称，必传
        /// </summary>
        [Required] 
        public string DevName { get; set; }
        /// <summary>
        /// 门区ID,默认，0
        /// </summary>
        public int DoorID { get; set; }
        /// <summary>
        /// 门区名称,默认，0
        /// </summary>
        public string DoorName { get; set; }
        /// <summary>
        /// 区域,表单中所选“分厂”，必传
        /// </summary>
        [Required] 
        public string RegionName { get; set; }
        /// <summary>
        /// 申请事由,表单中“进入事由”，必传
        /// </summary>
        [Required] 
        public string RMsg { get; set; }
        /// <summary>
        /// 数据生成时间
        /// </summary>
        public DateTime DataCreateTime { get; set; }
        /// <summary>
        /// 权限操作时间
        /// </summary>
        public DateTime DataOperateTime { get; set; }
        /// <summary>
        /// 申请状态,默认，0
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Timestamp { get; set; }
    }

}
