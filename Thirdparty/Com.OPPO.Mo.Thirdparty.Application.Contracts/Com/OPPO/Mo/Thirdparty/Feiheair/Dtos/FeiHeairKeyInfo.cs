using System;
using System.Xml.Serialization;

namespace Com.OPPO.Mo.Thirdparty.Feiheair.Dtos
{
    /// <summary>
    /// 飞鹤key输出信息
    /// </summary>
    [XmlRoot("result")]
    [Serializable]
    public class FeiHeairKeyInfo
    {
        /// <summary>
        /// 错误信息(当msg不为空时，表示调用出)
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// key(当调用出错时，key为空)
        /// </summary>
        [XmlElement("key")]
        public string Key { get; set; }
    }
}
