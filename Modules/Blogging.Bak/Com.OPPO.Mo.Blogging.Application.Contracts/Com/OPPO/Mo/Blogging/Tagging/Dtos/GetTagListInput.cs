using System;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Blogging.Tagging.Dtos
{
    public class GetTagListInput
    {
        public IEnumerable<Guid> Ids { get; set; }
    }
}