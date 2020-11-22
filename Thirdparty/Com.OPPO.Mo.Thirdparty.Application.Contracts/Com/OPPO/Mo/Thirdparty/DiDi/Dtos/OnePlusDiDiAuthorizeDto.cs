using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.DiDi.Dtos
{
    /// <summary>
    /// 滴滴授权认证返回结果实体
    /// </summary>
    public class OnePlusDiDiAuthorizeDto
    {
        /// <summary>
        /// 接口获取授权后的access token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// access_token的生命周期，单位是秒数
        /// </summary>
        public string ExpiresIn { get; set; }

        /// <summary>
        /// access_token类型
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// 权限范围
        /// </summary>
        public string Scope { get; set; }
    }
}
