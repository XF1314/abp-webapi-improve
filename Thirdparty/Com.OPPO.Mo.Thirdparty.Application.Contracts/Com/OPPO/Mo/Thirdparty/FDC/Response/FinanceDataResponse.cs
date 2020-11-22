using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Fdc.Response
{

    public class FinanceDataResponse
    {
        /// <summary>
        /// 返回编码
        /// </summary>
        public string ReturnCode { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string ReturnMsg { get; set; }
        /// <summary>
        /// 字符编码
        /// </summary>
        public string Charset { get; set; }
        /// <summary>
        /// 请求签名
        /// </summary>
        public string ReqSn { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public string Timestamp { get; set; }
        /// <summary>
        /// 格式
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// 应用程序ID
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string BizContent { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }
        /// <summary>
        /// 客户id
        /// </summary>
        public string CusId { get; set; }
        /// <summary>
        /// ApiCode
        /// </summary>
        public string ApiCode { get; set; }
        /// <summary>
        /// 标志类型
        /// </summary>
        public string SignType { get; set; }
    }

}
