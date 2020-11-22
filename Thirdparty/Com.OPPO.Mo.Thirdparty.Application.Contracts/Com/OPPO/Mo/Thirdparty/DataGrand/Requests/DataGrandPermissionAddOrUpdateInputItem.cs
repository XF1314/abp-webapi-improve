using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索权限新增或更新Input
    /// </summary>
    public class DataGrandPermissionAddOrUpdateInputItem : BaseDataGrandPermissionInputItem
    {
        /// <summary>
        /// <see cref="DataGrandPermissionAddOrUpdateInputItem"/>
        /// </summary>
        public DataGrandPermissionAddOrUpdateInputItem()
        {
            Roles = new List<string>();
        }

        /// <summary>
        /// 【必填项】 标识了当前用户的角色列表，列表元素为string类型，可能为userid、groupid或departid的抽象角色，
        /// 采用加前缀的方式进行区分，userid前加"u_"，groupid前加"g_"，departid前加"d_"，对于权限角色，
        /// 业务系统可以进行自定义，保证角色的唯一性，保证文档侧的角色一致即可，如: [“u_1002”, “g_2001”, “d_2001”]
        /// </summary>
        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

    }
}
