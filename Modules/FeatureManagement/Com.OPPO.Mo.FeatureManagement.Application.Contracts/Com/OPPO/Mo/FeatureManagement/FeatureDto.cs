﻿using System.Collections.Generic;
using Volo.Abp.Validation.StringValues;

namespace Com.OPPO.Mo.FeatureManagement
{
    public class FeatureDto
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

        public IStringValueType ValueType { get; set; }

        public int Depth { get; set; }

        public string ParentName { get; set; }
    }
}