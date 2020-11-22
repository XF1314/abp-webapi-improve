using System;
using System.Xml.Serialization;

namespace Com.OPPO.Mo.Thirdparty.Feiheair.Dtos
{
    /// <summary>
    /// 飞鹤key
    /// </summary>  
    public class FeiHeairKeyDto
    {
        /// <summary>
        /// 错误信息(当msg不为空时，表示调用出)
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// key(当调用出错时，key为空)
        /// </summary>
        public string Key { get; set; }
    }
}
