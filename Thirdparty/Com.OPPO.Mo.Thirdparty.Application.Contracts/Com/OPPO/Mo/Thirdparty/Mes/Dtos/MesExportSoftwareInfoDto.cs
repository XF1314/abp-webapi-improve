using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Mes.Dtos
{
    /// <summary>
    /// Mes外销软体信息Dto
    /// </summary>
    public  class MesExportSoftwareInfoDto
    {
        /// <summary>
        /// 【必填项】机型
        /// </summary>
        [Required]
        public string ProductModel { get; set; }

        /// <summary>
        /// 【必填项】软件名称
        /// </summary>
        [Required]
        public string SoftwareName { get; set; }

        /// <summary>
        /// 【必填项】软件版本
        /// </summary>
        [Required]
        public string SoftwareVersion { get; set; }

        /// <summary>
        /// 【必填项】是否失效历史软件
        /// </summary>
        [Required]
        public bool IfInvalidHistoryVersion { get; set; }

        /// <summary>
        /// 创建应用标识，填写当前系统标识即可
        /// </summary>
        public string AppId { get; set; }
    }
}
