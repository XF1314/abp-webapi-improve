using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr
{

    public interface ISecret
    {
        /// <summary>
        ///加密串,必填
        /// </summary>
        public string Secret { get; set; }
    }

}
