using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 业务对象表权限批量授予Input
    /// </summary>
    public class BusinessObjectTablePermissionBatchGrantInput
    {
        /// <summary>
        /// 【必填项】应用Id
        /// </summary>
        [JsonRequired]
        public string AppId { get; set; }

        /// <summary>
        /// 【必填项】应用名称
        /// </summary>
        [JsonRequired]
        public string AppName { get; set; }

        /// <summary>
        /// 【必填项】业务对象表名称s
        /// </summary>
        [JsonRequired]
        public List<string> BusinessObjectTableNames { get; set; }
    }
}
