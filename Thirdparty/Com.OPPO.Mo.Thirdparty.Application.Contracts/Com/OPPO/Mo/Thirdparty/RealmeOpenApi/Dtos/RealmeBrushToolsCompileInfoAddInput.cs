using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.RealmeOpenApi.Dtos
{
    /// <summary>
    /// Realme刷机工具编译信息新增Input
    /// </summary>
    public class RealmeBrushToolsCompileInfoAddInput
    {
        /// <summary>
        /// 【必填项】编译信息，格式：[{ "compile_time": "2017-12-28 18:38:42", "compiler": "172.17.121.188", "platform": "SDM660", "version_name": "MSM_17011_allnet_201712260101_USR", "version_type": "normal", "project": "17011", "download_type": "persist_no_userdata_no", "sha256": "a77f01c6cc5152ac5089de503c407713231d80a0f94572316efec6ae5d45cb1d" }]
        /// </summary>
        [Required]
        public string CompileInfo { get; set; }
    }
}
