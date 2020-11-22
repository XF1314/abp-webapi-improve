using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft
{
    public class BasePeoplesoftWebApiRequest : ISignatureBasedRequest, IAppIdInfo, IAppPasswordInfo
    {
        /// <summary>
        /// 应用标识
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 应用密码
        /// </summary>
        public string AppPassword { get; set; }

        public DateTime Timestamp { get; private  set; }

        public string Sign { get; set; }
    }
}
