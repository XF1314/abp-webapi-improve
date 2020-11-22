
using Com.OPPO.Mo.Thirdparty.HR.PsHr.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos
{

    public class ApprovalPreparationDto
    {
        /// <summary>
        /// 文件单号
        /// </summary>
        public string FileId { get; set; }


        /// <summary>
        /// 占用A/释放I
        /// </summary>
        public string Action { get; set; }


        /// <summary>
        /// 01(社招)/02(内聘)
        /// </summary>
        public string RecruitmentType { get; set; }

        /// <summary>
        /// 编制信息
        /// </summary>
        public List<DepartmentEmployDto> Datas { get; set; }
    }

    

}
