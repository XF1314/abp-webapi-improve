using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 基础达观搜索权限InputItem
    /// </summary>
    public abstract class BaseDataGrandPermissionInputItem
    {
        /// <summary>
        /// 【必填项】用户编码
        /// </summary>
        [JsonProperty("userid")]
        public  string UserCode { get; set; }

    }
}
