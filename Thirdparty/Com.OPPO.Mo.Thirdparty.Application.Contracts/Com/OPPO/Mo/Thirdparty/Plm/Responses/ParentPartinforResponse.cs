using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Plm.Responses
{

    public class ParentPartinforResponse
    {
        /// <summary>
        /// 源部件号
        /// </summary>
        public string sourcePartNumber { get; set; }
        /// <summary>
        /// 父部件号
        /// </summary>
        public string parentPartNumber { get; set; }
        /// <summary>
        /// 父部件名
        /// </summary>
        public string parentPartName { get; set; }
        /// <summary>
        /// 父部件规格
        /// </summary>
        public string parentPartSpec { get; set; }
        /// <summary>
        /// 父部件规格（英文）
        /// </summary>
        public string parentPartSpecEn { get; set; }
        /// <summary>
        /// 父部件状态
        /// </summary>
        public string parentPartStatus { get; set; }
        /// <summary>
        /// 源部件状态
        /// </summary>
        public string sourcePartStatus { get; set; }
        /// <summary>
        /// 源部件数量
        /// </summary>
        public string sourceQuantity { get; set; }
        /// <summary>
        /// 电话名
        /// </summary>
        public string phoneName { get; set; }
        /// <summary>
        /// 更换零件号
        /// </summary>
        public string replacePartNumber { get; set; }
        /// <summary>
        /// 更换零件状态
        /// </summary>
        public string replacePartStatus { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public string isSubstitue { get; set; }
        /// <summary>
        /// 零件参考号
        /// </summary>
        public string partReference { get; set; }
        /// <summary>
        /// 父级规范（中文）
        /// </summary>
        public string parentSpecificationZh { get; set; }
        /// <summary>
        /// 父级规范（英文）
        /// </summary>
        public string parentSpecificationEn { get; set; }
        /// <summary>
        /// 是否是子零件
        /// </summary>
        public string isChildSubstitue { get; set; }
    }


}
