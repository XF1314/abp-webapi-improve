using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm
{
    public interface ISignatureBasedActionSoftWebApiRequest
    {
        public string Sign { get; }
    }
}
