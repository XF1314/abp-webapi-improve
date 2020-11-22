using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos
{

    public class PsBadyRequestDto 
    {
        /// <summary>
        /// 接口代码,必填
        /// </summary>
        [Required] 
        public string InterfaceCode { get; set; }

        /// <summary>
        /// 系统ID,必填，示例MO
        /// </summary>
        [Required] 
        public string SystemCode { get; set; }

        /// <summary>
        /// 语言代码,必填，示例ZHS
        /// </summary>
        [Required] 
        public string Language { get; set; }

    }

    public class PsBadyRequestDto<TData> : PsBadyRequestDto
    {
        /// <summary>
        /// 请求数据
        /// </summary>
        public TData datas { get; set; }
    }
}
