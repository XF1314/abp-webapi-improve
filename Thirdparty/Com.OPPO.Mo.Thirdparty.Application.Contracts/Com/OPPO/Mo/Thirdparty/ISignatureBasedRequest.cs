using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISignatureBasedRequest
    {
        [JsonIgnore]
        string Sign { get; }
    }
}
