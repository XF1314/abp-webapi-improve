using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Ocsm.Dtos
{
    /// <summary>
    /// Ocsm刷机工具编译信息新增Input
    /// </summary>
    public class OcsmBrushToolsCompileInfoAddInput
    {
        /// <summary>
        /// 【必填项】编译信息，格式：[{ "compile_time": "2017-12-28 18:38:42", "compiler": "172.17.121.188", "platform": "SDM660", "version_name": "MSM_17011_allnet_201712260101_USR", "version_type": "normal", "project": "17011", "download_type": "persist_no_userdata_no", "sha256": "a77f01c6cc5152ac5089de503c407713231d80a0f94572316efec6ae5d45cb1d" }, { "compile_time": "编译时间", "compiler": "编译者", "platform": "平台", "version_name": "软件名称", "version_type": "版本类型", "project": "项目代码", "download_type": "下载类型", "sha256": "签名值" }]
        /// </summary>
        [Required]
        public string CompileInfo { get; set; }
    }
}
