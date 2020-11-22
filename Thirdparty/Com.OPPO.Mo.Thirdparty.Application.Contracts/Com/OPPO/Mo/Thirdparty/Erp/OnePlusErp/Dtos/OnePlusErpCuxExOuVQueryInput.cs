using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 获取主体信息输入参数
    /// </summary>
    public class OnePlusErpCuxExOuVQueryInput 
    {
        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// 主体code
        /// </summary>
        public string OrgCode { get; set; }

        /// <summary>
        /// 主体ID
        /// </summary>
        public string OrgId { get; set; }

        /// <summary>
        /// 主体名称
        /// </summary>
        public string OrgName { get; set; }

        /// <summary>
        /// 主体在PS系统中的ID
        /// </summary>
        public string PsLeId { get; set; }

        /// <summary>
        /// 主体本位币
        /// </summary>
        public string TargetCurrencyCode { get; set; }

        
    }
}
